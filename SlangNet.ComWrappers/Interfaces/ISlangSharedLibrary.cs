using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Interfaces;

namespace SlangNet.ComWrappers;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf8)]
[Guid("70DBC7C4-DC3B-4A07-AE7E-752AF6A81555")]
public partial interface ISlangSharedLibrary : ICastable
{
    [PreserveSig]
    unsafe void* FindFuncByName(string name);


    [PreserveSig]
    unsafe void* FindSymbolAddressByName(string name);
}