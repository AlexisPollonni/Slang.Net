using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace SlangNet.ComWrappers;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf8)]
[Guid("00000000-0000-0000-C000-000000000046")]
public partial interface IUnknown
{

}

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf8)]
[Guid("8BA5FB08-5195-40E2-AC58-0D989C3A0102")]
public partial interface IBlob : IUnknown
{
    [PreserveSig]
    unsafe void* GetBufferPointer();
    
    [PreserveSig]
    ulong GetBufferSize();
}


public static class BlobExtensions
{
    public static unsafe string? AsString(this IBlob blob)
    {
        var ptr = blob.GetBufferPointer();
        if (ptr is null) return null;
        
        return new((char*)ptr, 0, (int)blob.GetBufferSize());
    }
}

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf8)]
[Guid("67618701-D116-468F-AB3B-474BEDCE0E3D")]
public partial interface ISession : IUnknown
{
    
}

public static partial class Slang
{
    [LibraryImport("slang", EntryPoint = "slang_createGlobalSession")]
    public static partial void CreateGlobalSession(long apiVersion, out IGlobalSession globalSession);
}

