using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.Bindings.Generated;

namespace SlangNet.ComWrappers.Interfaces;

[Guid("87EDE0E1-4852-44B0-8BF2-CB31874DE239")]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf8)]
public partial interface ICastable : IUnknown
{
    [PreserveSig]
    IUnknown CastAs(in SlangUUID guid);
}
