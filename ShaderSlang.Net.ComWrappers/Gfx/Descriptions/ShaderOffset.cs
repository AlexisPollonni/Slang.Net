using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(
    typeof(MarshalableMarshaller.Bidirectional<ShaderOffset, Unmanaged.ShaderOffset>)
)]
public readonly struct ShaderOffset
    : IComparable<ShaderOffset>,
        IEquatable<ShaderOffset>,
        IMarshalsToNative<Unmanaged.ShaderOffset>,
        IMarshalsFromNative<ShaderOffset, Unmanaged.ShaderOffset>
{
    private readonly Unmanaged.ShaderOffset _offset;

    public ShaderOffset(long uniformOffset, int bindingRangeIndex, int bindingArrayIndex)
    {
        _offset = new()
        {
            uniformOffset = (nint)uniformOffset,
            bindingRangeIndex = bindingRangeIndex,
            bindingArrayIndex = bindingArrayIndex,
        };
    }

    public ShaderOffset(Unmanaged.ShaderOffset offset)
    {
        _offset = offset;
    }

    public ShaderOffset()
    {
        _offset = default;
    }

    public long UniformOffset => _offset.uniformOffset;

    public int BindingRangeIndex => _offset.bindingRangeIndex;

    public int BindingArrayIndex => _offset.bindingArrayIndex;

    public override int GetHashCode() =>
        (int)(((BindingRangeIndex << 20) + BindingArrayIndex) ^ UniformOffset);

    public int CompareTo(ShaderOffset other)
    {
        if (BindingRangeIndex < other.BindingRangeIndex)
            return -1;
        if (BindingRangeIndex > other.BindingRangeIndex)
            return 1;

        if (BindingArrayIndex < other.BindingArrayIndex)
            return -1;
        if (BindingArrayIndex > other.BindingArrayIndex)
            return 1;

        if (UniformOffset < other.UniformOffset)
            return -1;
        if (UniformOffset > other.UniformOffset)
            return 1;

        return 0;
    }

    public static bool operator <(ShaderOffset left, ShaderOffset right) =>
        left.CompareTo(right) < 0;

    public static bool operator >(ShaderOffset left, ShaderOffset right) =>
        left.CompareTo(right) > 0;

    public static bool operator <=(ShaderOffset left, ShaderOffset right) =>
        left.CompareTo(right) <= 0;

    public static bool operator >=(ShaderOffset left, ShaderOffset right) =>
        left.CompareTo(right) >= 0;

    public bool Equals(ShaderOffset other) =>
        UniformOffset == other.UniformOffset
        && BindingRangeIndex == other.BindingRangeIndex
        && BindingArrayIndex == other.BindingArrayIndex;

    public override bool Equals(object? obj) => obj is ShaderOffset other && Equals(other);

    public static bool operator ==(ShaderOffset left, ShaderOffset right) => left.Equals(right);

    public static bool operator !=(ShaderOffset left, ShaderOffset right) => !left.Equals(right);

    Unmanaged.ShaderOffset IMarshalsToNative<Unmanaged.ShaderOffset>.AsNative(
        ref GrowingStackBuffer buffer
    ) =>
        new()
        {
            uniformOffset = (nint)UniformOffset,
            bindingRangeIndex = BindingRangeIndex,
            bindingArrayIndex = BindingArrayIndex,
        };

    public static ShaderOffset CreateFromNative(Unmanaged.ShaderOffset unmanaged) => new(unmanaged);
}
