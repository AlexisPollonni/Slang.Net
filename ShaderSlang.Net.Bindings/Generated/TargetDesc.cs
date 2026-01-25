namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='TargetDesc.xml' path='doc/member[@name="TargetDesc"]/*' />
public unsafe partial struct TargetDesc
{
    /// <include file='TargetDesc.xml' path='doc/member[@name="TargetDesc.structureSize"]/*' />
    [NativeTypeName("size_t")]
    public nuint structureSize;

    /// <include file='TargetDesc.xml' path='doc/member[@name="TargetDesc.format"]/*' />
    [NativeTypeName("SlangCompileTarget")]
    public CompileTarget format;

    /// <include file='TargetDesc.xml' path='doc/member[@name="TargetDesc.profile"]/*' />
    [NativeTypeName("SlangProfileID")]
    public ProfileID profile;

    /// <include file='TargetDesc.xml' path='doc/member[@name="TargetDesc.flags"]/*' />
    [NativeTypeName("SlangTargetFlags")]
    public uint flags;

    /// <include file='TargetDesc.xml' path='doc/member[@name="TargetDesc.floatingPointMode"]/*' />
    [NativeTypeName("SlangFloatingPointMode")]
    public FloatingPointMode floatingPointMode;

    /// <include file='TargetDesc.xml' path='doc/member[@name="TargetDesc.lineDirectiveMode"]/*' />
    [NativeTypeName("SlangLineDirectiveMode")]
    public LineDirectiveMode lineDirectiveMode;

    /// <include file='TargetDesc.xml' path='doc/member[@name="TargetDesc.forceGLSLScalarBufferLayout"]/*' />
    [NativeTypeName("bool")]
    public Boolean forceGLSLScalarBufferLayout;

    /// <include file='TargetDesc.xml' path='doc/member[@name="TargetDesc.compilerOptionEntries"]/*' />
    [NativeTypeName("const CompilerOptionEntry *")]
    public CompilerOptionEntry* compilerOptionEntries;

    /// <include file='TargetDesc.xml' path='doc/member[@name="TargetDesc.compilerOptionEntryCount"]/*' />
    [NativeTypeName("uint32_t")]
    public uint compilerOptionEntryCount;
}
