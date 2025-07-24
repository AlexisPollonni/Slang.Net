using System;
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using CodeGenHelpers;
using Microsoft.CodeAnalysis;
using SGF;

namespace SlangNet.Pretty.SourceGenerator.Tooling.Extensions;

public static class BuilderExtensions
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
}