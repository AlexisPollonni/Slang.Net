using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.Bindings;
using ShaderSlang.Net.ComWrappers.Tools;
using ShaderSlang.Net.ComWrappers.Tools.Internal;

namespace ShaderSlang.Net.ComWrappers.Interfaces;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Custom, StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller))]
[Guid("8044A8A3-DDC0-4B7F-AF8E-026E905D7332")]
[GenerateThrowingMethods]
public partial interface IMetadata : ICastable
{
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult IsParameterLocationUsed(ParameterCategory category,
                                        nuint spaceIndex,
                                        nuint registerIndex,
                                        [MarshalAs(UnmanagedType.I1)] out bool used);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    string GetDebugBuildIdentifier();
}