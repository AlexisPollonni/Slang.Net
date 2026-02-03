using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Gfx.Interfaces;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(
    typeof(BidirectionalMarshaller<
        RenderPassLayoutDescription,
        Unmanaged.IRenderPassLayout.RenderPassLayoutDesc
    >)
)]
public readonly record struct RenderPassLayoutDescription(
    IFramebufferLayout FramebufferLayout,
    IReadOnlyList<Unmanaged.IRenderPassLayout.TargetAccessDesc> RenderTargetAccesses,
    Unmanaged.IRenderPassLayout.TargetAccessDesc? DepthStencilAccess
)
    : IMarshalsToNative<Unmanaged.IRenderPassLayout.RenderPassLayoutDesc>,
        IMarshalsFromNative<
            RenderPassLayoutDescription,
            Unmanaged.IRenderPassLayout.RenderPassLayoutDesc
        >,
        IFreeAfterMarshal<Unmanaged.IRenderPassLayout.RenderPassLayoutDesc>
{
    unsafe Unmanaged.IRenderPassLayout.RenderPassLayoutDesc IMarshalsToNative<Unmanaged.IRenderPassLayout.RenderPassLayoutDesc>.AsNative(
        ref GrowingStackBuffer buffer
    ) =>
        new()
        {
            framebufferLayout = FramebufferLayout.InterfaceToPtr<
                IFramebufferLayout,
                Unmanaged.IFramebufferLayout
            >(),
            renderTargetAccess = buffer.GetCollectionPtr(
                RenderTargetAccesses,
                out var renderTargetCount
            ),
            renderTargetCount = (int)renderTargetCount,
            depthStencilAccess = DepthStencilAccess is null
                ? null
                : buffer.GetStructPtr(DepthStencilAccess.Value),
        };

    public static unsafe RenderPassLayoutDescription CreateFromNative(
        Unmanaged.IRenderPassLayout.RenderPassLayoutDesc unmanaged
    ) =>
        new(
            ComInterfaceMarshaller<IFramebufferLayout>.ConvertToManaged(
                unmanaged.framebufferLayout
            )!,
            new ReadOnlySpan<Unmanaged.IRenderPassLayout.TargetAccessDesc>(
                unmanaged.renderTargetAccess,
                unmanaged.renderTargetCount
            ).ToArray(),
            unmanaged.depthStencilAccess is null ? null : *unmanaged.depthStencilAccess
        );

    public static unsafe void Free(scoped ref readonly Unmanaged.IRenderPassLayout.RenderPassLayoutDesc unmanaged)
    {
        ComInterfaceMarshaller<IFramebufferLayout>.Free(unmanaged.framebufferLayout);
    }
}
