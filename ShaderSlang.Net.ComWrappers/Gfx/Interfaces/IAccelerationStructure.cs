using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Gfx.Interfaces;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Custom,
                       StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller))]
[Guid("a5cdda3c-1D4E-4DF7-8EF2-B73FCE04DE3B")]
public partial interface IAccelerationStructure : IResourceView
{
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    ulong GetDeviceAddress();
}