using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using CommunityToolkit.HighPerformance;
using Nito.Disposables;
using SlangNet.Internal;

namespace SlangNet;

internal static unsafe class InteropUtils
{
    public static string? BlobToString(ISlangBlob* blob)
    {
        if (blob == null)
            return null;
        var pointer = blob->getBufferPointer();

        var size = checked((int)blob->getBufferSize().ToUInt32());
        if (size == 0)
            return "";
        return Encoding.UTF8.GetString((byte*)pointer, size);
    }

    public static string? AsString(this COMPointer<ISlangBlob> pointer) => BlobToString(pointer);

    public static string? PtrToStringUTF8(void* ptr, Encoding? encoding = null)
    {
        if (ptr is null) return null;
        
        encoding ??= Encoding.UTF8;

        var span = MemoryMarshal.CreateReadOnlySpanFromNullTerminated((byte*)ptr);
        return encoding.GetString(span);
    }

    public static string[]? PtrToStringArray(sbyte** ptr, int count)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(count);

        if (ptr is null || count == 0)
            return null;

        return new Utf8StringArray(ptr, count).ToStringArray();
    }

    public static TManaged[]? MarshalArrayToManaged<TManaged, TNative>(TNative* native, int count) 
        where TNative : unmanaged 
        where TManaged : IMarshalsFromNative<TManaged, TNative>
    {
        if (native is null || count == 0)
            return null;

        var res = new TManaged[count];
        var span = new Span<TNative>(native, count);


        for (var i = 0; i < count; i++)
        {
            TManaged.CreateFromNative(span[i], out var managed);
            res[i] = managed;
        }

        return res;
    }
    
    /// <summary>
    /// Adds the disposable to the list of disposables.
    /// </summary>
    /// <typeparam name="T">The type of the disposable. Must implement <see cref="IDisposable"/>.</typeparam>
    /// <param name="d">The disposable to add.</param>
    /// <param name="disposableList">The list of disposables to add the disposable to.</param>
    /// <returns>The disposable d that was added to be disposed</returns>
    internal static T? DisposeWith<T>(this T? d, CollectionDisposable disposableList) where T : IDisposable
    {
        if (d is not null)
        {
            disposableList.Add(d);
        }
        return d;
    }

    public static T* AsNullablePtr<T>(this ref T? item) where T : unmanaged
    {
        return (T*)SysUnsafe.AsPointer(ref item.DangerousGetValueOrNullReference());
    }

    public static T* AsNullablePtr<T>(this COMObject<T>? comObject) where T : unmanaged
    {
        return comObject is not null ? comObject.Pointer : null;
    }


    /// <summary>
    /// Returns the count of the collection if it is not null, 0 otherwise.
    /// </summary>
    /// <typeparam name="T">The type of the collection.</typeparam>
    /// <param name="collection">The collection to get the count of.</param>
    /// <returns>The count of the collection if it is not null, 0 if it is.</returns>
    public static int CountIfNotNull<T>(this IReadOnlyCollection<T>? collection)
    {
        if (collection is null)
            return 0;
        return collection.Count;
    }

    public static Span<T> AsSpan<T>(ref this T inline) where T : unmanaged
    {
        return MemoryMarshal.CreateSpan(ref inline, 1);
    }

    public static Span<TCast> AsSpan<T, TCast>(ref this T inline)
        where T : unmanaged
        where TCast : unmanaged
    {
        return inline.AsSpan().Cast<T, TCast>();
    }

    public static ReadOnlySpan<T> AsReadOnlySpan<T>(ref this T inline) where T : unmanaged
    {
        return MemoryMarshal.CreateReadOnlySpan(in inline, 1);
    }

    public static ReadOnlySpan<TCast> AsReadOnlySpan<T, TCast>(ref this T inline) 
        where T : unmanaged 
        where TCast : unmanaged
    {
        return inline.AsReadOnlySpan().Cast<T, TCast>();
    }

    public static ReadOnlySpan<uint> AsUintSpan<T>(ref this T inline) 
        where T : unmanaged 
    {
        return inline.AsReadOnlySpan().Cast<T, uint>();
    }
}


