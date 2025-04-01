﻿using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace SlangNet.Pretty.SourceGenerator;

[Generator]
public class ThrowingMethodGenerator : IIncrementalGenerator
{
    private static void ProcessClass(SourceProductionContext context, ITypeSymbol clazz)
    {
        var source = new StringBuilder();
        source.AppendLine("#nullable enable");
        source.AppendLine($"namespace {clazz.ContainingNamespace.ToDisplayString()};");

        var curContainer = clazz.ContainingType;
        while (curContainer != null)
        {
            source.AppendLine($"partial {(curContainer.TypeKind == TypeKind.Class ? "class" : "struct")} {curContainer.Name}");
            source.AppendLine("{");
            curContainer = curContainer.ContainingType;
        }

        source.AppendLine($"partial {(clazz.TypeKind == TypeKind.Class ? "class" : "struct")} {clazz.Name}");
        source.AppendLine("{");

        foreach (var method in clazz.GetMembers().OfType<IMethodSymbol>())
        {
            if (method.DeclaredAccessibility != Accessibility.Public ||
                !method.Name.StartsWith("Try") ||
                method.ReturnType.ToDisplayString() != "SlangNet.SlangResult" ||
                method.GetAttributes().Any(a => a.AttributeClass.ToDisplayString() == "SlangNet.IgnoreThrowingMethodAttribute"))
                continue;

            var returnType = "void";
            var hasDiagnosticParam = false;
            var parameters = method.Parameters.ToList();
            var outputParam = parameters.LastOrDefault();
            if (outputParam?.RefKind == RefKind.Out)
            {
                parameters.RemoveAt(parameters.Count - 1);
                returnType = outputParam.Type.ToDisplayString().TrimEnd('?');
            }
            else
                outputParam = null;
            if (parameters.LastOrDefault()?.ToDisplayString() == "out string? diagnostics")
            {
                parameters.RemoveAt(parameters.Count - 1);
                hasDiagnosticParam = true;
            }

            source.Append("    public ");
            if (method.IsStatic)
                source.Append("static ");
            source.Append(returnType);
            source.Append(' ');
            source.Append(method.Name.Substring(3));
            source.Append('(');

            foreach (var param in parameters)
            {
                if (!ReferenceEquals(param, parameters.First()))
                    source.Append(", ");
                source.Append(param.ToDisplayString());
            }
            source.AppendLine(")");
            source.AppendLine("    {");

            source.Append("        ");
            source.Append(method.Name);
            source.Append("(");

            foreach (var param in parameters)
            {
                if (!ReferenceEquals(param, parameters.First()))
                    source.Append(", ");
                if (param.RefKind == RefKind.Out)
                    source.Append("out ");
                if (param.RefKind == RefKind.Ref)
                    source.Append("ref ");
                source.Append(param.Name);
            }
            if (hasDiagnosticParam)
            {
                if (parameters.Any())
                    source.Append(", ");
                source.Append("out var diagnostics");
            }
            if (outputParam != null)
            {
                if (parameters.Any() || hasDiagnosticParam)
                    source.Append(", ");
                source.Append("out var ");
                source.Append(outputParam.Name);
            }
            source.Append(").ThrowIfFailed(");
            if (hasDiagnosticParam)
                source.Append("diagnostics");
            source.AppendLine(");");

            if (outputParam != null)
            {
                source.Append("        return ");
                source.Append(outputParam.Name);
                source.AppendLine("!;");
            }

            source.AppendLine("    }");
        }

        source.AppendLine("}");
        curContainer = clazz.ContainingType;
        while (curContainer != null)
        {
            source.AppendLine("}");
            curContainer = curContainer.ContainingType;
        }

        context.AddSource($"{clazz.Name}_throwing.g.cs", SourceText.From(source.ToString(), Encoding.UTF8));
    }

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var classProvider = context.SyntaxProvider.ForAttributeWithMetadataName("SlangNet.GenerateThrowingMethodsAttribute",
                                                            (node, _) => node is ClassDeclarationSyntax
                                                                or StructDeclarationSyntax,
                                                            (syntaxContext, _) => (ITypeSymbol)syntaxContext.TargetSymbol);
        
        context.RegisterSourceOutput(classProvider, ProcessClass);
    }
}
