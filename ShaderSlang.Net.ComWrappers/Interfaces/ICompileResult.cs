using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.Bindings;
using ShaderSlang.Net.ComWrappers.Tools;
using ShaderSlang.Net.ComWrappers.Tools.Internal;

namespace ShaderSlang.Net.ComWrappers.Interfaces;

[GeneratedComInterface(
    StringMarshalling = StringMarshalling.Custom,
    StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller)
)]
[Guid("5fa9380e-b62f-41e5-9F12-4BAD4D9EAAE4")]
[GenerateThrowingMethods]
public partial interface ICompileResult : ICastable
{
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    uint GetItemCount();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetItemData(uint index, out IBlob outBlob);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetMetadata(out IMetadata outMetadata);
}
