using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.Bindings;
using ShaderSlang.Net.ComWrappers.Interfaces;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Reflection;

[NativeMarshalling(typeof(HandleStructMarshaller<TypeReflection>))]
public readonly unsafe struct TypeReflection
    : IEquatable<TypeReflection>,
        INativeHandleMarshallable<TypeReflection>
{
    internal Unmanaged.SlangReflectionType* Pointer { get; }
    nint INativeHandleMarshallable<TypeReflection>.Handle => (nint)Pointer;

    public static TypeReflection CreateFromHandle(nint handle) =>
        new((Unmanaged.SlangReflectionType*)handle);

    internal TypeReflection(Unmanaged.SlangReflectionType* pointer)
    {
        ArgumentNullException.ThrowIfNull(pointer);
        Pointer = pointer;
        UserAttributes = new NativeBoundedReadOnlyList<TypeReflection, UserAttribute>
        {
            Container = this,
            GetCount = index => (nint)ReflectionApi.ReflectionType_GetUserAttributeCount(index),
            TryGetAt = (@this, index) =>
                ReflectionApi.ReflectionType_GetUserAttribute(@this, checked((uint)index)),
        };
        Fields = new NativeBoundedReadOnlyList<TypeReflection, VariableReflection>
        {
            Container = this,
            GetCount = index => (nint)ReflectionApi.ReflectionType_GetFieldCount(index),
            TryGetAt = (@this, index) =>
                ReflectionApi.ReflectionType_GetFieldByIndex(@this, checked((uint)index)),
        };
        // this is weird in the Slang API, for now we have a list for the types with null elements for future non-types
        // but for anything further we have to wait for the changes in the Slang API
        SpecializedTypeArgTypes = new NativeBoundedReadOnlyList<TypeReflection, TypeReflection>
        {
            Container = this,
            GetCount = @this =>
                checked((nint)ReflectionApi.ReflectionType_getSpecializedTypeArgCount(@this)),
            TryGetAt = (@this, index) =>
                ReflectionApi.ReflectionType_getSpecializedTypeArgType(@this, index),
        };
    }

    public bool Equals(TypeReflection other) => Pointer == other.Pointer;

    public override bool Equals(object? obj) => obj is TypeReflection other && Equals(other);

    public static bool operator ==(TypeReflection a, TypeReflection b) => a.Pointer == b.Pointer;

    public static bool operator !=(TypeReflection a, TypeReflection b) => a.Pointer != b.Pointer;

    public override int GetHashCode() => new IntPtr(Pointer).GetHashCode();

    public Unmanaged.TypeKind Kind => ReflectionApi.ReflectionType_GetKind(this);
    public IReadOnlyList<VariableReflection> Fields { get; }
    public IReadOnlyList<UserAttribute> UserAttributes { get; }

    public bool IsArray => Kind == Unmanaged.TypeKind.Array;

    //TODO: unwrap array

    public ulong ElementCount => ReflectionApi.ReflectionType_GetElementCount(this).ToUInt64();
    public ulong TotalArrayElementCount
    {
        get
        {
            if (!IsArray)
                return 0;
            ulong result = 1;
            TypeReflection? type = this;
            for (; ; )
            {
                if (!type?.IsArray ?? true)
                    return result;

                result *= type!.Value.ElementCount;
                type = type!.Value.ElementType;
            }
        }
    }
    public TypeReflection? ElementType => ReflectionApi.ReflectionType_GetElementType(this);

    public uint RowCount => ReflectionApi.ReflectionType_GetRowCount(this);
    public uint ColumnCount => ReflectionApi.ReflectionType_GetColumnCount(this);
    public Unmanaged.ScalarType ScalarType => ReflectionApi.ReflectionType_GetScalarType(this);
    public TypeReflection? ResourceResultType =>
        ReflectionApi.ReflectionType_GetResourceResultType(this);
    public Unmanaged.ResourceShape ResourceShape =>
        ReflectionApi.ReflectionType_GetResourceShape(this);
    public Unmanaged.ResourceAccess ResourceAccess =>
        ReflectionApi.ReflectionType_GetResourceAccess(this);

    public string? Name => ReflectionApi.ReflectionType_GetName(this);

    public SlangResult GetFullName(out IBlob nameBlob) =>
        ReflectionApi.ReflectionType_GetFullName(this, out nameBlob);

    public UserAttribute? FindUserAttributeByName(string name) =>
        ReflectionApi.ReflectionType_FindUserAttributeByName(this, name);

    public TypeReflection? ApplySpecializations(GenericReflection generic) =>
        ReflectionApi.ReflectionType_applySpecializations(this, generic);

    public GenericReflection? GenericContainer =>
        ReflectionApi.ReflectionType_GetGenericContainer(this);

    public IReadOnlyList<TypeReflection> SpecializedTypeArgTypes { get; }
}
