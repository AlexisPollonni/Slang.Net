using System;
using System.Collections.Generic;

namespace SlangNet;

public readonly unsafe partial struct TypeLayoutReflection : IEquatable<TypeLayoutReflection>
{
    private readonly Unsafe.TypeLayoutReflection* pointer;
    public Unsafe.TypeLayoutReflection* Pointer
    {
        get
        {
            ThrowIfNull();
            return pointer;
        }
    }
    private SlangReflectionTypeLayout* InternalPointer => (SlangReflectionTypeLayout*)Pointer;

    internal TypeLayoutReflection(SlangReflectionTypeLayout* pointer) : this((Unsafe.TypeLayoutReflection*)pointer) { }
    internal TypeLayoutReflection(Unsafe.TypeLayoutReflection* pointer)
    {
        this.pointer = pointer;
        Fields = new NativeBoundedReadOnlyList<SlangReflectionTypeLayout, VariableLayoutReflection>
        {
            Container = InternalPointer,
            GetCount = internalPointer => (nint)ReflectionTypeLayout_GetFieldCount(internalPointer),
            TryGetAt = (SlangReflectionTypeLayout* internalPointer, nint index, out VariableLayoutReflection variable) =>
            {
                var ptr = ReflectionTypeLayout_GetFieldByIndex(internalPointer, (uint)index);
                variable = ptr == null ? default : new(ptr);
                return ptr != null;
            }
        };
        Categories = new NativeBoundedReadOnlyList<SlangReflectionTypeLayout, ParameterCategory>
        {
            Container = InternalPointer,
            GetCount = type => (nint)ReflectionTypeLayout_GetCategoryCount(type),
            TryGetAt = (SlangReflectionTypeLayout* type, nint index, out ParameterCategory category) =>
            {
                category = ReflectionTypeLayout_GetCategoryByIndex(type, checked((uint)index));
                return true;
            }
        };
        BindingRanges = new NativeBoundedReadOnlyList<SlangReflectionTypeLayout, BindingRange>
        {
            Container = InternalPointer,
            GetCount = container => checked((nint)ReflectionTypeLayout_getBindingRangeCount(container)),
            TryGetAt = (SlangReflectionTypeLayout* type, nint index, out BindingRange bindingRange) =>
            {
                bindingRange = new(type, index);
                return true;
            }
        };
        DescriptorSets = new NativeBoundedReadOnlyList<SlangReflectionTypeLayout, DescriptorSet>
        {
            Container = InternalPointer,
            GetCount = container => checked((nint)ReflectionTypeLayout_getDescriptorSetCount(container)),
            TryGetAt = (SlangReflectionTypeLayout* type, nint index, out DescriptorSet descriptorSet) =>
            {
                descriptorSet = new(type, index);
                return true;
            }
        };
    }

    internal void ThrowIfNull()
    {
        if (pointer == null)
            throw new NullReferenceException("This instance of TypeLayoutReflection has a null pointer");
    }

    public bool Equals(TypeLayoutReflection other) => pointer == other.pointer;
    public override bool Equals(object? obj) => obj is TypeLayoutReflection other && Equals(other);
    public static bool operator == (TypeLayoutReflection a, TypeLayoutReflection b) => a.pointer == b.pointer;
    public static bool operator != (TypeLayoutReflection a, TypeLayoutReflection b) => a.pointer != b.pointer;
    public override int GetHashCode() => new IntPtr(pointer).GetHashCode();

    public TypeReflection Type
    {
        get
        {
            var ptr = ReflectionTypeLayout_GetType(InternalPointer);
            if (ptr == null)
                throw new SlangException($"{nameof(ReflectionTypeLayout_GetType)} returned a null pointer");
            return new(ptr);
        }
    }

    public TypeKind Kind => ReflectionTypeLayout_getKind(InternalPointer);

    public ulong GetSize(ParameterCategory category = ParameterCategory.Uniform) =>
        ReflectionTypeLayout_GetSize(InternalPointer, category).ToUInt64();

    public ulong GetStride(ParameterCategory category = ParameterCategory.Uniform) =>
        ReflectionTypeLayout_GetStride(InternalPointer, category).ToUInt64();

    public int GetAlignment(ParameterCategory category = ParameterCategory.Uniform) =>
        ReflectionTypeLayout_getAlignment(InternalPointer, category);

    public ulong GetElementStride(ParameterCategory category) =>
        ReflectionTypeLayout_GetElementStride(InternalPointer, category).ToUInt64();

    public IReadOnlyList<VariableLayoutReflection> Fields { get; }

    public long FindFieldIndexByName(ReadOnlySpan<byte> name)
    {
        fixed (byte* namePtr = name)
            return ReflectionTypeLayout_findFieldIndexByName(InternalPointer,
                (sbyte*)namePtr, (sbyte*)namePtr + name.Length);
    }

    public long FindFieldIndexByName(string name)
    {
        using var nameStr = new Utf8String(name);
        return ReflectionTypeLayout_findFieldIndexByName(InternalPointer, nameStr, null);
    }

    public long GetFieldBindingRangeOffset(long fieldIndex) =>
        ReflectionTypeLayout_getFieldBindingRangeOffset(InternalPointer, (nint)fieldIndex);

    public VariableLayoutReflection? ExplicitCounter
    {
        get
        {
            var ptr = ReflectionTypeLayout_GetExplicitCounter(InternalPointer);
            return ptr == null ? null : new(ptr);
        }
    }

    public long ExplicitCounterBindingRangeOffset =>
        ReflectionTypeLayout_getExplicitCounterBindingRangeOffset(InternalPointer);

    public TypeLayoutReflection? ElementTypeLayout
    {
        get
        {
            var ptr = ReflectionTypeLayout_GetElementTypeLayout(InternalPointer);
            return ptr == null ? null : new(ptr);
        }
    }

    public VariableLayoutReflection? ElementVarLayout
    {
        get
        {
            var ptr = ReflectionTypeLayout_GetElementVarLayout(InternalPointer);
            return ptr == null ? null : new(ptr);
        }
    }

    public VariableLayoutReflection? ContainerVarLayout
    {
        get
        {
            var ptr = ReflectionTypeLayout_getContainerVarLayout(InternalPointer);
            return ptr == null ? null : new(ptr);
        }
    }

    public ParameterCategory ParameterCategory =>
        ReflectionTypeLayout_GetParameterCategory(InternalPointer);

    public IReadOnlyList<ParameterCategory> Categories { get; }

    public MatrixLayoutMode MatrixLayoutMode =>
        ReflectionTypeLayout_GetMatrixLayoutMode(InternalPointer);

    public int GenericParamIndex =>
        ReflectionTypeLayout_getGenericParamIndex(InternalPointer);

    public TypeLayoutReflection? PendingDataTypeLayout
    {
        get
        {
            var ptr = ReflectionTypeLayout_getPendingDataTypeLayout(InternalPointer);
            return ptr == null ? null : new(ptr);
        }
    }

    public VariableLayoutReflection? SpecializedTypePendingDataVarLayout
    {
        get
        {
            var ptr = ReflectionTypeLayout_getSpecializedTypePendingDataVarLayout(InternalPointer);
            return ptr == null ? null : new(ptr);
        }
    }

    public IReadOnlyList<BindingRange> BindingRanges { get; }

    public IReadOnlyList<DescriptorSet> DescriptorSets { get; }
}