using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(typeof(MarshalableMarshaller.Bidirectional<FramebufferLayoutDescription, Unmanaged.IFramebufferLayout.FramebufferLayoutDesc>))]
public readonly record struct FramebufferLayoutDescription(
    IReadOnlyList<Unmanaged.IFramebufferLayout.TargetLayout> RenderTargets,
    Unmanaged.IFramebufferLayout.TargetLayout? DepthStencil) 
    : IMarshalsToNative<Unmanaged.IFramebufferLayout.FramebufferLayoutDesc>,
      IMarshalsFromNative<FramebufferLayoutDescription, Unmanaged.IFramebufferLayout.FramebufferLayoutDesc>
{
    unsafe Unmanaged.IFramebufferLayout.FramebufferLayoutDesc IMarshalsToNative<Unmanaged.IFramebufferLayout.FramebufferLayoutDesc>.
        AsNative(ref GrowingStackBuffer buffer)
    {
        var ptrTargets = stackalloc Unmanaged.IFramebufferLayout.TargetLayout[RenderTargets.Count];

        for (var i = 0; i < RenderTargets.Count; i++) ptrTargets[i] = RenderTargets[i];

        var depthStencil = DepthStencil;
        return new()
        {
            renderTargets = ptrTargets,
            renderTargetCount = RenderTargets.Count,
            depthStencil = depthStencil is null ? null : buffer.GetStructPtr(depthStencil.Value),
        };
    }

    public static unsafe FramebufferLayoutDescription CreateFromNative(Unmanaged.IFramebufferLayout.FramebufferLayoutDesc unmanaged)
    {
        var targets = new Unmanaged.IFramebufferLayout.TargetLayout[unmanaged.renderTargetCount];
        for (var i = 0; i < unmanaged.renderTargetCount; i++) targets[i] = unmanaged.renderTargets[i];

        return new(targets, unmanaged.depthStencil is null ? null : *unmanaged.depthStencil);
    }
}