using System;
using System.Collections.Generic;
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
        if (pointer == null)
            return null;
        var size = checked((int)blob->getBufferSize().ToUInt64());
        if (size == 0)
            return "";
        return Encoding.UTF8.GetString((byte*)pointer, size);
    }

    public static string? AsString(this COMPointer<ISlangBlob> pointer) => BlobToString(pointer);

    public static string? PtrToStringUTF8(void* ptr)
#if NETSTANDARD2_1_OR_GREATER
        => Marshal.PtrToStringUTF8(new(ptr));
#else
    {
        if (ptr == null)
            return null;
        var length = StrLen(ptr);
        if (length == 0)
            return "";
        return Encoding.UTF8.GetString((byte*)ptr, length);
    }
#endif

    // if somebody knows a better/native API usable in .NET Standard 2.0, send a PR
    public static int StrLen(void* ptrRaw)
    {
        if (ptrRaw == null)
            return 0;
        int length = 0;
        byte* ptr = (byte*)ptrRaw;
        for (; *ptr != 0; ptr++, length++) ;
        return length;
    }

#if !NETSTANDARD2_1_OR_GREATER
    public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> pair, out TKey key, out TValue value)
    {
        key = pair.Key;
        value = pair.Value;
    }
#endif

    public static int CombineHash<T1, T2>(T1 v1, T2 v2)
        where T1 : unmanaged
        where T2 : unmanaged
#if NETSTANDARD2_1_OR_GREATER
        => HashCode.Combine(v1, v2);
#else
    {
        // FNV-1a 
        unchecked
        {
            int hash = (int)2166136261;
            hash = (hash ^ v1.GetHashCode()) * 16777619;
            hash = (hash ^ v2.GetHashCode()) * 16777619;
            return hash;
        }
    }
#endif
    
    /// <summary>
    /// Adds the disposable to the list of disposables.
    /// </summary>
    /// <typeparam name="T">The type of the disposable. Must implement <see cref="IDisposable"/>.</typeparam>
    /// <param name="d">The disposable to add.</param>
    /// <param name="disposableList">The list of disposables to add the disposable to.</param>
    /// <returns>The disposable d that was added to be disposed</returns>
    internal static T DisposeWith<T>(this T d, CollectionDisposable disposableList) where T : IDisposable
    {
        disposableList.Add(d);
        return d;
    }
}


