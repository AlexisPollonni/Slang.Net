using System;
using SlangNet.Internal;

namespace SlangNet.Gfx;

[GenerateThrowingMethods]
public partial class BufferResource : COMObject<IBufferResource>
{
    internal unsafe BufferResource(IBufferResource* pointer) : base(pointer)
    { }
    
    public unsafe SlangResult TryGetNativeResourceHandle(out InteropHandle handle)
    {
        fixed (InteropHandle* pHandle = &handle)
        {
            return Pointer->getNativeResourceHandle(pHandle).ToSlangResult();
        }
    }
    
    public unsafe SlangResult TryGetSharedHandle(out InteropHandle handle)
    {
        fixed (InteropHandle* pHandle = &handle)
        {
            return Pointer->getSharedHandle(pHandle).ToSlangResult();
        }
    }
    
    public unsafe SlangResult TrySetDebugName(string name)
    {
        using var nameUtf8 = new Utf8String(name);
        return Pointer->setDebugName(nameUtf8).ToSlangResult();
    }
    
    public unsafe string GetDebugName()
    {
        var namePtr = Pointer->getDebugName();
        return InteropUtils.PtrToStringUTF8(namePtr) ?? string.Empty;
    }
    
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
    
    public unsafe SlangResult TryMap(in MemoryRange? rangeToRead, out IntPtr pointer)
    {
        void* nativePointer = null;
        
        var result = SlangResult.NotImplemented;
        if (rangeToRead.HasValue)
        {
            var nativeRange = rangeToRead.Value;
            result = Pointer->map(&nativeRange, &nativePointer).ToSlangResult();
        }
        else
        {
            result = Pointer->map(null, &nativePointer).ToSlangResult();
        }
        
        pointer = result ? (IntPtr)nativePointer : IntPtr.Zero;
        return result;
    }

    public unsafe SlangResult TryMap(in MemoryRange? rangeToRead, out Span<byte> span)
    {
        var result = TryMap(rangeToRead, out nint pointer);
        span = new Span<byte>((void*)pointer, (int)(rangeToRead?.size ?? GetDesc().SizeInBytes));
        return result;
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