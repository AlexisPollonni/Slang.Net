using System.Drawing;
using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(
    typeof(MarshalableMarshaller.Bidirectional<
        SamplerStateDescription,
        Unmanaged.ISamplerState.SamplerStateDesc
    >)
)]
public readonly record struct SamplerStateDescription(
    Unmanaged.TextureFilteringMode MinFilter = Unmanaged.TextureFilteringMode.Linear,
    Unmanaged.TextureFilteringMode MagFilter = Unmanaged.TextureFilteringMode.Linear,
    Unmanaged.TextureFilteringMode MipFilter = Unmanaged.TextureFilteringMode.Linear,
    Unmanaged.TextureReductionOp ReductionOp = Unmanaged.TextureReductionOp.Average,
    Unmanaged.TextureAddressingMode AddressU = Unmanaged.TextureAddressingMode.Wrap,
    Unmanaged.TextureAddressingMode AddressV = Unmanaged.TextureAddressingMode.Wrap,
    Unmanaged.TextureAddressingMode AddressW = Unmanaged.TextureAddressingMode.Wrap,
    float MipLodBias = 0.0f,
    uint MaxAnisotropy = 1,
    Unmanaged.ComparisonFunc ComparisonFunc = Unmanaged.ComparisonFunc.Never,
    Color? BorderColor = null,
    float MinLod = float.MinValue,
    float MaxLod = float.MaxValue
)
    : IMarshalsToNative<Unmanaged.ISamplerState.SamplerStateDesc>,
        IMarshalsFromNative<SamplerStateDescription, Unmanaged.ISamplerState.SamplerStateDesc>
{
    Unmanaged.ISamplerState.SamplerStateDesc IMarshalsToNative<Unmanaged.ISamplerState.SamplerStateDesc>.AsNative(
        ref GrowingStackBuffer buffer
    )
    {
        var desc = new Unmanaged.ISamplerState.SamplerStateDesc
        {
            minFilter = MinFilter,
            magFilter = MagFilter,
            mipFilter = MipFilter,
            reductionOp = ReductionOp,
            addressU = AddressU,
            addressV = AddressV,
            addressW = AddressW,
            mipLODBias = MipLodBias,
            maxAnisotropy = MaxAnisotropy,
            comparisonFunc = ComparisonFunc,
            minLOD = MinLod,
            maxLOD = MaxLod,
        };

        var color = BorderColor ?? Color.White;

        desc.borderColor[0] = (float)color.R / byte.MaxValue;
        desc.borderColor[1] = (float)color.G / byte.MaxValue;
        desc.borderColor[2] = (float)color.B / byte.MaxValue;
        desc.borderColor[3] = (float)color.A / byte.MaxValue;

        return desc;
    }

    public static SamplerStateDescription CreateFromNative(
        Unmanaged.ISamplerState.SamplerStateDesc unmanaged
    )
    {
        var borderColor = Color.FromArgb(
            (int)(unmanaged.borderColor[3] * byte.MaxValue),
            (int)(unmanaged.borderColor[0] * byte.MaxValue),
            (int)(unmanaged.borderColor[1] * byte.MaxValue),
            (int)(unmanaged.borderColor[2] * byte.MaxValue)
        );

        return new(
            unmanaged.minFilter,
            unmanaged.magFilter,
            unmanaged.mipFilter,
            unmanaged.reductionOp,
            unmanaged.addressU,
            unmanaged.addressV,
            unmanaged.addressW,
            unmanaged.mipLODBias,
            unmanaged.maxAnisotropy,
            unmanaged.comparisonFunc,
            borderColor,
            unmanaged.minLOD,
            unmanaged.maxLOD
        );
    }
}
