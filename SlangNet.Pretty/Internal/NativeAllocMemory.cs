using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using static System.Runtime.CompilerServices.Unsafe;

namespace SlangNet.Internal;


public unsafe class NativeAllocMemory : SafeHandle
{
    private readonly nuint _length;

    public override bool IsInvalid => _length == 0 || handle <= nint.Zero;

    public static NativeAllocMemory CreateFromItems<T>(Span<T> items) where T : unmanaged
    {
        var elementSize = (nuint)SizeOf<T>();
        var ptr = NativeMemory.Alloc((nuint)items.Length, elementSize);
        
        return new(ptr, elementSize * (nuint)items.Length);
    }
    
    public NativeAllocMemory(nuint length, bool zeroed = false) : base(nint.Zero, true)   
    {
        ArgumentOutOfRangeException.ThrowIfZero(length);

        SetHandle(zeroed ? NativeMemory.AllocZeroed(length) : NativeMemory.Alloc(length));
        _length = length;
    }

    private NativeAllocMemory(void* pointer, nuint length) : base(nint.Zero, true)
    {
        ArgumentNullException.ThrowIfNull(pointer);
        ArgumentOutOfRangeException.ThrowIfZero(length);
        
        SetHandle(pointer);
        _length = length;
    }

    private void SetHandle(void* v)
    {
        SetHandle(new IntPtr(v));  
    }

    public Span<T> AsSpan<T>() where T : unmanaged
    {
        ObjectDisposedException.ThrowIf(IsInvalid, this);
        ObjectDisposedException.ThrowIf(IsClosed, this);

        CheckNativeItemSize<T>(_length);
        
        return new((void*)handle, (int)_length / SizeOf<T>());
    }

    public T* AsPtr<T>() where T : unmanaged
    {
        return (T*)AsVoidPtr();
    }

    public void* AsVoidPtr()
    {
        ObjectDisposedException.ThrowIf(IsInvalid, this);
        ObjectDisposedException.ThrowIf(IsClosed, this);
        
        return (void*)handle;
    }

    public void ZeroBytes()
    {
        ObjectDisposedException.ThrowIf(IsClosed, this);

        if (!IsInvalid)
            NativeMemory.Clear((void*)handle, _length);
    }

    private static void CheckNativeItemSize<T>(nuint length) where T : unmanaged
    {
        if (checked((int)length) % SizeOf<T>() != 0) throw new NotSupportedException("Tried to convert native memory to wrong span managed type. Lengths do not match.");
    }

    protected override bool ReleaseHandle()
    {
        NativeMemory.Free((void*)handle);
        return true;
    }
}
