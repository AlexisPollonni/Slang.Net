using System;
using System.Collections.Generic;
using System.Linq;
using CodeGenHelpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SGF;
using SlangNet.Pretty.SourceGenerator.Tooling;

namespace SlangNet.Pretty.SourceGenerator;

[IncrementalGenerator]
public class ThrowingMethodGenerator() : IncrementalGenerator(nameof(ThrowingMethodGenerator))
{
    private static void ProcessClass(SgfSourceProductionContext context, ITypeSymbol clazz)
    {
        var classBuilder = CodeBuilder.Create(clazz.ContainingNamespace)
                                      .AddNamespaceImport("SlangNet")
                                      .Nullable(NullableState.Enable)
                                      .AddClass($"{clazz.Name}ThrowingExtensions")
                                      .MakePublicClass()
                                      .MakeStaticClass();

        foreach (var method in clazz.GetMembers().OfType<IMethodSymbol>())
        {
            if (method.DeclaredAccessibility != Accessibility.Public ||
                method.ReturnType.ToDisplayString() != "SlangNet.SlangResult" || method.GetAttributes()
                                                                                       .Any(a => a.AttributeClass
                                                                                                  .ToDisplayString() ==
                                                                                                 "SlangNet.IgnoreThrowingMethodAttribute"))
                continue;

            var mExtBuilder = classBuilder.AddMethod($"{method.Name}Throwing")
                                          .MakePublicMethod()
                                          .MakeStaticMethod()
                                          .AddGenericsFrom(method)
                                          .AddParameter($"this {clazz.ToFullyQualified()}", "instance");
            
            
            
            const string diagParamDefString = "out IBlob? diagnostics";
            var outParams = method.Parameters.Where(p => p.RefKind is RefKind.Out).ToArray();
            var lastOutParam = outParams.LastOrDefault(p => p.ToDisplayString() != diagParamDefString);
            var diagParam = outParams.LastOrDefault(p => p.ToDisplayString() == diagParamDefString);
            
            var invokeParams = method.Parameters;

            if (lastOutParam is not null)
            {
                mExtBuilder.WithReturnType(lastOutParam.Type.WithNullableAnnotation(NullableAnnotation.NotAnnotated));
                invokeParams = invokeParams.Remove(lastOutParam);
            }

            if (diagParam is not null)
            {
                mExtBuilder.AddParameterWithRefKind(RefKind.Out, "string?", "diagnostics");
                invokeParams = invokeParams.Remove(diagParam);
            }

            foreach (var parameter in invokeParams) mExtBuilder.AddParameterWithRefKind(parameter.RefKind, parameter.Type, parameter.Name);

            mExtBuilder.WithBody(writer =>
            {
                var invokeBuilder = writer.BuildMethodInvoke(method).WithInstance("instance");
                string? returnVar = null;

                if (lastOutParam is not null)
                {
                    var invokeName = $"__out{lastOutParam.Name}";
                    writer.WriteVariableDeclaration(lastOutParam.Type, invokeName).EndLine();

                    returnVar = invokeName;
                    invokeBuilder.AddParameter(lastOutParam, invokeName);
                }

                if (diagParam is not null)
                {
                    writer.WriteVariableDeclaration(diagParam.Type, "diagBlob").EndLine();

                    invokeBuilder.AddParameter(diagParam, "diagBlob");
                }
                
                foreach (var parameter in invokeParams) invokeBuilder.AddParameter(parameter, parameter.Name);

                invokeBuilder.Render();
                writer.AppendUnindentedLine(".ThrowIfFailed();");

                if (diagParam is not null)
                {
                    writer.AppendLine("diagnostics = diagBlob.AsString();");
                }

                if (returnVar is not null) writer.AppendLine($"return {returnVar};");
            });
        }

        var sourceText = classBuilder.Build(null!);
        context.AddSource($"{clazz.Name}_throwing.g.cs", sourceText);
    }


    public override void OnInitialize(SgfInitializationContext context)
    {
        var classProvider = context.SyntaxProvider.ForAttributeWithMetadataName("SlangNet.GenerateThrowingMethodsAttribute",
                                                                                (node, _) => node 
                                                                                    is ClassDeclarationSyntax
                                                                                    or StructDeclarationSyntax 
                                                                                    or InterfaceDeclarationSyntax,
                                                                                (syntaxContext, _) =>
                                                                                    (ITypeSymbol)syntaxContext.TargetSymbol);

        context.RegisterSourceOutput(classProvider, ProcessClass);
    }
}

public static class CodeGenBuilderExtensions
{
    public class InvokeBuilder(ICodeWriter writer, IMethodSymbol method)
    {
        private string? _instanceVar;
        private readonly Dictionary<string, (RefKind refKind, string? value)> _parameters = new();

        public InvokeBuilder AddParameter(IParameterSymbol parameter, string valueVar)
        {
            _parameters.Add(parameter.Name, (parameter.RefKind, valueVar));
            
            return this;
        }

        public InvokeBuilder WithInstance(string instanceVar)
        {
            _instanceVar = instanceVar;
            return this;
        }

        public void Render()
        {
            var reqParamNames = method.Parameters.Where(p => !p.HasExplicitDefaultValue)
                  .Select(p => p.Name).ToArray();
            if (reqParamNames.Any() && !reqParamNames.All(n => _parameters.ContainsKey(n)))
                throw new InvalidOperationException("Function invoke does not contain all necessary parameters");

            if (method.IsStatic)
            {
                writer.Append(method.ContainingType.ToFullyQualified());
            }
            else
            {
                if (_instanceVar is null)
                    throw new InvalidOperationException(
                        "Function invoke targets an instance function but not instance variable is provided");
                
                writer.Append(_instanceVar);
            }

            writer.AppendUnindented(".");
            writer.AppendUnindented(method.Name);
            writer.AppendUnindented("(");

            var invokeParams = _parameters.Select(pair => $"{pair.Key}: {pair.Value.refKind.ToDisplayString()} {pair.Value.value}");
            var joined = string.Join(", ", invokeParams);
            writer.AppendUnindented(joined);
            
            writer.AppendUnindented(")");
        }
    }
    
    public static InvokeBuilder BuildMethodInvoke(this ICodeWriter writer, IMethodSymbol method) => new(writer, method);

    public static ICodeWriter WriteVariableDeclaration(this ICodeWriter writer, string type, string name, string? value = null)
    {
        writer.Append($"{type} {name}");
        if (value is not null) writer.AppendUnindented($" = {value}");
        return writer;
    }

    public static ICodeWriter WriteVariableDeclaration(this ICodeWriter writer, ITypeSymbol type, string name, string? value = null)
    {
        return writer.WriteVariableDeclaration(type.ToFullyQualified(), name, value);
    }

    public static ICodeWriter EndLine(this ICodeWriter writer)
    {
        writer.AppendUnindentedLine(";");
        return writer;
    }
}

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
}

public static class EnumStringExtensions
{
    public static string ToDisplayString(this RefKind refKind) =>
        refKind switch
        {
            RefKind.None => "",
            RefKind.Ref => "ref",
            RefKind.Out => "out",
            RefKind.In => "in",
            RefKind.RefReadOnlyParameter => "ref readonly",
            _ => throw new ArgumentOutOfRangeException(nameof(refKind), refKind, null)
        };
}