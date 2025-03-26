using System;
using System.Drawing;
using Nito.Disposables;
using SlangNet.Internal;

namespace SlangNet.Gfx;

public abstract class ResourceCommandEncoder : CommandEncoder
{
    private unsafe IResourceCommandEncoder* ImplPtr => (IResourceCommandEncoder*)Pointer;
    internal unsafe ResourceCommandEncoder(IResourceCommandEncoder* pointer) : base((ICommandEncoder*)pointer) { }

    public unsafe void CopyBuffer(BufferResource dst, ulong dstOffset, BufferResource src, ulong srcOffset, ulong size)
    {
        ImplPtr->copyBuffer(dst.Pointer, (nuint)dstOffset, src.Pointer, (nuint)srcOffset, (nuint)size);
    }

    public unsafe void CopyTexture(TextureResource dst,
                                   ResourceState dstState,
                                   SubresourceRange dstSubresource,
                                   ITextureResource.Offset3D dstOffset,
                                   TextureResource src,
                                   ResourceState srcState,
                                   SubresourceRange srcSubresource,
                                   ITextureResource.Offset3D srcOffset,
                                   ITextureResource.Extents extent)
    {
        ImplPtr->copyTexture(dst.Pointer,
                             dstState,
                             dstSubresource,
                             dstOffset,
                             src.Pointer,
                             srcState,
                             srcSubresource,
                             srcOffset,
                             extent);
    }

    public unsafe void CopyTextureToBuffer(BufferResource dst,
                                           nuint dstOffset,
                                           nuint dstSize,
                                           nuint dstRowStride,
                                           TextureResource src,
                                           ResourceState srcState,
                                           SubresourceRange srcSubresource,
                                           ITextureResource.Offset3D srcOffset,
                                           ITextureResource.Extents extent)
    {
        ImplPtr->copyTextureToBuffer(dst.Pointer,
                                     dstOffset,
                                     dstSize,
                                     dstRowStride,
                                     src.Pointer,
                                     srcState,
                                     srcSubresource,
                                     srcOffset,
                                     extent);
    }
    
    
    public unsafe void UploadTextureData(TextureResource dst,
                                         SubresourceRange subresourceRange,
                                         ITextureResource.Offset3D offset,
                                         ITextureResource.Extents extent,
                                         ReadOnlySpan<TextureResource.SubresourceData> subresources)
    {
        var sbRrcPtr = stackalloc ITextureResource.SubresourceData[subresources.Length];
        using var d = new CollectionDisposable();
        
        for (var i = 0; i < subresources.Length; i++)
        {
            sbRrcPtr[i] = new()
            {
                data = subresources[i].Data.Pin().DisposeWith(d).Pointer,
                strideY = subresources[i].StrideY,
                strideZ = subresources[i].StrideZ
            };
        }
        
        ImplPtr->uploadTextureData(dst.Pointer, subresourceRange, offset, extent, sbRrcPtr, subresources.Length);
    }

    //TODO: Generic
    public unsafe void UploadBufferData(BufferResource dst, ulong dstOffset, ReadOnlySpan<byte> data)
    {
        fixed (void* pData = data) ImplPtr->uploadBufferData(dst.Pointer, (nuint)dstOffset, (nuint)data.Length, pData);
    }
    
    public unsafe void TextureBarrier(ReadOnlySpan<TextureResource> textures, ResourceState src, ResourceState dst)
    {
        var txtPtrs = stackalloc ITextureResource*[textures.Length];
        for (var i = 0; i < textures.Length; i++)
            txtPtrs[i] = textures[i].Pointer;
            
        ImplPtr->textureBarrier(textures.Length, txtPtrs, src, dst);
    }
    
    public unsafe void TextureSubresourceBarrier(TextureResource texture,
                                                 SubresourceRange subresourceRange,
                                                 ResourceState src,
                                                 ResourceState dst)
    {
        ImplPtr->textureSubresourceBarrier(texture.Pointer, subresourceRange, src, dst);
    }

    public unsafe void BufferBarrier(ReadOnlySpan<BufferResource> buffers, ResourceState src, ResourceState dst)
    {
        var ptr = stackalloc IBufferResource*[buffers.Length];
        for (int i = 0; i < buffers.Length; i++)
        {
            ptr[i] = buffers[i].Pointer;
        }

        ImplPtr->bufferBarrier(buffers.Length, ptr, src, dst);
    }

    public unsafe void ClearResourceView(ResourceView view, ClearValue value, ClearResourceViewFlags.Enum flags)
    {
        value.MarshalToNative<ClearValue, Unsafe.ClearValue>(clearPtr =>
        {
            ImplPtr->clearResourceView(view.Pointer, clearPtr, flags);
        });
    }
    
    public unsafe void ResolveResource(TextureResource src,
                                       ResourceState srcState,
                                       SubresourceRange srcRange,
                                       TextureResource dst,
                                       ResourceState dstState,
                                       SubresourceRange dstRange)
    {
        ImplPtr->resolveResource(src.Pointer, srcState, srcRange, dst.Pointer, dstState, dstRange);
    }

    public unsafe void ResolveQuery(QueryPool pool, int index, int count, BufferResource buffer, nuint bufferOffset)
    {
        ImplPtr->resolveQuery(pool.Pointer, index, count, buffer.Pointer, bufferOffset);
    }

    public unsafe void BeginDebugEvent(string name, Color color)
    {
        name.MarshalToNative<byte>(namePtr =>
        {
            var colorPtr = stackalloc float[3];
            colorPtr[0] = color.R / 255f;
            colorPtr[1] = color.G / 255f;
            colorPtr[2] = color.B / 255f;

            ImplPtr->beginDebugEvent(namePtr, colorPtr);
            return 0;
        });
    }

    public unsafe void EndDebugEvent()
    {
        ImplPtr->endDebugEvent();
    }
}