using CppSharp.AST;
using CppSharp.Passes;

namespace ShaderSlang.Net.Scripts.CppSharpGenerator.Passes;

internal sealed class RemoveAmbiguousNamingPrefixPass : TranslationUnitPass
{
    public override bool VisitFunctionDecl(Function function)
    {
        if (!function.Name.StartsWith("sp", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        if (function.Name.StartsWith("specialize", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        function.Name = function.Name.Remove(0, 2);

        return base.VisitFunctionDecl(function);
    }
}