using System.Linq;
using Microsoft.CodeAnalysis;

namespace SlangNet.Pretty.SourceGenerator.Tooling.Extensions;

static class MethodTransformExtensions
{
    public static InterfaceExtensionData TransformMethodNoThrow(this InterfaceExtensionData data, CommonTypesContext ctx)
    {
        if (!SymbolEqualityComparer.Default.Equals(data.Signature.ReturnSig.Type, ctx.SlangResultType)) return data;

        var lastOutParam = data.Signature.ParametersSig.Where(p => p.RefKind is RefKind.Out)
                               .LastOrDefault(p => !IsDiagParam(p));


        data = data.AddPostInvoke(writer => writer.AppendLine("__result.ThrowIfFailed();"))
                   .WithSignature(data.Signature.WithReturnSig(
                                      new(lastOutParam is null
                                              ? ctx.VoidType
                                              : lastOutParam.Type.WithNullableAnnotation(NullableAnnotation.NotAnnotated))));

        if (lastOutParam is null) return data;

        var varName = $"__out{lastOutParam.Name}";

        data = data.WithSignature(data.Signature.RemoveParametersSig(lastOutParam))
                   .WithReturnVarName(varName)
                   .AddPreInvoke(writer => writer.WriteVariableDeclaration(lastOutParam.Type, varName).EndLine())
                   .AddInvokeBuilderConfig(builder => builder.SetParameter(lastOutParam, varName));

        return data;
    }

    public static InterfaceExtensionData TransformMethodDiagBlobToString(this InterfaceExtensionData data,
                                                                         CommonTypesContext ctx)
    {
        var diagBlobParam = data.Signature.ParametersSig.Where(p => p.RefKind is RefKind.Out).LastOrDefault(IsDiagParam);

        if (diagBlobParam is null) return data;

        // If a diagnostic blob param is present, convert it to a string
        // We consider a valid diagnostic out parameter to be an IBlob with the "diagnostics" name 
        const string varName = "__diagBlob";

        var newType = ctx.StringType.WithNullableAnnotation(NullableAnnotation.Annotated);

        return data
               .WithSignature(data.Signature.WithParametersSig(
                                  data.Signature.ParametersSig.Replace(diagBlobParam, diagBlobParam.WithType(newType))))
               .AddPreInvoke(writer => writer.WriteVariableDeclaration(diagBlobParam.Type, varName).EndLine())
               .AddInvokeBuilderConfig(builder => builder.SetParameter(diagBlobParam, varName))
               .AddPostInvoke(writer => writer.AppendLine($"{diagBlobParam.Name} = {varName}.AsString();"));
    }

    public static InterfaceExtensionData TransformMethodImplicitSpanCount(this InterfaceExtensionData data,
                                                                          IMethodSymbol originalMethod)
    {
        var pairs = originalMethod.GetMarshalUsingSpanCountPairs().ToArray();

        if (pairs.Length == 0) return data;

        var modifiedData = data;

        foreach (var (spanParam, countParam) in pairs.Select(tuple => (spanParam: ParameterSignature.FromSymbol(tuple.Item1),
                                                                       countParam: ParameterSignature
                                                                           .FromSymbol(tuple.Item2))))
        {
            if(countParam.RefKind is not RefKind.None) continue;
            
            modifiedData = modifiedData.WithSignature(modifiedData.Signature.RemoveParametersSig(countParam))
                                       .AddInvokeBuilderConfig(builder => builder.SetParameter(countParam,
                                                                                               $"({countParam.Type.ToFullyQualified()}){spanParam.Name}.Length"));
        }

        return modifiedData;
    }

    public static bool IsSignatureEquivalent(this InterfaceExtensionData data, InterfaceExtensionData other) =>
        data.Signature.ParametersSig == other.Signature.ParametersSig &&
        data.Signature.ReturnSig == other.Signature.ReturnSig;

    private static bool IsDiagParam(ParameterSignature parameter) =>
        parameter.Type.Name == "IBlob" && parameter.Name == "diagnostics";
}