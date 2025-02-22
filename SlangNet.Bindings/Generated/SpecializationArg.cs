using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.Slang;

/// <include file='SpecializationArg.xml' path='doc/member[@name="SpecializationArg"]/*' />
public unsafe partial struct SpecializationArg
{
    /// <include file='SpecializationArg.xml' path='doc/member[@name="SpecializationArg.kind"]/*' />
    [NativeTypeName("slang::SpecializationArg::Kind")]
    public TypeKind kind;

    /// <include file='SpecializationArg.xml' path='doc/member[@name="SpecializationArg.Anonymous"]/*' />
    [NativeTypeName("__AnonymousRecord_slang_L4375_C5")]
    public _Anonymous_e__Union Anonymous;

    /// <include file='_Anonymous_e__Union.xml' path='doc/member[@name="_Anonymous_e__Union.type"]/*' />
    [UnscopedRef]
    public ref TypeReflection* type
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            return ref Anonymous.type;
        }
    }

    /// <include file='TypeKind.xml' path='doc/member[@name="TypeKind"]/*' />
    [NativeTypeName("int32_t")]
    public enum TypeKind
    {
        /// <include file='TypeKind.xml' path='doc/member[@name="TypeKind.Unknown"]/*' />
        Unknown,

        /// <include file='TypeKind.xml' path='doc/member[@name="TypeKind.Type"]/*' />
        Type,
    }

    /// <include file='_Anonymous_e__Union.xml' path='doc/member[@name="_Anonymous_e__Union"]/*' />
    [StructLayout(LayoutKind.Explicit)]
    public unsafe partial struct _Anonymous_e__Union
    {
        /// <include file='_Anonymous_e__Union.xml' path='doc/member[@name="_Anonymous_e__Union.type"]/*' />
        [FieldOffset(0)]
        [NativeTypeName("slang::TypeReflection *")]
        public TypeReflection* type;
    }
}
