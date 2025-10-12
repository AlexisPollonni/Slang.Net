using static ShaderSlang.Net.ComWrappers.Reflection.ReflectionApi;

namespace ShaderSlang.Net.ComWrappers.Reflection;

partial struct TypeLayoutReflection
{
    public readonly struct DescriptorRange : IEquatable<DescriptorRange>
    {
        public TypeLayoutReflection TypeLayout { get; }
        public long SetIndex { get; }
        public long RangeIndex { get; }

        internal DescriptorRange(TypeLayoutReflection typeLayout, long setIndex, long rangeIndex)
        {
            TypeLayout = typeLayout;
            SetIndex = setIndex;
            RangeIndex = rangeIndex;
        }

        public bool Equals(DescriptorRange other) =>
            TypeLayout == other.TypeLayout && SetIndex == other.SetIndex;

        public override bool Equals(object? obj) => obj is DescriptorRange other && Equals(other);

        public static bool operator ==(DescriptorRange a, DescriptorRange b) => a.Equals(b);

        public static bool operator !=(DescriptorRange a, DescriptorRange b) => !a.Equals(b);

        public override int GetHashCode() => HashCode.Combine(TypeLayout, SetIndex);

        public long IndexOffset =>
            ReflectionTypeLayout_getDescriptorSetDescriptorRangeIndexOffset(
                TypeLayout,
                (nint)SetIndex,
                (nint)RangeIndex
            );

        public long DescriptorCount =>
            ReflectionTypeLayout_getDescriptorSetDescriptorRangeDescriptorCount(
                TypeLayout,
                (nint)SetIndex,
                (nint)RangeIndex
            );

        public BindingType Type =>
            ReflectionTypeLayout_getDescriptorSetDescriptorRangeType(
                TypeLayout,
                (nint)SetIndex,
                (nint)RangeIndex
            );

        public ParameterCategory Category =>
            ReflectionTypeLayout_getDescriptorSetDescriptorRangeCategory(
                TypeLayout,
                (nint)SetIndex,
                (nint)RangeIndex
            );
    }
}
