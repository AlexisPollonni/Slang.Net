using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.Bindings;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Reflection;

[NativeMarshalling(typeof(HandleStructMarshaller<UserAttribute>))]
public readonly unsafe struct UserAttribute : IEquatable<UserAttribute>, INativeHandleMarshallable<UserAttribute>
{
    internal Unmanaged.SlangReflectionUserAttribute* Pointer { get; }
    nint INativeHandleMarshallable<UserAttribute>.Handle => (nint)Pointer;
    public static UserAttribute CreateFromHandle(nint handle) =>
        new((Unmanaged.SlangReflectionUserAttribute*)handle);

    internal UserAttribute(Unmanaged.SlangReflectionUserAttribute* pointer)
    {
        ArgumentNullException.ThrowIfNull(pointer);
        Pointer = pointer;
        Arguments = new NativeBoundedReadOnlyList<UserAttribute, UserAttributeArgument>
        {
            Container = this,
            GetCount = @this => (nint)ReflectionApi.ReflectionUserAttribute_GetArgumentCount(@this),
            TryGetAt = (@this, index) => new()
            {
                Attribute = @this,
                Index = checked((uint)index)
            }
        };
    }


    public bool Equals(UserAttribute other) => Pointer == other.Pointer;
    public override bool Equals(object? obj) => obj is UserAttribute other && Equals(other);
    public static bool operator ==(UserAttribute a, UserAttribute b) => a.Pointer == b.Pointer;
    public static bool operator !=(UserAttribute a, UserAttribute b) => a.Pointer != b.Pointer;
    public override int GetHashCode() => new IntPtr(Pointer).GetHashCode();

    public string? Name => ReflectionApi.ReflectionUserAttribute_GetName(this);
    public IReadOnlyList<UserAttributeArgument> Arguments { get; }
}


//TODO: add source gen
//[GenerateThrowingMethods]
public readonly unsafe partial struct UserAttributeArgument : IEquatable<UserAttributeArgument>
{
    internal UserAttribute Attribute { get; init; }
    public uint Index { get; internal init; }

    public bool Equals(UserAttributeArgument arg) => Attribute == arg.Attribute && Index == arg.Index;
    public override bool Equals(object? obj) => obj is UserAttributeArgument arg && Equals(arg);
    public override int GetHashCode() => HashCode.Combine(new nint(Attribute.Pointer), Index);
    public static bool operator ==(UserAttributeArgument left, UserAttributeArgument right) => left.Equals(right);
    public static bool operator !=(UserAttributeArgument left, UserAttributeArgument right) => !(left == right);

    public SlangResult TryAsInt(out int value) =>
        ReflectionApi.ReflectionUserAttribute_GetArgumentValueInt(Attribute, Index, out value);

    public SlangResult TryAsFloat(out float value) =>
        ReflectionApi.ReflectionUserAttribute_GetArgumentValueFloat(Attribute, Index, out value);

    public string? TryAsString() =>
        ReflectionApi.ReflectionUserAttribute_GetArgumentValueString(Attribute, Index, out var count)?[..(int)count];

    public string AsString() =>
        TryAsString() ??
        throw new SlangException("User attribute argument cannot be returned as string");
}
