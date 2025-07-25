using System;
using System.Collections.Immutable;
using System.Linq;
using CodeGenHelpers;
using Immutype;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SGF;
using SlangNet.Pretty.SourceGenerator.Tooling;
using SlangNet.Pretty.SourceGenerator.Tooling.Extensions;

namespace SlangNet.Pretty.SourceGenerator;

[IncrementalGenerator]
public class ThrowingMethodGenerator() : IncrementalGenerator(nameof(ThrowingMethodGenerator))
{
    private static void ProcessClass(SgfSourceProductionContext context, (CommonTypesContext, ITypeSymbol) pair)
    {
        var typeContext = pair.Item1;
        var clazz = pair.Item2;

        var classBuilder = CodeBuilder.Create(clazz.ContainingNamespace)
                                      .AddNamespaceImport("SlangNet")
                                      .AddNamespaceImport("SlangNet.ComWrappers.Tools.Extensions")
                                      .Nullable(NullableState.Enable)
                                      .AddClass($"{clazz.Name}ThrowingExtensions")
                                      .AddGeneratedCodeAttribute<ThrowingMethodGenerator>(new(0, 0, 1))
                                      .MakePublicClass()
                                      .MakeStaticClass();

        foreach (var method in clazz.GetMembers().OfType<IMethodSymbol>())
        {
            if (method.DeclaredAccessibility != Accessibility.Public || method.GetAttributes()
                                                                              .Select(d => d.AttributeClass)
                                                                              .Contains(typeContext.IgnoreThrowingAttribute,
                                                                                        SymbolEqualityComparer.Default))
                continue;

            var originalMethodData = new InterfaceExtensionData(MethodSignature.FromSymbol(method));

            var noThrowData = originalMethodData.TransformMethodNoThrow(typeContext)
                                                .TransformMethodDiagBlobToString(typeContext);

            if (!noThrowData.IsSignatureEquivalent(originalMethodData))
                classBuilder.AddGeneratedExtension(typeContext, noThrowData.WithSignature(noThrowData.Signature.WithName($"{method.Name}OrThrow")), method);

            var spanCollapsedData = originalMethodData.TransformMethodImplicitSpanCount(method)
                                                      .TransformMethodDiagBlobToString(typeContext);

            if (!spanCollapsedData.IsSignatureEquivalent(originalMethodData)) 
                classBuilder.AddGeneratedExtension(typeContext, spanCollapsedData, method);
        }

        var sourceText = classBuilder.Build(null!);
        context.AddSource($"{clazz.Name}_throwing.g.cs", sourceText);
    }
    
    public override void OnInitialize(SgfInitializationContext context)
    {
        var classProvider = context.SyntaxProvider.ForAttributeWithMetadataName(
            "SlangNet.GenerateThrowingMethodsAttribute",
            (node, _) => node is ClassDeclarationSyntax or StructDeclarationSyntax or InterfaceDeclarationSyntax,
            (syntaxContext, _) => (new CommonTypesContext(syntaxContext.SemanticModel.Compilation),
                                   (ITypeSymbol)syntaxContext.TargetSymbol));

        context.RegisterSourceOutput(classProvider, ProcessClass);
    }
}

[Target]
record InterfaceExtensionData(
    MethodSignature Signature,
    string? ReturnVarName = null,
    Action<InvokeBuilder>? ApiInvokeBuilder = null,
    Action<ICodeWriter>? PreInvokeCode = null,
    Action<ICodeWriter>? PostInvokeCode = null)
{
    public InterfaceExtensionData AddPreInvoke(Action<ICodeWriter> action) =>
        this with { PreInvokeCode = PreInvokeCode + action };

    public InterfaceExtensionData AddPostInvoke(Action<ICodeWriter> action) =>
        this with { PostInvokeCode = PostInvokeCode + action };

    public InterfaceExtensionData AddInvokeBuilderConfig(Action<InvokeBuilder> action) =>
        this with { ApiInvokeBuilder = ApiInvokeBuilder + action };
}

[Target]
record MethodSignature(string Name, ImmutableArray<ParameterSignature> ParametersSig, ReturnTypeSignature ReturnSig)
{
    public static MethodSignature FromSymbol(IMethodSymbol symbol)
    {
        return new(symbol.Name, [..symbol.Parameters.Select(ParameterSignature.FromSymbol)], new(symbol.ReturnType));
    }
}

[Target]
record ParameterSignature(string Name, ITypeSymbol Type, RefKind RefKind = RefKind.None)
{
    public static ParameterSignature FromSymbol(IParameterSymbol symbol) =>
        new(symbol.Name, symbol.Type, symbol.RefKind);
}

[Target]
record ReturnTypeSignature(ITypeSymbol Type);

record CommonTypesContext
{
    public CommonTypesContext(Compilation compilation)
    {
        StringType = compilation.GetSpecialType(SpecialType.System_String);
        VoidType = compilation.GetSpecialType(SpecialType.System_Void);

        SlangResultType = compilation.GetTypeByMetadataName("SlangNet.SlangResult") ??
                          throw new InvalidOperationException("SlangResult enum not found in compilation");

        IgnoreThrowingAttribute = compilation.GetTypeByMetadataName("SlangNet.IgnoreThrowingMethodAttribute") ??
                                  throw new InvalidOperationException(
                                      "SlangNet.IgnoreThrowingMethodAttribute not found in compilation");
    }

    public ITypeSymbol StringType { get; }
    public ITypeSymbol VoidType { get; }

    public ITypeSymbol SlangResultType { get; }

    public ITypeSymbol IgnoreThrowingAttribute { get; }
}