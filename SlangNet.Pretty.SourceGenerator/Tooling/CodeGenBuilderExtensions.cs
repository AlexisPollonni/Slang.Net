using System;
using System.Collections.Generic;
using System.Linq;
using CodeGenHelpers;
using Microsoft.CodeAnalysis;

namespace SlangNet.Pretty.SourceGenerator.Tooling;

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
            var reqParamNames = method.Parameters.Where(p => !p.HasExplicitDefaultValue).Select(p => p.Name).ToArray();
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

            var invokeParams
                = _parameters.Select(pair => $"{pair.Key}: {pair.Value.refKind.ToDisplayString()} {pair.Value.value}");
            var joined = string.Join(", ", invokeParams);
            writer.AppendUnindented(joined);

            writer.AppendUnindented(")");
        }
    }

    public static InvokeBuilder BuildMethodInvoke(this ICodeWriter writer, IMethodSymbol method) =>
        new(writer, method);

    public static ICodeWriter WriteVariableDeclaration(this ICodeWriter writer,
                                                       string type,
                                                       string name,
                                                       string? value = null)
    {
        writer.Append($"{type} {name}");
        if (value is not null) writer.AppendUnindented($" = {value}");
        return writer;
    }

    public static ICodeWriter WriteVariableDeclaration(this ICodeWriter writer,
                                                       ITypeSymbol type,
                                                       string name,
                                                       string? value = null)
    {
        return writer.WriteVariableDeclaration(type.ToFullyQualified(), name, value);
    }

    public static ICodeWriter EndLine(this ICodeWriter writer)
    {
        writer.AppendUnindentedLine(";");
        return writer;
    }
}