using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Interfaces;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Custom, StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller))]
[Guid("8BA5FB08-5195-40E2-AC58-0D989C3A0102")]
public partial interface IBlob : IUnknown
{
    [PreserveSig]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    unsafe void* GetBufferPointer();
    
    [PreserveSig]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    ulong GetBufferSize();
}

public static class BlobExtensions
{
    public static unsafe string? AsString(this IBlob? blob)
    {
        if(blob is null) return null;
        var ptr = blob.GetBufferPointer();
        if (ptr is null) return null;
        
        return new((char*)ptr, 0, (int)blob.GetBufferSize());
    }

    public static unsafe ReadOnlySpan<byte> AsReadOnlySpan(this IBlob blob) =>
        new(blob.GetBufferPointer(), (int)blob.GetBufferSize());
}
