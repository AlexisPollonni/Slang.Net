using CppSharp;
using CppSharp.AST;
using CppSharp.Generators;
using CppSharp.Generators.CSharp;
using CppSharp.Types;
using Attribute = CppSharp.AST.Attribute;
using Type = System.Type;

namespace ShaderSlang.Net.Scripts.CppSharp;

public static class CommonHelpers
{
    public static string ToGlobalFullName(this Type type) => $"global::{type.FullName}";

    public static string ToGlobalFullName(this Class @class)
    {
        var outputNamespace = @class.TranslationUnit.Module.OutputNamespace;
        
        var qualifiedNamespaces = @class.GatherParentNamespaces()
            .Select(decl => decl.Name)
            .Prepend(outputNamespace)
            .Where(ns => !string.IsNullOrEmpty(ns));
        
        return $"global::{string.Join('.', qualifiedNamespaces)}";
    }

    public static void AddTypeMapForClass(this TypeMapDatabase database, Class @class, TypeMap typeMap)
    {
        var key = @class.QualifiedOriginalName;
        var type = new TagType(@class);
        
        if (database.FindTypeMap(type, out _))
        {
            Diagnostics.Warning($"A type map for class {@class.Name} already exists, skipping");
            return;
        }
        
        database.TypeMaps.Add(key, typeMap);
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

    public ReturnAttribute()
    {
        
    }
}