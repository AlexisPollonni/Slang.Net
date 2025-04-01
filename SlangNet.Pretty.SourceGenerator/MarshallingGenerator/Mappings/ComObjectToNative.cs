using Microsoft.CodeAnalysis;
using SlangNet.Pretty.SourceGenerator.Tooling;

namespace SlangNet.Pretty.SourceGenerator.MarshallingGenerator.Mappings;

class ComObjectToNative(CSharpSourceBuilder builder, IParameterSymbol managed, IParameterSymbol native) : MarshalManagedNativeMappingBase(builder, managed, native)
{
    public override void WriteByteCountAllocVar(string countVarName)
    {
        Builder.AppendLine($"// Byte count calculations for ComObjects are a no-op");
    }
    public override void WriteBeforeMarshal(string _)
    {
        var natType = IsOutParameter ? ((IPointerTypeSymbol)Native.Type).PointedAtType.ToFullyQualified() : Native.Type.ToFullyQualified();
        Builder.AppendLine(!IsOutParameter
                               ? $"var {NativeVarName} = ({natType})({Managed.Name} is not null ? {Managed.Name}.Pointer : null);"
                               : $"{natType} {NativeVarName};");
    }

    public override void WriteNativeParameterPassing()
    {
        Builder.Append(IsOutParameter ? $"&{NativeVarName}" : NativeVarName);
    }

    public override void WriteAfterMarshal()
    {
        if (IsOutParameter)
        {
            Builder.AppendLine($"{Managed.Name} = {NativeVarName} is not null ?  new({NativeVarName}) : null;");
        }
    }
}