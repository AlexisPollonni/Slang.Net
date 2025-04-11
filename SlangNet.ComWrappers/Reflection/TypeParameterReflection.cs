using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Reflection;

[NativeMarshalling(typeof(HandleStructMarshaller<TypeParameterReflection>))]
public readonly unsafe struct TypeParameterReflection : IEquatable<TypeParameterReflection>, INativeHandleMarshallable<TypeParameterReflection>
{
    internal Unmanaged.SlangReflectionTypeParameter* Pointer { get; }
    nint INativeHandleMarshallable<TypeParameterReflection>.Handle => (nint)Pointer;
    public static TypeParameterReflection CreateFromHandle(nint handle) =>
        new((Unmanaged.SlangReflectionTypeParameter*)handle);

    internal TypeParameterReflection(Unmanaged.SlangReflectionTypeParameter* handle)
    {
        ArgumentNullException.ThrowIfNull(handle);
        Pointer = handle;
        Constraints = new NativeBoundedReadOnlyList<TypeParameterReflection, TypeReflection>
        {
            Container = this,
            GetCount = @this => checked((nint)ReflectionApi.ReflectionTypeParameter_GetConstraintCount(@this)),
            TryGetAt = (@this, index) => ReflectionApi.ReflectionTypeParameter_GetConstraintByIndex(@this, checked((uint)index))
        };
    }

    public bool Equals(TypeParameterReflection other) => Pointer == other.Pointer;
    public override bool Equals(object? obj) => obj is TypeParameterReflection other && Equals(other);
    public static bool operator ==(TypeParameterReflection a, TypeParameterReflection b) => a.Pointer == b.Pointer;
    public static bool operator !=(TypeParameterReflection a, TypeParameterReflection b) => a.Pointer != b.Pointer;
    public override int GetHashCode() => new nint(Pointer).GetHashCode();

    public string? Name => ReflectionApi.ReflectionTypeParameter_GetName(this);
    public uint Index => ReflectionApi.ReflectionTypeParameter_GetIndex(this);

    public IReadOnlyList<TypeReflection> Constraints { get; }
}
