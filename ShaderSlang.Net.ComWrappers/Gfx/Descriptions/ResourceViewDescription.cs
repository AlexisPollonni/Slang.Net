using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(typeof(MarshalableMarshaller.Bidirectional<ResourceViewDescription, Unmanaged.IResourceView.ResourceViewDesc>))]
public readonly record struct ResourceViewDescription(
    Unmanaged.IResourceView.ResourceViewType Type,
    Unmanaged.Format Format,
    Unmanaged.IResourceView.RenderTargetDesc RenderTarget,
    Unmanaged.SubresourceRange SubresourceRange,
    Unmanaged.BufferRange BufferRange) : IMarshalsToNative<Unmanaged.IResourceView.ResourceViewDesc>,
                                         IMarshalsFromNative<ResourceViewDescription, Unmanaged.IResourceView.ResourceViewDesc>
{
    Unmanaged.IResourceView.ResourceViewDesc IMarshalsToNative<Unmanaged.IResourceView.ResourceViewDesc>.AsNative(ref GrowingStackBuffer buffer) =>
        new()
        {
            type = Type,
            format = Format,
            renderTarget = RenderTarget,
            subresourceRange = SubresourceRange,
            bufferRange = BufferRange
        };

    public static ResourceViewDescription CreateFromNative(Unmanaged.IResourceView.ResourceViewDesc unmanaged) =>
        new(unmanaged.type, unmanaged.format, unmanaged.renderTarget, unmanaged.subresourceRange, unmanaged.bufferRange);
}