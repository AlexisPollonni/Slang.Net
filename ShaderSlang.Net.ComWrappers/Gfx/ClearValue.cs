using System.Drawing;
using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Gfx;

[NativeMarshalling(typeof(BidirectionalMarshaller<ClearValue, Unmanaged.ClearValue>))]
public readonly record struct ClearValue(Color Color, float Depth = 1f, uint Stencil = 0)
    : IMarshalsToNative<Unmanaged.ClearValue>,
        IMarshalsFromNative<ClearValue, Unmanaged.ClearValue>
{
    Unmanaged.ClearValue IMarshalsToNative<Unmanaged.ClearValue>.AsNative(
        ref GrowingStackBuffer buffer
    )
    {
        ReadOnlySpan<float> colorValues =
        [
            (float)Color.R / byte.MaxValue,
            (float)Color.G / byte.MaxValue,
            (float)Color.B / byte.MaxValue,
            (float)Color.A / byte.MaxValue,
        ];

        var natValues = new Unmanaged.ColorClearValue();

        colorValues.CopyTo(natValues.floatValues.AsFloatSpan());

        return new()
        {
            color = natValues,
            depthStencil = new() { depth = Depth, stencil = Stencil },
        };
    }

    public static ClearValue CreateFromNative(Unmanaged.ClearValue unmanaged)
    {
        if (
            unmanaged.color.floatValues[0] is >= 0 and <= 1
            && unmanaged.color.floatValues[1] is >= 0 and <= 1
            && unmanaged.color.floatValues[2] is >= 0 and <= 1
            && unmanaged.color.floatValues[3] is >= 0 and <= 1
        )
        {
            return new(
                Color.FromArgb(
                    (int)(unmanaged.color.floatValues[3] * byte.MaxValue),
                    (int)(unmanaged.color.floatValues[0] * byte.MaxValue),
                    (int)(unmanaged.color.floatValues[1] * byte.MaxValue),
                    (int)(unmanaged.color.floatValues[2] * byte.MaxValue)
                ),
                unmanaged.depthStencil.depth,
                unmanaged.depthStencil.stencil
            );
        }

        return new(
            Color.FromArgb(
                (int)unmanaged.color.uintValues[3],
                (int)unmanaged.color.uintValues[0],
                (int)unmanaged.color.uintValues[1],
                (int)unmanaged.color.uintValues[2]
            ),
            unmanaged.depthStencil.depth,
            unmanaged.depthStencil.stencil
        );
    }
}
