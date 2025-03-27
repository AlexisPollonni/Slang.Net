using System.Collections.Generic;
using SlangNet.Internal;

namespace SlangNet.Gfx;

public sealed class RenderPassLayout : COMObject<IRenderPassLayout>
{
    internal unsafe RenderPassLayout(IRenderPassLayout* pointer) : base(pointer) { }

    public readonly record struct RenderPassLayoutDesc(FramebufferLayout FramebufferLayout,
                                                       IReadOnlyList<IRenderPassLayout.TargetAccessDesc> RenderTargetAccesses,
                                                       IRenderPassLayout.TargetAccessDesc? DepthStencilAccess)
        : IMarshalsToNative<IRenderPassLayout.RenderPassLayoutDesc>
    {
        public unsafe int GetNativeAllocSize() => sizeof(IRenderPassLayout.RenderPassLayoutDesc) * (RenderTargetAccesses.Count + (DepthStencilAccess is null ? 0 : 1));

        public unsafe void AsNative(ref MarshallingAllocBuffer buffer, out IRenderPassLayout.RenderPassLayoutDesc native)
        {
            var renderTrgtsPtr = buffer.AllocForPtr<IRenderPassLayout.TargetAccessDesc>(RenderTargetAccesses.Count);
            for (var i = 0; i < RenderTargetAccesses.Count; i++) renderTrgtsPtr[i] = RenderTargetAccesses[i];

            var depthStencilAccess = DepthStencilAccess;
            native = new()
            {
                framebufferLayout = FramebufferLayout.Pointer,
                renderTargetAccess = renderTrgtsPtr,
                renderTargetCount = RenderTargetAccesses.Count,
                depthStencilAccess = depthStencilAccess.AsNullablePtr(),
            };
        }
    }
}