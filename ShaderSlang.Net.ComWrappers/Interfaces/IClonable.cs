using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Interfaces;

[Guid("1EC36168-E9F4-430D-BB17-048A8046B31F")]
[GeneratedComInterface(
    StringMarshalling = StringMarshalling.Custom,
    StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller)
)]
public partial interface IClonable : ICastable
{
    [PreserveSig]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    IUnknown Clone(in Unmanaged.SlangUUID guid);
}
