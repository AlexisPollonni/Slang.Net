using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Gfx.Interfaces;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Custom,
                       StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller))]
[Guid("9a672b87-5035-45E3-967C-1F85CDB3634F")]
public partial interface IRayTracingCommandEncoder : IResourceCommandEncoder
{
    //[PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    //TODO
}