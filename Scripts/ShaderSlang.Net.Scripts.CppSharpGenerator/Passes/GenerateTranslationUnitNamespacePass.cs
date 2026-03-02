using CppSharp.AST;
using CppSharp.Passes;
using Type = System.Type;

namespace ShaderSlang.Net.Scripts.CppSharpGenerator.Passes;

internal sealed class GenerateTranslationUnitNamespacePass : TranslationUnitPass
{
    public override bool VisitTranslationUnit(TranslationUnit unit)
    {
        var outputNamespaceName = unit.Module?.OutputNamespace;

        if (string.IsNullOrEmpty(outputNamespaceName))
            return false;

        var outputNamespace = new Namespace
        {
            Name = outputNamespaceName,
            Declarations = unit.Declarations,
            Namespace = unit,

            //This pass tries tp escape the namespace and causes errors
            ExcludeFromPasses = new HashSet<Type>([typeof(CheckKeywordNamesPass)]),
        };

        foreach (var decl in unit.Declarations)
        {
            decl.Namespace = outputNamespace;
        }

        unit.Declarations = [outputNamespace];

        return base.VisitTranslationUnit(unit);
    }
}
