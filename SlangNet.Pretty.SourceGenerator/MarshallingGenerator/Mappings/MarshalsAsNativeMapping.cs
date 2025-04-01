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
        if (!IsOutParameter)
        {
            Builder.AppendLine($"// Marshalling of parameter {Managed.Name} from {Managed.Type} to {Native.Type}");
            Builder.AppendLine($"{Managed.Name}.AsNative(ref {bufferVarName}, out var {NativeVarName});");
        }
        else
        {
            Builder.AppendLine($"{Native.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)} {NativeVarName};");
        }

    }
    
    public override void WriteAfterMarshal()
    {
        if (IsOutParameter)
            Builder.AppendLine($"{Managed.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat)}.CreateFromNative(*{NativeVarName}, out {Managed.Name});");
    }
}