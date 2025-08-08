using System;
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using CodeGenHelpers;
using Microsoft.CodeAnalysis;
using SGF;

namespace SlangNet.Pretty.SourceGenerator.Tooling.Extensions;

static class BuilderExtensions
{
    public static MethodBuilder AddGenericsFrom(this MethodBuilder methodBuilder, IMethodSymbol originMethod)
    {
        if (originMethod.IsGenericMethod)
        {
            foreach (var methodTypeParameter in originMethod.TypeParameters)
            {
                methodBuilder.AddGeneric(methodTypeParameter.Name,
                                         builder =>
                                         {
                                             if (methodTypeParameter.HasConstructorConstraint) builder.New();
                                             if (methodTypeParameter.HasReferenceTypeConstraint) builder.Class();
                                             if (methodTypeParameter.AllowsRefLikeType)
                                                 builder.AddConstraint("allows ref struct");
                                             if (methodTypeParameter.HasNotNullConstraint) builder.AddConstraint("not null");
                                             if (methodTypeParameter.HasValueTypeConstraint) builder.AddConstraint("struct");
                                             if (methodTypeParameter.HasUnmanagedTypeConstraint)
                                                 builder.AddConstraint("unmanaged");

                                             foreach (var constraint in methodTypeParameter.ConstraintTypes)
                                                 builder.AddConstraint(constraint.ToFullyQualified());
                                         });
            }
        }

        return methodBuilder;
    }

    public static MethodBuilder AddParameterWithRefKind(this MethodBuilder methodBuilder,
                                                        RefKind refKind,
                                                        ITypeSymbol type,
                                                        string name)
    {
        return methodBuilder.AddParameterWithRefKind(refKind, type.ToFullyQualified(), name);
    }

    public static MethodBuilder AddParameterWithRefKind(this MethodBuilder methodBuilder,
                                                        RefKind refKind,
                                                        string type,
                                                        string name)
    {
        return methodBuilder.AddParameter($"{refKind.ToDisplayString()} {type}", name);
    }

    public static MethodBuilder WithReturnType(this MethodBuilder methodBuilder, ITypeSymbol returnType)
    {
        return methodBuilder.WithReturnType(returnType.ToFullyQualified());
    }

    public static MethodBuilder AddAggressiveInliningAttribute(this MethodBuilder methodBuilder)
    {
        methodBuilder.AddNamespaceImport(typeof(MethodImplAttribute).Namespace!);
        return methodBuilder.AddAttribute("MethodImpl(MethodImplOptions.AggressiveInlining)");
    }

    public static MethodBuilder AddGeneratedCodeAttribute<TGenerator>(this MethodBuilder methodBuilder, Version version)
        where TGenerator : IncrementalGenerator
    {
        methodBuilder.AddNamespaceImport(typeof(GeneratedCodeAttribute).Namespace!);
        return methodBuilder.AddAttribute(
            $"GeneratedCodeAttribute(\"{typeof(TGenerator).FullName}\", \"{version.ToString(3)}\")");
    }

    public static ClassBuilder AddGeneratedCodeAttribute<TGenerator>(this ClassBuilder classBuilder, Version version)
        where TGenerator : IncrementalGenerator
    {
        classBuilder.AddNamespaceImport(typeof(GeneratedCodeAttribute).Namespace!);
        return classBuilder.AddAttribute(
            $"GeneratedCodeAttribute(\"{typeof(TGenerator).FullName}\", \"{version.ToString(3)}\")");
    }

    public static MethodBuilder AddExtensionMethodOverload(this ClassBuilder classBuilder,
                                                           string methodName,
                                                           ITypeSymbol typeToExtendSymbol,
                                                           IMethodSymbol originalMethodToCall)
    {
        var mExtBuilder = classBuilder.AddMethod(methodName)
                                      .MakePublicMethod()
                                      .MakeStaticMethod()
                                      .AddGenericsFrom(originalMethodToCall)
                                      .AddAggressiveInliningAttribute()
                                      .AddGeneratedCodeAttribute<GeneratedOverloadsGenerator>(new(0, 0, 1))
                                      .AddParameter($"this {typeToExtendSymbol.ToFullyQualified()}", "instance");
        return mExtBuilder;
    }

    public static ClassBuilder AddGeneratedExtension(this ClassBuilder classBuilder,
                                                     CommonTypesContext ctx,
                                                     InterfaceExtensionData data,
                                                     IMethodSymbol originalMethod)
    {
        var methodBuilder
            = classBuilder.AddExtensionMethodOverload(data.Signature.Name, originalMethod.ContainingType, originalMethod);

        foreach (var pmSig in data.Signature.ParametersSig)
        {
            if(pmSig.DefaultValue is not null)
                if (pmSig.DefaultValue.IsNull)
                    methodBuilder.AddParameterWithNullValue(pmSig.Type, pmSig.Name);
                else
                    methodBuilder.AddParameterWithDefaultValue(pmSig.Type,
                                                               pmSig.Name,
                                                               pmSig.DefaultValue.ExplicitType);
            else methodBuilder.AddParameterWithRefKind(pmSig.RefKind,
                                                       pmSig.Type,
                                                       pmSig.Name);
        }

        var isVoidReturn = SymbolEqualityComparer.Default.Equals(data.Signature.ReturnSig.Type, ctx.VoidType);
        if (!isVoidReturn) 
            methodBuilder.WithReturnType(data.Signature.ReturnSig.Type);

        methodBuilder.WithBody(writer =>
        {
            data.PreInvokeCode?.Invoke(writer);

            var invokeBuilder = writer.BuildMethodInvoke(originalMethod).WithInstance("instance");

            data.ApiInvokeBuilder?.Invoke(invokeBuilder);
            foreach (var pSymbol in originalMethod.Parameters) invokeBuilder.TrySetParameter(pSymbol, pSymbol.Name);

            if (!originalMethod.ReturnsVoid)
            {
                writer.WriteVariableDeclaration(originalMethod.ReturnType, "__result").EndLine();
                writer.Append("__result = ");
                invokeBuilder.RenderUnindented();
            }
            else invokeBuilder.Render();
            writer.EndLine();

            data.PostInvokeCode?.Invoke(writer);

            if (data.ReturnVarName is not null) writer.AppendLine($"return {data.ReturnVarName}!;");
            else if (!originalMethod.ReturnsVoid &&
                     SymbolEqualityComparer.Default.Equals(originalMethod.ReturnType, data.Signature.ReturnSig.Type))
                writer.AppendLine("return __result;");
        });

        return classBuilder;
    }
}