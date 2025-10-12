namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='SessionDesc.xml' path='doc/member[@name="SessionDesc"]/*' />
public unsafe partial struct SessionDesc
{
    /// <include file='SessionDesc.xml' path='doc/member[@name="SessionDesc.structureSize"]/*' />
    [NativeTypeName("size_t")]
    public nuint structureSize;

    /// <include file='SessionDesc.xml' path='doc/member[@name="SessionDesc.targets"]/*' />
    [NativeTypeName("const TargetDesc *")]
    public TargetDesc* targets;

    /// <include file='SessionDesc.xml' path='doc/member[@name="SessionDesc.targetCount"]/*' />
    [NativeTypeName("SlangInt")]
    public nint targetCount;

    /// <include file='SessionDesc.xml' path='doc/member[@name="SessionDesc.flags"]/*' />
    [NativeTypeName("slang::SessionFlags")]
    public uint flags;

    /// <include file='SessionDesc.xml' path='doc/member[@name="SessionDesc.defaultMatrixLayoutMode"]/*' />
    [NativeTypeName("SlangMatrixLayoutMode")]
    public MatrixLayoutMode defaultMatrixLayoutMode;

    /// <include file='SessionDesc.xml' path='doc/member[@name="SessionDesc.searchPaths"]/*' />
    [NativeTypeName("const char *const *")]
    public sbyte** searchPaths;

    /// <include file='SessionDesc.xml' path='doc/member[@name="SessionDesc.searchPathCount"]/*' />
    [NativeTypeName("SlangInt")]
    public nint searchPathCount;

    /// <include file='SessionDesc.xml' path='doc/member[@name="SessionDesc.preprocessorMacros"]/*' />
    [NativeTypeName("const PreprocessorMacroDesc *")]
    public PreprocessorMacroDesc* preprocessorMacros;

    /// <include file='SessionDesc.xml' path='doc/member[@name="SessionDesc.preprocessorMacroCount"]/*' />
    [NativeTypeName("SlangInt")]
    public nint preprocessorMacroCount;

    /// <include file='SessionDesc.xml' path='doc/member[@name="SessionDesc.fileSystem"]/*' />
    public ISlangFileSystem* fileSystem;

    /// <include file='SessionDesc.xml' path='doc/member[@name="SessionDesc.enableEffectAnnotations"]/*' />
    [NativeTypeName("bool")]
    public Boolean enableEffectAnnotations;

    /// <include file='SessionDesc.xml' path='doc/member[@name="SessionDesc.allowGLSLSyntax"]/*' />
    [NativeTypeName("bool")]
    public Boolean allowGLSLSyntax;

    /// <include file='SessionDesc.xml' path='doc/member[@name="SessionDesc.compilerOptionEntries"]/*' />
    [NativeTypeName("slang::CompilerOptionEntry *")]
    public CompilerOptionEntry* compilerOptionEntries;

    /// <include file='SessionDesc.xml' path='doc/member[@name="SessionDesc.compilerOptionEntryCount"]/*' />
    [NativeTypeName("uint32_t")]
    public uint compilerOptionEntryCount;

    /// <include file='SessionDesc.xml' path='doc/member[@name="SessionDesc.skipSPIRVValidation"]/*' />
    [NativeTypeName("bool")]
    public Boolean skipSPIRVValidation;
}
