using CppSharp;
using CppSharp.AST;
using Microsoft.CodeAnalysis;

namespace ShaderSlang.Net.Scripts.CppSharpGenerator.Passes;

internal sealed partial class SyntaxCodeGeneratorPass
{
    public SyntaxNode? VisitTypedefNameDecl(TypedefNameDecl typedef) => UnsupportedDeclType(typedef);
    public SyntaxNode? VisitTypedefDecl(TypedefDecl typedef) => UnsupportedDeclType(typedef);
    public SyntaxNode? VisitTypeAliasDecl(TypeAlias typeAlias) => UnsupportedDeclType(typeAlias);
    public SyntaxNode? VisitFunctionDecl(Function function) => UnsupportedDeclType(function);
    public SyntaxNode? VisitVariableDecl(Variable variable) => UnsupportedDeclType(variable);
    public SyntaxNode? VisitMacroDefinition(MacroDefinition macro) => UnsupportedDeclType(macro);
    public SyntaxNode? VisitEvent(Event @event) => UnsupportedDeclType(@event);
    public SyntaxNode? VisitFriend(Friend friend) => UnsupportedDeclType(friend);
    public SyntaxNode? VisitClassTemplateDecl(ClassTemplate template) => UnsupportedDeclType(template);
    public SyntaxNode? VisitClassTemplateSpecializationDecl(ClassTemplateSpecialization specialization) => UnsupportedDeclType(specialization);
    public SyntaxNode? VisitFunctionTemplateDecl(FunctionTemplate template) => UnsupportedDeclType(template);
    public SyntaxNode? VisitFunctionTemplateSpecializationDecl(FunctionTemplateSpecialization specialization) => UnsupportedDeclType(specialization);
    public SyntaxNode? VisitVarTemplateDecl(VarTemplate template) => UnsupportedDeclType(template);
    public SyntaxNode? VisitVarTemplateSpecializationDecl(VarTemplateSpecialization template) => UnsupportedDeclType(template);
    public SyntaxNode? VisitTemplateTemplateParameterDecl(TemplateTemplateParameter templateTemplateParameter) => UnsupportedDeclType(templateTemplateParameter);
    public SyntaxNode? VisitTemplateParameterDecl(TypeTemplateParameter templateParameter) => UnsupportedDeclType(templateParameter);
    public SyntaxNode? VisitNonTypeTemplateParameterDecl(NonTypeTemplateParameter nonTypeTemplateParameter) => UnsupportedDeclType(nonTypeTemplateParameter);
    public SyntaxNode? VisitTypeAliasTemplateDecl(TypeAliasTemplate typeAliasTemplate) => UnsupportedDeclType(typeAliasTemplate);
    public SyntaxNode? VisitUnresolvedUsingDecl(UnresolvedUsingTypename unresolvedUsingTypename) => UnsupportedDeclType(unresolvedUsingTypename);

    private static SyntaxNode? UnsupportedDeclType<T>(T decl) where T : Declaration
    {
        Diagnostics.Error($"Declaration of type '{typeof(T)}' is not supported in C# or by the code generator, aborted for declaration '{decl.Name}'");
        return null;
    }

    private static SyntaxNode? UnsupportedDeclType(MacroDefinition decl)
    {
        Diagnostics.Error($"Macro definitions are not supported in C# or by the code generator, aborted for macro '{decl.Name}'");
        return null;
    }

    private static SyntaxNode? UnsupportedDeclType(FunctionTemplateSpecialization decl)
    {
        Diagnostics.Error($"Function template specializations are not supported in C# or by the code generator, aborted for specialization template '{decl.Template}'");
        return null;
    }
}