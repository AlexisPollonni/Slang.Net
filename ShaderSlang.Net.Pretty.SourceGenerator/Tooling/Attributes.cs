using JetBrains.Annotations;

namespace ShaderSlang.Net.Pretty.SourceGenerator.Tooling;

public static class Attributes
{
    [LanguageInjection("csharp")]
    public const string MarshallingGen = """
                                         using System;

                                         namespace ShaderSlang.Net.Pretty.SourceGenerator;
                                                         
                                         [AttributeUsage(AttributeTargets.Method)]
                                         class GenerateMarshallingCodeAttribute<TNativeContainerClass>(string nativeMethodName) : Attribute
                                         { 
                                             private string NativeMethodName = nativeMethodName;
                                         }
                                         """;
}