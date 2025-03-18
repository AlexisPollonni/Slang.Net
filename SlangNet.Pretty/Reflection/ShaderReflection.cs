using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlangNet;

public readonly unsafe struct ShaderReflection : IEquatable<ShaderReflection>
{
    private readonly Unsafe.ShaderReflection* pointer;
    public Unsafe.ShaderReflection* Pointer
    {
        get
        {
            ThrowIfNull();
            return pointer;
        }
    }
    internal SlangProgramLayout* InternalPointer => (SlangProgramLayout*)Pointer;

    internal ShaderReflection(SlangProgramLayout* pointer) : this((Unsafe.ShaderReflection*)pointer) {}
    internal ShaderReflection(Unsafe.ShaderReflection* pointer)
    {
        this.pointer = pointer;
        Parameters = new NativeBoundedReadOnlyList<SlangProgramLayout, VariableLayoutReflection>
        {
            Container = InternalPointer,
            GetCount = program => (nint)Reflection_GetParameterCount(program),
            TryGetAt = (SlangProgramLayout* program, nint index, out VariableLayoutReflection variable) =>
            {
                var ptr = Reflection_GetParameterByIndex(program, checked((uint)index));
                variable = ptr == null ? default : new(ptr);
                return ptr != null;
            }
        };
        TypeParameters = new NativeBoundedReadOnlyList<SlangProgramLayout, TypeParameterReflection>
        {
            Container = InternalPointer,
            GetCount = program => (nint)Reflection_GetTypeParameterCount(program),
            TryGetAt = (SlangProgramLayout* program, nint index, out TypeParameterReflection typeParam) =>
            {
                var ptr = Reflection_GetTypeParameterByIndex(program, checked((uint)index));
                typeParam = ptr == null ? default : new(ptr);
                return ptr != null;
            }
        };
        EntryPoints = new NativeBoundedReadOnlyList<SlangProgramLayout, EntryPointReflection>
        {
            Container = InternalPointer,
            GetCount = program => (nint)Reflection_getEntryPointCount(program),
            TryGetAt = (SlangProgramLayout* program, nint index, out EntryPointReflection entryPoint) =>
            {
                var ptr = Reflection_getEntryPointByIndex(program, checked((nuint)index));
                entryPoint = ptr == null ? default : new(ptr);
                return ptr != null;
            }
        };
        HashedStrings = new NativeBoundedReadOnlyList<SlangProgramLayout, string>
        {
            Container = InternalPointer,
            GetCount = program => checked((nint)Reflection_getHashedStringCount(program)),
            TryGetAt = (SlangProgramLayout* program, nint index, out string hashedString) =>
            {
                nuint countPtr;
                var ptr = Reflection_getHashedString(program, checked((nuint)index), &countPtr);
                hashedString = ptr != null ? Encoding.UTF8.GetString((byte*)ptr, checked((int)countPtr.ToUInt64())) : string.Empty;
                return ptr != null;
            }
        };
    }

    internal void ThrowIfNull()
    {
        if (pointer == null)
            throw new NullReferenceException("This instance of ShaderReflection has a null pointer");
    }

    public bool Equals(ShaderReflection other) => pointer == other.pointer;
    public override bool Equals(object? obj) => obj is ShaderReflection other && Equals(other);
    public static bool operator ==(ShaderReflection a, ShaderReflection b) => a.pointer == b.pointer;
    public static bool operator !=(ShaderReflection a, ShaderReflection b) => a.pointer != b.pointer;
    public override int GetHashCode() => new IntPtr(pointer).GetHashCode();

    public IReadOnlyList<VariableLayoutReflection> Parameters { get; }

    public IReadOnlyList<TypeParameterReflection> TypeParameters { get; }

    public TypeParameterReflection? FindTypeParameter(ReadOnlySpan<byte> name)
    {
        SlangReflectionTypeParameter* paramPtr;
        fixed (byte* namePtr = name)
            paramPtr = Reflection_FindTypeParameter(InternalPointer, (sbyte*)namePtr);
        return paramPtr == null ? null : new(paramPtr);
    }

    public TypeParameterReflection? FindTypeParameter(string name)
    {
        using var nameStr = new Utf8String(name);
        var paramPtr = Reflection_FindTypeParameter(InternalPointer, nameStr);
        return paramPtr == null ? null : new(paramPtr);
    }

    public TypeReflection? FindTypeByName(ReadOnlySpan<byte> name)
    {
        SlangReflectionType* typePtr;
        fixed (byte* namePtr = name)
            typePtr = Reflection_FindTypeByName(InternalPointer, (sbyte*)namePtr);
        return typePtr == null ? null : new(typePtr);
    }

    public TypeReflection? FindTypeByName(string name)
    {
        using var nameStr = new Utf8String(name);
        var typePtr = Reflection_FindTypeByName(InternalPointer, nameStr);
        return typePtr == null ? null : new(typePtr);
    }

    public TypeLayoutReflection? GetTypeLayout(TypeReflection type, LayoutRules rules)
    {
        var layoutPtr = Reflection_GetTypeLayout(InternalPointer, type.InternalPointer, rules);
        return layoutPtr == null ? null : new(layoutPtr);
    }

    public IReadOnlyList<EntryPointReflection> EntryPoints { get; }

    public EntryPointReflection? FindEntryPointByName(ReadOnlySpan<byte> name)
    {
        SlangEntryPointLayout* entryPointPtr;
        fixed (byte* namePtr = name)
            entryPointPtr = Reflection_findEntryPointByName(InternalPointer, (sbyte*)namePtr);
        return entryPointPtr == null ? null : new(entryPointPtr);
    }

    public EntryPointReflection? FindEntryPointByName(string name)
    {
        using var nameStr = new Utf8String(name);
        var entryPointPtr = Reflection_findEntryPointByName(InternalPointer, nameStr);
        return entryPointPtr == null ? null : new(entryPointPtr);
    }

    public ulong GlobalConstantBufferBinding =>
        Reflection_getGlobalConstantBufferBinding(InternalPointer);

    public ulong GlobalConstantBufferSize =>
        Reflection_getGlobalConstantBufferSize(InternalPointer).ToUInt64();

    public TypeReflection? SpecializeType(TypeReflection type, IEnumerable<TypeReflection> specializationArgs, out string? diagnostics)
    {
        var specializationArray = new SlangReflectionType*[specializationArgs.Count()];
        int i = 0;
        foreach (var arg in specializationArgs)
            specializationArray[i++] = arg.InternalPointer;

        using var diagnosticsBlob = new COMPointer<ISlangBlob>();
        SlangReflectionType* specializedTypePtr;
        fixed (SlangReflectionType** specializationPtrs = specializationArray)
            specializedTypePtr = Reflection_specializeType(InternalPointer, type.InternalPointer, specializationArray.Length, specializationPtrs, &diagnosticsBlob.Pointer);
        diagnostics = diagnosticsBlob.AsString();
        return specializedTypePtr == null ? null : new(specializedTypePtr);
    }

    public IReadOnlyList<string> HashedStrings { get; }

    public static uint ComputeStringHash(ReadOnlySpan<byte> chars)
    {
        fixed(byte* charsPtr = chars)
            return SlangApi.ComputeStringHash((sbyte*)charsPtr, new((uint)chars.Length));
    }

    public static uint ComputeStringHash(string chars)
    {
        using var charsStr = new Utf8String(chars);
        return SlangApi.ComputeStringHash(charsStr, (nuint)charsStr.ByteSize);
    }

    public TypeLayoutReflection? GlobalParamsTypeLayout
    {
        get
        {
            var ptr = Reflection_getGlobalParamsTypeLayout(InternalPointer);
            return ptr == null ? null : new(ptr);
        }
    }

    public VariableLayoutReflection? GlobalParamsVarLayout
    {
        get
        {
            var ptr = Reflection_getGlobalParamsVarLayout(InternalPointer);
            return ptr == null ? null : new(ptr);
        }
    }
}
