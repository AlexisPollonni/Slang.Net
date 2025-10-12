using System;
using System.Collections.Generic;
using System.Linq;
using CodeGenHelpers;
using Microsoft.CodeAnalysis;
using ShaderSlang.Net.Pretty.SourceGenerator.Tooling.Extensions;

namespace ShaderSlang.Net.Pretty.SourceGenerator.Tooling;

class InvokeBuilder(ICodeWriter writer, IMethodSymbol method)
{
    private string? _instanceVar;
    private readonly Dictionary<string, (RefKind refKind, string? value)> _parameters = new();

    public InvokeBuilder SetParameter(IParameterSymbol parameter, string valueVar)
    {
        _parameters[parameter.Name] = (parameter.RefKind, valueVar);

        return this;
    }

    public InvokeBuilder SetParameter(ParameterSignature signature, string valueVar)
    {
        _parameters[signature.Name] = (signature.RefKind, valueVar);

        return this;
    }

    public InvokeBuilder TrySetParameter(ParameterSignature signature, string valueVar)
    {
        if (!_parameters.ContainsKey(signature.Name))
            SetParameter(signature, valueVar);
        return this;
    }

    public InvokeBuilder TrySetParameter(IParameterSymbol symbol, string valueVar)
    {
        if (!_parameters.ContainsKey(symbol.Name))
            SetParameter(symbol, valueVar);
        return this;
    }

    public InvokeBuilder WithInstance(string instanceVar)
    {
        _instanceVar = instanceVar;
        return this;
    }

    public void RenderLine()
    {
        writer.Append("");
        RenderUnindented();
        writer.AppendUnindentedLine("");
    }

    public void RenderLineUnindented()
    {
        RenderUnindented();
        writer.AppendUnindentedLine("");
    }

    public void Render()
    {
        writer.Append("");
        RenderUnindented();
    }

    public void RenderUnindented()
    {
        var reqParamNames = method
            .Parameters.Where(p => !p.HasExplicitDefaultValue)
            .Select(p => p.Name)
            .ToArray();
        if (reqParamNames.Any() && !reqParamNames.All(n => _parameters.ContainsKey(n)))
            throw new InvalidOperationException(
                "Function invoke does not contain all necessary parameters"
            );

        if (method.IsStatic)
        {
            writer.AppendUnindented(method.ContainingType.ToFullyQualified());
        }
        else
        {
            if (_instanceVar is null)
                throw new InvalidOperationException(
                    "Function invoke targets an instance function but not instance variable is provided"
                );

            writer.AppendUnindented(_instanceVar);
        }

        writer.AppendUnindented(".");
        writer.AppendUnindented(method.Name);
        writer.AppendUnindented("(");

        var invokeParams = _parameters.Select(pair =>
            $"{pair.Key}: {pair.Value.refKind.ToDisplayString()} {pair.Value.value}"
        );
        var joined = string.Join(", ", invokeParams);
        writer.AppendUnindented(joined);

        writer.AppendUnindented(")");
    }
}
