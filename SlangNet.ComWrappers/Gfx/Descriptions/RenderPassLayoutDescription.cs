using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Gfx.Interfaces;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(typeof(MarshalableMarshaller.Bidirectional<RenderPassLayoutDescription, Unmanaged.IRenderPassLayout.RenderPassLayoutDesc>))]
public readonly record struct RenderPassLayoutDescription(IFramebufferLayout FramebufferLayout,
                                                   IReadOnlyList<Unmanaged.IRenderPassLayout.TargetAccessDesc> RenderTargetAccesses,
                                                   Unmanaged.IRenderPassLayout.TargetAccessDesc? DepthStencilAccess)
    : IMarshalsToNative<Unmanaged.IRenderPassLayout.RenderPassLayoutDesc>,
      IMarshalsFromNative<RenderPassLayoutDescription, Unmanaged.IRenderPassLayout.RenderPassLayoutDesc>,
      IFreeAfterMarshal<Unmanaged.IRenderPassLayout.RenderPassLayoutDesc>
{
    unsafe Unmanaged.IRenderPassLayout.RenderPassLayoutDesc IMarshalsToNative<Unmanaged.IRenderPassLayout.RenderPassLayoutDesc>.AsNative(ref GrowingStackBuffer buffer) =>
        new()
        {
            framebufferLayout = FramebufferLayout.InterfaceToPtr<IFramebufferLayout, Unmanaged.IFramebufferLayout>(),
            renderTargetAccess = buffer.GetCollectionPtr(RenderTargetAccesses, out var renderTargetCount),
            renderTargetCount = (int)renderTargetCount,
            depthStencilAccess = DepthStencilAccess is null ? null : buffer.GetStructPtr(DepthStencilAccess.Value),
        };

    public static unsafe RenderPassLayoutDescription CreateFromNative(Unmanaged.IRenderPassLayout.RenderPassLayoutDesc unmanaged) =>
        new(ComInterfaceMarshaller<IFramebufferLayout>.ConvertToManaged(unmanaged.framebufferLayout)!,
            new ReadOnlySpan<Unmanaged.IRenderPassLayout.TargetAccessDesc>(unmanaged.renderTargetAccess, unmanaged.renderTargetCount).ToArray(),
            unmanaged.depthStencilAccess is null ? null : *unmanaged.depthStencilAccess);

    public unsafe void Free(Unmanaged.IRenderPassLayout.RenderPassLayoutDesc* unmanaged)
    {
        ComInterfaceMarshaller<IFramebufferLayout>.Free(unmanaged->framebufferLayout);
    }
}