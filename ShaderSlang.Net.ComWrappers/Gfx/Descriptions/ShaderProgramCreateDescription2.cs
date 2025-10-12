using System.Buffers;
using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Tools;
using ShaderSlang.Net.ComWrappers.Tools.Internal;

namespace ShaderSlang.Net.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(typeof(MarshalableMarshaller.Bidirectional<ShaderProgramCreateDescription2, Unmanaged.IShaderProgram.CreateDesc2>))]
public record struct ShaderProgramCreateDescription2(Unmanaged.ShaderModuleSourceType SourceType,
                                                     Memory<byte> SourceData,
                                                     IReadOnlyCollection<string> EntryPointNames)
    : IMarshalsToNative<Unmanaged.IShaderProgram.CreateDesc2>,
      IMarshalsFromNative<ShaderProgramCreateDescription2, Unmanaged.IShaderProgram.CreateDesc2>,
      IFreeAfterMarshal<Unmanaged.IShaderProgram.CreateDesc2>
{
    private MemoryHandle? _marshalHandle;
    
    public Unmanaged.ShaderModuleSourceType SourceType { get; init; } = SourceType;
    public Memory<byte> SourceData { get; init; } = SourceData;
    public IReadOnlyCollection<string> EntryPointNames { get; init; } = EntryPointNames;

    unsafe Unmanaged.IShaderProgram.CreateDesc2 IMarshalsToNative<Unmanaged.IShaderProgram.CreateDesc2>.AsNative(ref GrowingStackBuffer buffer)
    {
        _marshalHandle ??= SourceData.Pin();
        
        return new()
        {
            sourceType = SourceType,
            entryPointNames = buffer.GetCollectionPtr(EntryPointNames, out var entryPointNamesCount),
            entryPointCount = (int)entryPointNamesCount,
        };
    }

    public static unsafe ShaderProgramCreateDescription2 CreateFromNative(Unmanaged.IShaderProgram.CreateDesc2 unmanaged)
    {
        var dataOwner = new NativeOwnedMemoryManager((byte*)unmanaged.sourceData, (int)unmanaged.sourceDataSize);
        return new(unmanaged.sourceType, dataOwner.Memory, InteropUtils.PtrToStringArray(unmanaged.entryPointNames, unmanaged.entryPointCount)!);
    }

    public unsafe void Free(Unmanaged.IShaderProgram.CreateDesc2* unmanaged)
    {
        _marshalHandle?.Dispose();
    }
}