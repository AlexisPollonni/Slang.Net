using System.Diagnostics.CodeAnalysis;
using CppSharp;
using CppSharp.AST;
using CppSharp.AST.Extensions;
using CppSharp.Generators;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using Type = CppSharp.AST.Type;

namespace ShaderSlang.Net.Scripts.CppSharpGenerator;

public static class RoslynExtensions
{
    public static TypeSyntax? BuiltInToPredefinedSyntax(this BuiltinType type) =>
        type.Type switch
        {
            PrimitiveType.Null => null,
            PrimitiveType.Void => PredefinedType(Token(SyntaxKind.VoidKeyword)),
            PrimitiveType.Bool => PredefinedType(Token(SyntaxKind.BoolKeyword)),
            PrimitiveType.WideChar => PredefinedType(Token(SyntaxKind.CharKeyword)),
            PrimitiveType.Char => PredefinedType(Token(SyntaxKind.CharKeyword)),
            PrimitiveType.SChar => PredefinedType(Token(SyntaxKind.CharKeyword)),
            PrimitiveType.UChar => PredefinedType(Token(SyntaxKind.CharKeyword)),
            PrimitiveType.Char16 => PredefinedType(Token(SyntaxKind.CharKeyword)),
            PrimitiveType.Char32 => PredefinedType(Token(SyntaxKind.CharKeyword)),
            PrimitiveType.Short => PredefinedType(Token(SyntaxKind.ShortKeyword)),
            PrimitiveType.UShort => PredefinedType(Token(SyntaxKind.UShortKeyword)),
            PrimitiveType.Int => PredefinedType(Token(SyntaxKind.IntKeyword)),
            PrimitiveType.UInt => PredefinedType(Token(SyntaxKind.UIntKeyword)),
            PrimitiveType.Long => PredefinedType(Token(SyntaxKind.LongKeyword)),
            PrimitiveType.ULong => PredefinedType(Token(SyntaxKind.ULongKeyword)),
            PrimitiveType.LongLong => PredefinedType(Token(SyntaxKind.LongKeyword)),
            PrimitiveType.ULongLong => PredefinedType(Token(SyntaxKind.ULongKeyword)),
            PrimitiveType.Float => PredefinedType(Token(SyntaxKind.FloatKeyword)),
            PrimitiveType.Double => PredefinedType(Token(SyntaxKind.DoubleKeyword)),
            PrimitiveType.LongDouble => PredefinedType(Token(SyntaxKind.DecimalKeyword)),
            PrimitiveType.Float128 => PredefinedType(Token(SyntaxKind.DecimalKeyword)),
            PrimitiveType.Decimal => PredefinedType(Token(SyntaxKind.DecimalKeyword)),
            PrimitiveType.String => PredefinedType(Token(SyntaxKind.StringKeyword)),
            _ => null,
        };

    public static TypeSyntax ToSyntax(this CILType cilType)
    {
        var globalFullName = cilType.Type.ToGlobalFullName();

        return ParseTypeName(globalFullName);
    }

    [SuppressMessage("ReSharper", "TailRecursiveCall")]
    public static TypeSyntax ToSyntax(this Type type)
    {
        switch (type)
        {
            case BuiltinType builtin:
            {
                var predefined = builtin.BuiltInToPredefinedSyntax();
                if (predefined is not null)
                    return predefined;

                if (builtin.Type == PrimitiveType.IntPtr)
                {
                    return new CILType(typeof(nint)).ToSyntax();
                }

                if (builtin.Type == PrimitiveType.UIntPtr)
                {
                    return new CILType(typeof(nuint)).ToSyntax();
                }

                Diagnostics.Error(
                    "Null type does not have a direct C# equivalent, using 'object?' as a fallback. This may lead to incorrect code generation."
                );
                return NullableType(PredefinedType(Token(SyntaxKind.ObjectKeyword)));
            }
            case CILType cilType:
                return cilType.ToSyntax();

            case TypedefType typedef:
                if (typedef.Declaration is TypedefDecl typedefDecl)
                {
                    return typedefDecl.Type.ToSyntax();
                }

                Diagnostics.Error(
                    $"Typedef {typedef} does not have a declaration, cannot generate syntax."
                );
                break;
        }

        if (type.IsReference())
        {
            return RefType(type.GetPointee().ToSyntax());
        }

        if (type.IsPointer())
        {
            return PointerType(type.GetPointee().ToSyntax());
        }

        if (type.TryGetClass(out var classDef))
        {
            return ParseTypeName(classDef.ToGlobalFullName());
        }

        if (type.TryGetEnum(out var enumDef))
        {
            return ParseTypeName(enumDef.ToGlobalFullName());
        }

        Diagnostics.Warning(
            $"Type '{type}' does not have a predefined managed mapping, using its name as identifier. This may lead to incorrect code generation."
        );

        return ParseTypeName(type.ToString());
    }

    public static TypeSyntax ToSyntax(this QualifiedType qualifiedType)
    {
        var baseTypeSyntax = qualifiedType.Type.ToSyntax();

        // TODO: Handle qualifiers (const, volatile, pointers, references) if needed. C# has no direct equivalents for some of these

        return baseTypeSyntax;
    }

    public static T WithDocumentationFrom<T>(this T node, Declaration decl)
        where T : SyntaxNode
    {
        var rawComment = decl.Comment;
        if (rawComment is null)
        {
            return node;
        }

        if (rawComment.IsInvalid)
        {
            Diagnostics.Warning(
                $"Comment for declaration {decl} is invalid, it will not be generated"
            );
            return node;
        }

        var documentationTrivia = AstToSyntaxFactory.CreateDocumentationTriviaFrom(
            rawComment.FullComment
        );

        var syntaxToAttachTo = node.DescendantNodesAndTokens().FirstOrDefault(node);

        var newTriviaList = syntaxToAttachTo.GetLeadingTrivia().Insert(0, documentationTrivia);

        var syntaxWithDoc = syntaxToAttachTo.WithLeadingTrivia(newTriviaList);

        return syntaxWithDoc.IsNode
            ? node.ReplaceNode(syntaxToAttachTo.AsNode()!, syntaxWithDoc.AsNode()!)
            : node.ReplaceToken(syntaxToAttachTo.AsToken(), syntaxWithDoc.AsToken());
    }

    public static SyntaxToken ToToken(this AccessSpecifier access) =>
        access switch
        {
            AccessSpecifier.Private => Token(SyntaxKind.PrivateKeyword),
            AccessSpecifier.Protected => Token(SyntaxKind.ProtectedKeyword),
            AccessSpecifier.Internal => Token(SyntaxKind.InternalKeyword),
            AccessSpecifier.Public => Token(SyntaxKind.PublicKeyword),
            _ => throw new ArgumentOutOfRangeException(nameof(access), access, null),
        };
}
