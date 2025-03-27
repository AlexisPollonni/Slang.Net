using System.Collections.Generic;
using SlangNet.Internal;

namespace SlangNet.Gfx;

public sealed class Framebuffer : COMObject<IFramebuffer>
{
    internal unsafe Framebuffer(IFramebuffer* pointer) : base(pointer) { }

    public readonly record struct FramebufferDesc(
        IReadOnlyCollection<ResourceView> RenderTargetViews,
        ResourceView? DepthStencilView,
        FramebufferLayout Layout) : IMarshalsToNative<IFramebuffer.FramebufferDesc>
    {
        public int GetNativeAllocSize() =>
            SysUnsafe.SizeOf<IFramebuffer.FramebufferDesc>() + RenderTargetViews.Count * SysUnsafe.SizeOf<nint>();

        public unsafe void AsNative(ref MarshallingAllocBuffer buffer, out IFramebuffer.FramebufferDesc native)
        {
            var renderTrgtsPtr = RenderTargetViews.MarshalToNative(ref buffer);
            native = new()
            {
                renderTargetViews = renderTrgtsPtr,
                renderTargetCount = RenderTargetViews.Count,
                depthStencilView = DepthStencilView.AsNullablePtr(),
                layout = Layout.Pointer
            };
        }
    }
}