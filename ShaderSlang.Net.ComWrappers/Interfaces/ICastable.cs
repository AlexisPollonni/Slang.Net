using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Interfaces;

[Guid("87EDE0E1-4852-44B0-8BF2-CB31874DE239")]
[GeneratedComInterface(
    StringMarshalling = StringMarshalling.Custom,
    StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller)
)]
public partial interface ICastable : IUnknown
{
    [PreserveSig]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    IUnknown CastAs(in Unmanaged.SlangUUID guid);
}
