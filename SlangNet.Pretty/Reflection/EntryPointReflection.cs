using System;
using System.Collections.Generic;

namespace SlangNet;

public readonly unsafe struct EntryPointReflection : IEquatable<EntryPointReflection>
{
    private readonly Unsafe.EntryPointReflection* pointer;
    public Unsafe.EntryPointReflection* Pointer
    {
        get
        {
            ThrowIfNull();
            return pointer;
        }
    }
    internal SlangEntryPointLayout* InternalPointer => (SlangEntryPointLayout*)Pointer;

    internal EntryPointReflection(SlangEntryPointLayout* pointer) : this((Unsafe.EntryPointReflection*)pointer) {}
    internal EntryPointReflection(Unsafe.EntryPointReflection* pointer)
    {
        this.pointer = pointer;
        Parameters = new NativeBoundedReadOnlyList<SlangEntryPointLayout, VariableLayoutReflection>
        {
            Container = InternalPointer,
            GetCount = container => (nint)ReflectionEntryPoint_getParameterCount(container),
            TryGetAt = (SlangEntryPointLayout* entryPoint, nint index, out VariableLayoutReflection variable) =>
            {
                var ptr = ReflectionEntryPoint_getParameterByIndex(entryPoint, checked((uint)index));
                variable = ptr == null ? default : new(ptr);
                return ptr != null;
            }
        };
    }

    internal void ThrowIfNull()
    {
        if (pointer == null)
            throw new NullReferenceException("This instance of EntryPointReflection has a null pointer");
    }

    public bool Equals(EntryPointReflection other) => pointer == other.pointer;
    public override bool Equals(object? obj) => obj is EntryPointReflection other && Equals(other);
    public static bool operator ==(EntryPointReflection a, EntryPointReflection b) => a.pointer == b.pointer;
    public static bool operator !=(EntryPointReflection a, EntryPointReflection b) => a.pointer != b.pointer;
    public override int GetHashCode() => new IntPtr(pointer).GetHashCode();

    public string Name =>
        InteropUtils.PtrToStringUTF8(ReflectionEntryPoint_getName(InternalPointer)) ??
        throw new NullReferenceException("ReflectionEntryPoint_getName returned a null pointer");

    public string OverrideName =>
        InteropUtils.PtrToStringUTF8(ReflectionEntryPoint_getNameOverride(InternalPointer)) ??
        throw new NullReferenceException("ReflectionEntryPoint_getOverrideName returned a null pointer");

    public IReadOnlyList<VariableLayoutReflection> Parameters { get; }
    
    public Stage Stage =>
        ReflectionEntryPoint_getStage(InternalPointer);

    private const int MaxComputeAxes = 3;
    public nuint[] ComputeThreadGroupSize
    {
        get
        {
            var axes = new nuint[MaxComputeAxes];
            fixed (nuint* axesPtr = axes)
                ReflectionEntryPoint_getComputeThreadGroupSize(InternalPointer, MaxComputeAxes, axesPtr);
            return axes;
        }
    }

    public bool UsesAnySampleRateInput =>
        ReflectionEntryPoint_usesAnySampleRateInput(InternalPointer) != 0;

    public VariableLayoutReflection? VarLayout
    {
        get
        {
            var ptr = ReflectionEntryPoint_getVarLayout(InternalPointer);
            return ptr == null ? null : new(ptr);
        }
    }

    public VariableLayoutReflection? ResultVarLayout
    {
        get
        {
            var ptr = ReflectionEntryPoint_getResultVarLayout(InternalPointer);
            return ptr == null ? null : new(ptr);
        }
    }

    public bool HasDefaultConstantBuffer =>
        ReflectionEntryPoint_hasDefaultConstantBuffer(InternalPointer) != 0; 
}
