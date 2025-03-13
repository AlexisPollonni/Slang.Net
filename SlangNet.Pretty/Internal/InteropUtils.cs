using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
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

        var size = checked((int)blob->getBufferSize().ToUInt64());
        if (size == 0)
            return "";
        return new Utf8String((sbyte*)pointer, size).ToString();
    }

    public static string? AsString(this COMPointer<ISlangBlob> pointer) => BlobToString(pointer);

    public static string? PtrToStringUTF8(void* ptr)
        => new Utf8String((sbyte*)ptr).ToString();

    public static unsafe string[]? PtrToStringArray(sbyte** ptr, int count)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(count);

        if (ptr is null || count == 0)
            return null;

        return new Utf8StringArray(ptr, count).ToStringArray();
    }

    public static Utf8StringArray? StringArrayToUtf8StringArray(this IReadOnlyCollection<string>? strings)
    {
        if (strings is null)
            return null;
        return new Utf8StringArray(strings);
    }

    public unsafe static sbyte* StringToPtr(this string? str, CollectionDisposable disposables)
    {
        if (str is null)
            return null;
        return new Utf8String(str).DisposeWith(disposables).Memory;
    }

    public unsafe static sbyte** StringArrayToPtr(this IReadOnlyCollection<string>? strings, CollectionDisposable disposables)
    {
        if (strings is null)
            return null;

        var utf8Strings = strings.StringArrayToUtf8StringArray()?.DisposeWith(disposables);

        if (utf8Strings is null)
            return null;

        return utf8Strings.Value.Memory;
    }

    public static int CombineHash<T1, T2>(T1 v1, T2 v2)
        where T1 : unmanaged
        where T2 : unmanaged 
        => HashCode.Combine(v1, v2);

    
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





    public static unsafe T* AsNullablePtr<T>(this COMObject<T>? comObject) where T : unmanaged
    {
        return comObject is not null ? comObject.Pointer : null;
    }

    public static unsafe T** ToPtrArray<T>(this IReadOnlyCollection<COMObject<T>>? items, CollectionDisposable disposables) 
        where T : unmanaged
    {
        if (items is null)
            return null;
            
        var alloc = new NativeAllocMemory((nuint)(items.Count * sizeof(T*)), false).DisposeWith(disposables)!;
        
        var ptr = (T**)alloc.AsVoidPtr();
        
        var i = 0;
        foreach (var item in items)
        {
            ptr[i] = item.AsNullablePtr();
            i++;
        }

        return ptr;
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
}


