using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.Bindings.Generated;

namespace SlangNet.ComWrappers.Interfaces;

[Guid("1EC36168-E9F4-430D-BB17-048A8046B31F")]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf8)]
public partial interface IClonable : ICastable
{
    [PreserveSig]
    IUnknown Clone(in SlangUUID guid);
}
