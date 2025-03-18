using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.HighPerformance;

namespace SlangNet.Internal;

public ref struct MarshallingAllocBuffer
{
    private readonly Span<byte> _data;
    private int _allocatedSize;

    // If the data is too long to fit in the buffer, we'll use a backup heap allocated store
    // TODO: Maybe use a single large buffer instead? Or a linked list of buffers of fixed optimum size?
    private List<Array>? _backupStore = null;

    private const int MaxSizeForStackAlloc = 1024;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Create<TIn, TOut>(int allocSize,
                                         TIn input,
                                         out TOut output,
                                         Func<TIn, MarshallingAllocBuffer, TOut> func)
    {
        var span = allocSize > MaxSizeForStackAlloc
            ? GC.AllocateUninitializedArray<byte>(allocSize, true)
            : stackalloc byte[allocSize];

        var buffer = new MarshallingAllocBuffer(span);

        output = func(input, buffer);
    }

    public MarshallingAllocBuffer(Span<byte> backingStore)
    {
        _data = backingStore;
    }

    public ReadOnlySpan<sbyte> ConvertString(string str)
    {
        var allocSize = str.GetNativeAllocSize();

        var span = AllocWithBackup<sbyte>(allocSize);

        Encoding.UTF8.GetBytes(str, span.AsBytes());

        span[^1] = (sbyte)'\0'; //Get bytes does not add the null terminal character

        return span;
    }

    public unsafe NativeArrayOfStrings ConvertStringArray(IReadOnlyCollection<string> strings)
    {
        var handleToArrays = AllocWithBackup<nint>(strings.Count);

        var start = _allocatedSize;

        var i = 0;
        foreach (var str in strings)
        {
            var strSpan = ConvertString(str);

            var ptr = (sbyte*)SysUnsafe.AsPointer(ref strSpan.DangerousGetReference());
            handleToArrays[i] = (nint)ptr;

            i++;
        }

        var fullDataSpan = _data[start..].Cast<byte, sbyte>();

        return new(handleToArrays, fullDataSpan);
    }

    public Span<T> AllocFor<T>(int count) where T : unmanaged
    {
        return AllocWithBackup<T>(count);
    }

    /// <summary>
    /// Allocates a span of memory from the backing store (stack allocated or not) with a backup heap allocated store in case its too small.
    /// The memory is UNINITIALIZED.
    /// </summary>
    /// <typeparam name="T">The type of the unmanaged memory to allocate</typeparam>
    /// <param name="count">The number of elements to allocate</param>
    /// <returns>A span of UNINITIALIZED memory of the unmanaged type T</returns>
    private unsafe Span<T> AllocWithBackup<T>(int count) where T : unmanaged
    {
        ArgumentOutOfRangeException.ThrowIfNegative(count);

        if (count is 0) return [];

        var byteSizeToAlloc = count * SysUnsafe.SizeOf<T>();

        if (_allocatedSize + byteSizeToAlloc > _data.Length)
        {
            _backupStore ??= [];
            var arr = GC.AllocateUninitializedArray<T>(byteSizeToAlloc, true);
            _backupStore.Add(arr);

            return arr;
        }

        var start = _allocatedSize;

        _allocatedSize += byteSizeToAlloc;

        return MemoryMarshal.Cast<byte, T>(_data[start..])[..count];
    }

    public readonly ref struct NativeArrayOfStrings : IReadOnlyList<string>
    {
        private readonly ReadOnlySpan<nint> _handleToArrays;
        private readonly Span<sbyte> _fullData;

        public NativeArrayOfStrings(ReadOnlySpan<nint> handleToArrays, Span<sbyte> fullData)
        {
            _handleToArrays = handleToArrays;
            _fullData = fullData;
        }

        public unsafe string this[int index] =>
            InteropUtils.PtrToStringUTF8((void*)_handleToArrays[index]) ??
            throw new InvalidOperationException("Failed to convert string");

        public int Count => _handleToArrays.Length;

        public unsafe sbyte** AsPointer()
        {
            ref var h = ref _handleToArrays.DangerousGetReference();
            var ptr = (sbyte**)SysUnsafe.AsPointer(ref h);
            return ptr;
        }

        public Enumerator GetEnumerator() =>
            new(this);

        IEnumerator<string> IEnumerable<string>.GetEnumerator() =>
            throw new NotSupportedException(
                "Cannot use standard enumerator with ref struct. Use the Enumerator struct directly.");

        IEnumerator IEnumerable.GetEnumerator() =>
            throw new NotSupportedException(
                "Cannot use standard enumerator with ref struct. Use the Enumerator struct directly.");

        // Custom value-type enumerator that doesn't use yield
        public ref struct Enumerator : IEnumerator<string>
        {
            private readonly NativeArrayOfStrings _array;
            private int _index;

            public Enumerator(NativeArrayOfStrings array)
            {
                _array = array;
                _index = -1;
            }

            public readonly string Current => _array[_index];

            readonly object IEnumerator.Current => Current;

            public readonly void Dispose()
            {
                // Do nothing
            }

            public bool MoveNext()
            {
                _index++;
                return _index < _array.Count;
            }

            public void Reset()
            {
                _index = -1;
            }
        }
    }
}

public static class MarshallingAllocBufferExtensions
{
    public static int GetNativeAllocSize(this string? str)
    {
        if (str is null) return 0;

        return Encoding.UTF8.GetByteCount(str) + Encoding.UTF8.GetByteCount("\0");
    }

    public static int GetNativeAllocSize(this IReadOnlyCollection<string>? strings)
    {
        if (strings is null) return 0;

        return strings.Sum(s => s.GetNativeAllocSize());
    }

