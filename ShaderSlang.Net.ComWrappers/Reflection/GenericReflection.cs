using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Reflection;

[NativeMarshalling(typeof(HandleStructMarshaller<GenericReflection>))]
public readonly unsafe struct GenericReflection : IEquatable<GenericReflection>, INativeHandleMarshallable<GenericReflection>
{
    internal Unmanaged.SlangReflectionGeneric* Pointer { get; }
    nint INativeHandleMarshallable<GenericReflection>.Handle => (nint)Pointer;
    public static GenericReflection CreateFromHandle(nint handle) =>
        new((Unmanaged.SlangReflectionGeneric*)handle);

    public GenericReflection(Unmanaged.SlangReflectionGeneric* pointer)
    {
        ArgumentNullException.ThrowIfNull(pointer);
        Pointer = pointer;
        TypeParameters = new NativeBoundedReadOnlyList<GenericReflection, VariableReflection>()
        {
            Container = this,
            GetCount = @this => (nint)ReflectionApi.ReflectionGeneric_GetTypeParameterCount(@this),
            TryGetAt = (@this, index) => ReflectionApi.ReflectionGeneric_GetTypeParameter(@this, (uint)index)
        };
        ValueParameters = new NativeBoundedReadOnlyList<GenericReflection, VariableReflection>()
        {
            Container = this,
            GetCount = @this => (nint)ReflectionApi.ReflectionGeneric_GetValueParameterCount(@this),
            TryGetAt = (@this, index) => ReflectionApi.ReflectionGeneric_GetValueParameter(@this, (uint)index)
        };
    }
    
    public bool Equals(GenericReflection other) =>
        Pointer == other.Pointer;

    public override bool Equals(object? obj) =>
        obj is GenericReflection other && Equals(other);

    public override int GetHashCode() =>
        unchecked((int)(long)Pointer);

    public static bool operator ==(GenericReflection left, GenericReflection right) =>
        left.Equals(right);

    public static bool operator !=(GenericReflection left, GenericReflection right) =>
        !left.Equals(right);

    public DeclReflection? AsDecl => ReflectionApi.ReflectionGeneric_asDecl(this);
    public string? Name => ReflectionApi.ReflectionGeneric_GetName(this);
    public IReadOnlyList<VariableReflection> TypeParameters { get; }
    public IReadOnlyList<VariableReflection> ValueParameters { get; }
    
    public IReadOnlyList<TypeReflection> GetTypeParameterConstraintTypes(VariableReflection typeParam) =>
        new NativeBoundedReadOnlyList<GenericReflection, VariableReflection, TypeReflection>
        {
            Container = this,
            Argument = typeParam,
            GetCount = (@this, arg) => (nint)ReflectionApi.ReflectionGeneric_GetTypeParameterConstraintCount(@this, arg),
            TryGetAt = (@this, arg, index) => ReflectionApi.ReflectionGeneric_GetTypeParameterConstraintType(@this, arg, (uint)index)
        };
    
    
    public DeclReflection? InnerDecl => ReflectionApi.ReflectionGeneric_GetInnerDecl(this);
    public Unmanaged.DeclKind InnerKind => ReflectionApi.ReflectionGeneric_GetInnerKind(this);
    public GenericReflection? OuterGenericContainer => ReflectionApi.ReflectionGeneric_GetOuterGenericContainer(this);

    public TypeReflection? GetConcreteType(VariableReflection typeParam) =>
        ReflectionApi.ReflectionGeneric_GetConcreteType(this, typeParam);

    public long GetConcreteIntVal(VariableReflection valueParam) =>
        ReflectionApi.ReflectionGeneric_GetConcreteIntVal(this, valueParam);

    public GenericReflection? ApplySpecializations(GenericReflection generic) =>
        ReflectionApi.ReflectionGeneric_applySpecializations(this, generic);
}