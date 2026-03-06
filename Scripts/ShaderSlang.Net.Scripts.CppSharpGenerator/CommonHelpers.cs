using CppSharp;
using CppSharp.AST;
using CppSharp.Types;
using Attribute = CppSharp.AST.Attribute;
using Type = System.Type;

namespace ShaderSlang.Net.Scripts.CppSharpGenerator;

public static class CommonHelpers
{
    public static string ToGlobalFullName(this Type type) => $"global::{type.FullName}";

    public static string ToGlobalFullName(this DeclarationContext @class)
    {
        var outputNamespace = @class.TranslationUnit.Module.OutputNamespace;

        var qualifiedNamespaces = @class
            .GatherParentNamespaces()
            .Select(decl => decl.Name)
            .Where(ns => !string.IsNullOrEmpty(ns));

        var combined = string.Join('.', qualifiedNamespaces);
        if (!combined.StartsWith(outputNamespace, StringComparison.Ordinal))
        {
            combined = $"{outputNamespace}.{combined}";
        }

        return $"global::{combined}";
    }

    public static bool IsISlangUnknown(this Class potential)
    {
        return potential.OriginalName == "ISlangUnknown"
            || potential.HasClassInHierarchy("ISlangUnknown");
    }

    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> source)
        where T : class
    {
        return source.Where(item => item is not null)!;
    }

    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> source)
        where T : struct
    {
        return source.Where(item => item is not null).Select(arg => arg!.Value);
    }
}

/// <summary>
/// Since the default attribute type do not support applying to return values, we define a custom attribute that can be used for this purpose.
/// The code generator will recognize this attribute and apply it to the return type of the method.
/// </summary>
internal class ReturnAttribute : Attribute
{
    public ReturnAttribute(Attribute attribute)
    {
        Type = attribute.Type;
        Value = attribute.Value;
    }

    public ReturnAttribute() { }
}
