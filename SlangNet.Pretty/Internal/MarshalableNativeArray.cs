using System;
using System.Collections;
using System.Collections.Generic;
using Nito.Disposables;
using static System.Runtime.CompilerServices.Unsafe;

namespace SlangNet.Internal;

internal sealed class MarshalableManagedArray<TManaged, TNative> : IReadOnlyList<TNative>, IDisposable
    where TNative : unmanaged
    where TManaged : IMarshalsToNative<TNative>
{
    private readonly NativeAllocMemory _nativeMemory;
    private readonly CollectionDisposable _asNativeDisposables;

    internal MarshalableManagedArray(IReadOnlyCollection<TManaged> managed)
    {
        _asNativeDisposables = new();
        
        _nativeMemory = new((nuint)(managed.Count * SizeOf<TNative>()));

        var span = _nativeMemory.AsSpan<TNative>();
        
        var i = 0;
        foreach (var item in managed)
        {
            item.AsNative(out var native).DisposeWith(_asNativeDisposables);

            span[i] = native;
            i++;
        }
    }

    public TNative this[int index] => _nativeMemory.AsSpan<TNative>()[index];

    public int Count => (int)(_nativeMemory.Length / (nuint)SizeOf<TNative>());

    public unsafe TNative* AsPtr() => _nativeMemory.AsPtr<TNative>();
        
    public void Dispose()
    {
        _nativeMemory.Dispose();
        _asNativeDisposables.Dispose();
    }

    public IEnumerator<TNative> GetEnumerator()
    {
        for (var i = 0; i < Count; i++)
        {
            yield return _nativeMemory.AsSpan<TNative>()[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}


internal readonly unsafe struct MarshalableNativeArray<TManaged, TNative> : IReadOnlyList<TManaged>
    where TNative : unmanaged
    where TManaged : IMarshalsFromNative<TManaged, TNative>
{
    private readonly TManaged[] _managedArray;

    public MarshalableNativeArray(TNative* nativePtr, int count)
    {
        ArgumentNullException.ThrowIfNull(nativePtr);
        ArgumentOutOfRangeException.ThrowIfNegative(count);

        _managedArray = new TManaged[count];

        for (var i = 0; i < count; i++)
        {
            TManaged.CreateFromNative(nativePtr[i], out var managed);
            _managedArray[i] = managed;
        }
    }

    public TManaged this[int index] => _managedArray[index];

    public int Count => _managedArray.Length;

    public IEnumerator<TManaged> GetEnumerator()
    {
        return (IEnumerator<TManaged>)_managedArray.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
