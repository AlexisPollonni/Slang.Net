using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(typeof(MarshalableMarshaller.Bidirectional<SampleDescription, Unmanaged.ITextureResource.SampleDesc>))]
public readonly record struct SampleDescription(int NumSamples = 1, int Quality = 0)
    : IMarshalsToNative<Unmanaged.ITextureResource.SampleDesc>,
      IMarshalsFromNative<SampleDescription, Unmanaged.ITextureResource.SampleDesc>
{
    Unmanaged.ITextureResource.SampleDesc IMarshalsToNative<Unmanaged.ITextureResource.SampleDesc>.AsNative(
        ref GrowingStackBuffer buffer) =>
        new()
        {
            numSamples = NumSamples,
            quality = Quality
        };

    public static SampleDescription CreateFromNative(Unmanaged.ITextureResource.SampleDesc unmanaged) =>
        new(unmanaged.numSamples, unmanaged.quality);
}