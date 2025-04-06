using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace SlangNet.ComWrappers;

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
