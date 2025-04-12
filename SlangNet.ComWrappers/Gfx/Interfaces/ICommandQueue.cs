using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Gfx.Descriptions;
using SlangNet.ComWrappers.Interfaces;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Gfx.Interfaces;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Custom,
                       StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller))]
[Guid("14e2bed0-0AD0-4DC8-B341-063FE72DBF0E")]
public partial interface ICommandQueue : IUnknown
{
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    CommandQueueDescription GetDesc();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void ExecuteCommandBuffers(int count,
                               [MarshalUsing(CountElementName = "count")]
                               Span<ICommandBuffer> commandBuffers,
                               IFence? fenceToSignal = null,
                               ulong newFenceValue = 0);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetNativeHandle(out Unmanaged.InteropHandle handle);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void WaitOnHost();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult WaitForFenceValuesOnDevice(int fenceCount, 
                                           [MarshalUsing(CountElementName = "fenceCount")]
                                           Span<IFence> fences, 
                                           [MarshalUsing(CountElementName = "fenceCount")]
                                           Span<ulong> waitValues);
}