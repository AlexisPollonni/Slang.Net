using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Interfaces;
using SlangNet.ComWrappers.Tools;
using SlangNet.Enums;

namespace SlangNet.ComWrappers;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Custom, StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller))]
[Guid("96D33993-317C-4DB5-AFD8-666EE77248E2")]
public partial interface ICompileRequest : IUnknown
{
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetFileSystem(IFileSystem fileSystem);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetCompileFlags(CompileFlags flags);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    CompileFlags GetCompileFlags();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetDumpIntermediates(int enable);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetDumpIntermediatePrefix(string prefix);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetLineDirectiveMode(Unmanaged.LineDirectiveMode mode);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetCodeGenTarget(Unmanaged.CompileTarget target);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    int AddCodeGenTarget(Unmanaged.CompileTarget target);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetTargetProfile(int targetIndex, Unmanaged.ProfileID profile);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetTargetFlags(int targetIndex, TargetFlags flags);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetTargetFloatingPointMode(int targetIndex, Unmanaged.FloatingPointMode mode);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetTargetMatrixLayoutMode(int targetIndex, Unmanaged.MatrixLayoutMode mode);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetMatrixLayoutMode(Unmanaged.MatrixLayoutMode mode);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetDebugInfoLevel(Unmanaged.DebugInfoLevel level);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetOptimizationLevel(Unmanaged.OptimizationLevel level);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetOutputContainerFormat(Unmanaged.ContainerFormat format);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetPassThrough(Unmanaged.PassThrough passThrough);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetDiagnosticCallback(Unmanaged.SlangDiagnosticCallback callback, string userData);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetWriter(Unmanaged.WriterChannel channel, IWriter writer);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    IWriter? GetWriter(Unmanaged.WriterChannel channel);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void AddSearchPath(string searchDir);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void AddPreprocessorDefine(string key, string value);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult ProcessCommandLineArguments([MarshalUsing(CountElementName = "argCount")] Span<string> args, int argCount);
    
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    int AddTranslationUnit(Unmanaged.SourceLanguage language, string name);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetDefaultModuleName(string defaultModuleName);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void AddTranslationUnitPreprocessorDefine(int translationUnitIndex, string key, string value);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void AddTranslationUnitSourceFile(int translationUnitIndex, string path);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void AddTranslationUnitSourceString(int translationUnitIndex, string path, string source);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult AddLibraryReference(string basePath,
                                    [MarshalUsing(CountElementName = "libDataSize")] Span<byte> libData,
                                    nuint libDataSize);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void AddTranslationUnitSourceStringSpan(int translationUnitIndex, string path, string source, nint unused = 0);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void AddTranslationUnitSourceBlob(int translationUnitIndex, string path, IBlob sourceBlob);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    int AddEntryPoint(int translationUnitIndex, string name, Unmanaged.Stage stage);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    int AddEntryPointEx(int translationUnitIndex,
                        string name,
                        Unmanaged.Stage stage,
                        int genericArgCount,
                        [MarshalUsing(CountElementName = "genericArgCount")] Span<string> genericArgs);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult SetGlobalGenericArgs(int genericArgCount,
                                     [MarshalUsing(CountElementName = "genericArgCount")] Span<string> genericArgs);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult SetTypeNameForGlobalExistentialTypeParam(int slotIndex, string typeName);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult SetTypeNameForEntryPointExistentialTypeParam(int entryPointIndex, int slotIndex, string typeName);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetAllowGlslInput([MarshalAs(UnmanagedType.I1)] bool value);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult Compile();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    string? GetDiagnosticOutput();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetDiagnosticOutputBlob(out IBlob outBlob);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    int GetDependencyFileCount();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    [return: MarshalUsing(typeof(UnownedUTF8StringMarshaller))]
    string? GetDependencyFilePath(int index);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    int GetTranslationUnitCount();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    [return: MarshalUsing(typeof(UnownedUTF8StringMarshaller))]
    string? GetEntryPointSource(int entryPointIndex);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    [return: MarshalUsing(CountElementName = "outSize")]
    ReadOnlySpan<byte> GetEntryPointCode(int entryPointIndex, out nuint outSize);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetEntryPointCodeBlob(int entryPointIndex, int targetIndex, out IBlob outBlob);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetEntryPointHostCallable(int entryPointIndex, int targetIndex, out ISlangSharedLibrary outSharedLibrary);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetTargetCodeBlob(int targetIndex, out IBlob outBlob);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetTargetHostCallable(int targetIndex, out ISlangSharedLibrary outSharedLibrary);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    [return: MarshalUsing(CountElementName = "outSize")]
    ReadOnlySpan<byte> GetCompileRequestCode(out nuint outSize);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    IMutableFileSystem GetCompileRequestResultAsFileSystem();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetContainerCode(out IBlob outBlob);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult LoadRepro(IFileSystem fileSystem,
                          [MarshalUsing(CountElementName = "size")] Span<byte> data,
                          nuint size);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult SaveRepro(out IBlob outBlob);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult EnableReproCapture();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetProgram(out IComponentType outProgram);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetEntryPoint(nint entryPointIndex, out IComponentType outEntryPoint);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetModule(nint translationUnitIndex, out IModule outModule);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetSession(out ISession outSession);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<ShaderReflection>))]
    ShaderReflection? GetReflection();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetCommandLineCompilerMode();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult AddTargetCapability(nint targetIndex, Unmanaged.CapabilityID capability);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetProgramWithEntryPoints(out IComponentType outProgram);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult IsParameterLocationUsed(nint entryPointIndex,
                                        nint targetIndex,
                                        ParameterCategory category,
                                        nuint spaceIndex,
                                        nuint registerIndex,
                                        [MarshalAs(UnmanagedType.I1)] out bool outUsed);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetTargetLineDirectiveMode(nint targetIndex, Unmanaged.LineDirectiveMode mode);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetTargetForceGlslScalarBufferLayout(int targetIndex, [MarshalAs(UnmanagedType.I1)] bool forceScalarLayout);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void OverrideDiagnosticSeverity(nint messageId, Unmanaged.Severity overrideSeverity);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    DiagnosticFlags GetDiagnosticFlags();

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetDiagnosticFlags(DiagnosticFlags flags);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetDebugInfoFormat(Unmanaged.DebugInfoFormat debugFormat);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetEnableEffectAnnotations([MarshalAs(UnmanagedType.I1)] bool value);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetReportDownstreamTime([MarshalAs(UnmanagedType.I1)] bool value);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetReportPerfBenchmark([MarshalAs(UnmanagedType.I1)] bool value);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetSkipSpirvValidation([MarshalAs(UnmanagedType.I1)] bool value);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetTargetUseMinimumSlangOptimization(int targetIndex, [MarshalAs(UnmanagedType.I1)] bool value);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetIgnoreCapabilityCheck([MarshalAs(UnmanagedType.I1)] bool value);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult GetCompileTimeProfile(out IProfiler compileTimeProfile, [MarshalAs(UnmanagedType.I1)] bool shouldClear);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetTargetGenerateWholeProgram(int targetIndex, [MarshalAs(UnmanagedType.I1)] bool value);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetTargetForceDxLayout(int targetIndex, [MarshalAs(UnmanagedType.I1)] bool value);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetTargetEmbedDownstreamIr(int targetIndex, [MarshalAs(UnmanagedType.I1)] bool value);
}