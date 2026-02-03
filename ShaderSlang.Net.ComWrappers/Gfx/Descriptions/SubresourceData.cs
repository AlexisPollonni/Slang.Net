using System.Buffers;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Tools;
using ShaderSlang.Net.ComWrappers.Tools.Internal;

namespace ShaderSlang.Net.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(
    typeof(BidirectionalMarshaller<
        SubresourceData,
        Unmanaged.ITextureResource.SubresourceData
    >)
)]
public record struct SubresourceData(Memory<byte> Data, nuint StrideY, nuint StrideZ)
    : IMarshalsToNative<Unmanaged.ITextureResource.SubresourceData>,
        IMarshalsFromNative<SubresourceData, Unmanaged.ITextureResource.SubresourceData>,
        IFreeAfterMarshal<Unmanaged.ITextureResource.SubresourceData>
{
    public Memory<byte> Data { get; init; } = Data;
    public nuint StrideY { get; init; } = StrideY;
    public nuint StrideZ { get; init; } = StrideZ;

    unsafe Unmanaged.ITextureResource.SubresourceData IMarshalsToNative<Unmanaged.ITextureResource.SubresourceData>.AsNative(
        ref GrowingStackBuffer buffer
    )
    {
        return new()
        {
            data = Data.AllocAndCopyToNativeMemory(),
            strideY = StrideY,
            strideZ = StrideZ,
        };
    }

    public static unsafe SubresourceData CreateFromNative(
        Unmanaged.ITextureResource.SubresourceData unmanaged
    )
    {
        var ownedMemory = new NativeOwnedMemoryManager(
            (byte*)unmanaged.data,
            (int)(unmanaged.strideY * unmanaged.strideZ)
        );
        return new(ownedMemory.Memory, unmanaged.strideY, unmanaged.strideZ);
    }

    public static unsafe void Free(ref readonly Unmanaged.ITextureResource.SubresourceData unmanaged)
    {
        NativeMemory.Free(unmanaged.data);
    }
}
