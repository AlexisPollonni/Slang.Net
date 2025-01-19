using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='GenericArgReflection.xml' path='doc/member[@name="GenericArgReflection"]/*' />
[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct GenericArgReflection
{
    /// <include file='GenericArgReflection.xml' path='doc/member[@name="GenericArgReflection.typeVal"]/*' />
    [FieldOffset(0)]
    [NativeTypeName("slang::TypeReflection *")]
    public TypeReflection* typeVal;

    /// <include file='GenericArgReflection.xml' path='doc/member[@name="GenericArgReflection.intVal"]/*' />
    [FieldOffset(0)]
    [NativeTypeName("int64_t")]
    public nint intVal;

    /// <include file='GenericArgReflection.xml' path='doc/member[@name="GenericArgReflection.boolVal"]/*' />
    [FieldOffset(0)]
    [NativeTypeName("bool")]
    public byte boolVal;
}
