using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Gfx.Interfaces;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(typeof(MarshalableMarshaller.Bidirectional<FramebufferDescription, Unmanaged.IFramebuffer.FramebufferDesc>))]
public readonly record struct FramebufferDescription(
    IReadOnlyCollection<IResourceView>? RenderTargetViews,
    IResourceView? DepthStencilView,
    IFramebufferLayout? Layout) : IMarshalsToNative<Unmanaged.IFramebuffer.FramebufferDesc>,
                                  IMarshalsFromNative<FramebufferDescription, Unmanaged.IFramebuffer.FramebufferDesc>,
                                  IFreeAfterMarshal<Unmanaged.IFramebuffer.FramebufferDesc>
{
    unsafe Unmanaged.IFramebuffer.FramebufferDesc IMarshalsToNative<Unmanaged.IFramebuffer.FramebufferDesc>.AsNative(
        ref GrowingStackBuffer buffer) =>
        new()
        {
            renderTargetViews
                = buffer.GetComCollectionPtr<IResourceView, Unmanaged.IResourceView>(
                    RenderTargetViews,
                    out var renderTargetCount),
            renderTargetCount = (int)renderTargetCount,
            depthStencilView = DepthStencilView.InterfaceToPtr<IResourceView, Unmanaged.IResourceView>(),
            layout = Layout.InterfaceToPtr<IFramebufferLayout, Unmanaged.IFramebufferLayout>()
        };

    static unsafe FramebufferDescription IMarshalsFromNative<FramebufferDescription, Unmanaged.IFramebuffer.FramebufferDesc>.
        CreateFromNative(Unmanaged.IFramebuffer.FramebufferDesc unmanaged) =>
        new(InteropUtils.ComPtrToManagedMarshal<IResourceView, Unmanaged.IResourceView>(
                unmanaged.renderTargetViews,
                unmanaged.renderTargetCount),
            ComInterfaceMarshaller<IResourceView>.ConvertToManaged(unmanaged.depthStencilView),
            ComInterfaceMarshaller<IFramebufferLayout>.ConvertToManaged(unmanaged.layout));

    public unsafe void Free(Unmanaged.IFramebuffer.FramebufferDesc* unmanaged)
    {
        for (var i = 0; i < unmanaged->renderTargetCount; i++)
        {
            ComInterfaceMarshaller<IResourceView>.Free(unmanaged->renderTargetViews[i]);
        }

        ComInterfaceMarshaller<IResourceView>.Free(unmanaged->depthStencilView);
        ComInterfaceMarshaller<IFramebufferLayout>.Free(unmanaged->layout);
    }
}