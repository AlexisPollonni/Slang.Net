using System;
using System.Drawing;
using SlangNet.Internal;

namespace SlangNet.Gfx;

public abstract class ResourceCommandEncoder : CommandEncoder
{
    private unsafe IResourceCommandEncoder* ImplPtr => (IResourceCommandEncoder*)Pointer;
    internal unsafe ResourceCommandEncoder(IResourceCommandEncoder* pointer) : base((ICommandEncoder*)pointer)
    { }

    public unsafe void CopyBuffer(BufferResource dst, ulong dstOffset, BufferResource src, ulong srcOffset, ulong size)
    {
        ImplPtr->copyBuffer(dst.Pointer, (nuint)dstOffset, src.Pointer, (nuint)srcOffset, (nuint)size);
    }


    //TODO: CopyTexture

    //TODO: CopyTextureToBuffer

    //TODO: UploadTextureData

    //TODO: Generic
    public unsafe void UploadBufferData(BufferResource dst, ulong dstOffset, ReadOnlySpan<byte> data)
    {
        fixed (void* pData = data)
            ImplPtr->uploadBufferData(dst.Pointer, (nuint)dstOffset, (nuint)data.Length, pData);
    }

    //TODO: TextureBarrier

    //TODO: TextureSubresourceBarrier

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

    //TODO: ResolveResource

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
