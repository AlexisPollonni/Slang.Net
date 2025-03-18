using System;
using SlangNet.Internal;

namespace SlangNet.Gfx.Tools;

public struct ShaderOffset : IComparable<ShaderOffset>, IEquatable<ShaderOffset>, IMarshalsToNative<Unsafe.ShaderOffset>
{
    private Unsafe.ShaderOffset _offset;

    public ShaderOffset(long uniformOffset, int bindingRangeIndex, int bindingArrayIndex)
    {
        _offset = new() {
            uniformOffset = uniformOffset,
            bindingRangeIndex = bindingRangeIndex,
            bindingArrayIndex = bindingArrayIndex
        };
    }

    public ShaderOffset(Unsafe.ShaderOffset offset)
    {
        _offset = offset;
    }

    public ShaderOffset()
    {
        _offset = default;
    }

    public readonly long UniformOffset => _offset.uniformOffset;

    public readonly int BindingRangeIndex => _offset.bindingRangeIndex;

    public readonly int BindingArrayIndex => _offset.bindingArrayIndex;

    
    
    public readonly override int GetHashCode() =>
        (int)(((BindingRangeIndex << 20) + BindingArrayIndex) ^ UniformOffset);
    public readonly int CompareTo(ShaderOffset other)
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

    
    
    public readonly bool Equals(ShaderOffset other) =>
        UniformOffset == other.UniformOffset && BindingRangeIndex == other.BindingRangeIndex && BindingArrayIndex == other.BindingArrayIndex;

    public override readonly bool Equals(object? obj) =>
        obj is ShaderOffset other && Equals(other);

    public static bool operator ==(ShaderOffset left, ShaderOffset right) =>
        left.Equals(right);

    public static bool operator !=(ShaderOffset left, ShaderOffset right) =>
        !left.Equals(right);




    public readonly int GetNativeAllocSize()
    {
        return SysUnsafe.SizeOf<Unsafe.ShaderOffset>();
    }

    public void AsNative(ref MarshallingAllocBuffer buffer, out Unsafe.ShaderOffset native)
    {
        native = new() {
            uniformOffset = UniformOffset,
            bindingRangeIndex = BindingRangeIndex,
            bindingArrayIndex = BindingArrayIndex
        };
    }
}
