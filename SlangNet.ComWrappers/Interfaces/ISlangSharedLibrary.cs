using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Interfaces;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Custom, StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller))]
[Guid("70DBC7C4-DC3B-4A07-AE7E-752AF6A81555")]
public partial interface ISlangSharedLibrary : ICastable
{
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    unsafe void* FindFuncByName(string name);


    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    unsafe void* FindSymbolAddressByName(string name);
}