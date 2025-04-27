using System.Buffers;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Tools;
using SlangNet.ComWrappers.Tools.Internal;

namespace SlangNet.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(typeof(MarshalableMarshaller.Bidirectional<SubresourceData, Unmanaged.ITextureResource.SubresourceData>))]
public record struct SubresourceData(Memory<byte> Data, nuint StrideY, nuint StrideZ)
    : IMarshalsToNative<Unmanaged.ITextureResource.SubresourceData>,
      IMarshalsFromNative<SubresourceData, Unmanaged.ITextureResource.SubresourceData>,
      IFreeAfterMarshal<Unmanaged.ITextureResource.SubresourceData>
{
    private MemoryHandle? _memoryHandle;
    
    public Memory<byte> Data { get; init; } = Data;
    public nuint StrideY { get; init; } = StrideY;
    public nuint StrideZ { get; init; } = StrideZ;

    unsafe Unmanaged.ITextureResource.SubresourceData IMarshalsToNative<Unmanaged.ITextureResource.SubresourceData>.AsNative(
        ref GrowingStackBuffer buffer)
    {
        _memoryHandle ??= Data.Pin();

        return new()
        {
            data = _memoryHandle.Value.Pointer,
            strideY = StrideY,
            strideZ = StrideZ
        };
    }

    public static unsafe SubresourceData CreateFromNative(Unmanaged.ITextureResource.SubresourceData unmanaged)
    {
        var ownedMemory = new NativeOwnedMemoryManager((byte*)unmanaged.data, (int)(unmanaged.strideY * unmanaged.strideZ));
        return new(ownedMemory.Memory, unmanaged.strideY, unmanaged.strideZ);
    }

    public unsafe void Free(Unmanaged.ITextureResource.SubresourceData* unmanaged)
    {
        _memoryHandle?.Dispose();
    }
}