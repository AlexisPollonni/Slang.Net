using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Tools;
using static SlangNet.ComWrappers.Reflection.ReflectionApi;

namespace SlangNet.ComWrappers.Reflection;

//TODO: Check api parity with native header
[NativeMarshalling(typeof(HandleStructMarshaller<TypeLayoutReflection>))]
public readonly unsafe partial struct TypeLayoutReflection : IEquatable<TypeLayoutReflection>, INativeHandleMarshallable<TypeLayoutReflection>
{
    private Unmanaged.SlangReflectionTypeLayout* Pointer { get; }
    nint INativeHandleMarshallable<TypeLayoutReflection>.Handle => (nint)Pointer;
    public static TypeLayoutReflection CreateFromHandle(nint handle) =>
        new((Unmanaged.SlangReflectionTypeLayout*)handle);

    internal TypeLayoutReflection(Unmanaged.SlangReflectionTypeLayout* pointer)
    {
        ArgumentNullException.ThrowIfNull(pointer);
        Pointer = pointer;
        Fields = new NativeBoundedReadOnlyList<TypeLayoutReflection, VariableLayoutReflection>
        {
            Container = this,
            GetCount = layout => (nint)ReflectionTypeLayout_GetFieldCount(layout),
            TryGetAt = (layout, index) => ReflectionTypeLayout_GetFieldByIndex(layout, (uint)index)
        };
        Categories = new NativeBoundedReadOnlyList<TypeLayoutReflection, ParameterCategory>
        {
            Container = this,
            GetCount = layout => (nint)ReflectionTypeLayout_GetCategoryCount(layout),
            TryGetAt = (layout, index) => ReflectionTypeLayout_GetCategoryByIndex(layout, checked((uint)index))
        };
        BindingRanges = new NativeBoundedReadOnlyList<TypeLayoutReflection, BindingRange>
        {
            Container = this,
            GetCount = layout => checked((nint)ReflectionTypeLayout_getBindingRangeCount(layout)),
            TryGetAt = (layout, index) => new(layout, index)
        };
        DescriptorSets = new NativeBoundedReadOnlyList<TypeLayoutReflection, DescriptorSet>
        {
            Container = this,
            GetCount = layout => checked((nint)ReflectionTypeLayout_getDescriptorSetCount(layout)),
            TryGetAt = (layout, index) => new(layout, index)
        };
    }
    
    public bool Equals(TypeLayoutReflection other) => Pointer == other.Pointer;
    public override bool Equals(object? obj) => obj is TypeLayoutReflection other && Equals(other);
    public static bool operator == (TypeLayoutReflection a, TypeLayoutReflection b) => a.Pointer == b.Pointer;
    public static bool operator != (TypeLayoutReflection a, TypeLayoutReflection b) => a.Pointer != b.Pointer;
    public override int GetHashCode() => new IntPtr(Pointer).GetHashCode();

    public TypeReflection Type =>
        ReflectionTypeLayout_GetType(this) ??
        throw new SlangException($"{nameof(ReflectionTypeLayout_GetType)} returned a null pointer");

    public Unmanaged.TypeKind Kind => ReflectionTypeLayout_getKind(this);

    public ulong GetSize(ParameterCategory category = ParameterCategory.Uniform) =>
        ReflectionTypeLayout_GetSize(this, category).ToUInt64();

    public ulong GetStride(ParameterCategory category = ParameterCategory.Uniform) =>
        ReflectionTypeLayout_GetStride(this, category).ToUInt64();

    public int GetAlignment(ParameterCategory category = ParameterCategory.Uniform) =>
        ReflectionTypeLayout_getAlignment(this, category);

    public ulong GetElementStride(ParameterCategory category) =>
        ReflectionTypeLayout_GetElementStride(this, category).ToUInt64();

    public IReadOnlyList<VariableLayoutReflection> Fields { get; }

    public long FindFieldIndexByName(string name) =>
        ReflectionTypeLayout_findFieldIndexByName(this, name);

    public long GetFieldBindingRangeOffset(long fieldIndex) =>
        ReflectionTypeLayout_getFieldBindingRangeOffset(this, (nint)fieldIndex);

    public VariableLayoutReflection? ExplicitCounter => ReflectionTypeLayout_GetExplicitCounter(this);

    public long ExplicitCounterBindingRangeOffset =>
        ReflectionTypeLayout_getExplicitCounterBindingRangeOffset(this);

    public TypeLayoutReflection? ElementTypeLayout => ReflectionTypeLayout_GetElementTypeLayout(this);

    public VariableLayoutReflection? ElementVarLayout => ReflectionTypeLayout_GetElementVarLayout(this);

    public VariableLayoutReflection? ContainerVarLayout => ReflectionTypeLayout_getContainerVarLayout(this);

    public ParameterCategory ParameterCategory =>
        ReflectionTypeLayout_GetParameterCategory(this);

    public IReadOnlyList<ParameterCategory> Categories { get; }

    public Unmanaged.MatrixLayoutMode MatrixLayoutMode =>
        ReflectionTypeLayout_GetMatrixLayoutMode(this);

    public int GenericParamIndex =>
        ReflectionTypeLayout_getGenericParamIndex(this);

    public TypeLayoutReflection? PendingDataTypeLayout => ReflectionTypeLayout_getPendingDataTypeLayout(this);

    public VariableLayoutReflection? SpecializedTypePendingDataVarLayout => ReflectionTypeLayout_getSpecializedTypePendingDataVarLayout(this);

    public IReadOnlyList<BindingRange> BindingRanges { get; }

    public IReadOnlyList<DescriptorSet> DescriptorSets { get; }
}