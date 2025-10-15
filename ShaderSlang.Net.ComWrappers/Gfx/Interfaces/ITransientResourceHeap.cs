using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.Bindings;
using ShaderSlang.Net.ComWrappers.Interfaces;
using ShaderSlang.Net.ComWrappers.Tools;
using ShaderSlang.Net.ComWrappers.Tools.Internal;

namespace ShaderSlang.Net.ComWrappers.Gfx.Interfaces;

[GeneratedComInterface(
    StringMarshalling = StringMarshalling.Custom,
    StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller)
)]
[Guid("cd48bd29-EE72-41B8-BCFF-0A2B3AAA6DEB")]
[GenerateThrowingMethods]
public partial interface ITransientResourceHeap : IUnknown
{
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult SynchronizeAndReset();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult Finish();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult CreateCommandBuffer(out ICommandBuffer commandBuffer);
}
