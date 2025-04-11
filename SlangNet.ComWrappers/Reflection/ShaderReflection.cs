using System.Runtime.InteropServices.Marshalling;
using System.Text;
using SlangNet.ComWrappers.Interfaces;
using SlangNet.ComWrappers.Tools;
using static SlangNet.ComWrappers.Reflection.ReflectionApi;

namespace SlangNet.ComWrappers.Reflection;

//TODO: COMPLETE PROPERTIES
[NativeMarshalling(typeof(HandleStructMarshaller<ShaderReflection>))]
public readonly unsafe struct ShaderReflection : IEquatable<ShaderReflection>, INativeHandleMarshallable<ShaderReflection>
{
    internal Unmanaged.SlangProgramLayout* Pointer { get; }
    nint INativeHandleMarshallable<ShaderReflection>.Handle => (nint)Pointer;
    public static ShaderReflection CreateFromHandle(nint handle) =>
        new((Unmanaged.SlangProgramLayout*)handle);

    internal ShaderReflection(Unmanaged.SlangProgramLayout* pointer)
    {
        ArgumentNullException.ThrowIfNull(pointer);
        Pointer = pointer;
        Parameters = new NativeBoundedReadOnlyList<ShaderReflection, VariableLayoutReflection>
        {
            Container = this,
            GetCount = program => (nint)Reflection_GetParameterCount(program),
            TryGetAt = (program, index) => Reflection_GetParameterByIndex(program, checked((uint)index))
        };
        TypeParameters = new NativeBoundedReadOnlyList<ShaderReflection, TypeParameterReflection>
        {
            Container = this,
            GetCount = program => (nint)Reflection_GetTypeParameterCount(program),
            TryGetAt = (program, index) => Reflection_GetTypeParameterByIndex(program, checked((uint)index))
        };
        EntryPoints = new NativeBoundedReadOnlyList<ShaderReflection, EntryPointReflection>
        {
            Container = this,
            GetCount = program => (nint)Reflection_getEntryPointCount(program),
            TryGetAt = (program, index) => Reflection_getEntryPointByIndex(program, checked((nuint)index))
        };
        HashedStrings = new NativeClassBoundedReadOnlyList<ShaderReflection, string>
        {
            Container = this,
            GetCount = program => checked((nint)Reflection_getHashedStringCount(program)),
            TryGetAt = (program, index) => Reflection_getHashedString(program, checked((nuint)index), out var count)?[..(int)count]
        };
    }


    public bool Equals(ShaderReflection other) => Pointer == other.Pointer;
    public override bool Equals(object? obj) => obj is ShaderReflection other && Equals(other);
    public static bool operator ==(ShaderReflection a, ShaderReflection b) => a.Pointer == b.Pointer;
    public static bool operator !=(ShaderReflection a, ShaderReflection b) => a.Pointer != b.Pointer;
    public override int GetHashCode() => new nint(Pointer).GetHashCode();



    public ISession Session => Reflection_GetSession(this) 
                               ?? throw new SlangException("Could not retrieve Session from program layout, this should not happen!");
    
    public IReadOnlyList<VariableLayoutReflection> Parameters { get; }
    public IReadOnlyList<TypeParameterReflection> TypeParameters { get; }

    public TypeParameterReflection? FindTypeParameter(string name) => Reflection_FindTypeParameter(this, name);
    public TypeReflection? FindTypeByName(string name) => Reflection_FindTypeByName(this, name);

    public TypeLayoutReflection? GetTypeLayout(TypeReflection type, LayoutRules rules) => 
        Reflection_GetTypeLayout(this, type, rules);

    public IReadOnlyList<EntryPointReflection> EntryPoints { get; }
    
    public EntryPointReflection? FindEntryPointByName(string name) => Reflection_findEntryPointByName(this, name);
    public ulong GlobalConstantBufferBinding => Reflection_getGlobalConstantBufferBinding(this);
    public ulong GlobalConstantBufferSize => Reflection_getGlobalConstantBufferSize(this).ToUInt64();

    public TypeReflection? SpecializeType(TypeReflection type, IEnumerable<TypeReflection> specializationArgs, out string? diagnostics)
    {
        var args = specializationArgs.ToArray();
        var resType = Reflection_specializeType(this, type, args.Length, args, out var diagBlob);

        diagnostics = diagBlob.AsString();
        return resType;
    }

    public IReadOnlyList<string> HashedStrings { get; }
    
    public static uint ComputeStringHash(string chars) =>
        ReflectionApi.ComputeStringHash(chars, (nuint)(Encoding.UTF8.GetByteCount(chars) + 1));

    public TypeLayoutReflection? GlobalParamsTypeLayout => Reflection_getGlobalParamsTypeLayout(this);
    public VariableLayoutReflection? GlobalParamsVarLayout => Reflection_getGlobalParamsVarLayout(this);
}
