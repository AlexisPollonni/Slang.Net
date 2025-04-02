using Microsoft.CodeAnalysis;
using SlangNet.Pretty.SourceGenerator.Tooling;

namespace SlangNet.Pretty.SourceGenerator.MarshallingGenerator.Mappings;

class MarshalsAsNativeMapping(CSharpSourceBuilder builder, IParameterSymbol managed, IParameterSymbol native) : MarshalManagedNativeMappingBase(builder, managed, native)
{
    public override void WriteByteCountAllocVar(string countVarName)
    {
        Builder.AppendLine($"{countVarName} += {Managed.Name}.GetNativeAllocSize();");
    }
    public override void WriteBeforeMarshal(string bufferVarName)
    {
        if (IsOutParameter) Builder.AddDefaultVar(Managed.Type, NativeVarName);
        else
            Builder.AppendLine($"{Managed.Name}.AsNative(ref {bufferVarName}, out var {NativeVarName});");
    }
    
    public override void WriteAfterMarshal()
    {
        if (IsOutParameter)
            Builder.AppendLine($"{Managed.Type.ToFullyQualified()}.CreateFromNative(*{NativeVarName}, out {Managed.Name});");
    }
}