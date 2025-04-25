using JetBrains.Annotations;

namespace SlangNet.Pretty.SourceGenerator.Tooling;

public static class Attributes
{
    [LanguageInjection("csharp")]
    public const string MarshallingGen = """
                                         using System;

                                         namespace SlangNet.Pretty.SourceGenerator;
                                                         
                                         [AttributeUsage(AttributeTargets.Method)]
                                         class GenerateMarshallingCodeAttribute<TNativeContainerClass>(string nativeMethodName) : Attribute
                                         { 
                                             private string NativeMethodName = nativeMethodName;
                                         }
                                         """;
}