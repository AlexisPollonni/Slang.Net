using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SlangNet.Pretty.SourceGenerator;

[Generator]
public class MarshallingGenerator : IIncrementalGenerator
{
    private const string AttributeNamespace = "SlangNet.Pretty.SourceGenerator";
    private const string AttributeName = "GenerateMarshallingCodeAttribute";
    private const string AttributeFullName = $"{AttributeNamespace}.{AttributeName}";

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {

        // Register the attribute in the compilation
        context.RegisterPostInitializationOutput(static ctx => 
        {
            //ctx.AddEmbeddedAttributeDefinition();
            Debug.WriteLine("Registering attribute");
            ctx.AddSource(
                $"{AttributeName}.g.cs",
                $$"""
                using System;
                
                namespace {{AttributeNamespace}};
                
                [AttributeUsage(AttributeTargets.Method)]
                internal class {{AttributeName}}<TNativeContainerClass>(string nativeMethodName) : Attribute
                { 
                    private string NativeMethodName = nativeMethodName;
                }
                
                """);
            Debug.WriteLine("Attribute registered");
        });

        // Find all methods with our attribute
        var methodDeclarations = context.SyntaxProvider
            .ForAttributeWithMetadataName(
                AttributeFullName + "`1",
                predicate: (node, _) => 
                {
                    Debug.WriteLine($"Checking node type: {node.GetType().Name}");
                    if (node is MethodDeclarationSyntax method)
                    {
                        Debug.WriteLine($"Found method: {method.Identifier.Text}");
                        Debug.WriteLine($"Has attributes: {method.AttributeLists.Count > 0}");
                        Debug.WriteLine($"Is not static: {!method.Modifiers.Any(SyntaxKind.StaticKeyword)}");
                        return method.AttributeLists.Count > 0 && !method.Modifiers.Any(SyntaxKind.StaticKeyword);
                    }
                    return false;
                },
                transform: (context, token) => 
                {
                    var methodSymbol = (IMethodSymbol)context.TargetSymbol;
                    Debug.WriteLine($"Transforming method: {methodSymbol.Name}");
                    Debug.WriteLine($"Attribute count: {context.Attributes.Length}");
                    foreach (var attr in context.Attributes)
                    {
                        Debug.WriteLine($"Attribute class: {attr.AttributeClass?.Name}");
                        Debug.WriteLine($"Constructor args: {attr.ConstructorArguments.Length}");
                    }
                    return GetTargetForGeneration(context);
                })
            .Where(static m => m is not null);

        // Combine with the compilation
        var compilationAndMethods = context.CompilationProvider.Combine(methodDeclarations.Collect());

        // Generate the source
        context.RegisterSourceOutput(compilationAndMethods, 
            static (spc, source) => 
            {
                Debug.WriteLine($"Executing source generation for {source.Right.Length} methods");
                Execute(source.Left, source.Right, spc);
            });
    }

    private static (IMethodSymbol Method, IMethodSymbol NativeMethod)? GetTargetForGeneration(GeneratorAttributeSyntaxContext context)
    {
        var methodSymbol = (IMethodSymbol)context.TargetSymbol;
        Debug.WriteLine($"Getting target for generation: {methodSymbol.Name}");
        
        var attributeData = context.Attributes[0];
        Debug.WriteLine($"Attribute constructor argument count: {attributeData.ConstructorArguments.Length}");
        
        var nativeMethodContainerType = attributeData.AttributeClass.TypeArguments.Single();
        Debug.WriteLine($"Type name: {nativeMethodContainerType}");
        
        var compilation = context.SemanticModel.Compilation;
        //var nativeMethodContainerType = compilation.GetTypeByMetadataName(typeNameArg);
        var nativeMethodName = attributeData.ConstructorArguments[0].Value as string;

        Debug.WriteLine($"Native type: {nativeMethodContainerType?.Name}");
        Debug.WriteLine($"Native method name: {nativeMethodName}");

        if (nativeMethodContainerType == null || string.IsNullOrEmpty(nativeMethodName))
        {
            Debug.WriteLine("Invalid attribute arguments");
            return null;
        }

        var nativeMethod = nativeMethodContainerType.GetMembers(nativeMethodName)
            .OfType<IMethodSymbol>()
            .FirstOrDefault();

        if (nativeMethod == null)
        {
            Debug.WriteLine($"Native method not found: {nativeMethodName}");
            return null;
        }

        Debug.WriteLine("Successfully found native method");
        return (methodSymbol, nativeMethod);
    }

    private static void Execute(Compilation compilation, ImmutableArray<(IMethodSymbol Method, IMethodSymbol NativeMethod)?> methods, SourceProductionContext context)
    {
        if (methods.IsDefaultOrEmpty)
        {
            Debug.WriteLine("No methods to process");
            return;
        }

        Debug.WriteLine($"Processing {methods.Length} methods");
        var distinctMethods = methods.Distinct();
        foreach (var methodPair in distinctMethods)
        {
            if (methodPair == null)
            {
                Debug.WriteLine("Skipping null method pair");
                continue;
            }

            var (methodSymbol, nativeMethod) = methodPair.Value;
            Debug.WriteLine($"Processing method: {methodSymbol.Name}");

            //if (!ParameterValidator.ValidateParameters(methodSymbol, nativeMethod, methodSymbol.Locations[0], context))
            //{
            //    Debug.WriteLine("Parameter validation failed");
            //    continue;
            //}

            // Generate the marshalling code
            
            var source = MarshallingCodeGenerator.GenerateCode(methodSymbol, nativeMethod, compilation);
            var fileName = $"{methodSymbol.ContainingType.Name}.{methodSymbol.Name}.g.cs";
            Debug.WriteLine($"Adding source file: {fileName}");
            context.AddSource(fileName, source);
        }
    }
}