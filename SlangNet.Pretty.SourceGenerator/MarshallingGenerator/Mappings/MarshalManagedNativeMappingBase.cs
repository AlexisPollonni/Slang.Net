using Microsoft.CodeAnalysis;
using SlangNet.Pretty.SourceGenerator.Tooling;

namespace SlangNet.Pretty.SourceGenerator.MarshallingGenerator.Mappings;

abstract class MarshalManagedNativeMappingBase(CSharpSourceBuilder builder, IParameterSymbol managed, IParameterSymbol native)
{
    public CSharpSourceBuilder Builder { get; } = builder;
    public IParameterSymbol Managed { get; } = managed;
    public IParameterSymbol Native { get; } = native;

    public string ManagedVarName => $"managed_{Managed.RefKind}_{Managed.Name}";
    public string NativeVarName => $"native_{Managed.RefKind}_{Managed.Name}";
    
    public bool IsOutParameter => Managed.RefKind is RefKind.Out or RefKind.Ref;
    
    public abstract void WriteByteCountAllocVar(string countVarName);
    public abstract void WriteBeforeMarshal(string bufferVarName);

    public virtual void WriteNativeParameterPassing()
    {
        Builder.Append($"&{NativeVarName}");
    }
    public abstract void WriteAfterMarshal();
}