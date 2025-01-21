using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.Slang;

/// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest"]/*' />
[NativeTypeName("struct ICompileRequest : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct ICompileRequest
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(ICompileRequest* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(ICompileRequest* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(ICompileRequest* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setFileSystem(ICompileRequest* pThis, ISlangFileSystem* fileSystem);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setCompileFlags(ICompileRequest* pThis, [NativeTypeName("SlangCompileFlags")] uint flags);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangCompileFlags")]
    public delegate uint _getCompileFlags(ICompileRequest* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setDumpIntermediates(ICompileRequest* pThis, int enable);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setDumpIntermediatePrefix(ICompileRequest* pThis, [NativeTypeName("const char *")] sbyte* prefix);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setLineDirectiveMode(ICompileRequest* pThis, [NativeTypeName("SlangLineDirectiveMode")] LineDirectiveMode mode);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setCodeGenTarget(ICompileRequest* pThis, [NativeTypeName("SlangCompileTarget")] CompileTarget target);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate int _addCodeGenTarget(ICompileRequest* pThis, [NativeTypeName("SlangCompileTarget")] CompileTarget target);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setTargetProfile(ICompileRequest* pThis, int targetIndex, [NativeTypeName("SlangProfileID")] ProfileID profile);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setTargetFlags(ICompileRequest* pThis, int targetIndex, [NativeTypeName("SlangTargetFlags")] uint flags);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setTargetFloatingPointMode(ICompileRequest* pThis, int targetIndex, [NativeTypeName("SlangFloatingPointMode")] FloatingPointMode mode);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setTargetMatrixLayoutMode(ICompileRequest* pThis, int targetIndex, [NativeTypeName("SlangMatrixLayoutMode")] MatrixLayoutMode mode);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setMatrixLayoutMode(ICompileRequest* pThis, [NativeTypeName("SlangMatrixLayoutMode")] MatrixLayoutMode mode);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setDebugInfoLevel(ICompileRequest* pThis, [NativeTypeName("SlangDebugInfoLevel")] DebugInfoLevel level);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setOptimizationLevel(ICompileRequest* pThis, [NativeTypeName("SlangOptimizationLevel")] OptimizationLevel level);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setOutputContainerFormat(ICompileRequest* pThis, [NativeTypeName("SlangContainerFormat")] ContainerFormat format);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setPassThrough(ICompileRequest* pThis, [NativeTypeName("SlangPassThrough")] PassThrough passThrough);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setDiagnosticCallback(ICompileRequest* pThis, [NativeTypeName("SlangDiagnosticCallback")] IntPtr callback, [NativeTypeName("const void *")] void* userData);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setWriter(ICompileRequest* pThis, [NativeTypeName("SlangWriterChannel")] WriterChannel channel, ISlangWriter* writer);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate ISlangWriter* _getWriter(ICompileRequest* pThis, [NativeTypeName("SlangWriterChannel")] WriterChannel channel);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _addSearchPath(ICompileRequest* pThis, [NativeTypeName("const char *")] sbyte* searchDir);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _addPreprocessorDefine(ICompileRequest* pThis, [NativeTypeName("const char *")] sbyte* key, [NativeTypeName("const char *")] sbyte* value);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _processCommandLineArguments(ICompileRequest* pThis, [NativeTypeName("const char *const *")] sbyte** args, int argCount);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate int _addTranslationUnit(ICompileRequest* pThis, [NativeTypeName("SlangSourceLanguage")] SourceLanguage language, [NativeTypeName("const char *")] sbyte* name);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setDefaultModuleName(ICompileRequest* pThis, [NativeTypeName("const char *")] sbyte* defaultModuleName);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _addTranslationUnitPreprocessorDefine(ICompileRequest* pThis, int translationUnitIndex, [NativeTypeName("const char *")] sbyte* key, [NativeTypeName("const char *")] sbyte* value);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _addTranslationUnitSourceFile(ICompileRequest* pThis, int translationUnitIndex, [NativeTypeName("const char *")] sbyte* path);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _addTranslationUnitSourceString(ICompileRequest* pThis, int translationUnitIndex, [NativeTypeName("const char *")] sbyte* path, [NativeTypeName("const char *")] sbyte* source);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _addLibraryReference(ICompileRequest* pThis, [NativeTypeName("const char *")] sbyte* basePath, [NativeTypeName("const void *")] void* libData, [NativeTypeName("size_t")] nuint libDataSize);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _addTranslationUnitSourceStringSpan(ICompileRequest* pThis, int translationUnitIndex, [NativeTypeName("const char *")] sbyte* path, [NativeTypeName("const char *")] sbyte* sourceBegin, [NativeTypeName("const char *")] sbyte* sourceEnd);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _addTranslationUnitSourceBlob(ICompileRequest* pThis, int translationUnitIndex, [NativeTypeName("const char *")] sbyte* path, ISlangBlob* sourceBlob);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate int _addEntryPoint(ICompileRequest* pThis, int translationUnitIndex, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("SlangStage")] Stage stage);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate int _addEntryPointEx(ICompileRequest* pThis, int translationUnitIndex, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("SlangStage")] Stage stage, int genericArgCount, [NativeTypeName("const char **")] sbyte** genericArgs);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _setGlobalGenericArgs(ICompileRequest* pThis, int genericArgCount, [NativeTypeName("const char **")] sbyte** genericArgs);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _setTypeNameForGlobalExistentialTypeParam(ICompileRequest* pThis, int slotIndex, [NativeTypeName("const char *")] sbyte* typeName);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _setTypeNameForEntryPointExistentialTypeParam(ICompileRequest* pThis, int entryPointIndex, int slotIndex, [NativeTypeName("const char *")] sbyte* typeName);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setAllowGLSLInput(ICompileRequest* pThis, [NativeTypeName("bool")] byte value);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _compile(ICompileRequest* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("const char *")]
    public delegate sbyte* _getDiagnosticOutput(ICompileRequest* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getDiagnosticOutputBlob(ICompileRequest* pThis, ISlangBlob** outBlob);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate int _getDependencyFileCount(ICompileRequest* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("const char *")]
    public delegate sbyte* _getDependencyFilePath(ICompileRequest* pThis, int index);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate int _getTranslationUnitCount(ICompileRequest* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("const char *")]
    public delegate sbyte* _getEntryPointSource(ICompileRequest* pThis, int entryPointIndex);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("const void *")]
    public delegate void* _getEntryPointCode(ICompileRequest* pThis, int entryPointIndex, [NativeTypeName("size_t *")] nuint* outSize);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getEntryPointCodeBlob(ICompileRequest* pThis, int entryPointIndex, int targetIndex, ISlangBlob** outBlob);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getEntryPointHostCallable(ICompileRequest* pThis, int entryPointIndex, int targetIndex, ISlangSharedLibrary** outSharedLibrary);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getTargetCodeBlob(ICompileRequest* pThis, int targetIndex, ISlangBlob** outBlob);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getTargetHostCallable(ICompileRequest* pThis, int targetIndex, ISlangSharedLibrary** outSharedLibrary);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("const void *")]
    public delegate void* _getCompileRequestCode(ICompileRequest* pThis, [NativeTypeName("size_t *")] nuint* outSize);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate ISlangMutableFileSystem* _getCompileRequestResultAsFileSystem(ICompileRequest* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getContainerCode(ICompileRequest* pThis, ISlangBlob** outBlob);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _loadRepro(ICompileRequest* pThis, ISlangFileSystem* fileSystem, [NativeTypeName("const void *")] void* data, [NativeTypeName("size_t")] nuint size);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _saveRepro(ICompileRequest* pThis, ISlangBlob** outBlob);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _enableReproCapture(ICompileRequest* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getProgram(ICompileRequest* pThis, [NativeTypeName("slang::IComponentType **")] IComponentType** outProgram);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getEntryPoint(ICompileRequest* pThis, [NativeTypeName("SlangInt")] nint entryPointIndex, [NativeTypeName("slang::IComponentType **")] IComponentType** outEntryPoint);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getModule(ICompileRequest* pThis, [NativeTypeName("SlangInt")] nint translationUnitIndex, [NativeTypeName("slang::IModule **")] IModule** outModule);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getSession(ICompileRequest* pThis, [NativeTypeName("slang::ISession **")] ISession** outSession);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangReflection *")]
    public delegate SlangProgramLayout* _getReflection(ICompileRequest* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setCommandLineCompilerMode(ICompileRequest* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _addTargetCapability(ICompileRequest* pThis, [NativeTypeName("SlangInt")] nint targetIndex, [NativeTypeName("SlangCapabilityID")] CapabilityID capability);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getProgramWithEntryPoints(ICompileRequest* pThis, [NativeTypeName("slang::IComponentType **")] IComponentType** outProgram);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _isParameterLocationUsed(ICompileRequest* pThis, [NativeTypeName("SlangInt")] nint entryPointIndex, [NativeTypeName("SlangInt")] nint targetIndex, [NativeTypeName("SlangParameterCategory")] ParameterCategory category, [NativeTypeName("SlangUInt")] nuint spaceIndex, [NativeTypeName("SlangUInt")] nuint registerIndex, [NativeTypeName("bool &")] bool* outUsed);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setTargetLineDirectiveMode(ICompileRequest* pThis, [NativeTypeName("SlangInt")] nint targetIndex, [NativeTypeName("SlangLineDirectiveMode")] LineDirectiveMode mode);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setTargetForceGLSLScalarBufferLayout(ICompileRequest* pThis, int targetIndex, [NativeTypeName("bool")] byte forceScalarLayout);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _overrideDiagnosticSeverity(ICompileRequest* pThis, [NativeTypeName("SlangInt")] nint messageID, [NativeTypeName("SlangSeverity")] Severity overrideSeverity);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangDiagnosticFlags")]
    public delegate int _getDiagnosticFlags(ICompileRequest* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setDiagnosticFlags(ICompileRequest* pThis, [NativeTypeName("SlangDiagnosticFlags")] int flags);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setDebugInfoFormat(ICompileRequest* pThis, [NativeTypeName("SlangDebugInfoFormat")] DebugInfoFormat debugFormat);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setEnableEffectAnnotations(ICompileRequest* pThis, [NativeTypeName("bool")] byte value);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setReportDownstreamTime(ICompileRequest* pThis, [NativeTypeName("bool")] byte value);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setReportPerfBenchmark(ICompileRequest* pThis, [NativeTypeName("bool")] byte value);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setSkipSPIRVValidation(ICompileRequest* pThis, [NativeTypeName("bool")] byte value);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setTargetUseMinimumSlangOptimization(ICompileRequest* pThis, int targetIndex, [NativeTypeName("bool")] byte value);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setIgnoreCapabilityCheck(ICompileRequest* pThis, [NativeTypeName("bool")] byte value);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getCompileTimeProfile(ICompileRequest* pThis, ISlangProfiler** compileTimeProfile, [NativeTypeName("bool")] byte shouldClear);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setTargetGenerateWholeProgram(ICompileRequest* pThis, int targetIndex, [NativeTypeName("bool")] byte value);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setTargetForceDXLayout(ICompileRequest* pThis, int targetIndex, [NativeTypeName("bool")] byte value);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void _setTargetEmbedDownstreamIR(ICompileRequest* pThis, int targetIndex, [NativeTypeName("bool")] byte value);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((ICompileRequest*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((ICompileRequest*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((ICompileRequest*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setFileSystem"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setFileSystem(ISlangFileSystem* fileSystem)
    {
        Marshal.GetDelegateForFunctionPointer<_setFileSystem>(lpVtbl->setFileSystem)((ICompileRequest*)Unsafe.AsPointer(ref this), fileSystem);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setCompileFlags"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setCompileFlags([NativeTypeName("SlangCompileFlags")] uint flags)
    {
        Marshal.GetDelegateForFunctionPointer<_setCompileFlags>(lpVtbl->setCompileFlags)((ICompileRequest*)Unsafe.AsPointer(ref this), flags);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.getCompileFlags"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangCompileFlags")]
    public uint getCompileFlags()
    {
        return Marshal.GetDelegateForFunctionPointer<_getCompileFlags>(lpVtbl->getCompileFlags)((ICompileRequest*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setDumpIntermediates"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setDumpIntermediates(int enable)
    {
        Marshal.GetDelegateForFunctionPointer<_setDumpIntermediates>(lpVtbl->setDumpIntermediates)((ICompileRequest*)Unsafe.AsPointer(ref this), enable);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setDumpIntermediatePrefix"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setDumpIntermediatePrefix([NativeTypeName("const char *")] sbyte* prefix)
    {
        Marshal.GetDelegateForFunctionPointer<_setDumpIntermediatePrefix>(lpVtbl->setDumpIntermediatePrefix)((ICompileRequest*)Unsafe.AsPointer(ref this), prefix);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setLineDirectiveMode"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setLineDirectiveMode([NativeTypeName("SlangLineDirectiveMode")] LineDirectiveMode mode)
    {
        Marshal.GetDelegateForFunctionPointer<_setLineDirectiveMode>(lpVtbl->setLineDirectiveMode)((ICompileRequest*)Unsafe.AsPointer(ref this), mode);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setCodeGenTarget"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setCodeGenTarget([NativeTypeName("SlangCompileTarget")] CompileTarget target)
    {
        Marshal.GetDelegateForFunctionPointer<_setCodeGenTarget>(lpVtbl->setCodeGenTarget)((ICompileRequest*)Unsafe.AsPointer(ref this), target);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.addCodeGenTarget"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int addCodeGenTarget([NativeTypeName("SlangCompileTarget")] CompileTarget target)
    {
        return Marshal.GetDelegateForFunctionPointer<_addCodeGenTarget>(lpVtbl->addCodeGenTarget)((ICompileRequest*)Unsafe.AsPointer(ref this), target);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setTargetProfile"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setTargetProfile(int targetIndex, [NativeTypeName("SlangProfileID")] ProfileID profile)
    {
        Marshal.GetDelegateForFunctionPointer<_setTargetProfile>(lpVtbl->setTargetProfile)((ICompileRequest*)Unsafe.AsPointer(ref this), targetIndex, profile);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setTargetFlags"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setTargetFlags(int targetIndex, [NativeTypeName("SlangTargetFlags")] uint flags)
    {
        Marshal.GetDelegateForFunctionPointer<_setTargetFlags>(lpVtbl->setTargetFlags)((ICompileRequest*)Unsafe.AsPointer(ref this), targetIndex, flags);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setTargetFloatingPointMode"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setTargetFloatingPointMode(int targetIndex, [NativeTypeName("SlangFloatingPointMode")] FloatingPointMode mode)
    {
        Marshal.GetDelegateForFunctionPointer<_setTargetFloatingPointMode>(lpVtbl->setTargetFloatingPointMode)((ICompileRequest*)Unsafe.AsPointer(ref this), targetIndex, mode);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setTargetMatrixLayoutMode"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setTargetMatrixLayoutMode(int targetIndex, [NativeTypeName("SlangMatrixLayoutMode")] MatrixLayoutMode mode)
    {
        Marshal.GetDelegateForFunctionPointer<_setTargetMatrixLayoutMode>(lpVtbl->setTargetMatrixLayoutMode)((ICompileRequest*)Unsafe.AsPointer(ref this), targetIndex, mode);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setMatrixLayoutMode"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setMatrixLayoutMode([NativeTypeName("SlangMatrixLayoutMode")] MatrixLayoutMode mode)
    {
        Marshal.GetDelegateForFunctionPointer<_setMatrixLayoutMode>(lpVtbl->setMatrixLayoutMode)((ICompileRequest*)Unsafe.AsPointer(ref this), mode);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setDebugInfoLevel"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setDebugInfoLevel([NativeTypeName("SlangDebugInfoLevel")] DebugInfoLevel level)
    {
        Marshal.GetDelegateForFunctionPointer<_setDebugInfoLevel>(lpVtbl->setDebugInfoLevel)((ICompileRequest*)Unsafe.AsPointer(ref this), level);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setOptimizationLevel"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setOptimizationLevel([NativeTypeName("SlangOptimizationLevel")] OptimizationLevel level)
    {
        Marshal.GetDelegateForFunctionPointer<_setOptimizationLevel>(lpVtbl->setOptimizationLevel)((ICompileRequest*)Unsafe.AsPointer(ref this), level);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setOutputContainerFormat"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setOutputContainerFormat([NativeTypeName("SlangContainerFormat")] ContainerFormat format)
    {
        Marshal.GetDelegateForFunctionPointer<_setOutputContainerFormat>(lpVtbl->setOutputContainerFormat)((ICompileRequest*)Unsafe.AsPointer(ref this), format);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setPassThrough"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setPassThrough([NativeTypeName("SlangPassThrough")] PassThrough passThrough)
    {
        Marshal.GetDelegateForFunctionPointer<_setPassThrough>(lpVtbl->setPassThrough)((ICompileRequest*)Unsafe.AsPointer(ref this), passThrough);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setDiagnosticCallback"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setDiagnosticCallback([NativeTypeName("SlangDiagnosticCallback")] IntPtr callback, [NativeTypeName("const void *")] void* userData)
    {
        Marshal.GetDelegateForFunctionPointer<_setDiagnosticCallback>(lpVtbl->setDiagnosticCallback)((ICompileRequest*)Unsafe.AsPointer(ref this), callback, userData);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setWriter"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setWriter([NativeTypeName("SlangWriterChannel")] WriterChannel channel, ISlangWriter* writer)
    {
        Marshal.GetDelegateForFunctionPointer<_setWriter>(lpVtbl->setWriter)((ICompileRequest*)Unsafe.AsPointer(ref this), channel, writer);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.getWriter"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ISlangWriter* getWriter([NativeTypeName("SlangWriterChannel")] WriterChannel channel)
    {
        return Marshal.GetDelegateForFunctionPointer<_getWriter>(lpVtbl->getWriter)((ICompileRequest*)Unsafe.AsPointer(ref this), channel);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.addSearchPath"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void addSearchPath([NativeTypeName("const char *")] sbyte* searchDir)
    {
        Marshal.GetDelegateForFunctionPointer<_addSearchPath>(lpVtbl->addSearchPath)((ICompileRequest*)Unsafe.AsPointer(ref this), searchDir);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.addPreprocessorDefine"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void addPreprocessorDefine([NativeTypeName("const char *")] sbyte* key, [NativeTypeName("const char *")] sbyte* value)
    {
        Marshal.GetDelegateForFunctionPointer<_addPreprocessorDefine>(lpVtbl->addPreprocessorDefine)((ICompileRequest*)Unsafe.AsPointer(ref this), key, value);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.processCommandLineArguments"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int processCommandLineArguments([NativeTypeName("const char *const *")] sbyte** args, int argCount)
    {
        return Marshal.GetDelegateForFunctionPointer<_processCommandLineArguments>(lpVtbl->processCommandLineArguments)((ICompileRequest*)Unsafe.AsPointer(ref this), args, argCount);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.addTranslationUnit"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int addTranslationUnit([NativeTypeName("SlangSourceLanguage")] SourceLanguage language, [NativeTypeName("const char *")] sbyte* name)
    {
        return Marshal.GetDelegateForFunctionPointer<_addTranslationUnit>(lpVtbl->addTranslationUnit)((ICompileRequest*)Unsafe.AsPointer(ref this), language, name);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setDefaultModuleName"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setDefaultModuleName([NativeTypeName("const char *")] sbyte* defaultModuleName)
    {
        Marshal.GetDelegateForFunctionPointer<_setDefaultModuleName>(lpVtbl->setDefaultModuleName)((ICompileRequest*)Unsafe.AsPointer(ref this), defaultModuleName);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.addTranslationUnitPreprocessorDefine"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void addTranslationUnitPreprocessorDefine(int translationUnitIndex, [NativeTypeName("const char *")] sbyte* key, [NativeTypeName("const char *")] sbyte* value)
    {
        Marshal.GetDelegateForFunctionPointer<_addTranslationUnitPreprocessorDefine>(lpVtbl->addTranslationUnitPreprocessorDefine)((ICompileRequest*)Unsafe.AsPointer(ref this), translationUnitIndex, key, value);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.addTranslationUnitSourceFile"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void addTranslationUnitSourceFile(int translationUnitIndex, [NativeTypeName("const char *")] sbyte* path)
    {
        Marshal.GetDelegateForFunctionPointer<_addTranslationUnitSourceFile>(lpVtbl->addTranslationUnitSourceFile)((ICompileRequest*)Unsafe.AsPointer(ref this), translationUnitIndex, path);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.addTranslationUnitSourceString"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void addTranslationUnitSourceString(int translationUnitIndex, [NativeTypeName("const char *")] sbyte* path, [NativeTypeName("const char *")] sbyte* source)
    {
        Marshal.GetDelegateForFunctionPointer<_addTranslationUnitSourceString>(lpVtbl->addTranslationUnitSourceString)((ICompileRequest*)Unsafe.AsPointer(ref this), translationUnitIndex, path, source);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.addLibraryReference"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int addLibraryReference([NativeTypeName("const char *")] sbyte* basePath, [NativeTypeName("const void *")] void* libData, [NativeTypeName("size_t")] nuint libDataSize)
    {
        return Marshal.GetDelegateForFunctionPointer<_addLibraryReference>(lpVtbl->addLibraryReference)((ICompileRequest*)Unsafe.AsPointer(ref this), basePath, libData, libDataSize);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.addTranslationUnitSourceStringSpan"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void addTranslationUnitSourceStringSpan(int translationUnitIndex, [NativeTypeName("const char *")] sbyte* path, [NativeTypeName("const char *")] sbyte* sourceBegin, [NativeTypeName("const char *")] sbyte* sourceEnd)
    {
        Marshal.GetDelegateForFunctionPointer<_addTranslationUnitSourceStringSpan>(lpVtbl->addTranslationUnitSourceStringSpan)((ICompileRequest*)Unsafe.AsPointer(ref this), translationUnitIndex, path, sourceBegin, sourceEnd);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.addTranslationUnitSourceBlob"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void addTranslationUnitSourceBlob(int translationUnitIndex, [NativeTypeName("const char *")] sbyte* path, ISlangBlob* sourceBlob)
    {
        Marshal.GetDelegateForFunctionPointer<_addTranslationUnitSourceBlob>(lpVtbl->addTranslationUnitSourceBlob)((ICompileRequest*)Unsafe.AsPointer(ref this), translationUnitIndex, path, sourceBlob);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.addEntryPoint"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int addEntryPoint(int translationUnitIndex, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("SlangStage")] Stage stage)
    {
        return Marshal.GetDelegateForFunctionPointer<_addEntryPoint>(lpVtbl->addEntryPoint)((ICompileRequest*)Unsafe.AsPointer(ref this), translationUnitIndex, name, stage);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.addEntryPointEx"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int addEntryPointEx(int translationUnitIndex, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("SlangStage")] Stage stage, int genericArgCount, [NativeTypeName("const char **")] sbyte** genericArgs)
    {
        return Marshal.GetDelegateForFunctionPointer<_addEntryPointEx>(lpVtbl->addEntryPointEx)((ICompileRequest*)Unsafe.AsPointer(ref this), translationUnitIndex, name, stage, genericArgCount, genericArgs);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setGlobalGenericArgs"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int setGlobalGenericArgs(int genericArgCount, [NativeTypeName("const char **")] sbyte** genericArgs)
    {
        return Marshal.GetDelegateForFunctionPointer<_setGlobalGenericArgs>(lpVtbl->setGlobalGenericArgs)((ICompileRequest*)Unsafe.AsPointer(ref this), genericArgCount, genericArgs);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setTypeNameForGlobalExistentialTypeParam"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int setTypeNameForGlobalExistentialTypeParam(int slotIndex, [NativeTypeName("const char *")] sbyte* typeName)
    {
        return Marshal.GetDelegateForFunctionPointer<_setTypeNameForGlobalExistentialTypeParam>(lpVtbl->setTypeNameForGlobalExistentialTypeParam)((ICompileRequest*)Unsafe.AsPointer(ref this), slotIndex, typeName);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setTypeNameForEntryPointExistentialTypeParam"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int setTypeNameForEntryPointExistentialTypeParam(int entryPointIndex, int slotIndex, [NativeTypeName("const char *")] sbyte* typeName)
    {
        return Marshal.GetDelegateForFunctionPointer<_setTypeNameForEntryPointExistentialTypeParam>(lpVtbl->setTypeNameForEntryPointExistentialTypeParam)((ICompileRequest*)Unsafe.AsPointer(ref this), entryPointIndex, slotIndex, typeName);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setAllowGLSLInput"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setAllowGLSLInput([NativeTypeName("bool")] byte value)
    {
        Marshal.GetDelegateForFunctionPointer<_setAllowGLSLInput>(lpVtbl->setAllowGLSLInput)((ICompileRequest*)Unsafe.AsPointer(ref this), value);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.compile"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int compile()
    {
        return Marshal.GetDelegateForFunctionPointer<_compile>(lpVtbl->compile)((ICompileRequest*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.getDiagnosticOutput"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("const char *")]
    public sbyte* getDiagnosticOutput()
    {
        return Marshal.GetDelegateForFunctionPointer<_getDiagnosticOutput>(lpVtbl->getDiagnosticOutput)((ICompileRequest*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.getDiagnosticOutputBlob"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getDiagnosticOutputBlob(ISlangBlob** outBlob)
    {
        return Marshal.GetDelegateForFunctionPointer<_getDiagnosticOutputBlob>(lpVtbl->getDiagnosticOutputBlob)((ICompileRequest*)Unsafe.AsPointer(ref this), outBlob);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.getDependencyFileCount"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int getDependencyFileCount()
    {
        return Marshal.GetDelegateForFunctionPointer<_getDependencyFileCount>(lpVtbl->getDependencyFileCount)((ICompileRequest*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.getDependencyFilePath"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("const char *")]
    public sbyte* getDependencyFilePath(int index)
    {
        return Marshal.GetDelegateForFunctionPointer<_getDependencyFilePath>(lpVtbl->getDependencyFilePath)((ICompileRequest*)Unsafe.AsPointer(ref this), index);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.getTranslationUnitCount"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int getTranslationUnitCount()
    {
        return Marshal.GetDelegateForFunctionPointer<_getTranslationUnitCount>(lpVtbl->getTranslationUnitCount)((ICompileRequest*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.getEntryPointSource"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("const char *")]
    public sbyte* getEntryPointSource(int entryPointIndex)
    {
        return Marshal.GetDelegateForFunctionPointer<_getEntryPointSource>(lpVtbl->getEntryPointSource)((ICompileRequest*)Unsafe.AsPointer(ref this), entryPointIndex);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.getEntryPointCode"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("const void *")]
    public void* getEntryPointCode(int entryPointIndex, [NativeTypeName("size_t *")] nuint* outSize)
    {
        return Marshal.GetDelegateForFunctionPointer<_getEntryPointCode>(lpVtbl->getEntryPointCode)((ICompileRequest*)Unsafe.AsPointer(ref this), entryPointIndex, outSize);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.getEntryPointCodeBlob"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getEntryPointCodeBlob(int entryPointIndex, int targetIndex, ISlangBlob** outBlob)
    {
        return Marshal.GetDelegateForFunctionPointer<_getEntryPointCodeBlob>(lpVtbl->getEntryPointCodeBlob)((ICompileRequest*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outBlob);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.getEntryPointHostCallable"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getEntryPointHostCallable(int entryPointIndex, int targetIndex, ISlangSharedLibrary** outSharedLibrary)
    {
        return Marshal.GetDelegateForFunctionPointer<_getEntryPointHostCallable>(lpVtbl->getEntryPointHostCallable)((ICompileRequest*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outSharedLibrary);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.getTargetCodeBlob"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getTargetCodeBlob(int targetIndex, ISlangBlob** outBlob)
    {
        return Marshal.GetDelegateForFunctionPointer<_getTargetCodeBlob>(lpVtbl->getTargetCodeBlob)((ICompileRequest*)Unsafe.AsPointer(ref this), targetIndex, outBlob);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.getTargetHostCallable"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getTargetHostCallable(int targetIndex, ISlangSharedLibrary** outSharedLibrary)
    {
        return Marshal.GetDelegateForFunctionPointer<_getTargetHostCallable>(lpVtbl->getTargetHostCallable)((ICompileRequest*)Unsafe.AsPointer(ref this), targetIndex, outSharedLibrary);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.getCompileRequestCode"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("const void *")]
    public void* getCompileRequestCode([NativeTypeName("size_t *")] nuint* outSize)
    {
        return Marshal.GetDelegateForFunctionPointer<_getCompileRequestCode>(lpVtbl->getCompileRequestCode)((ICompileRequest*)Unsafe.AsPointer(ref this), outSize);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.getCompileRequestResultAsFileSystem"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ISlangMutableFileSystem* getCompileRequestResultAsFileSystem()
    {
        return Marshal.GetDelegateForFunctionPointer<_getCompileRequestResultAsFileSystem>(lpVtbl->getCompileRequestResultAsFileSystem)((ICompileRequest*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.getContainerCode"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getContainerCode(ISlangBlob** outBlob)
    {
        return Marshal.GetDelegateForFunctionPointer<_getContainerCode>(lpVtbl->getContainerCode)((ICompileRequest*)Unsafe.AsPointer(ref this), outBlob);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.loadRepro"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int loadRepro(ISlangFileSystem* fileSystem, [NativeTypeName("const void *")] void* data, [NativeTypeName("size_t")] nuint size)
    {
        return Marshal.GetDelegateForFunctionPointer<_loadRepro>(lpVtbl->loadRepro)((ICompileRequest*)Unsafe.AsPointer(ref this), fileSystem, data, size);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.saveRepro"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int saveRepro(ISlangBlob** outBlob)
    {
        return Marshal.GetDelegateForFunctionPointer<_saveRepro>(lpVtbl->saveRepro)((ICompileRequest*)Unsafe.AsPointer(ref this), outBlob);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.enableReproCapture"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int enableReproCapture()
    {
        return Marshal.GetDelegateForFunctionPointer<_enableReproCapture>(lpVtbl->enableReproCapture)((ICompileRequest*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.getProgram"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getProgram([NativeTypeName("slang::IComponentType **")] IComponentType** outProgram)
    {
        return Marshal.GetDelegateForFunctionPointer<_getProgram>(lpVtbl->getProgram)((ICompileRequest*)Unsafe.AsPointer(ref this), outProgram);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.getEntryPoint"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getEntryPoint([NativeTypeName("SlangInt")] nint entryPointIndex, [NativeTypeName("slang::IComponentType **")] IComponentType** outEntryPoint)
    {
        return Marshal.GetDelegateForFunctionPointer<_getEntryPoint>(lpVtbl->getEntryPoint)((ICompileRequest*)Unsafe.AsPointer(ref this), entryPointIndex, outEntryPoint);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.getModule"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getModule([NativeTypeName("SlangInt")] nint translationUnitIndex, [NativeTypeName("slang::IModule **")] IModule** outModule)
    {
        return Marshal.GetDelegateForFunctionPointer<_getModule>(lpVtbl->getModule)((ICompileRequest*)Unsafe.AsPointer(ref this), translationUnitIndex, outModule);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.getSession"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getSession([NativeTypeName("slang::ISession **")] ISession** outSession)
    {
        return Marshal.GetDelegateForFunctionPointer<_getSession>(lpVtbl->getSession)((ICompileRequest*)Unsafe.AsPointer(ref this), outSession);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.getReflection"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangReflection *")]
    public SlangProgramLayout* getReflection()
    {
        return Marshal.GetDelegateForFunctionPointer<_getReflection>(lpVtbl->getReflection)((ICompileRequest*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setCommandLineCompilerMode"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setCommandLineCompilerMode()
    {
        Marshal.GetDelegateForFunctionPointer<_setCommandLineCompilerMode>(lpVtbl->setCommandLineCompilerMode)((ICompileRequest*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.addTargetCapability"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int addTargetCapability([NativeTypeName("SlangInt")] nint targetIndex, [NativeTypeName("SlangCapabilityID")] CapabilityID capability)
    {
        return Marshal.GetDelegateForFunctionPointer<_addTargetCapability>(lpVtbl->addTargetCapability)((ICompileRequest*)Unsafe.AsPointer(ref this), targetIndex, capability);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.getProgramWithEntryPoints"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getProgramWithEntryPoints([NativeTypeName("slang::IComponentType **")] IComponentType** outProgram)
    {
        return Marshal.GetDelegateForFunctionPointer<_getProgramWithEntryPoints>(lpVtbl->getProgramWithEntryPoints)((ICompileRequest*)Unsafe.AsPointer(ref this), outProgram);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.isParameterLocationUsed"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int isParameterLocationUsed([NativeTypeName("SlangInt")] nint entryPointIndex, [NativeTypeName("SlangInt")] nint targetIndex, [NativeTypeName("SlangParameterCategory")] ParameterCategory category, [NativeTypeName("SlangUInt")] nuint spaceIndex, [NativeTypeName("SlangUInt")] nuint registerIndex, [NativeTypeName("bool &")] bool* outUsed)
    {
        return Marshal.GetDelegateForFunctionPointer<_isParameterLocationUsed>(lpVtbl->isParameterLocationUsed)((ICompileRequest*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, category, spaceIndex, registerIndex, outUsed);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setTargetLineDirectiveMode"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setTargetLineDirectiveMode([NativeTypeName("SlangInt")] nint targetIndex, [NativeTypeName("SlangLineDirectiveMode")] LineDirectiveMode mode)
    {
        Marshal.GetDelegateForFunctionPointer<_setTargetLineDirectiveMode>(lpVtbl->setTargetLineDirectiveMode)((ICompileRequest*)Unsafe.AsPointer(ref this), targetIndex, mode);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setTargetForceGLSLScalarBufferLayout"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setTargetForceGLSLScalarBufferLayout(int targetIndex, [NativeTypeName("bool")] byte forceScalarLayout)
    {
        Marshal.GetDelegateForFunctionPointer<_setTargetForceGLSLScalarBufferLayout>(lpVtbl->setTargetForceGLSLScalarBufferLayout)((ICompileRequest*)Unsafe.AsPointer(ref this), targetIndex, forceScalarLayout);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.overrideDiagnosticSeverity"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void overrideDiagnosticSeverity([NativeTypeName("SlangInt")] nint messageID, [NativeTypeName("SlangSeverity")] Severity overrideSeverity)
    {
        Marshal.GetDelegateForFunctionPointer<_overrideDiagnosticSeverity>(lpVtbl->overrideDiagnosticSeverity)((ICompileRequest*)Unsafe.AsPointer(ref this), messageID, overrideSeverity);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.getDiagnosticFlags"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangDiagnosticFlags")]
    public int getDiagnosticFlags()
    {
        return Marshal.GetDelegateForFunctionPointer<_getDiagnosticFlags>(lpVtbl->getDiagnosticFlags)((ICompileRequest*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setDiagnosticFlags"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setDiagnosticFlags([NativeTypeName("SlangDiagnosticFlags")] int flags)
    {
        Marshal.GetDelegateForFunctionPointer<_setDiagnosticFlags>(lpVtbl->setDiagnosticFlags)((ICompileRequest*)Unsafe.AsPointer(ref this), flags);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setDebugInfoFormat"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setDebugInfoFormat([NativeTypeName("SlangDebugInfoFormat")] DebugInfoFormat debugFormat)
    {
        Marshal.GetDelegateForFunctionPointer<_setDebugInfoFormat>(lpVtbl->setDebugInfoFormat)((ICompileRequest*)Unsafe.AsPointer(ref this), debugFormat);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setEnableEffectAnnotations"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setEnableEffectAnnotations([NativeTypeName("bool")] byte value)
    {
        Marshal.GetDelegateForFunctionPointer<_setEnableEffectAnnotations>(lpVtbl->setEnableEffectAnnotations)((ICompileRequest*)Unsafe.AsPointer(ref this), value);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setReportDownstreamTime"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setReportDownstreamTime([NativeTypeName("bool")] byte value)
    {
        Marshal.GetDelegateForFunctionPointer<_setReportDownstreamTime>(lpVtbl->setReportDownstreamTime)((ICompileRequest*)Unsafe.AsPointer(ref this), value);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setReportPerfBenchmark"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setReportPerfBenchmark([NativeTypeName("bool")] byte value)
    {
        Marshal.GetDelegateForFunctionPointer<_setReportPerfBenchmark>(lpVtbl->setReportPerfBenchmark)((ICompileRequest*)Unsafe.AsPointer(ref this), value);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setSkipSPIRVValidation"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setSkipSPIRVValidation([NativeTypeName("bool")] byte value)
    {
        Marshal.GetDelegateForFunctionPointer<_setSkipSPIRVValidation>(lpVtbl->setSkipSPIRVValidation)((ICompileRequest*)Unsafe.AsPointer(ref this), value);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setTargetUseMinimumSlangOptimization"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setTargetUseMinimumSlangOptimization(int targetIndex, [NativeTypeName("bool")] byte value)
    {
        Marshal.GetDelegateForFunctionPointer<_setTargetUseMinimumSlangOptimization>(lpVtbl->setTargetUseMinimumSlangOptimization)((ICompileRequest*)Unsafe.AsPointer(ref this), targetIndex, value);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setIgnoreCapabilityCheck"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setIgnoreCapabilityCheck([NativeTypeName("bool")] byte value)
    {
        Marshal.GetDelegateForFunctionPointer<_setIgnoreCapabilityCheck>(lpVtbl->setIgnoreCapabilityCheck)((ICompileRequest*)Unsafe.AsPointer(ref this), value);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.getCompileTimeProfile"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getCompileTimeProfile(ISlangProfiler** compileTimeProfile, [NativeTypeName("bool")] byte shouldClear)
    {
        return Marshal.GetDelegateForFunctionPointer<_getCompileTimeProfile>(lpVtbl->getCompileTimeProfile)((ICompileRequest*)Unsafe.AsPointer(ref this), compileTimeProfile, shouldClear);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setTargetGenerateWholeProgram"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setTargetGenerateWholeProgram(int targetIndex, [NativeTypeName("bool")] byte value)
    {
        Marshal.GetDelegateForFunctionPointer<_setTargetGenerateWholeProgram>(lpVtbl->setTargetGenerateWholeProgram)((ICompileRequest*)Unsafe.AsPointer(ref this), targetIndex, value);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setTargetForceDXLayout"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setTargetForceDXLayout(int targetIndex, [NativeTypeName("bool")] byte value)
    {
        Marshal.GetDelegateForFunctionPointer<_setTargetForceDXLayout>(lpVtbl->setTargetForceDXLayout)((ICompileRequest*)Unsafe.AsPointer(ref this), targetIndex, value);
    }

    /// <include file='ICompileRequest.xml' path='doc/member[@name="ICompileRequest.setTargetEmbedDownstreamIR"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setTargetEmbedDownstreamIR(int targetIndex, [NativeTypeName("bool")] byte value)
    {
        Marshal.GetDelegateForFunctionPointer<_setTargetEmbedDownstreamIR>(lpVtbl->setTargetEmbedDownstreamIR)((ICompileRequest*)Unsafe.AsPointer(ref this), targetIndex, value);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **)")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t ()")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t ()")]
        public IntPtr release;

        [NativeTypeName("void (ISlangFileSystem *)")]
        public IntPtr setFileSystem;

        [NativeTypeName("void (SlangCompileFlags)")]
        public IntPtr setCompileFlags;

        [NativeTypeName("SlangCompileFlags ()")]
        public IntPtr getCompileFlags;

        [NativeTypeName("void (int)")]
        public IntPtr setDumpIntermediates;

        [NativeTypeName("void (const char *)")]
        public IntPtr setDumpIntermediatePrefix;

        [NativeTypeName("void (SlangLineDirectiveMode)")]
        public IntPtr setLineDirectiveMode;

        [NativeTypeName("void (SlangCompileTarget)")]
        public IntPtr setCodeGenTarget;

        [NativeTypeName("int (SlangCompileTarget)")]
        public IntPtr addCodeGenTarget;

        [NativeTypeName("void (int, SlangProfileID)")]
        public IntPtr setTargetProfile;

        [NativeTypeName("void (int, SlangTargetFlags)")]
        public IntPtr setTargetFlags;

        [NativeTypeName("void (int, SlangFloatingPointMode)")]
        public IntPtr setTargetFloatingPointMode;

        [NativeTypeName("void (int, SlangMatrixLayoutMode)")]
        public IntPtr setTargetMatrixLayoutMode;

        [NativeTypeName("void (SlangMatrixLayoutMode)")]
        public IntPtr setMatrixLayoutMode;

        [NativeTypeName("void (SlangDebugInfoLevel)")]
        public IntPtr setDebugInfoLevel;

        [NativeTypeName("void (SlangOptimizationLevel)")]
        public IntPtr setOptimizationLevel;

        [NativeTypeName("void (SlangContainerFormat)")]
        public IntPtr setOutputContainerFormat;

        [NativeTypeName("void (SlangPassThrough)")]
        public IntPtr setPassThrough;

        [NativeTypeName("void (SlangDiagnosticCallback, const void *)")]
        public IntPtr setDiagnosticCallback;

        [NativeTypeName("void (SlangWriterChannel, ISlangWriter *)")]
        public IntPtr setWriter;

        [NativeTypeName("ISlangWriter *(SlangWriterChannel)")]
        public IntPtr getWriter;

        [NativeTypeName("void (const char *)")]
        public IntPtr addSearchPath;

        [NativeTypeName("void (const char *, const char *)")]
        public IntPtr addPreprocessorDefine;

        [NativeTypeName("SlangResult (const char *const *, int)")]
        public IntPtr processCommandLineArguments;

        [NativeTypeName("int (SlangSourceLanguage, const char *)")]
        public IntPtr addTranslationUnit;

        [NativeTypeName("void (const char *)")]
        public IntPtr setDefaultModuleName;

        [NativeTypeName("void (int, const char *, const char *)")]
        public IntPtr addTranslationUnitPreprocessorDefine;

        [NativeTypeName("void (int, const char *)")]
        public IntPtr addTranslationUnitSourceFile;

        [NativeTypeName("void (int, const char *, const char *)")]
        public IntPtr addTranslationUnitSourceString;

        [NativeTypeName("SlangResult (const char *, const void *, size_t)")]
        public IntPtr addLibraryReference;

        [NativeTypeName("void (int, const char *, const char *, const char *)")]
        public IntPtr addTranslationUnitSourceStringSpan;

        [NativeTypeName("void (int, const char *, ISlangBlob *)")]
        public IntPtr addTranslationUnitSourceBlob;

        [NativeTypeName("int (int, const char *, SlangStage)")]
        public IntPtr addEntryPoint;

        [NativeTypeName("int (int, const char *, SlangStage, int, const char **)")]
        public IntPtr addEntryPointEx;

        [NativeTypeName("SlangResult (int, const char **)")]
        public IntPtr setGlobalGenericArgs;

        [NativeTypeName("SlangResult (int, const char *)")]
        public IntPtr setTypeNameForGlobalExistentialTypeParam;

        [NativeTypeName("SlangResult (int, int, const char *)")]
        public IntPtr setTypeNameForEntryPointExistentialTypeParam;

        [NativeTypeName("void (bool)")]
        public IntPtr setAllowGLSLInput;

        [NativeTypeName("SlangResult ()")]
        public IntPtr compile;

        [NativeTypeName("const char *()")]
        public IntPtr getDiagnosticOutput;

        [NativeTypeName("SlangResult (ISlangBlob **)")]
        public IntPtr getDiagnosticOutputBlob;

        [NativeTypeName("int ()")]
        public IntPtr getDependencyFileCount;

        [NativeTypeName("const char *(int)")]
        public IntPtr getDependencyFilePath;

        [NativeTypeName("int ()")]
        public IntPtr getTranslationUnitCount;

        [NativeTypeName("const char *(int)")]
        public IntPtr getEntryPointSource;

        [NativeTypeName("const void *(int, size_t *)")]
        public IntPtr getEntryPointCode;

        [NativeTypeName("SlangResult (int, int, ISlangBlob **)")]
        public IntPtr getEntryPointCodeBlob;

        [NativeTypeName("SlangResult (int, int, ISlangSharedLibrary **)")]
        public IntPtr getEntryPointHostCallable;

        [NativeTypeName("SlangResult (int, ISlangBlob **)")]
        public IntPtr getTargetCodeBlob;

        [NativeTypeName("SlangResult (int, ISlangSharedLibrary **)")]
        public IntPtr getTargetHostCallable;

        [NativeTypeName("const void *(size_t *)")]
        public IntPtr getCompileRequestCode;

        [NativeTypeName("ISlangMutableFileSystem *()")]
        public IntPtr getCompileRequestResultAsFileSystem;

        [NativeTypeName("SlangResult (ISlangBlob **)")]
        public IntPtr getContainerCode;

        [NativeTypeName("SlangResult (ISlangFileSystem *, const void *, size_t)")]
        public IntPtr loadRepro;

        [NativeTypeName("SlangResult (ISlangBlob **)")]
        public IntPtr saveRepro;

        [NativeTypeName("SlangResult ()")]
        public IntPtr enableReproCapture;

        [NativeTypeName("SlangResult (slang::IComponentType **)")]
        public IntPtr getProgram;

        [NativeTypeName("SlangResult (SlangInt, slang::IComponentType **)")]
        public IntPtr getEntryPoint;

        [NativeTypeName("SlangResult (SlangInt, slang::IModule **)")]
        public IntPtr getModule;

        [NativeTypeName("SlangResult (slang::ISession **)")]
        public IntPtr getSession;

        [NativeTypeName("SlangReflection *()")]
        public IntPtr getReflection;

        [NativeTypeName("void ()")]
        public IntPtr setCommandLineCompilerMode;

        [NativeTypeName("SlangResult (SlangInt, SlangCapabilityID)")]
        public IntPtr addTargetCapability;

        [NativeTypeName("SlangResult (slang::IComponentType **)")]
        public IntPtr getProgramWithEntryPoints;

        [NativeTypeName("SlangResult (SlangInt, SlangInt, SlangParameterCategory, SlangUInt, SlangUInt, bool &)")]
        public IntPtr isParameterLocationUsed;

        [NativeTypeName("void (SlangInt, SlangLineDirectiveMode)")]
        public IntPtr setTargetLineDirectiveMode;

        [NativeTypeName("void (int, bool)")]
        public IntPtr setTargetForceGLSLScalarBufferLayout;

        [NativeTypeName("void (SlangInt, SlangSeverity)")]
        public IntPtr overrideDiagnosticSeverity;

        [NativeTypeName("SlangDiagnosticFlags ()")]
        public IntPtr getDiagnosticFlags;

        [NativeTypeName("void (SlangDiagnosticFlags)")]
        public IntPtr setDiagnosticFlags;

        [NativeTypeName("void (SlangDebugInfoFormat)")]
        public IntPtr setDebugInfoFormat;

        [NativeTypeName("void (bool)")]
        public IntPtr setEnableEffectAnnotations;

        [NativeTypeName("void (bool)")]
        public IntPtr setReportDownstreamTime;

        [NativeTypeName("void (bool)")]
        public IntPtr setReportPerfBenchmark;

        [NativeTypeName("void (bool)")]
        public IntPtr setSkipSPIRVValidation;

        [NativeTypeName("void (int, bool)")]
        public IntPtr setTargetUseMinimumSlangOptimization;

        [NativeTypeName("void (bool)")]
        public IntPtr setIgnoreCapabilityCheck;

        [NativeTypeName("SlangResult (ISlangProfiler **, bool)")]
        public IntPtr getCompileTimeProfile;

        [NativeTypeName("void (int, bool)")]
        public IntPtr setTargetGenerateWholeProgram;

        [NativeTypeName("void (int, bool)")]
        public IntPtr setTargetForceDXLayout;

        [NativeTypeName("void (int, bool)")]
        public IntPtr setTargetEmbedDownstreamIR;
    }
}
