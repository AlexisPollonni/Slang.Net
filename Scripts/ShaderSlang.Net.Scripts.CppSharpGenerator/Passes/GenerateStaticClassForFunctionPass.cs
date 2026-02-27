using CppSharp;
using CppSharp.AST;
using CppSharp.Passes;

namespace ShaderSlang.Net.Scripts.CppSharpGenerator.Passes;

internal sealed class GenerateStaticClassForFunctionPass(string functionPrefix) : TranslationUnitPass
{
    public override bool VisitMethodDecl(Method method) =>
        true;

    public override bool VisitFunctionDecl(Function function)
    {
        if (!function.IsGenerated) return false;

        if (!function.OriginalName.StartsWith(functionPrefix, StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        var newName = function.OriginalName.Remove(0, functionPrefix.Length);

        newName = StringHelpers.Capitalize(newName);

        var className = functionPrefix.Trim('_');

        newName = newName.Insert(0, className);

        function.Name = newName;

        GetOrCreateClass(function, className);

        return true;
    }

    private static Class GetOrCreateClass(Function function, string className)
    {
        var nGlobal = function.Namespace;

        var staticClass = nGlobal.FindClass(className);

        if (staticClass is not null) return staticClass;

        staticClass = new()
        {
            Name = className,
            IsStatic = true,
            Namespace = nGlobal,
            Access = AccessSpecifier.Public,
        };

        nGlobal.Declarations.Add(staticClass);
        
        return staticClass;
    }
}