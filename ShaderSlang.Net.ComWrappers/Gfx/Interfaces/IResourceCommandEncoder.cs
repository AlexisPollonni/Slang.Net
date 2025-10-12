using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Gfx.Descriptions;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Gfx.Interfaces;

[GeneratedComInterface(
    StringMarshalling = StringMarshalling.Custom,
    StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller)
)]
[Guid("F99A00E9-ED50-4088-8A0E-3B26755031EA")]
public partial interface IResourceCommandEncoder : ICommandEncoder
{
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void CopyBuffer(
        IBufferResource dst,
        nuint dstOffset,
        IBufferResource src,
        nuint srcOffset,
        nuint size
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void CopyTexture(
        ITextureResource dst,
        Unmanaged.ResourceState dstState,
        Unmanaged.SubresourceRange dstSubresource,
        Unmanaged.ITextureResource.Offset3D dstOffset,
        ITextureResource src,
        Unmanaged.ResourceState srcState,
        Unmanaged.SubresourceRange srcSubresource,
        Unmanaged.ITextureResource.Offset3D srcOffset,
        Unmanaged.ITextureResource.Extents extent
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void CopyTextureToBuffer(
        IBufferResource dst,
        Unmanaged.ITextureResource.Offset3D dstOffset,
        nuint dstSize,
        nuint dstRowStride,
        ITextureResource src,
        Unmanaged.ResourceState srcState,
        Unmanaged.SubresourceRange srcSubresource,
        Unmanaged.ITextureResource.Offset3D srcOffset,
        Unmanaged.ITextureResource.Extents extent
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void UploadTextureData(
        ITextureResource dst,
        Unmanaged.SubresourceRange subresourceRange,
        Unmanaged.ITextureResource.Offset3D offset,
        Unmanaged.ITextureResource.Extents extent,
        [MarshalUsing(CountElementName = "subResourceDataCount")] Span<SubresourceData> data,
        int subResourceDataCount
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void UploadBufferData(
        IBufferResource dst,
        nuint offset,
        nuint size,
        [MarshalUsing(CountElementName = "size")] Span<byte> data
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void TextureBarrier(
        int count,
        [MarshalUsing(CountElementName = "count")] Span<ITextureResource> textures,
        Unmanaged.ResourceState src,
        Unmanaged.ResourceState dst
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void TextureSubresourceBarrier(
        ITextureResource texture,
        Unmanaged.SubresourceRange subresourceRange,
        Unmanaged.ResourceState src,
        Unmanaged.ResourceState dst
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void BufferBarrier(
        int count,
        [MarshalUsing(CountElementName = "count")] Span<IBufferResource> buffers,
        Unmanaged.ResourceState src,
        Unmanaged.ResourceState dst
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void ClearResourceView(
        IResourceView view,
        Unmanaged.ClearValue clearValue,
        Unmanaged.ClearResourceViewFlags flags
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void ResolveResource(
        ITextureResource source,
        Unmanaged.ResourceState srcState,
        Unmanaged.SubresourceRange srcRange,
        ITextureResource dst,
        Unmanaged.ResourceState dstState,
        Unmanaged.SubresourceRange dstRange
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void ResolveQuery(
        IQueryPool queryPool,
        int index,
        int count,
        IBufferResource buffer,
        nuint offset
    );

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void BeginDebugEvent(string name, Vector3 rgbColor); //TODO: Maybe change vector for dedicated type or RGB marshaller

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void EndDebugEvent();
}
