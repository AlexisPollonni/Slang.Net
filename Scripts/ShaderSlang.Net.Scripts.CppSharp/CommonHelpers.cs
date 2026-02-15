using Attribute = CppSharp.AST.Attribute;

namespace ShaderSlang.Net.Scripts.CppSharp;

public static class CommonHelpers
{
    public static string ToGlobalFullName(this Type type) => $"global::{type.FullName}";
}

/// <summary>
/// Since the default attribute type does not support applying to return values, we define a custom attribute that can be used for this purpose.
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