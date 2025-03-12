using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Nito.Disposables.Internals;

namespace SlangNet;

/// <summary>
/// A string that is either stored in native memory or managed memory. To use when marshaling to native code.
/// </summary>
internal unsafe struct Utf8String : IDisposable
{
    public static implicit operator sbyte*(Utf8String self) => self.Memory;

    public sbyte* Memory { get; private set; }
    public sbyte* MemoryEnd { get; private set; }

    private static readonly int NullTerminatorSize = Encoding.UTF8.GetByteCount("\0");
    public readonly int ByteSize => (int)(MemoryEnd - Memory);
    
    private readonly bool _isNativeAllocated;
    private readonly string? _managedString;

    public Utf8String(string? text)
    {
        if (text is null)
        {
            Memory = null;
            MemoryEnd = null;
            _isNativeAllocated = false;
            _managedString = null;
            return;
        }

        _isNativeAllocated = true;
        _managedString = text;

        var byteSize = Encoding.UTF8.GetByteCount(text) + NullTerminatorSize;

        Memory = (sbyte*)NativeMemory.Alloc((nuint)byteSize);
        MemoryEnd = Memory + byteSize;

        Encoding.UTF8.GetBytes(text, new Span<byte>(Memory, byteSize - NullTerminatorSize));

        Memory[byteSize - 1] = (sbyte)'\0';
    }

    /// <summary>
    /// Creates a new Utf8String from a native pointer and a byte size.
    /// </summary>
    /// <param name="memory">The native pointer to the string.</param>
    /// <param name="byteSize">The size of the string in bytes including the null terminator.</param>
    public Utf8String(sbyte* memory, int byteSize)
    {
        Memory = memory;
        MemoryEnd = Memory + byteSize;
        _managedString = Encoding.UTF8.GetString((byte*)Memory, byteSize);
        _isNativeAllocated = false;
    }

    public Utf8String(sbyte* memory) : this(memory, GetUtf8StringLength(memory))
    {}

    public readonly override string? ToString() => _managedString;

    public void Dispose()
    {
        if (Memory != null)
        {
            if (_isNativeAllocated)
                NativeMemory.Free(Memory);

            Memory = MemoryEnd = null;
        }
    }

    private static unsafe int GetUtf8StringLength(sbyte* ptr)
    {
        if (ptr is null)
            return 0;
            
        // Find the null terminator using optimized native memory search
        nuint offset = 0;
        while (System.Runtime.CompilerServices.Unsafe.Read<sbyte>(ptr + offset) != 0 && offset < int.MaxValue)
        {
            offset++;
        }

        if (offset >= int.MaxValue)
            throw new InvalidOperationException("String is too long to be represented in managed code.");
        
        return (int)offset;
    }
}


internal unsafe struct Utf8StringArray : IDisposable
{
    public sbyte** Memory { get; private set; }
    public readonly int Count => _managedStrings.Length;


    private readonly bool _isNativeAllocated;
    private readonly string[] _managedStrings;
    private readonly Utf8String[]? _allocatedStrings;

    public Utf8StringArray(IEnumerable<string> managedStrings)
    {
        ArgumentNullException.ThrowIfNull(managedStrings);

        _managedStrings = [.. managedStrings];

        _allocatedStrings = [.. _managedStrings.Select(str => new Utf8String(str))];

        Memory = (sbyte**) NativeMemory.Alloc((nuint)(sizeof(sbyte*) * Count));
        _isNativeAllocated = true;

        for (int i = 0; i < Count; i++)
        {
            Memory[i] = _allocatedStrings[i].Memory;
        }
    }

    public Utf8StringArray(sbyte** nativeMemory, int count)
    {
        ArgumentNullException.ThrowIfNull(nativeMemory);

        Memory = nativeMemory;
        _isNativeAllocated = false;

        _managedStrings = new string[count];
        for (int i = 0; i < count; i++)
        {
            _managedStrings[i] = new Utf8String(nativeMemory[i]).ToString()!;
        }
    }

    public readonly string[] ToStringArray() => _managedStrings;

    public void Dispose()
    {
        if (Memory is not null)
        {
            if (_isNativeAllocated)
                NativeMemory.Free(Memory);

            Memory = null;
        }

        if (_allocatedStrings is not null)
        {
            foreach (var str in _allocatedStrings)
                str.Dispose();
        }
    }
}
