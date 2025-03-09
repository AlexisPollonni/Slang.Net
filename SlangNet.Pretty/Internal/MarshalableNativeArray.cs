using System;
using Nito.Disposables;
using static System.Runtime.CompilerServices.Unsafe;

namespace SlangNet.Internal;

internal sealed class MarshalableNativeArray<TManaged, TNative> : IDisposable
    where TNative : unmanaged
    where TManaged : IMarshalable<TManaged, TNative>
{
    private readonly NativeAllocMemory _nativeMemory;
    private readonly CollectionDisposable _asNativeDisposables;

    internal MarshalableNativeArray(TManaged[] managedArray) : this(managedArray.AsSpan())
    {
        
    }
    
    internal MarshalableNativeArray(ReadOnlySpan<TManaged> managed)
    {
        _asNativeDisposables = new();
        
        var mItemArray = managed.ToArray();
        _nativeMemory = new((nuint)(mItemArray.Length * SizeOf<TNative>()));

        var span = _nativeMemory.AsSpan<TNative>();
        
        for (var i = 0; i < mItemArray.Length; i++)
        {
            var m = mItemArray[i];
            m.AsNative(out var native).DisposeWith(_asNativeDisposables);

            span[i] = native;
        }
    }

    public unsafe TNative* AsPtr() => _nativeMemory.AsPtr<TNative>();
        
    public void Dispose()
    {
        _nativeMemory.Dispose();
        _asNativeDisposables.Dispose();
    }
}
