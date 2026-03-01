using CppSharp;
using CppSharp.AST;
using CppSharp.Generators;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shouldly;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static ShaderSlang.Net.Scripts.CppSharpGenerator.AstToSyntaxFactory;
using Delegate = CppSharp.AST.Delegate;
using Type = CppSharp.AST.Type;

namespace ShaderSlang.Net.Scripts.CppSharpGenerator.Passes;

internal sealed partial class SyntaxCodeGeneratorPass(BindingContext context) : IDeclVisitor<SyntaxNode?>, IAstVisited
{
    private readonly BindingContext _context = context;
    private readonly Dictionary<Declaration, SyntaxNode> _declarationSyntaxMap = [];

    public SyntaxTree Visit(TranslationUnit unit)
    {
        var unitSyntax = VisitTranslationUnit(unit).ShouldBeOfType<CompilationUnitSyntax>();
        
        return SyntaxTree(unitSyntax);
    }
    
    public SyntaxNode? VisitDeclaration(Declaration decl)
    {
        if (!decl.IsGenerated)
        {
            return null;
        }
        
        var matchingNode = decl switch
        {
            null => null,
            AccessSpecifierDecl => null,
            ClassTemplatePartialSpecialization classTemplatePartialSpecialization => VisitClassTemplateSpecializationDecl(classTemplatePartialSpecialization),
            ClassTemplateSpecialization classTemplateSpecialization => VisitClassTemplateSpecializationDecl(classTemplateSpecialization),
            ClassTemplate classTemplate => VisitClassTemplateDecl(classTemplate),
            Class @class => VisitClassDecl(@class),
            Enumeration.Item item => VisitEnumItemDecl(item),
            Enumeration enumeration => VisitEnumDecl(enumeration),
            Event @event => VisitEvent(@event),
            Method method => VisitMethodDecl(method),
            Function function => VisitFunctionDecl(function),
            TranslationUnit translationUnit => VisitTranslationUnit(translationUnit),
            Namespace ns => VisitNamespace(ns),
            DeclarationContext => null,
            Delegate => null,
            Field field => VisitFieldDecl(field),
            Friend friend => VisitFriend(friend),
            FunctionTemplate functionTemplate => VisitFunctionTemplateDecl(functionTemplate),
            NonTypeTemplateParameter nonTypeTemplateParameter => VisitNonTypeTemplateParameterDecl(nonTypeTemplateParameter),
            Parameter parameter => VisitParameterDecl(parameter),
            Property property => VisitProperty(property),
            TemplateTemplateParameter templateTemplateParameter => VisitTemplateTemplateParameterDecl(templateTemplateParameter),
            TypeAliasTemplate typeAliasTemplate => VisitTypeAliasTemplateDecl(typeAliasTemplate),
            VarTemplatePartialSpecialization varTemplatePartialSpecialization => VisitVarTemplateSpecializationDecl(varTemplatePartialSpecialization),
            VarTemplateSpecialization varTemplateSpecialization => VisitVarTemplateSpecializationDecl(varTemplateSpecialization),
            VarTemplate varTemplate => VisitVarTemplateDecl(varTemplate),
            TypeAlias typeAlias => VisitTypeAliasDecl(typeAlias),
            TypedefDecl typedefDecl => VisitTypedefDecl(typedefDecl),
            TypedefNameDecl typedefNameDecl => VisitTypedefNameDecl(typedefNameDecl),
            TypeTemplateParameter typeTemplateParameter => VisitTemplateParameterDecl(typeTemplateParameter),
            UnresolvedUsingTypename unresolvedUsingTypename => VisitUnresolvedUsingDecl(unresolvedUsingTypename),
            Variable variable => VisitVariableDecl(variable),
            _ => throw new ArgumentOutOfRangeException(nameof(decl))
        };

        if (matchingNode is null) return matchingNode;
        if (decl != null) _declarationSyntaxMap[decl] = matchingNode;

        return matchingNode;
    }

    public SyntaxNode? VisitTranslationUnit(TranslationUnit unit)
    {
        var unitMembers = unit.Declarations
                              .Select(VisitDeclaration)
                              .WhereNotNull()
                              .Cast<MemberDeclarationSyntax>();
        
        return CompilationUnit()
            .AddMembers([..unitMembers]);
    }

    public SyntaxNode? VisitNamespace(Namespace @namespace)
    {
        var members = @namespace.Declarations
                                .Select(VisitDeclaration)
                                .WhereNotNull()
                                .Cast<MemberDeclarationSyntax>();
        
        return CreateNamespaceDeclarationFrom(@namespace)
            .AddMembers([..members]);
    }

    public SyntaxNode? VisitEnumDecl(Enumeration @enum)
    {
        return CreateEnumDeclarationFrom(@enum);
    }

    public SyntaxNode? VisitClassDecl(Class @class)
    {
        var members = @class.Declarations
                            .Select(VisitDeclaration)
                            .WhereNotNull()
                            .Cast<MemberDeclarationSyntax>();
        
        return CreateTypeDeclarationFrom(@class)
            .AddMembers([..members]);
    }

    public SyntaxNode? VisitFieldDecl(Field field)
    {
        var declarator = VariableDeclarator(field.Name);
        if (field.IsBitField)
        {
            declarator = declarator.WithArgumentList(MakeDeclaratorFromBitField(field));
        }

        return FieldDeclaration(VariableDeclaration(field.Type.ToSyntax(), [declarator]))
               .WithDocumentationFrom(field)
               .AddAttributeLists(CreateAttributeListsFrom(field))
               .AddModifiers(field.Access.ToToken());
    }

    public SyntaxNode? VisitProperty(Property property)
    {
        var propertyDeclaration = PropertyDeclaration(property.Type.ToSyntax(), property.Name)
                                  .WithDocumentationFrom(property)
                                  .AddAttributeLists(CreateAttributeListsFrom(property))
                                  .AddModifiers(property.Access.ToToken());

        if (property.IsStatic)
        {
            propertyDeclaration = propertyDeclaration.AddModifiers(Token(SyntaxKind.StaticKeyword));
        }
        
        if (property.HasGetter)
        {
            propertyDeclaration = propertyDeclaration.AddAccessorListAccessors(AccessorDeclaration(SyntaxKind.GetAccessorDeclaration).WithSemicolonToken(Token(SyntaxKind.SemicolonToken)));
        }

        if (property.HasGetter)
        {
            propertyDeclaration = propertyDeclaration.AddAccessorListAccessors(AccessorDeclaration(SyntaxKind.SetAccessorDeclaration).WithSemicolonToken(Token(SyntaxKind.SemicolonToken)));
        }

        return propertyDeclaration;
    }

    public SyntaxNode? VisitMethodDecl(Method method)
    {
        var methodSyntax = CreateMethodFrom(method);

        if (method.IsStatic)
        {
            methodSyntax = methodSyntax.AddModifiers(Token(SyntaxKind.StaticKeyword));
        }

        if (method.IsVirtual)
        {
            methodSyntax = methodSyntax.AddModifiers(Token(SyntaxKind.VirtualKeyword));
        }
        
        return methodSyntax;
    }

    public bool AlreadyVisited(Declaration decl) =>
        Visited.Contains(decl);

    public bool AlreadyVisited(Type type) =>
        throw new NotImplementedException();
    
    private BracketedArgumentListSyntax MakeDeclaratorFromBitField(Field field)
    {
        var bitFieldSizeArgument = Argument(LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(field.BitWidth)));
        return BracketedArgumentList([bitFieldSizeArgument]);
    }

    public ISet<object> Visited { get; } = new HashSet<object>();
}

//Contains already handled declarations

//contains unsupported declarations