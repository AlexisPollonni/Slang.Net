using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Tools;
using static SlangNet.ComWrappers.Reflection.ReflectionApi;

namespace SlangNet.ComWrappers.Reflection;

[NativeMarshalling(typeof(HandleStructMarshaller<VariableLayoutReflection>))]
public readonly unsafe struct VariableLayoutReflection : IEquatable<VariableLayoutReflection>, INativeHandleMarshallable<VariableLayoutReflection>
{
    private Unmanaged.SlangReflectionVariableLayout* Pointer { get; }
    nint INativeHandleMarshallable<VariableLayoutReflection>.Handle => (nint)Pointer;
    public static VariableLayoutReflection CreateFromHandle(nint handle) =>
        new((Unmanaged.SlangReflectionVariableLayout*)handle);

    internal VariableLayoutReflection(Unmanaged.SlangReflectionVariableLayout* pointer)
    {
        ArgumentNullException.ThrowIfNull(pointer);
        Pointer = pointer;
    }

    public bool Equals(VariableLayoutReflection other) => Pointer == other.Pointer;
    public override bool Equals(object? obj) => obj is VariableLayoutReflection other && Equals(other);
    public static bool operator ==(VariableLayoutReflection a, VariableLayoutReflection b) => a.Pointer == b.Pointer;
    public static bool operator !=(VariableLayoutReflection a, VariableLayoutReflection b) => a.Pointer != b.Pointer;
    public override int GetHashCode() => new nint(Pointer).GetHashCode();

    public VariableReflection Variable =>
        ReflectionVariableLayout_GetVariable(this)??
        throw new SlangException($"{nameof(ReflectionVariableLayout_GetVariable)} returned a null pointer");

    public string? Name => Variable.Name;

    public ModifierReflection? FindModifier(Unmanaged.ModifierID id) =>
        Variable.FindModifier(id);
    
    public TypeLayoutReflection TypeLayout =>
        ReflectionVariableLayout_GetTypeLayout(this) ??
        throw new SlangException($"{nameof(ReflectionVariableLayout_GetTypeLayout)} returned a null pointer");

    public ParameterCategory Category => TypeLayout.ParameterCategory;
    public IReadOnlyList<ParameterCategory> Categories => TypeLayout.Categories;
    
    public ulong GetOffset(ParameterCategory category = ParameterCategory.Uniform) =>
        ReflectionVariableLayout_GetOffset(this, category).ToUInt64();

    public TypeReflection? Type => Variable.Type;
    
    public uint BindingIndex => ReflectionParameter_GetBindingIndex(this);
    public uint BindingSpace => ReflectionParameter_GetBindingSpace(this);

    public nuint GetBindingSpace(ParameterCategory category) =>
        ReflectionVariableLayout_GetSpace(this, category);

    private Unmanaged.ImageFormat ImageFormat => ReflectionVariableLayout_GetImageFormat(this);
    
    public string? SemanticName => ReflectionVariableLayout_GetSemanticName(this);
    public ulong SemanticIndex => ReflectionVariableLayout_GetSemanticIndex(this).ToUInt64();
    public Unmanaged.Stage Stage => ReflectionVariableLayout_getStage(this);

    public VariableLayoutReflection? PendingDataLayout => ReflectionVariableLayout_getPendingDataLayout(this);
}