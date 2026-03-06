using CppSharp.AST;
using CppSharp.Passes;

namespace ShaderSlang.Net.Scripts.CppSharpGenerator.Passes;

internal sealed class ResolveOpaqueClassesPass : TranslationUnitPass
{
    public override bool VisitClassDecl(Class @class)
    {
        if (@class.IsOpaque && @class.IsGenerated)
        {
            @class.IsIncomplete = false;
        }

        return base.VisitClassDecl(@class);
    }
}
