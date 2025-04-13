using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Gfx.Interfaces;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Custom,
                       StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller))]
[Guid("88AA9322-82F7-4FE6-A68A-29C7FE798737")]
public partial interface IComputeCommandEncoder : IResourceCommandEncoder
{
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult BindPipeline(IPipelineState state, out IShaderObject rootObject);
    
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult BindPipelineWithRootObject(IPipelineState state, IShaderObject rootObject);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult DispatchCompute(int x, int y, int z);
    
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult DispatchComputeIndirect(IBufferResource cmdBuffer, nuint offset);
}