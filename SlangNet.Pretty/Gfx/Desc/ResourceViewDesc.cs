using System;
using SlangNet.Internal;

namespace SlangNet.Gfx.Desc;

public record struct ResourceViewDesc(
    IResourceView.ResourceViewType Type, 
    Format Format, 
    IResourceView.RenderTargetDesc RenderTarget, 
    SubresourceRange SubresourceRange,
    BufferRange BufferRange
) :
    IMarshalsToNative<IResourceView.ResourceViewDesc>,
    IMarshalsFromNative<ResourceViewDesc, IResourceView.ResourceViewDesc>
{
    public void AsNative(ref MarshallingAllocBuffer buffer, out IResourceView.ResourceViewDesc native)
    {
        native = new()
        {
            type = Type,
            format = Format,
            renderTarget = RenderTarget,
            subresourceRange = SubresourceRange,
            bufferRange = BufferRange
        };
    }

    public readonly int GetNativeAllocSize()
    {
        return SysUnsafe.SizeOf<IResourceView.ResourceViewDesc>();
    }

    public static void CreateFromNative(IResourceView.ResourceViewDesc native, out ResourceViewDesc managed)
    {
        managed = new(
            native.type,
            native.format,
            native.renderTarget,
            native.subresourceRange,
            native.bufferRange
        );
    }
}