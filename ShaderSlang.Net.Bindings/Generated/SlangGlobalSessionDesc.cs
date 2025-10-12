using System.Runtime.CompilerServices;

namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='SlangGlobalSessionDesc.xml' path='doc/member[@name="SlangGlobalSessionDesc"]/*' />
public partial struct SlangGlobalSessionDesc
{
    /// <include file='SlangGlobalSessionDesc.xml' path='doc/member[@name="SlangGlobalSessionDesc.structureSize"]/*' />
    [NativeTypeName("uint32_t")]
    public uint structureSize;

    /// <include file='SlangGlobalSessionDesc.xml' path='doc/member[@name="SlangGlobalSessionDesc.apiVersion"]/*' />
    [NativeTypeName("uint32_t")]
    public uint apiVersion;

    /// <include file='SlangGlobalSessionDesc.xml' path='doc/member[@name="SlangGlobalSessionDesc.minLanguageVersion"]/*' />
    [NativeTypeName("uint32_t")]
    public uint minLanguageVersion;

    /// <include file='SlangGlobalSessionDesc.xml' path='doc/member[@name="SlangGlobalSessionDesc.enableGLSL"]/*' />
    [NativeTypeName("bool")]
    public Boolean enableGLSL;

    /// <include file='SlangGlobalSessionDesc.xml' path='doc/member[@name="SlangGlobalSessionDesc.reserved"]/*' />
    [NativeTypeName("uint32_t[16]")]
    public _reserved_e__FixedBuffer reserved;

    /// <include file='_reserved_e__FixedBuffer.xml' path='doc/member[@name="_reserved_e__FixedBuffer"]/*' />
    [InlineArray(16)]
    public partial struct _reserved_e__FixedBuffer
    {
        public uint e0;
    }
}
