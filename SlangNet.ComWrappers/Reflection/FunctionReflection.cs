using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers;
using SlangNet.ComWrappers.Tools;

namespace SlangNet;

[NativeMarshalling(typeof(HandleStructMarshaller<FunctionReflection>))]
public readonly unsafe struct FunctionReflection : IEquatable<FunctionReflection>, INativeHandleMarshallable<FunctionReflection>
{
    internal Unmanaged.SlangReflectionFunction* Pointer { get; }
    nint INativeHandleMarshallable<FunctionReflection>.Handle => (nint)Pointer;

    public static FunctionReflection CreateFromHandle(nint handle) =>
        new((Unmanaged.SlangReflectionFunction*)handle);

    public bool Equals(FunctionReflection other) =>
        Pointer == other.Pointer;

    public override bool Equals(object? obj) =>
        obj is FunctionReflection other && Equals(other);

    public override int GetHashCode() =>
        unchecked((int)(long)Pointer);

    public static bool operator ==(FunctionReflection left, FunctionReflection right) =>
        left.Equals(right);

    public static bool operator !=(FunctionReflection left, FunctionReflection right) =>
        !left.Equals(right);
    
    public FunctionReflection(Unmanaged.SlangReflectionFunction* pointer)
    {
        ArgumentNullException.ThrowIfNull(pointer);
        Pointer = pointer;
        Parameters = new NativeBoundedReadOnlyList<FunctionReflection, VariableReflection>()
        {
            Container = this,
            GetCount = @this => (nint)ReflectionApi.ReflectionFunction_GetParameterCount(@this),
            TryGetAt = (@this, index) => ReflectionApi.ReflectionFunction_GetParameter(@this, (uint)index)
        };
        UserAttributes = new NativeBoundedReadOnlyList<FunctionReflection, UserAttribute>()
        {
            Container = this,
            GetCount = @this => (nint)ReflectionApi.ReflectionFunction_GetUserAttributeCount(@this),
            TryGetAt = (@this, index) => ReflectionApi.ReflectionFunction_GetUserAttribute(@this, (uint)index)
        };
        Overloads = new NativeBoundedReadOnlyList<FunctionReflection, FunctionReflection>
        {
            Container = this,
            GetCount = @this => (nint)ReflectionApi.ReflectionFunction_getOverloadCount(@this),
            TryGetAt = (@this, index) => ReflectionApi.ReflectionFunction_getOverload(@this, (uint)index)
        };
    }

    public string? Name => ReflectionApi.ReflectionFunction_GetName(this);
    public TypeReflection? ReturnType => ReflectionApi.ReflectionFunction_GetResultType(this);
    
    public IReadOnlyList<VariableReflection> Parameters { get; }
    public IReadOnlyList<UserAttribute> UserAttributes { get; }

    public UserAttribute? FindAttributeByName(IGlobalSession globalSession, string name) =>
        ReflectionApi.ReflectionFunction_FindUserAttributeByName(this, globalSession, name);

    public ModifierReflection? FindModifier(Unmanaged.ModifierID id) =>
        ReflectionApi.ReflectionFunction_FindModifier(this, id);

    public GenericReflection? GenericContainer => ReflectionApi.ReflectionFunction_GetGenericContainer(this);

    public FunctionReflection? ApplySpecializations(GenericReflection generic) =>
        ReflectionApi.ReflectionFunction_applySpecializations(this, generic);

    public FunctionReflection? SpecializeWithArgTypes(ReadOnlySpan<TypeReflection> argTypes) =>
        ReflectionApi.ReflectionFunction_specializeWithArgTypes(this, argTypes.Length, argTypes);

    public bool IsOverloaded => ReflectionApi.ReflectionFunction_isOverloaded(this);
    
    public IReadOnlyList<FunctionReflection> Overloads { get; }

}