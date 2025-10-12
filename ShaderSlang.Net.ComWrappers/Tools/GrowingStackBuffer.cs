using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using ShaderSlang.Net.ComWrappers.Interfaces;

namespace ShaderSlang.Net.ComWrappers.Tools;

internal unsafe ref struct GrowingStackBuffer(Span<byte> buffer) : IDisposable
{
    private Span<byte> _bufferData = buffer;
    private int _allocatedSize = 0;
    private bool _grewFromHeap;

    public GrowingStackBuffer(int capacity) : this(new Span<byte>(NativeMemory.Alloc((nuint)capacity), capacity))
    {
        _grewFromHeap = true;
    }
    
    public readonly Span<byte> FreeMemory => _bufferData[_allocatedSize..];

    /// <summary>
    /// If the buffer was grown from the heap, free it.
    /// </summary>
    public void Free()
    {
        if (!_grewFromHeap) return;
        
        NativeMemory.Free(PtrFromSpan(_bufferData));
        _bufferData = default;
        _allocatedSize = 0;
        _grewFromHeap = false;
    }

    public sbyte* GetStringPtr(string? str)
    {
        if (str == null)
            return null;
        
        var byteSize = Encoding.UTF8.GetByteCount(str) + 1;
        
        var span = Allocate(byteSize);

        Encoding.UTF8.GetBytes(str, span);
        span[^1] = 0;

        return (sbyte*)PtrFromSpan(span);
    }

    public T* GetStructPtr<T>(in T value) where T : unmanaged
    {
        var span = Allocate(sizeof(T));
        if(!MemoryMarshal.TryWrite(span, in value)) throw new InvalidOperationException("Failed to write struct to buffer");
        return (T*)PtrFromSpan(span);
    }

    public delegate TUnmanaged UnmanagedConverter<TManaged, out TUnmanaged>(in TManaged managed, ref GrowingStackBuffer buffer);

    public TUnmanaged* GetCollectionPtr<TManaged, TUnmanaged>(IEnumerable<TManaged>? collection, UnmanagedConverter<TManaged, TUnmanaged> converter, out uint count)
        where TUnmanaged : unmanaged
    {
        count = 0;
        if(collection == null) return null;

        var start = _allocatedSize;
        foreach (var item in collection)
        {
            var span = Allocate(sizeof(TUnmanaged));
            if(!MemoryMarshal.TryWrite(span, converter(item, ref this))) throw new InvalidOperationException("Failed to write struct to buffer");
            count++;
        }

        // If the collection is empty, return null
        if(start == _allocatedSize)
            return null;

        return (TUnmanaged*)Unsafe.AsPointer(ref _bufferData[start]);
    }
    public TUnmanaged* GetCollectionPtr<TManaged, TUnmanaged>(IEnumerable<TManaged>? collection, out uint count)
        where TManaged : IMarshalsToNative<TUnmanaged>
        where TUnmanaged : unmanaged
    {
        count = 0;
        if(collection == null) return null;

        var start = _allocatedSize;
        foreach (var item in collection)
        {
            var span = Allocate(sizeof(TUnmanaged));
            var unmanaged = item.AsNative(ref this);
            if(!MemoryMarshal.TryWrite(span, unmanaged)) throw new InvalidOperationException("Failed to write struct to buffer");
            count++;
        }

        // If the collection is empty, return null
        if(start == _allocatedSize)
            return null;

        return (TUnmanaged*)Unsafe.AsPointer(ref _bufferData[start]);
    }

    public sbyte** GetCollectionPtr(IEnumerable<string>? collection, out uint count)
    {
        return (sbyte**)GetCollectionPtr(collection, StringConverter, out count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static nint StringConverter(in string s, ref GrowingStackBuffer buffer)
        {
            return (nint)buffer.GetStringPtr(s);
        }
    }

    public TUnmanaged* GetCollectionPtr<TUnmanaged>(IEnumerable<TUnmanaged>? collection, out uint count) 
        where TUnmanaged : unmanaged
    {
        return GetCollectionPtr(collection, UnmanagedToUnmanagedConverter, out count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static TUnmanaged UnmanagedToUnmanagedConverter(in TUnmanaged managed, ref GrowingStackBuffer growingStackBuffer) =>
            managed;
    }
    
    public TUnmanaged** GetComCollectionPtr<TManagedInterface, TUnmanaged>(
        IEnumerable<TManagedInterface>? comObject, out uint count)
        where TManagedInterface : IUnknown 
        where TUnmanaged : unmanaged
    {
        return (TUnmanaged**)GetCollectionPtr(comObject, UnknownConverter, out count);

        static nint UnknownConverter(in TManagedInterface com, ref GrowingStackBuffer buffer)
        {
            return (nint)com.InterfaceToPtr<TManagedInterface, TUnmanaged>();
        }
    }

    public void Dispose() => Free();



    private Span<byte> Allocate(int size)
    {
        if (_allocatedSize + size > _bufferData.Length)
        {
            //We either double the size or just enough for the new alloc. Depending which is bigger. 
            Grow(_allocatedSize + Math.Max(_allocatedSize, size));
        }

        _allocatedSize += size;
        return _bufferData.Slice(_allocatedSize - size, size);
    }

    private void Grow(int newCapacity)
    {
        var newBuffer = new Span<byte>(NativeMemory.Alloc((nuint)newCapacity), newCapacity);

        _bufferData.CopyTo(newBuffer);

        if (_grewFromHeap)
        {
            NativeMemory.Free(PtrFromSpan(_bufferData));
        }

        _bufferData = newBuffer;
        _grewFromHeap = true;
    }

    private static void* PtrFromSpan(Span<byte> span)
    {
        return Unsafe.AsPointer(ref MemoryMarshal.GetReference(span));
    }
}
