using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SlangNet.Pretty.SourceGenerator.MarshallingGenerator;

[Generator]
public class MarshallingGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Register the attribute in the compilation
        context.RegisterPostInitializationOutput(static ctx =>
        {
            
            //TODO: when i update to more recent versions of CodeAnalysis lib
            //ctx.AddEmbeddedAttributeDefinition();

            ctx.AddSource("GenerateMarshallingCodeAttribute.g.cs", 
                          """
                          using System;
                          
                          namespace SlangNet.Pretty.SourceGenerator;
                                          
                          [AttributeUsage(AttributeTargets.Method)]
                          class GenerateMarshallingCodeAttribute<TNativeContainerClass>(string nativeMethodName) : Attribute
                          { 
                              private string NativeMethodName = nativeMethodName;
                          }
                          """);
        });

        // context.SyntaxProvider.CreateSyntaxProvider((node, _) =>
        //                                             {
        //                                                 if (node is not TypeDeclarationSyntax tds) return false;
        //
        //                                                 if (tds.Modifiers.Any(SyntaxKind.PartialKeyword))
        //                                                 {
        //                                                     return tds.BaseList?.Types
        //                                                               .SelectMany(syntax => syntax.ChildNodes())
        //                                                               .OfType<IdentifierNameSyntax>()
        //                                                               .Any(i => i.Identifier.ValueText ==
        //                                                                         "IMarshalsToNative") ?? false;
        //                                                 }
        //
        //                                                 return false;
        //                                             },
        //                                             (syntaxContext, token) =>
        //                                                 syntaxContext.SemanticModel.GetDeclaredSymbol(
        //                                                     (TypeDeclarationSyntax)syntaxContext.Node,
        //                                                     token))
        //        .Where(symbol => symbol?.ImplementsIMarshalToNative() ?? false)
        //        .Select((symbol, _) => );

        // Find all methods with our attribute
        var methodDeclarations = context.SyntaxProvider.ForAttributeWithMetadataName(
                                            "SlangNet.Pretty.SourceGenerator.GenerateMarshallingCodeAttribute`1",
                                            predicate: (node, _) =>
                                            {
                                                if (node is not MethodDeclarationSyntax method) return false;

                                                return method.AttributeLists.Count > 0 &&
                                                       !method.Modifiers.Any(SyntaxKind.StaticKeyword);
                                            },
                                            transform: (context, _) => GetTargetForGeneration(context))
                                        .Where(static m => m is not null);

        // Generate the source
        context.RegisterSourceOutput(methodDeclarations,
                                     static (spc, source) =>
                                     {
                                         Debug.WriteLine($"Executing source generation for {source.Value} methods");
                                         Execute(source.Value.Method, source.Value.NativeMethod, spc);
                                     });
    }

    private static (IMethodSymbol Method, IMethodSymbol NativeMethod)? GetTargetForGeneration(
        GeneratorAttributeSyntaxContext context)
    {
        var methodSymbol = (IMethodSymbol)context.TargetSymbol;
        var attributeData = context.Attributes.Single();

        var nativeMethodContainerType = attributeData.AttributeClass!.TypeArguments.Single();
        var nativeMethodName = (string)attributeData.ConstructorArguments[0].Value!;

        if (string.IsNullOrWhiteSpace(nativeMethodName))
        {
            Debug.WriteLine("Invalid attribute arguments");
            return null;
        }

        var nativeMethod = nativeMethodContainerType.GetMembers(nativeMethodName).OfType<IMethodSymbol>().FirstOrDefault();

        if (nativeMethod != null) return (methodSymbol, nativeMethod);

        Debug.WriteLine($"Native method not found: {nativeMethodName}");
        return null;
    }

    private static void Execute(IMethodSymbol managedMethod, IMethodSymbol nativeMethod, SourceProductionContext context)
    {
        // Generate the marshalling code

        var generator = new MarshallingCodeGenerator();
        var source = generator.GenerateCode(managedMethod, nativeMethod);

        foreach (var diag in generator.Diagnostics)
        {
            context.ReportDiagnostic(diag);
        }
        
        var fileName = $"{managedMethod.ContainingType.Name}.{managedMethod.Name}.g.cs";
        Debug.WriteLine($"Adding source file: {fileName}");
        context.AddSource(fileName, source);
    }
}