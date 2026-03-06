using System.Runtime.InteropServices;
using CppSharp;
using CppSharp.AST;
using CppSharp.Passes;
using Shouldly;
using Attribute = CppSharp.AST.Attribute;

namespace ShaderSlang.Net.Scripts.CppSharpGenerator.Passes;

internal sealed class GenerateStaticClassForFunctionPass(string functionPrefix, string className)
    : TranslationUnitPass
{
    public override bool VisitMethodDecl(Method method) => true;

    public override bool VisitFunctionDecl(Function function)
    {
        if (!function.IsGenerated)
            return false;

        if (!function.OriginalName.StartsWith(functionPrefix, StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        var newName = function.OriginalName.Remove(0, functionPrefix.Length);

        newName = StringHelpers.Capitalize(newName);

        var staticClass = GetOrCreateClass(function, className);

        MoveFunctionToStaticClass(newName, function, staticClass);

        return true;
    }

    private static Class GetOrCreateClass(Function function, string className)
    {
        var nGlobal = function.Namespace;

        var staticClass = nGlobal.FindClass(className);

        if (staticClass?.TranslationUnit != nGlobal.TranslationUnit)
            staticClass = null;

        if (staticClass is not null)
            return staticClass;

        staticClass = new()
        {
            Name = className,
            IsStatic = true,
            Namespace = nGlobal,
            Access = AccessSpecifier.Public,
        };

        //TODO: insert before first function instead of adding to end of decls
        nGlobal.Declarations.Add(staticClass);

        return staticClass;
    }

    private static void MoveFunctionToStaticClass(
        string methodName,
        Function function,
        Class staticClass
    )
    {
        staticClass.IsStatic.ShouldBeTrue();

        var newMethod = new Method(function)
        {
            Namespace = staticClass,
            OriginalNamespace = function.Namespace,
            Name = methodName,
            Access = AccessSpecifier.Public,
            Kind = CXXMethodKind.Normal,
            IsStatic = true,
            Conversion = MethodConversionKind.FunctionToStaticMethod,
        };

        var libImportAttribute = AstAttributeFactory.CreateLibraryImportAttribute(
            function.TranslationUnit.Module.SharedLibraryName,
            function.Mangled,
            StringMarshalling.Utf8
        );

        newMethod.Attributes.Add(libImportAttribute);

        foreach (var methodParameter in newMethod.Parameters)
        {
            methodParameter.Namespace = newMethod;
        }

        function.ExplicitlyIgnore();

        staticClass.Methods.Add(newMethod);
        staticClass.Declarations.Add(newMethod);
        Diagnostics.Debug(
            "Function converted to static method: {0}::{1}",
            staticClass.Name,
            methodName
        );
    }
}
