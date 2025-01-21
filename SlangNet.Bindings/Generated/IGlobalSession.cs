using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.Slang;

/// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession"]/*' />
[Guid("C140B5FD-0C78-452E-BA7C-1A1E70C7F71C")]
[NativeTypeName("struct IGlobalSession : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct IGlobalSession
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(IGlobalSession* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IGlobalSession* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IGlobalSession* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _createSession(IGlobalSession* pThis, [NativeTypeName("const SessionDesc &")] SessionDesc* desc, ISession** outSession);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangProfileID")]
    public delegate ProfileID _findProfile(IGlobalSession* pThis, [NativeTypeName("const char *")] sbyte* name);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setDownstreamCompilerPath(IGlobalSession* pThis, [NativeTypeName("SlangPassThrough")] PassThrough passThrough, [NativeTypeName("const char *")] sbyte* path);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setDownstreamCompilerPrelude(IGlobalSession* pThis, [NativeTypeName("SlangPassThrough")] PassThrough passThrough, [NativeTypeName("const char *")] sbyte* preludeText);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _getDownstreamCompilerPrelude(IGlobalSession* pThis, [NativeTypeName("SlangPassThrough")] PassThrough passThrough, ISlangBlob** outPrelude);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("const char *")]
    public delegate sbyte* _getBuildTagString(IGlobalSession* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _setDefaultDownstreamCompiler(IGlobalSession* pThis, [NativeTypeName("SlangSourceLanguage")] SourceLanguage sourceLanguage, [NativeTypeName("SlangPassThrough")] PassThrough defaultCompiler);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangPassThrough")]
    public delegate PassThrough _getDefaultDownstreamCompiler(IGlobalSession* pThis, [NativeTypeName("SlangSourceLanguage")] SourceLanguage sourceLanguage);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setLanguagePrelude(IGlobalSession* pThis, [NativeTypeName("SlangSourceLanguage")] SourceLanguage sourceLanguage, [NativeTypeName("const char *")] sbyte* preludeText);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _getLanguagePrelude(IGlobalSession* pThis, [NativeTypeName("SlangSourceLanguage")] SourceLanguage sourceLanguage, ISlangBlob** outPrelude);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _addBuiltins(IGlobalSession* pThis, [NativeTypeName("const char *")] sbyte* sourcePath, [NativeTypeName("const char *")] sbyte* sourceString);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setSharedLibraryLoader(IGlobalSession* pThis, ISlangSharedLibraryLoader* loader);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate ISlangSharedLibraryLoader* _getSharedLibraryLoader(IGlobalSession* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _checkCompileTargetSupport(IGlobalSession* pThis, [NativeTypeName("SlangCompileTarget")] CompileTarget target);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _checkPassThroughSupport(IGlobalSession* pThis, [NativeTypeName("SlangPassThrough")] PassThrough passThrough);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _compileCoreModule(IGlobalSession* pThis, [NativeTypeName("slang::CompileCoreModuleFlags")] uint flags);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _loadCoreModule(IGlobalSession* pThis, [NativeTypeName("const void *")] void* coreModule, [NativeTypeName("size_t")] nuint coreModuleSizeInBytes);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _saveCoreModule(IGlobalSession* pThis, [NativeTypeName("SlangArchiveType")] ArchiveType archiveType, ISlangBlob** outBlob);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangCapabilityID")]
    public delegate CapabilityID _findCapability(IGlobalSession* pThis, [NativeTypeName("const char *")] sbyte* name);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setDownstreamCompilerForTransition(IGlobalSession* pThis, [NativeTypeName("SlangCompileTarget")] CompileTarget source, [NativeTypeName("SlangCompileTarget")] CompileTarget target, [NativeTypeName("SlangPassThrough")] PassThrough compiler);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangPassThrough")]
    public delegate PassThrough _getDownstreamCompilerForTransition(IGlobalSession* pThis, [NativeTypeName("SlangCompileTarget")] CompileTarget source, [NativeTypeName("SlangCompileTarget")] CompileTarget target);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _getCompilerElapsedTime(IGlobalSession* pThis, double* outTotalTime, double* outDownstreamTime);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _setSPIRVCoreGrammar(IGlobalSession* pThis, [NativeTypeName("const char *")] sbyte* jsonPath);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _parseCommandLineArguments(IGlobalSession* pThis, int argc, [NativeTypeName("const char *const *")] sbyte** argv, [NativeTypeName("slang::SessionDesc *")] SessionDesc* outSessionDesc, ISlangUnknown** outAuxAllocation);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getSessionDescDigest(IGlobalSession* pThis, [NativeTypeName("slang::SessionDesc *")] SessionDesc* sessionDesc, ISlangBlob** outBlob);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((IGlobalSession*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((IGlobalSession*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((IGlobalSession*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.createSession"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int createSession([NativeTypeName("const SessionDesc &")] SessionDesc* desc, ISession** outSession)
    {
        return Marshal.GetDelegateForFunctionPointer<_createSession>(lpVtbl->createSession)((IGlobalSession*)Unsafe.AsPointer(ref this), desc, outSession);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.findProfile"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangProfileID")]
    public ProfileID findProfile([NativeTypeName("const char *")] sbyte* name)
    {
        return Marshal.GetDelegateForFunctionPointer<_findProfile>(lpVtbl->findProfile)((IGlobalSession*)Unsafe.AsPointer(ref this), name);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.setDownstreamCompilerPath"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setDownstreamCompilerPath([NativeTypeName("SlangPassThrough")] PassThrough passThrough, [NativeTypeName("const char *")] sbyte* path)
    {
        Marshal.GetDelegateForFunctionPointer<_setDownstreamCompilerPath>(lpVtbl->setDownstreamCompilerPath)((IGlobalSession*)Unsafe.AsPointer(ref this), passThrough, path);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.setDownstreamCompilerPrelude"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setDownstreamCompilerPrelude([NativeTypeName("SlangPassThrough")] PassThrough passThrough, [NativeTypeName("const char *")] sbyte* preludeText)
    {
        Marshal.GetDelegateForFunctionPointer<_setDownstreamCompilerPrelude>(lpVtbl->setDownstreamCompilerPrelude)((IGlobalSession*)Unsafe.AsPointer(ref this), passThrough, preludeText);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.getDownstreamCompilerPrelude"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void getDownstreamCompilerPrelude([NativeTypeName("SlangPassThrough")] PassThrough passThrough, ISlangBlob** outPrelude)
    {
        Marshal.GetDelegateForFunctionPointer<_getDownstreamCompilerPrelude>(lpVtbl->getDownstreamCompilerPrelude)((IGlobalSession*)Unsafe.AsPointer(ref this), passThrough, outPrelude);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.getBuildTagString"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("const char *")]
    public sbyte* getBuildTagString()
    {
        return Marshal.GetDelegateForFunctionPointer<_getBuildTagString>(lpVtbl->getBuildTagString)((IGlobalSession*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.setDefaultDownstreamCompiler"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int setDefaultDownstreamCompiler([NativeTypeName("SlangSourceLanguage")] SourceLanguage sourceLanguage, [NativeTypeName("SlangPassThrough")] PassThrough defaultCompiler)
    {
        return Marshal.GetDelegateForFunctionPointer<_setDefaultDownstreamCompiler>(lpVtbl->setDefaultDownstreamCompiler)((IGlobalSession*)Unsafe.AsPointer(ref this), sourceLanguage, defaultCompiler);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.getDefaultDownstreamCompiler"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangPassThrough")]
    public PassThrough getDefaultDownstreamCompiler([NativeTypeName("SlangSourceLanguage")] SourceLanguage sourceLanguage)
    {
        return Marshal.GetDelegateForFunctionPointer<_getDefaultDownstreamCompiler>(lpVtbl->getDefaultDownstreamCompiler)((IGlobalSession*)Unsafe.AsPointer(ref this), sourceLanguage);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.setLanguagePrelude"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setLanguagePrelude([NativeTypeName("SlangSourceLanguage")] SourceLanguage sourceLanguage, [NativeTypeName("const char *")] sbyte* preludeText)
    {
        Marshal.GetDelegateForFunctionPointer<_setLanguagePrelude>(lpVtbl->setLanguagePrelude)((IGlobalSession*)Unsafe.AsPointer(ref this), sourceLanguage, preludeText);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.getLanguagePrelude"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void getLanguagePrelude([NativeTypeName("SlangSourceLanguage")] SourceLanguage sourceLanguage, ISlangBlob** outPrelude)
    {
        Marshal.GetDelegateForFunctionPointer<_getLanguagePrelude>(lpVtbl->getLanguagePrelude)((IGlobalSession*)Unsafe.AsPointer(ref this), sourceLanguage, outPrelude);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.addBuiltins"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void addBuiltins([NativeTypeName("const char *")] sbyte* sourcePath, [NativeTypeName("const char *")] sbyte* sourceString)
    {
        Marshal.GetDelegateForFunctionPointer<_addBuiltins>(lpVtbl->addBuiltins)((IGlobalSession*)Unsafe.AsPointer(ref this), sourcePath, sourceString);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.setSharedLibraryLoader"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setSharedLibraryLoader(ISlangSharedLibraryLoader* loader)
    {
        Marshal.GetDelegateForFunctionPointer<_setSharedLibraryLoader>(lpVtbl->setSharedLibraryLoader)((IGlobalSession*)Unsafe.AsPointer(ref this), loader);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.getSharedLibraryLoader"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ISlangSharedLibraryLoader* getSharedLibraryLoader()
    {
        return Marshal.GetDelegateForFunctionPointer<_getSharedLibraryLoader>(lpVtbl->getSharedLibraryLoader)((IGlobalSession*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.checkCompileTargetSupport"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int checkCompileTargetSupport([NativeTypeName("SlangCompileTarget")] CompileTarget target)
    {
        return Marshal.GetDelegateForFunctionPointer<_checkCompileTargetSupport>(lpVtbl->checkCompileTargetSupport)((IGlobalSession*)Unsafe.AsPointer(ref this), target);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.checkPassThroughSupport"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int checkPassThroughSupport([NativeTypeName("SlangPassThrough")] PassThrough passThrough)
    {
        return Marshal.GetDelegateForFunctionPointer<_checkPassThroughSupport>(lpVtbl->checkPassThroughSupport)((IGlobalSession*)Unsafe.AsPointer(ref this), passThrough);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.compileCoreModule"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int compileCoreModule([NativeTypeName("slang::CompileCoreModuleFlags")] uint flags)
    {
        return Marshal.GetDelegateForFunctionPointer<_compileCoreModule>(lpVtbl->compileCoreModule)((IGlobalSession*)Unsafe.AsPointer(ref this), flags);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.loadCoreModule"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int loadCoreModule([NativeTypeName("const void *")] void* coreModule, [NativeTypeName("size_t")] nuint coreModuleSizeInBytes)
    {
        return Marshal.GetDelegateForFunctionPointer<_loadCoreModule>(lpVtbl->loadCoreModule)((IGlobalSession*)Unsafe.AsPointer(ref this), coreModule, coreModuleSizeInBytes);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.saveCoreModule"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int saveCoreModule([NativeTypeName("SlangArchiveType")] ArchiveType archiveType, ISlangBlob** outBlob)
    {
        return Marshal.GetDelegateForFunctionPointer<_saveCoreModule>(lpVtbl->saveCoreModule)((IGlobalSession*)Unsafe.AsPointer(ref this), archiveType, outBlob);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.findCapability"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangCapabilityID")]
    public CapabilityID findCapability([NativeTypeName("const char *")] sbyte* name)
    {
        return Marshal.GetDelegateForFunctionPointer<_findCapability>(lpVtbl->findCapability)((IGlobalSession*)Unsafe.AsPointer(ref this), name);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.setDownstreamCompilerForTransition"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setDownstreamCompilerForTransition([NativeTypeName("SlangCompileTarget")] CompileTarget source, [NativeTypeName("SlangCompileTarget")] CompileTarget target, [NativeTypeName("SlangPassThrough")] PassThrough compiler)
    {
        Marshal.GetDelegateForFunctionPointer<_setDownstreamCompilerForTransition>(lpVtbl->setDownstreamCompilerForTransition)((IGlobalSession*)Unsafe.AsPointer(ref this), source, target, compiler);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.getDownstreamCompilerForTransition"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangPassThrough")]
    public PassThrough getDownstreamCompilerForTransition([NativeTypeName("SlangCompileTarget")] CompileTarget source, [NativeTypeName("SlangCompileTarget")] CompileTarget target)
    {
        return Marshal.GetDelegateForFunctionPointer<_getDownstreamCompilerForTransition>(lpVtbl->getDownstreamCompilerForTransition)((IGlobalSession*)Unsafe.AsPointer(ref this), source, target);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.getCompilerElapsedTime"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void getCompilerElapsedTime(double* outTotalTime, double* outDownstreamTime)
    {
        Marshal.GetDelegateForFunctionPointer<_getCompilerElapsedTime>(lpVtbl->getCompilerElapsedTime)((IGlobalSession*)Unsafe.AsPointer(ref this), outTotalTime, outDownstreamTime);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.setSPIRVCoreGrammar"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int setSPIRVCoreGrammar([NativeTypeName("const char *")] sbyte* jsonPath)
    {
        return Marshal.GetDelegateForFunctionPointer<_setSPIRVCoreGrammar>(lpVtbl->setSPIRVCoreGrammar)((IGlobalSession*)Unsafe.AsPointer(ref this), jsonPath);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.parseCommandLineArguments"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int parseCommandLineArguments(int argc, [NativeTypeName("const char *const *")] sbyte** argv, [NativeTypeName("slang::SessionDesc *")] SessionDesc* outSessionDesc, ISlangUnknown** outAuxAllocation)
    {
        return Marshal.GetDelegateForFunctionPointer<_parseCommandLineArguments>(lpVtbl->parseCommandLineArguments)((IGlobalSession*)Unsafe.AsPointer(ref this), argc, argv, outSessionDesc, outAuxAllocation);
    }

    /// <include file='IGlobalSession.xml' path='doc/member[@name="IGlobalSession.getSessionDescDigest"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getSessionDescDigest([NativeTypeName("slang::SessionDesc *")] SessionDesc* sessionDesc, ISlangBlob** outBlob)
    {
        return Marshal.GetDelegateForFunctionPointer<_getSessionDescDigest>(lpVtbl->getSessionDescDigest)((IGlobalSession*)Unsafe.AsPointer(ref this), sessionDesc, outBlob);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **)")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t ()")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t ()")]
        public IntPtr release;

        [NativeTypeName("SlangResult (const SessionDesc &, ISession **)")]
        public IntPtr createSession;

        [NativeTypeName("SlangProfileID (const char *)")]
        public IntPtr findProfile;

        [NativeTypeName("void (SlangPassThrough, const char *)")]
        public IntPtr setDownstreamCompilerPath;

        [NativeTypeName("void (SlangPassThrough, const char *)")]
        public IntPtr setDownstreamCompilerPrelude;

        [NativeTypeName("void (SlangPassThrough, ISlangBlob **)")]
        public IntPtr getDownstreamCompilerPrelude;

        [NativeTypeName("const char *()")]
        public IntPtr getBuildTagString;

        [NativeTypeName("SlangResult (SlangSourceLanguage, SlangPassThrough)")]
        public IntPtr setDefaultDownstreamCompiler;

        [NativeTypeName("SlangPassThrough (SlangSourceLanguage)")]
        public IntPtr getDefaultDownstreamCompiler;

        [NativeTypeName("void (SlangSourceLanguage, const char *)")]
        public IntPtr setLanguagePrelude;

        [NativeTypeName("void (SlangSourceLanguage, ISlangBlob **)")]
        public IntPtr getLanguagePrelude;

        [NativeTypeName("void (const char *, const char *)")]
        public IntPtr addBuiltins;

        [NativeTypeName("void (ISlangSharedLibraryLoader *)")]
        public IntPtr setSharedLibraryLoader;

        [NativeTypeName("ISlangSharedLibraryLoader *()")]
        public IntPtr getSharedLibraryLoader;

        [NativeTypeName("SlangResult (SlangCompileTarget)")]
        public IntPtr checkCompileTargetSupport;

        [NativeTypeName("SlangResult (SlangPassThrough)")]
        public IntPtr checkPassThroughSupport;

        [NativeTypeName("SlangResult (CompileCoreModuleFlags)")]
        public IntPtr compileCoreModule;

        [NativeTypeName("SlangResult (const void *, size_t)")]
        public IntPtr loadCoreModule;

        [NativeTypeName("SlangResult (SlangArchiveType, ISlangBlob **)")]
        public IntPtr saveCoreModule;

        [NativeTypeName("SlangCapabilityID (const char *)")]
        public IntPtr findCapability;

        [NativeTypeName("void (SlangCompileTarget, SlangCompileTarget, SlangPassThrough)")]
        public IntPtr setDownstreamCompilerForTransition;

        [NativeTypeName("SlangPassThrough (SlangCompileTarget, SlangCompileTarget)")]
        public IntPtr getDownstreamCompilerForTransition;

        [NativeTypeName("void (double *, double *)")]
        public IntPtr getCompilerElapsedTime;

        [NativeTypeName("SlangResult (const char *)")]
        public IntPtr setSPIRVCoreGrammar;

        [NativeTypeName("SlangResult (int, const char *const *, SessionDesc *, ISlangUnknown **)")]
        public IntPtr parseCommandLineArguments;

        [NativeTypeName("SlangResult (SessionDesc *, ISlangBlob **)")]
        public IntPtr getSessionDescDigest;
    }
}
