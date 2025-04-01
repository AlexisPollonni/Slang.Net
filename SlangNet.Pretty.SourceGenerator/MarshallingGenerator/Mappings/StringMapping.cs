using Microsoft.CodeAnalysis;
using SlangNet.Pretty.SourceGenerator.Tooling;

namespace SlangNet.Pretty.SourceGenerator.MarshallingGenerator.Mappings;

class StringMapping(CSharpSourceBuilder builder, IParameterSymbol managed, IParameterSymbol native) : MarshalManagedNativeMappingBase(builder, managed, native) {
    public override void WriteByteCountAllocVar(string countVarName)
    {
        Builder.AppendLine(
            $"{countVarName} += global::System.Text.Encoding.UTF8.GetByteCount({Managed.Name}) + global::System.Text.Encoding.UTF8.GetByteCount(\"\\0\");");
    }
    public override void WriteBeforeMarshal(string bufferVarName)
    {
        Builder.AppendLine($"sbyte* {NativeVarName} = null;");
        if (!IsOutParameter)
        {
            using (Builder.BeginScope($"if ({Managed.Name} is not null)"))
            {
                var spanVarName = $"_span_utf8_{Managed.Name}";
                Builder.AppendLine($"var {spanVarName} = {bufferVarName}.ConvertString({Managed.Name});");
                Builder.AppendLine(
                    $"{NativeVarName} = (sbyte*)global::System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::System.Runtime.InteropServices.MemoryMarshal.GetReference({spanVarName}));");
            }
        }
    }

    public override void WriteNativeParameterPassing()
    {
        Builder.Append(IsOutParameter ? $"&{NativeVarName}" : NativeVarName);
    }

    public override void WriteAfterMarshal()
    {
        if (IsOutParameter)
        {
            Builder.AppendLine($"{Managed.Name} = global::SlangNet.InteropUtils.PtrToStringUTF8({NativeVarName});");
        }
    }
}