using System;
using System.Collections.Generic;
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
public class GeneratedOverloadsGenerator() : IncrementalGenerator(nameof(GeneratedOverloadsGenerator))
{
    private static void ProcessClass(SgfSourceProductionContext context, (CommonTypesContext, ITypeSymbol) pair)
    {
        var typeContext = pair.Item1;
        var clazz = pair.Item2;

        var classBuilder = CodeBuilder.Create(clazz.ContainingNamespace)
                                      .AddNamespaceImport("SlangNet")
                                      .AddNamespaceImport("SlangNet.ComWrappers.Tools.Extensions")
                                      .Nullable(NullableState.Enable)
                                      .AddClass($"{clazz.Name}OverloadExtensions")
                                      .AddGeneratedCodeAttribute<GeneratedOverloadsGenerator>(new(0, 0, 2))
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

            var diagBlobToStringData = originalMethodData.TransformMethodDiagBlobToString(typeContext);
            var spanCollapsedData = diagBlobToStringData.TransformMethodImplicitSpanCount(method);

            var extensionList = new List<InterfaceExtensionData>([diagBlobToStringData, spanCollapsedData]);
            
            if (originalMethodData.Signature.ReturnSig.Type.Equals(typeContext.SlangResultType, SymbolEqualityComparer.Default))
            {
                var noThrowData = diagBlobToStringData.WithMethodName($"{method.Name}OrThrow")
                                                      .TransformMethodNoThrow(typeContext);


                var spanCollapsedNoThrow = noThrowData.TransformMethodImplicitSpanCount(method);
                
                extensionList.Add(noThrowData);
                extensionList.Add(spanCollapsedNoThrow);
            }

            foreach (var data in extensionList
                                 .Where(data => !data.IsSignatureEquivalent(originalMethodData))
                                 .Distinct(SignatureEquivalentComparer.Instance)) 
                classBuilder.AddGeneratedExtension(typeContext, data, method);
        }

        var sourceText = classBuilder.Build(null!);
        context.AddSource($"{clazz.Name}_overloads.g.cs", sourceText);
    }

    private class SignatureEquivalentComparer : EqualityComparer<InterfaceExtensionData>
    {
        public static readonly SignatureEquivalentComparer Instance = new();
        
        public override bool Equals(InterfaceExtensionData x, InterfaceExtensionData y) =>
            x.IsSignatureEquivalent(y);

        public override int GetHashCode(InterfaceExtensionData obj) =>
            Default.GetHashCode(obj);
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
record MethodSignature(string Name, EquatableArray<ParameterSignature> ParametersSig, ReturnTypeSignature ReturnSig)
{
    public static MethodSignature FromSymbol(IMethodSymbol symbol)
    {
        var parameters = symbol.Parameters.Select(ParameterSignature.FromSymbol).ToImmutableArray().AsEquatableArray();
        return new(symbol.Name, parameters, new(symbol.ReturnType));
    }

    public MethodSignature RemoveParametersSig(ParameterSignature paramSig)
    {
        return this.WithParametersSig(ParametersSig.AsImmutableArray().Remove(paramSig));
    }
    
    public MethodSignature ReplaceParametersSig(ParameterSignature oldSig, ParameterSignature newSig)
    {
        return this.WithParametersSig(ParametersSig.AsImmutableArray().Replace(oldSig, newSig));
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

        SlangResultType = FindSymbol(compilation, "SlangNet.SlangResult");
        IBlobType = FindSymbol(compilation, "SlangNet.ComWrappers.Interfaces.IBlob");
        
        
        IgnoreThrowingAttribute = FindSymbol(compilation, "SlangNet.IgnoreThrowingMethodAttribute");
    }
    
    private ITypeSymbol FindSymbol(Compilation compilation, string metadataName) =>
        compilation.GetTypeByMetadataName(metadataName) ??
        throw new InvalidOperationException($"Type '{metadataName}' not found in compilation");

    public ITypeSymbol StringType { get; }
    public ITypeSymbol VoidType { get; }

    public ITypeSymbol SlangResultType { get; }
    public ITypeSymbol IBlobType { get; }
    
    public ITypeSymbol IgnoreThrowingAttribute { get; }
}