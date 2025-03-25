using System;
using SlangNet.Internal;

namespace SlangNet.Gfx.Desc;

public readonly record struct SampleDesc(int NumSamples = 1, int Quality = 0)
    : IMarshalsToNative<ITextureResource.SampleDesc>, IMarshalsFromNative<SampleDesc, ITextureResource.SampleDesc>
{
    public int GetNativeAllocSize() =>
        SysUnsafe.SizeOf<ITextureResource.SampleDesc>();

    public void AsNative(ref MarshallingAllocBuffer buffer, out ITextureResource.SampleDesc native)
    {
        native = new()
        {
            numSamples = NumSamples,
            quality = Quality
        };
    }

    public static void CreateFromNative(ITextureResource.SampleDesc native, out SampleDesc managed)
    {
        managed = new(native.numSamples, native.quality);
    }
}

public readonly record struct TextureResourceDesc(
    ResourceDescBase Base,
    ITextureResource.Extents Size,
    Format Format,
    SampleDesc SampleDesc,
    ClearValue ClearValue,
    int ArraySize = 0,
    int NumMipLevels = 0) : IMarshalsToNative<ITextureResource.TextureResourceDesc>,
                            IMarshalsFromNative<TextureResourceDesc, ITextureResource.TextureResourceDesc>
{
    public int GetNativeAllocSize() =>
        SysUnsafe.SizeOf<ITextureResource.TextureResourceDesc>();

    public unsafe void AsNative(ref MarshallingAllocBuffer buffer, out ITextureResource.TextureResourceDesc native)
    {
        Base.AsNative(ref buffer, out var natBase);
        ClearValue.AsNative(ref buffer, out var natClear);
        SampleDesc.AsNative(ref buffer, out var sampleDesc);

        native = new()
        {
            Base = natBase,
            size = Size,
            format = Format,
            sampleDesc = sampleDesc,
            optimalClearValue = &natClear,
            arraySize = ArraySize,
            numMipLevels = NumMipLevels
        };
    }

    public static unsafe void CreateFromNative(ITextureResource.TextureResourceDesc native, out TextureResourceDesc managed)
    {
        ResourceDescBase.CreateFromNative(native.Base, out var @base);
        SampleDesc.CreateFromNative(native.sampleDesc, out var sampleDesc);
        ClearValue.CreateFromNative(*native.optimalClearValue, out var clearValue);


        managed = new(@base, native.size, native.format, sampleDesc, clearValue, native.arraySize, native.numMipLevels);
    }
}