using ShaderSlang.Net.ComWrappers.Tools;
using static ShaderSlang.Net.ComWrappers.Reflection.ReflectionApi;

namespace ShaderSlang.Net.ComWrappers.Reflection;

partial struct TypeLayoutReflection
{
    public readonly struct DescriptorSet : IEquatable<DescriptorSet>
    {
        public TypeLayoutReflection TypeLayout { get; }
        public long Index { get; }

        internal DescriptorSet(TypeLayoutReflection typeLayout, long index)
        {
            TypeLayout = typeLayout;
            Index = index;
            Ranges = new NativeBoundedReadOnlyList<TypeLayoutReflection, nint, DescriptorRange>
            {
                Container = TypeLayout,
                Argument = (nint)Index,
                GetCount = (container, arg) => checked((nint)ReflectionTypeLayout_getDescriptorSetDescriptorRangeCount(container, arg)),
                TryGetAt = (layout, setIndex, rangeIndex) => new DescriptorRange(layout, setIndex, rangeIndex)
            };
        }
        
        public bool Equals(DescriptorSet other) => TypeLayout == other.TypeLayout && Index == other.Index;
        public override bool Equals(object? obj) => obj is DescriptorSet other && Equals(other);
        public static bool operator ==(DescriptorSet a, DescriptorSet b) => a.Equals(b);
        public static bool operator !=(DescriptorSet a, DescriptorSet b) => !a.Equals(b);
        public override int GetHashCode() => HashCode.Combine(TypeLayout, Index);

        public long SpaceOffset =>
            ReflectionTypeLayout_getDescriptorSetSpaceOffset(TypeLayout, (nint)Index);

        public IReadOnlyList<DescriptorRange> Ranges { get; }
    }
}