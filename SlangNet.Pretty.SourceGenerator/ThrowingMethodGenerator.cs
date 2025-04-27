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
                                      .AddGeneratedCodeAttribute<ThrowingMethodGenerator>(new(0, 0, 1))
                                      .MakePublicClass()
                                      .MakeStaticClass();

        foreach (var method in clazz.GetMembers().OfType<IMethodSymbol>())
        {
            if (method.DeclaredAccessibility != Accessibility.Public ||
                method.ReturnType.ToDisplayString() != "SlangNet.SlangResult" || method.GetAttributes()
                                                                                       .Any(a => a.AttributeClass
                                                                                                  ?.ToDisplayString() ==
                                                                                                 "SlangNet.IgnoreThrowingMethodAttribute"))
                continue;

            var mExtBuilder = classBuilder.AddMethod($"{method.Name}OrThrow")
                                          .MakePublicMethod()
                                          .MakeStaticMethod()
                                          .AddGenericsFrom(method)
                                          .AddAggressiveInliningAttribute()
                                          .AddGeneratedCodeAttribute<ThrowingMethodGenerator>(new(0, 0, 1))
                                          .AddParameter($"this {clazz.ToFullyQualified()}", "instance");

            var outParams = method.Parameters.Where(p => p.RefKind is RefKind.Out).ToArray();
            var lastOutParam = outParams.LastOrDefault(p => !IsDiagParam(p));
            var diagParam = outParams.LastOrDefault(IsDiagParam);

            var invokeParams = method.Parameters;

            if (lastOutParam is not null)
            {
                mExtBuilder.WithReturnType(lastOutParam.Type.WithNullableAnnotation(NullableAnnotation.NotAnnotated));
                invokeParams = invokeParams.Remove(lastOutParam);
            }

            foreach (var parameter in invokeParams)
            {
                if (ReferenceEquals(parameter, diagParam))
                {
                    mExtBuilder.AddParameterWithRefKind(RefKind.Out, "string?", "diagnostics");
                    mExtBuilder.AddNamespaceImport("SlangNet.ComWrappers.Tools.Extensions");
                    invokeParams = invokeParams.Remove(diagParam!);
                    continue;
                }

                mExtBuilder.AddParameterWithRefKind(parameter.RefKind, parameter.Type, parameter.Name);
            }

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

                if (returnVar is not null) writer.AppendLine($"return {returnVar}!;");
            });
            continue;

            bool IsDiagParam(IParameterSymbol parameter) =>
                parameter.Type.Name == "IBlob" && parameter.Name == "diagnostics";
        }

        var sourceText = classBuilder.Build(null!);
        context.AddSource($"{clazz.Name}_throwing.g.cs", sourceText);
    }

    public override void OnInitialize(SgfInitializationContext context)
    {
        var classProvider = context.SyntaxProvider.ForAttributeWithMetadataName(
            "SlangNet.GenerateThrowingMethodsAttribute",
            (node, _) => node is ClassDeclarationSyntax or StructDeclarationSyntax or InterfaceDeclarationSyntax,
            (syntaxContext, _) => (ITypeSymbol)syntaxContext.TargetSymbol);

        context.RegisterSourceOutput(classProvider, ProcessClass);
    }
}