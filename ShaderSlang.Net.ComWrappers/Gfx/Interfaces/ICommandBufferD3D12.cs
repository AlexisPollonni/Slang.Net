using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Gfx.Interfaces;

[GeneratedComInterface(
    StringMarshalling = StringMarshalling.Custom,
    StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller)
)]
[Guid("d56b7616-6C14-4841-9D9C-7B7FDB9FD9B8")]
public partial interface ICommandBufferD3D12 : ICommandBuffer
{
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void InvalidatedDescriptorHeapBinding();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void EnsureInternalDescriptorHeapsBound();
}
