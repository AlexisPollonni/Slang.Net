using System.Runtime.InteropServices;
using SlangNet.Internal;

namespace SlangNet.Gfx;

[GenerateThrowingMethods]
public partial class PipelineState : COMObject<IPipelineState>
{
    internal unsafe PipelineState(IPipelineState* pointer) : base(pointer)
    { }
    
    public unsafe SlangResult TryGetNativeHandle(out InteropHandle handle)
    {
        fixed (InteropHandle* pHandle = &handle)
        {
            return Pointer->getNativeHandle(pHandle).ToSlangResult();
        }
    }
}
