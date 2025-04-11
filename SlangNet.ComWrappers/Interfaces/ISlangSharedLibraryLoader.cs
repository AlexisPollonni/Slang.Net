using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Interfaces;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Custom, StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller))]
[Guid("6264AB2B-A3E8-4A06-97F1-49BC2D2AB14D")]
public partial interface ISlangSharedLibraryLoader : IUnknown
{
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult LoadSharedLibrary(string path, out ISlangSharedLibrary sharedLibrary);
}
