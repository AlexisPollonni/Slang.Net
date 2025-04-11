using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Interfaces;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Reflection;

[NativeMarshalling(typeof(HandleStructMarshaller<VariableReflection>))]
public readonly unsafe struct VariableReflection : IEquatable<VariableReflection>, INativeHandleMarshallable<VariableReflection>
{
    private Unmanaged.SlangReflectionVariable* Pointer { get; }
    nint INativeHandleMarshallable<VariableReflection>.Handle => (nint)Pointer;
    public static VariableReflection CreateFromHandle(nint handle) =>
        new((Unmanaged.SlangReflectionVariable*)handle);

    internal VariableReflection(Unmanaged.SlangReflectionVariable* pointer)
    {
        ArgumentNullException.ThrowIfNull(pointer);
        Pointer = pointer;
        UserAttributes = new NativeBoundedReadOnlyList<VariableReflection, UserAttribute>
        {
            Container = this,
            GetCount = @this => (nint)ReflectionApi.ReflectionVariable_GetUserAttributeCount(@this),
            TryGetAt = (@this, index) => ReflectionApi.ReflectionVariable_GetUserAttribute(@this, checked((uint)index))
        };
    }

    public bool Equals(VariableReflection other) => Pointer == other.Pointer;
    public override bool Equals(object? obj) => obj is VariableReflection other && Equals(other);
    public static bool operator ==(VariableReflection a, VariableReflection b) => a.Pointer == b.Pointer;
    public static bool operator !=(VariableReflection a, VariableReflection b) => a.Pointer != b.Pointer;
    public override int GetHashCode() => new nint(Pointer).GetHashCode();

    public string? Name => ReflectionApi.ReflectionVariable_GetName(this);
    public TypeReflection Type => ReflectionApi.ReflectionVariable_GetType(this) 
                                  ?? throw new SlangException($"{nameof(ReflectionApi.ReflectionVariable_GetType)} returned a null pointer");
    
    public bool HasModifier(Unmanaged.ModifierID id) => FindModifier(id) is not null;

    public ModifierReflection? FindModifier(Unmanaged.ModifierID id) =>
        ReflectionApi.ReflectionVariable_FindModifier(this, id);
    
    public IReadOnlyList<UserAttribute> UserAttributes { get; }

    public UserAttribute? FindUserAttributeByName(IGlobalSession globalSession, string name) =>
        ReflectionApi.ReflectionVariable_FindUserAttributeByName(this, globalSession, name);

    public bool HasDefaultValue => ReflectionApi.ReflectionVariable_HasDefaultValue(this);
    public long? DefaultValueInt => ReflectionApi.ReflectionVariable_GetDefaultValueInt(this, out var res) ? res : null;

    public GenericReflection? GenericContainer => ReflectionApi.ReflectionVariable_GetGenericContainer(this);

    public VariableReflection? ApplySpecializations(GenericReflection generic) =>
        ReflectionApi.ReflectionVariable_applySpecializations(this, generic);
}