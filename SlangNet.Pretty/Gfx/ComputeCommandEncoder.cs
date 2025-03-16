using System;

namespace SlangNet.Gfx;

[GenerateThrowingMethods]
public partial class ComputeCommandEncoder : ResourceCommandEncoder
{
    private unsafe IComputeCommandEncoder* ImplPtr => (IComputeCommandEncoder*)Pointer;

    public unsafe ComputeCommandEncoder(IComputeCommandEncoder* pointer) : base((IResourceCommandEncoder*)pointer)
    {
    }

    public unsafe SlangResult TryBindPipeline(PipelineState state, out ShaderObject? outRootShaderObject)
    {
        IShaderObject* outPtr = null;
        var result = ImplPtr->bindPipeline(state.Pointer, &outPtr).ToSlangResult();
        outRootShaderObject = outPtr is not null ? new ShaderObject(outPtr) : null;
        return result;
    }

    public unsafe SlangResult TryBindPipelineWithRootObject(PipelineState state, ShaderObject rootObject)
    {
        return ImplPtr->bindPipelineWithRootObject(state.Pointer, rootObject.Pointer).ToSlangResult();
    }

    public unsafe SlangResult TryDispatchCompute(int x, int y, int z)
    {
        return ImplPtr->dispatchCompute(x, y, z).ToSlangResult();
    }
    
    public unsafe SlangResult TryDispatchComputeIndirect(BufferResource cmdBuffer, nuint offset)
    {
        return ImplPtr->dispatchComputeIndirect(cmdBuffer.Pointer, offset).ToSlangResult();
    }
}
