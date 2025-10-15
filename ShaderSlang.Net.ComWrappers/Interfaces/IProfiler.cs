using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Interfaces;

[GeneratedComInterface(
    StringMarshalling = StringMarshalling.Custom,
    StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller)
)]
[Guid("197772C7-0155-4B91-84E8-6668BAFF0619")]
public partial interface IProfiler : IUnknown
{
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    ulong GetEntryCount();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    string GetEntryName(uint index);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    [return: MarshalUsing(typeof(TimeSpanMillisecondsMarshaller))]
    TimeSpan GetEntryTime(uint index);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    uint GetEntryInvocationTimes(uint index);
}
