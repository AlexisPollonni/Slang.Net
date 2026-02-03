using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(
    typeof(BidirectionalMarshaller<
        TextureResourceDescription,
        Unmanaged.ITextureResource.TextureResourceDesc
    >)
)]
public readonly record struct TextureResourceDescription(
    ResourceDescriptionBase Base,
    Unmanaged.ITextureResource.Extents Size,
    Unmanaged.Format Format,
    SampleDescription SampleDesc,
    ClearValue ClearValue,
    int ArraySize = 0,
    int NumMipLevels = 0
)
    : IMarshalsToNative<Unmanaged.ITextureResource.TextureResourceDesc>,
        IMarshalsFromNative<
            TextureResourceDescription,
            Unmanaged.ITextureResource.TextureResourceDesc
        >
{
    unsafe Unmanaged.ITextureResource.TextureResourceDesc IMarshalsToNative<Unmanaged.ITextureResource.TextureResourceDesc>.AsNative(
        ref GrowingStackBuffer buffer
    ) =>
        new()
        {
            Base = ((IMarshalsToNative<Unmanaged.IResource.DescBase>)Base).AsNative(ref buffer),
            size = Size,
            format = Format,
            sampleDesc = (
                (IMarshalsToNative<Unmanaged.ITextureResource.SampleDesc>)SampleDesc
            ).AsNative(ref buffer),
            optimalClearValue = buffer.GetStructPtr(
                ((IMarshalsToNative<Unmanaged.ClearValue>)ClearValue).AsNative(ref buffer)
            ),
            arraySize = ArraySize,
            numMipLevels = NumMipLevels,
        };

    public static unsafe TextureResourceDescription CreateFromNative(
        Unmanaged.ITextureResource.TextureResourceDesc unmanaged
    ) =>
        new(
            ResourceDescriptionBase.CreateFromNative(unmanaged.Base),
            unmanaged.size,
            unmanaged.format,
            SampleDescription.CreateFromNative(unmanaged.sampleDesc),
            ClearValue.CreateFromNative(*unmanaged.optimalClearValue),
            unmanaged.arraySize,
            unmanaged.numMipLevels
        );
}
