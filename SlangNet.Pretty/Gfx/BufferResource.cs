using System;

namespace SlangNet.Gfx;

[GenerateThrowingMethods]
public partial class BufferResource : Resource
{
    public new unsafe IBufferResource* Pointer => (IBufferResource*)base.Pointer;

    internal unsafe BufferResource(IBufferResource* pointer) : base((IResource*)pointer) { }

    public unsafe BufferResourceDesc GetDesc()
    {
        var descPtr = Pointer->getDesc();
        BufferResourceDesc.CreateFromNative(*descPtr, out var desc);
        return desc;
    }

    public unsafe ulong GetDeviceAddress()
    {
        return Pointer->getDeviceAddress();
    }

    public unsafe SlangResult TryMap(MemoryRange? rangeToRead, out Span<byte> span)
    {
        var range = rangeToRead;
        void* nativePointer = null;
        int size;

        var result = Pointer->map(range.AsNullablePtr(), &nativePointer).ToSlangResult();

        if (!result)
        {
            span = [];
            return result;
        }

        if (range is null)
        {
            size = checked((int)GetDesc().SizeInBytes);
        }
        else
        {
            size = checked((int)range.Value.size);
            var offset = checked((int)range.Value.offset);

            //Range is not implemented for vulkan, always returns the full data so we handle it separately
            //TODO: Replace this when slang supports it
            if (TryGetNativeResourceHandle(out var natHandle))
            {
                if (natHandle.api is InteropHandleAPI.Vulkan)
                {
                    var fullSize = checked((int)GetDesc().SizeInBytes);
                    span = new Span<byte>(nativePointer, fullSize).Slice(offset, size);
                    return result;
                }
            }
        }

        span = new(nativePointer, size);

        return result;
    }

    public Span<byte> Map(ulong offset = 0, ulong size = 0)
    {
        Span<byte> span;
        if (size is 0 && offset is 0)
        {
            TryMap(null, out span).ThrowIfFailed();
            return span;
        }

        if (size is 0)
        {
            size = GetDesc().SizeInBytes;
        }

        TryMap(new()
               {
                   offset = offset,
                   size = size
               },
               out span)
            .ThrowIfFailed();

        return span;
    }

    public unsafe SlangResult TryUnmap(in MemoryRange? writtenRange = null)
    {
        if (writtenRange.HasValue)
        {
            var nativeRange = writtenRange.Value;
            return Pointer->unmap(&nativeRange).ToSlangResult();
        }
        else
        {
            return Pointer->unmap(null).ToSlangResult();
        }
    }
}