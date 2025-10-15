using Microsoft.CodeAnalysis;

namespace ShaderSlang.Net.Pretty.SourceGenerator.Tooling.Extensions;

static class MethodTransformExtensions
{
    private static bool IsDiagParam(this ParameterSignature parameter, CommonTypesContext ctx) =>
        (
            parameter.Type.Equals(ctx.IBlobType, SymbolEqualityComparer.Default)
            || parameter.Type.Equals(ctx.StringType, SymbolEqualityComparer.Default)
        )
        && parameter.Name == "diagnostics";

    extension(InterfaceExtensionData data)
    {
        public InterfaceExtensionData TransformMethodNoThrow(CommonTypesContext ctx)
        {
            if (
                !SymbolEqualityComparer.Default.Equals(
                    data.Signature.ReturnSig.Type,
                    ctx.SlangResultType
                )
            )
                return data;

            var lastOutParam = data
                .Signature.ParametersSig.Where(p => p.RefKind is RefKind.Out)
                .LastOrDefault(p => !p.IsDiagParam(ctx));

            data = data.AddPostInvoke(writer => writer.AppendLine("__result.ThrowIfFailed();"))
                .WithSignature(
                    data.Signature.WithReturnSig(
                        new(
                            lastOutParam is null
                                ? ctx.VoidType
                                : lastOutParam.Type.WithNullableAnnotation(
                                    NullableAnnotation.NotAnnotated
                                )
                        )
                    )
                );

            if (lastOutParam is null)
                return data;

            var varName = $"__out{lastOutParam.Name}";

            data = data.WithSignature(data.Signature.RemoveParametersSig(lastOutParam))
                .WithReturnVarName(varName)
                .AddPreInvoke(writer =>
                    writer.WriteVariableDeclaration(lastOutParam.Type, varName).EndLine()
                )
                .AddInvokeBuilderConfig(builder => builder.SetParameter(lastOutParam, varName));

            return data;
        }

        public InterfaceExtensionData TransformMethodDiagBlobToString(CommonTypesContext ctx)
        {
            var diagBlobParam = data
                .Signature.ParametersSig.Where(p => p.RefKind is RefKind.Out)
                .LastOrDefault(p => p.IsDiagParam(ctx));

            if (diagBlobParam is null)
                return data;

            // If a diagnostic blob param is present, convert it to a string
            // We consider a valid diagnostic out parameter to be an IBlob with the "diagnostics" name
            const string varName = "__diagBlob";

            var newType = ctx.StringType.WithNullableAnnotation(NullableAnnotation.Annotated);

            return data.WithSignature(
                    data.Signature.ReplaceParametersSig(
                        diagBlobParam,
                        diagBlobParam.WithType(newType)
                    )
                )
                .AddPreInvoke(writer =>
                    writer.WriteVariableDeclaration(diagBlobParam.Type, varName).EndLine()
                )
                .AddInvokeBuilderConfig(builder => builder.SetParameter(diagBlobParam, varName))
                .AddPostInvoke(writer =>
                    writer.AppendLine($"{diagBlobParam.Name} = {varName}.AsString();")
                );
        }

        public InterfaceExtensionData TransformMethodImplicitSpanCount(IMethodSymbol originalMethod)
        {
            var pairs = originalMethod.GetMarshalUsingSpanCountPairs().ToArray();

            if (pairs.Length == 0)
                return data;

            var modifiedData = data;

            foreach (
                var (spanParam, countParam) in pairs.Select(tuple =>
                    (
                        spanParam: ParameterSignature.FromSymbol(tuple.Item1),
                        countParam: ParameterSignature.FromSymbol(tuple.Item2)
                    )
                )
            )
            {
                if (countParam.RefKind is not RefKind.None)
                    continue;

                modifiedData = modifiedData
                    .WithSignature(modifiedData.Signature.RemoveParametersSig(countParam))
                    .AddInvokeBuilderConfig(builder =>
                        builder.SetParameter(
                            countParam,
                            $"({countParam.Type.ToFullyQualified()}){spanParam.Name}.Length"
                        )
                    );
            }

            return modifiedData;
        }

        public InterfaceExtensionData WithMethodName(string newName) =>
            data.WithSignature(data.Signature.WithName(newName));

        public bool IsSignatureEquivalent(InterfaceExtensionData other) =>
            data.Signature.ParametersSig == other.Signature.ParametersSig
            && data.Signature.ReturnSig == other.Signature.ReturnSig;
    }
}
