using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Interfaces;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf8)]
[Guid("197772C7-0155-4B91-84E8-6668BAFF0619")]
public partial interface IProfiler : IUnknown
{
    [PreserveSig]
    ulong GetEntryCount();

    [PreserveSig]
    string GetEntryName(uint index);

    [PreserveSig]
    [return:MarshalUsing(typeof(TimeSpanMillisecondsMarshaller))]
    TimeSpan GetEntryTime(uint index);

    [PreserveSig]
    uint GetEntryInvocationTimes(uint index);
}