    public static int GetNativeAllocSize<TManaged, TNative>(this IReadOnlyCollection<TManaged>? items)
        where TManaged : IMarshalsToNative<TNative> where TNative : unmanaged
    {
        if (items is null) return 0;

        return items.Sum(i => i.GetNativeAllocSize());
    }

    public static unsafe T* AllocForPtr<T>(ref this MarshallingAllocBuffer buffer, int count) where T : unmanaged
    {
        ArgumentOutOfRangeException.ThrowIfNegative(count);

        if (count is 0) return null;

        var span = buffer.AllocFor<T>(count);

        return (T*)SysUnsafe.AsPointer(ref MemoryMarshal.GetReference(span));
    }

    public static unsafe sbyte* MarshalToNative(this string? str, ref MarshallingAllocBuffer buffer)
    {
        if (str is null) return null;

        var span = buffer.ConvertString(str);

        return (sbyte*)SysUnsafe.AsPointer(ref MemoryMarshal.GetReference(span));
    }

    public static unsafe sbyte** MarshalToNative(this IReadOnlyCollection<string>? strings,
                                                 ref MarshallingAllocBuffer buffer)
    {
        if (strings is null) return null;


        var res = buffer.ConvertStringArray(strings);

        return res.AsPointer();
    }

    public static unsafe TNative* MarshalToNative<TManaged, TNative>(this IReadOnlyCollection<TManaged>? items,
                                                                     ref MarshallingAllocBuffer buffer)
        where TManaged : IMarshalsToNative<TNative> where TNative : unmanaged
    {
        if (items is null) return null;

        var span = buffer.AllocFor<TNative>(items.Count);

        var i = 0;
        foreach (var item in items)
        {
            item.AsNative(ref buffer, out var native);
            span[i] = native;
            i++;
        }

        return (TNative*)SysUnsafe.AsPointer(ref MemoryMarshal.GetReference(span));
    }

    public static unsafe T** MarshalToNative<T>(this IReadOnlyCollection<COMObject<T>>? items,
                                                ref MarshallingAllocBuffer buffer) where T : unmanaged
    {
        if (items is null) return null;

        var ptr = (T**)buffer.AllocForPtr<nint>(items.Count);

        var i = 0;
        foreach (var item in items)
        {
            ptr[i] = item.AsNullablePtr();

            if (ptr[i] is null)
                throw new InvalidOperationException(
                    "Failed to marshal COMObject array to pointer. One of the handle values is null.");

            i++;
        }

        return ptr;
    }

    public static unsafe void MarshalToNative<TManaged, TNative>(this TManaged? item,
                                                                 PostMarshalDelegate<TNative> postMarshal)
        where TManaged : IMarshalsToNative<TNative> where TNative : unmanaged
    {
        if (item is null)
        {
            postMarshal(null);
            return;
        }

        MarshallingAllocBuffer.Create(item.GetNativeAllocSize(),
                                      (item, postMarshal),
                                      out _,
                                      static (pair, buffer) =>
                                      {
                                          pair.item.AsNative(ref buffer, out var native);

                                          pair.postMarshal(&native);
                                          return byte.MinValue;
                                      });
    }

    public static unsafe SlangResult MarshalToNative<TManaged, TNative, TResult>(
        this TManaged? item,
        out TResult result,
        PostMarshalDelegateWithResult<TNative, TResult> postMarshal)
        where TManaged : IMarshalsToNative<TNative> where TNative : unmanaged
    {
        if (item is null)
        {
            var t = postMarshal(null);
            result = t.Item2;
            return t.Item1;
        }

        MarshallingAllocBuffer.Create(item.GetNativeAllocSize(),
                                      (item, postMarshal),
                                      out var res,
                                      static (tuple, allocBuffer) =>
                                      {
                                          tuple.item.AsNative(ref allocBuffer, out var native);

                                          return tuple.postMarshal(&native);
                                      });

        result = res.Item2;
        return res.Item1;
    }

    public static unsafe TResult MarshalToNative<TManaged, TNative, TArg, TResult>(
        this TManaged? item,
        TArg arg,
        PostMarshalDelegate<TNative, TArg, TResult> postMarshal) where TManaged : IMarshalsToNative<TNative>
                                                                 where TNative : unmanaged
                                                                 where TArg : allows ref struct
    {
        if (item is null) return postMarshal(null, arg);
        
        var size = item.GetNativeAllocSize();
        var span = size > 1024 ? GC.AllocateUninitializedArray<byte>(size, true) : stackalloc byte[size];

        var buffer = new MarshallingAllocBuffer(span);

        item.AsNative(ref buffer, out var native);

        return postMarshal(&native, arg);
    }

    public static unsafe TResult MarshalToNative<TResult>(this string? str, PostMarshalDelegate<sbyte, TResult> postMarshal)
    {
        if (str is null) return postMarshal(null);

        var size = str.GetNativeAllocSize();
        var span = size > 1024 ? GC.AllocateUninitializedArray<byte>(size, true) : stackalloc byte[size];

        var buffer = new MarshallingAllocBuffer(span);

        var ptr = str.MarshalToNative(ref buffer);

        return postMarshal(ptr);
    }

    public unsafe delegate void PostMarshalDelegate<TNative>(TNative* ptr) where TNative : unmanaged;
    public unsafe delegate TResult PostMarshalDelegate<TNative, out TResult>(TNative* ptr) where TNative : unmanaged;

    public unsafe delegate TResult PostMarshalDelegate<TNative, in TArg, out TResult>(TNative* ptr, TArg arg)
        where TNative : unmanaged where TArg : allows ref struct;

    public unsafe delegate (SlangResult, TResult) PostMarshalDelegateWithResult<TNative, TResult>(TNative* ptr)
        where TNative : unmanaged;
}