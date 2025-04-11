using static SlangNet.ComWrappers.Reflection.ReflectionApi;

namespace SlangNet.ComWrappers.Reflection;

partial struct TypeLayoutReflection
{
    public readonly struct BindingRange : IEquatable<BindingRange>
    {
        public TypeLayoutReflection TypeLayout { get; }
        public long Index { get; }

        internal BindingRange(TypeLayoutReflection typeLayout, long index)
        {
            TypeLayout= typeLayout;
            Index = index;
        }


        public bool Equals(BindingRange other) => TypeLayout == other.TypeLayout && Index == other.Index;
        public override bool Equals(object? obj) => obj is BindingRange other && Equals(other);
        public static bool operator ==(BindingRange a, BindingRange b) => a.Equals(b);
        public static bool operator !=(BindingRange a, BindingRange b) => !a.Equals(b);
        public override int GetHashCode() => HashCode.Combine(TypeLayout, Index);

        public BindingType BindingRangeType => ReflectionTypeLayout_getBindingRangeType(TypeLayout, (nint)Index);
        public long BindingCount => ReflectionTypeLayout_getBindingRangeBindingCount(TypeLayout, (nint)Index);
        public TypeLayoutReflection? LeafTypeLayout => ReflectionTypeLayout_getBindingRangeLeafTypeLayout(TypeLayout, (nint)Index);
        public VariableReflection? LeafVariable => ReflectionTypeLayout_getBindingRangeLeafVariable(TypeLayout, (nint)Index);
        public long DescriptorSetIndex => ReflectionTypeLayout_getBindingRangeDescriptorSetIndex(TypeLayout, (nint)Index);
        public long FirstDescriptorRangeIndex => ReflectionTypeLayout_getBindingRangeFirstDescriptorRangeIndex(TypeLayout, (nint)Index);
        public long DescriptorRangeCount => ReflectionTypeLayout_getBindingRangeDescriptorRangeCount(TypeLayout, (nint)Index);
    }
}
