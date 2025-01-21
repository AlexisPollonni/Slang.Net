using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.Slang;

/// <include file='SlangReflectionGenericArg.xml' path='doc/member[@name="SlangReflectionGenericArg"]/*' />
[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct SlangReflectionGenericArg
{
    /// <include file='SlangReflectionGenericArg.xml' path='doc/member[@name="SlangReflectionGenericArg.typeVal"]/*' />
    [FieldOffset(0)]
    public SlangReflectionType* typeVal;

    /// <include file='SlangReflectionGenericArg.xml' path='doc/member[@name="SlangReflectionGenericArg.intVal"]/*' />
    [FieldOffset(0)]
    [NativeTypeName("int64_t")]
    public nint intVal;

    /// <include file='SlangReflectionGenericArg.xml' path='doc/member[@name="SlangReflectionGenericArg.boolVal"]/*' />
    [FieldOffset(0)]
    [NativeTypeName("bool")]
    public byte boolVal;
}
