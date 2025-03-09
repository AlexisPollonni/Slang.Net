using SlangNet.Internal;

namespace SlangNet.Gfx;

[GenerateThrowingMethods]
public partial class TransientResourceHeap : COMObject<ITransientResourceHeap>
{
    internal unsafe TransientResourceHeap(ITransientResourceHeap* pointer) : base(pointer)
    { }
    
    public unsafe SlangResult TrySynchronizeAndReset()
    {
        return Pointer->synchronizeAndReset().ToSlangResult();
    }
    
    public unsafe SlangResult TryFinish()
    {
        return Pointer->finish().ToSlangResult();
    }
    
    public unsafe SlangResult TryCreateCommandBuffer(out CommandBuffer? commandBuffer)
    {
        ICommandBuffer* nativeCommandBuffer = null;
        var result = Pointer->createCommandBuffer(&nativeCommandBuffer).ToSlangResult();
        commandBuffer = result ? new CommandBuffer(nativeCommandBuffer) : null;
        return result;
    }
}
