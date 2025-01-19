using System;

namespace SlangNet;

unsafe partial struct TypeLayoutReflection
{
    public readonly struct DescriptorRange : IEquatable<DescriptorRange>
    {
        private readonly SlangReflectionTypeLayout* pointer;
        public SlangReflectionTypeLayout* Pointer
        {
            get
            {
                ThrowIfNull();
                return pointer;
            }
        }
        public long SetIndex { get; }
        public long RangeIndex { get; }

        internal DescriptorRange(SlangReflectionTypeLayout* pointer, long setIndex, long rangeIndex)
        {
            this.pointer = pointer;
            SetIndex = setIndex;
            RangeIndex = rangeIndex;
        }

        internal void ThrowIfNull()
        {
            if (pointer == null)
                throw new NullReferenceException("This instance of TypeLayoutReflection.DescriptorRange has a null pointer");
        }

        public bool Equals(DescriptorRange other) => pointer == other.pointer && SetIndex == other.SetIndex;
        public override bool Equals(object? obj) => obj is DescriptorRange other && Equals(other);
        public static bool operator ==(DescriptorRange a, DescriptorRange b) => a.Equals(b);
        public static bool operator !=(DescriptorRange a, DescriptorRange b) => !a.Equals(b);
        public override int GetHashCode() => InteropUtils.CombineHash(new IntPtr(pointer), SetIndex);

        public long IndexOffset =>
            ReflectionTypeLayout_getDescriptorSetDescriptorRangeIndexOffset(Pointer, (nint)SetIndex, (nint)RangeIndex);

        public long DescriptorCount =>
            ReflectionTypeLayout_getDescriptorSetDescriptorRangeDescriptorCount(Pointer, (nint)SetIndex, (nint)RangeIndex);

        public BindingType Type =>
            ReflectionTypeLayout_getDescriptorSetDescriptorRangeType(Pointer, (nint)SetIndex, (nint)RangeIndex);

        public ParameterCategory Category =>
            ReflectionTypeLayout_getDescriptorSetDescriptorRangeCategory(Pointer, (nint)SetIndex, (nint)RangeIndex);
    }
}