using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Gfx.Interfaces;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Custom,
                       StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller))]
[Guid("9a672b87-5035-45E3-967C-1F85CDB3634F")]
public partial interface IRayTracingCommandEncoder : IResourceCommandEncoder
{
    //[PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    //TODO
}