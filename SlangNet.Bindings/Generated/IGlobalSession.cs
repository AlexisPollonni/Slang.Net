using System.Runtime.CompilerServices;

namespace SlangNet.Bindings.Generated;

/// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession"]/*' />
[NativeTypeName("struct IGlobalSession : ISlangUnknown")]
public unsafe partial struct IGlobalSession
{
    public void** lpVtbl;

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, SlangUUID*, void**, int>)(lpVtbl[0]))((IGlobalSession*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, uint>)(lpVtbl[1]))((IGlobalSession*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, uint>)(lpVtbl[2]))((IGlobalSession*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.createSession"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int createSession([NativeTypeName("const SessionDesc &")] SessionDesc* desc, ISession** outSession)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, SessionDesc*, ISession**, int>)(lpVtbl[3]))((IGlobalSession*)Unsafe.AsPointer(ref this), desc, outSession);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.findProfile"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangProfileID")]
    public ProfileID findProfile([NativeTypeName("const char *")] sbyte* name)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, sbyte*, ProfileID>)(lpVtbl[4]))((IGlobalSession*)Unsafe.AsPointer(ref this), name);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.setDownstreamCompilerPath"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setDownstreamCompilerPath([NativeTypeName("SlangPassThrough")] PassThrough passThrough, [NativeTypeName("const char *")] sbyte* path)
    {
        ((delegate* unmanaged[Stdcall]<IGlobalSession*, PassThrough, sbyte*, void>)(lpVtbl[5]))((IGlobalSession*)Unsafe.AsPointer(ref this), passThrough, path);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.setDownstreamCompilerPrelude"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setDownstreamCompilerPrelude([NativeTypeName("SlangPassThrough")] PassThrough passThrough, [NativeTypeName("const char *")] sbyte* preludeText)
    {
        ((delegate* unmanaged[Stdcall]<IGlobalSession*, PassThrough, sbyte*, void>)(lpVtbl[6]))((IGlobalSession*)Unsafe.AsPointer(ref this), passThrough, preludeText);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.getDownstreamCompilerPrelude"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void getDownstreamCompilerPrelude([NativeTypeName("SlangPassThrough")] PassThrough passThrough, ISlangBlob** outPrelude)
    {
        ((delegate* unmanaged[Stdcall]<IGlobalSession*, PassThrough, ISlangBlob**, void>)(lpVtbl[7]))((IGlobalSession*)Unsafe.AsPointer(ref this), passThrough, outPrelude);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.getBuildTagString"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("const char *")]
    public sbyte* getBuildTagString()
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, sbyte*>)(lpVtbl[8]))((IGlobalSession*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.setDefaultDownstreamCompiler"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int setDefaultDownstreamCompiler([NativeTypeName("SlangSourceLanguage")] SourceLanguage sourceLanguage, [NativeTypeName("SlangPassThrough")] PassThrough defaultCompiler)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, SourceLanguage, PassThrough, int>)(lpVtbl[9]))((IGlobalSession*)Unsafe.AsPointer(ref this), sourceLanguage, defaultCompiler);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.getDefaultDownstreamCompiler"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangPassThrough")]
    public PassThrough getDefaultDownstreamCompiler([NativeTypeName("SlangSourceLanguage")] SourceLanguage sourceLanguage)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, SourceLanguage, PassThrough>)(lpVtbl[10]))((IGlobalSession*)Unsafe.AsPointer(ref this), sourceLanguage);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.setLanguagePrelude"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setLanguagePrelude([NativeTypeName("SlangSourceLanguage")] SourceLanguage sourceLanguage, [NativeTypeName("const char *")] sbyte* preludeText)
    {
        ((delegate* unmanaged[Stdcall]<IGlobalSession*, SourceLanguage, sbyte*, void>)(lpVtbl[11]))((IGlobalSession*)Unsafe.AsPointer(ref this), sourceLanguage, preludeText);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.getLanguagePrelude"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void getLanguagePrelude([NativeTypeName("SlangSourceLanguage")] SourceLanguage sourceLanguage, ISlangBlob** outPrelude)
    {
        ((delegate* unmanaged[Stdcall]<IGlobalSession*, SourceLanguage, ISlangBlob**, void>)(lpVtbl[12]))((IGlobalSession*)Unsafe.AsPointer(ref this), sourceLanguage, outPrelude);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.addBuiltins"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void addBuiltins([NativeTypeName("const char *")] sbyte* sourcePath, [NativeTypeName("const char *")] sbyte* sourceString)
    {
        ((delegate* unmanaged[Stdcall]<IGlobalSession*, sbyte*, sbyte*, void>)(lpVtbl[14]))((IGlobalSession*)Unsafe.AsPointer(ref this), sourcePath, sourceString);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.setSharedLibraryLoader"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setSharedLibraryLoader(ISlangSharedLibraryLoader* loader)
    {
        ((delegate* unmanaged[Stdcall]<IGlobalSession*, ISlangSharedLibraryLoader*, void>)(lpVtbl[15]))((IGlobalSession*)Unsafe.AsPointer(ref this), loader);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.getSharedLibraryLoader"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ISlangSharedLibraryLoader* getSharedLibraryLoader()
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, ISlangSharedLibraryLoader*>)(lpVtbl[16]))((IGlobalSession*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.checkCompileTargetSupport"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int checkCompileTargetSupport([NativeTypeName("SlangCompileTarget")] CompileTarget target)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, CompileTarget, int>)(lpVtbl[17]))((IGlobalSession*)Unsafe.AsPointer(ref this), target);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.checkPassThroughSupport"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int checkPassThroughSupport([NativeTypeName("SlangPassThrough")] PassThrough passThrough)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, PassThrough, int>)(lpVtbl[18]))((IGlobalSession*)Unsafe.AsPointer(ref this), passThrough);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.compileCoreModule"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int compileCoreModule([NativeTypeName("slang::CompileCoreModuleFlags")] uint flags)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, uint, int>)(lpVtbl[19]))((IGlobalSession*)Unsafe.AsPointer(ref this), flags);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.loadCoreModule"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int loadCoreModule([NativeTypeName("const void *")] void* coreModule, [NativeTypeName("size_t")] nuint coreModuleSizeInBytes)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, void*, nuint, int>)(lpVtbl[20]))((IGlobalSession*)Unsafe.AsPointer(ref this), coreModule, coreModuleSizeInBytes);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.saveCoreModule"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int saveCoreModule([NativeTypeName("SlangArchiveType")] ArchiveType archiveType, ISlangBlob** outBlob)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, ArchiveType, ISlangBlob**, int>)(lpVtbl[21]))((IGlobalSession*)Unsafe.AsPointer(ref this), archiveType, outBlob);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.findCapability"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangCapabilityID")]
    public CapabilityID findCapability([NativeTypeName("const char *")] sbyte* name)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, sbyte*, CapabilityID>)(lpVtbl[22]))((IGlobalSession*)Unsafe.AsPointer(ref this), name);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.setDownstreamCompilerForTransition"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setDownstreamCompilerForTransition([NativeTypeName("SlangCompileTarget")] CompileTarget source, [NativeTypeName("SlangCompileTarget")] CompileTarget target, [NativeTypeName("SlangPassThrough")] PassThrough compiler)
    {
        ((delegate* unmanaged[Stdcall]<IGlobalSession*, CompileTarget, CompileTarget, PassThrough, void>)(lpVtbl[23]))((IGlobalSession*)Unsafe.AsPointer(ref this), source, target, compiler);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.getDownstreamCompilerForTransition"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangPassThrough")]
    public PassThrough getDownstreamCompilerForTransition([NativeTypeName("SlangCompileTarget")] CompileTarget source, [NativeTypeName("SlangCompileTarget")] CompileTarget target)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, CompileTarget, CompileTarget, PassThrough>)(lpVtbl[24]))((IGlobalSession*)Unsafe.AsPointer(ref this), source, target);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.getCompilerElapsedTime"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void getCompilerElapsedTime(double* outTotalTime, double* outDownstreamTime)
    {
        ((delegate* unmanaged[Stdcall]<IGlobalSession*, double*, double*, void>)(lpVtbl[25]))((IGlobalSession*)Unsafe.AsPointer(ref this), outTotalTime, outDownstreamTime);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.setSPIRVCoreGrammar"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int setSPIRVCoreGrammar([NativeTypeName("const char *")] sbyte* jsonPath)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, sbyte*, int>)(lpVtbl[26]))((IGlobalSession*)Unsafe.AsPointer(ref this), jsonPath);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.parseCommandLineArguments"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int parseCommandLineArguments(int argc, [NativeTypeName("const char *const *")] sbyte** argv, [NativeTypeName("slang::SessionDesc *")] SessionDesc* outSessionDesc, ISlangUnknown** outAuxAllocation)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, int, sbyte**, SessionDesc*, ISlangUnknown**, int>)(lpVtbl[27]))((IGlobalSession*)Unsafe.AsPointer(ref this), argc, argv, outSessionDesc, outAuxAllocation);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.getSessionDescDigest"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getSessionDescDigest([NativeTypeName("slang::SessionDesc *")] SessionDesc* sessionDesc, ISlangBlob** outBlob)
    {
        return ((delegate* unmanaged[Stdcall]<IGlobalSession*, SessionDesc*, ISlangBlob**, int>)(lpVtbl[28]))((IGlobalSession*)Unsafe.AsPointer(ref this), sessionDesc, outBlob);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, SlangUUID*, void**, int> queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, uint> addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, uint> release;

        [NativeTypeName("SlangResult (const SessionDesc &, ISession **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, SessionDesc*, ISession**, int> createSession;

        [NativeTypeName("SlangProfileID (const char *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, sbyte*, ProfileID> findProfile;

        [NativeTypeName("void (SlangPassThrough, const char *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, PassThrough, sbyte*, void> setDownstreamCompilerPath;

        [NativeTypeName("void (SlangPassThrough, const char *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, PassThrough, sbyte*, void> setDownstreamCompilerPrelude;

        [NativeTypeName("void (SlangPassThrough, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, PassThrough, ISlangBlob**, void> getDownstreamCompilerPrelude;

        [NativeTypeName("const char *() __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, sbyte*> getBuildTagString;

        [NativeTypeName("SlangResult (SlangSourceLanguage, SlangPassThrough) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, SourceLanguage, PassThrough, int> setDefaultDownstreamCompiler;

        [NativeTypeName("SlangPassThrough (SlangSourceLanguage) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, SourceLanguage, PassThrough> getDefaultDownstreamCompiler;

        [NativeTypeName("void (SlangSourceLanguage, const char *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, SourceLanguage, sbyte*, void> setLanguagePrelude;

        [NativeTypeName("void (SlangSourceLanguage, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, SourceLanguage, ISlangBlob**, void> getLanguagePrelude;

        [NativeTypeName("void (const char *, const char *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, sbyte*, sbyte*, void> addBuiltins;

        [NativeTypeName("void (ISlangSharedLibraryLoader *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, ISlangSharedLibraryLoader*, void> setSharedLibraryLoader;

        [NativeTypeName("ISlangSharedLibraryLoader *() __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, ISlangSharedLibraryLoader*> getSharedLibraryLoader;

        [NativeTypeName("SlangResult (SlangCompileTarget) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, CompileTarget, int> checkCompileTargetSupport;

        [NativeTypeName("SlangResult (SlangPassThrough) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, PassThrough, int> checkPassThroughSupport;

        [NativeTypeName("SlangResult (CompileCoreModuleFlags) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, uint, int> compileCoreModule;

        [NativeTypeName("SlangResult (const void *, size_t) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, void*, nuint, int> loadCoreModule;

        [NativeTypeName("SlangResult (SlangArchiveType, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, ArchiveType, ISlangBlob**, int> saveCoreModule;

        [NativeTypeName("SlangCapabilityID (const char *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, sbyte*, CapabilityID> findCapability;

        [NativeTypeName("void (SlangCompileTarget, SlangCompileTarget, SlangPassThrough) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, CompileTarget, CompileTarget, PassThrough, void> setDownstreamCompilerForTransition;

        [NativeTypeName("SlangPassThrough (SlangCompileTarget, SlangCompileTarget) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, CompileTarget, CompileTarget, PassThrough> getDownstreamCompilerForTransition;

        [NativeTypeName("void (double *, double *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, double*, double*, void> getCompilerElapsedTime;

        [NativeTypeName("SlangResult (const char *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, sbyte*, int> setSPIRVCoreGrammar;

        [NativeTypeName("SlangResult (int, const char *const *, SessionDesc *, ISlangUnknown **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, int, sbyte**, SessionDesc*, ISlangUnknown**, int> parseCommandLineArguments;

        [NativeTypeName("SlangResult (SessionDesc *, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IGlobalSession*, SessionDesc*, ISlangBlob**, int> getSessionDescDigest;
    }
}
