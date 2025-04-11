using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Interfaces;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Custom, StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller))]
[Guid("8044A8A3-DDC0-4B7F-AF8E-026E905D7332")]
public partial interface IMetadata : ICastable
{
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult IsParameterLocationUsed(ParameterCategory category,
                                        nuint spaceIndex,
                                        nuint registerIndex,
                                        [MarshalAs(UnmanagedType.I1)] out bool used);
}