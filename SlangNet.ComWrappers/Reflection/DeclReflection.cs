using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Reflection;

[NativeMarshalling(typeof(HandleStructMarshaller<DeclReflection>))]
public readonly struct DeclReflection : INativeHandleMarshallable<DeclReflection>
{
    internal unsafe Unmanaged.SlangReflectionDecl* Pointer { get; }
    unsafe nint INativeHandleMarshallable<DeclReflection>.Handle => (nint)Pointer;
    public static unsafe DeclReflection CreateFromHandle(nint handle) =>
        new((Unmanaged.SlangReflectionDecl*)handle);

    public unsafe DeclReflection(Unmanaged.SlangReflectionDecl* pointer)
    {
        ArgumentNullException.ThrowIfNull(pointer);
        Pointer = pointer;
        Children = new NativeBoundedReadOnlyList<DeclReflection, DeclReflection>
        {
            Container = this,
            GetCount = @this => (nint)ReflectionApi.ReflectionDecl_getChildrenCount(@this),
            TryGetAt = (@this, index) => ReflectionApi.ReflectionDecl_getChild(@this, (uint)index)
        };
    }

    public string? Name => ReflectionApi.ReflectionDecl_getName(this);
    public Unmanaged.DeclKind Kind => ReflectionApi.ReflectionDecl_getKind(this);

    public IReadOnlyList<DeclReflection> Children { get; }

    public TypeReflection? Type => ReflectionApi.Reflection_getTypeFromDecl(this);

    public VariableReflection? AsVariable => ReflectionApi.ReflectionDecl_castToVariable(this);
    public FunctionReflection? AsFunction => ReflectionApi.ReflectionDecl_castToFunction(this);
    public GenericReflection? AsGeneric => ReflectionApi.ReflectionDecl_castToGeneric(this);

    public DeclReflection? Parent => ReflectionApi.ReflectionDecl_getParent(this);
    
}