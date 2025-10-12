using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Reflection;

[NativeMarshalling(typeof(HandleStructMarshaller<ModifierReflection>))]
public readonly unsafe struct ModifierReflection
    : IEquatable<ModifierReflection>,
        INativeHandleMarshallable<ModifierReflection>
{
    internal Unmanaged.SlangReflectionModifier* Pointer { get; }
    nint INativeHandleMarshallable<ModifierReflection>.Handle => (nint)Pointer;

    public static ModifierReflection CreateFromHandle(nint handle) =>
        new((Unmanaged.SlangReflectionModifier*)handle);

    public ModifierReflection(Unmanaged.SlangReflectionModifier* pointer)
    {
        Pointer = pointer;
        ArgumentNullException.ThrowIfNull(pointer);
    }

    public bool Equals(ModifierReflection other) => Pointer == other.Pointer;

    public override bool Equals(object? obj) => obj is ModifierReflection other && Equals(other);

    public override int GetHashCode() => unchecked((int)(long)Pointer);

    public static bool operator ==(ModifierReflection left, ModifierReflection right) =>
        left.Equals(right);

    public static bool operator !=(ModifierReflection left, ModifierReflection right) =>
        !left.Equals(right);
}
