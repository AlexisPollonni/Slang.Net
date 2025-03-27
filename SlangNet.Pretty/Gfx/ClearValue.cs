using System;
using System.Drawing;
using SlangNet.Internal;

namespace SlangNet.Gfx;

public readonly record struct ClearValue(Color Color, float Depth = 1f, uint Stencil = 0) 
    : IMarshalsToNative<Unsafe.ClearValue>,
      IMarshalsFromNative<ClearValue, Unsafe.ClearValue>
{
    public int GetNativeAllocSize() => SysUnsafe.SizeOf<Unsafe.ClearValue>();

    public void AsNative(ref MarshallingAllocBuffer buffer, out Unsafe.ClearValue native)
    {
        ReadOnlySpan<float> colorValues =
        [
            (float)Color.R / byte.MaxValue,  
            (float)Color.G / byte.MaxValue,
            (float)Color.B / byte.MaxValue,
            (float)Color.A / byte.MaxValue
        ];

        var natValues = new ColorClearValue();

        colorValues.CopyTo(natValues.floatValues.AsSpan<ColorClearValue._floatValues_e__FixedBuffer, float>());

        native = new()
        {
            color = natValues,
            depthStencil = new()
            {
                depth = Depth,
                stencil = Stencil
            },
        };
    }

    public static void CreateFromNative(Unsafe.ClearValue native, out ClearValue managed)
    {
        if (native.color.floatValues[0] is >= 0 and <= 1
            && native.color.floatValues[1] is >= 0 and <= 1
            && native.color.floatValues[2] is >= 0 and <= 1
            && native.color.floatValues[3] is >= 0 and <= 1)
        {
            managed = new(
                Color.FromArgb(
                    (int)(native.color.floatValues[3] * byte.MaxValue),
                    (int)(native.color.floatValues[0] * byte.MaxValue),
                    (int)(native.color.floatValues[1] * byte.MaxValue),
                    (int)(native.color.floatValues[2] * byte.MaxValue)
                ),
                native.depthStencil.depth,
                native.depthStencil.stencil
            );
        }
        else
        {
            managed = new(
                Color.FromArgb(
                    (int)native.color.uintValues[3],
                    (int)native.color.uintValues[0],
                    (int)native.color.uintValues[1],
                    (int)native.color.uintValues[2]
                    ),
                native.depthStencil.depth,
                native.depthStencil.stencil
            );
        }
    }
}