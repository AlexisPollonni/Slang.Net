using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Interfaces;
using SlangNet.ComWrappers.Tools;
using SlangNet.Enums;

namespace SlangNet.ComWrappers;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf8, Options = ComInterfaceOptions.ComObjectWrapper)]
[Guid("96D33993-317C-4DB5-AFD8-666EE77248E2")]
public partial interface ICompileRequest : IUnknown
{
    [PreserveSig]
    void SetFileSystem(IFileSystem fileSystem);

    [PreserveSig]
    void SetCompileFlags(CompileFlags flags);

    [PreserveSig]
    CompileFlags GetCompileFlags();

    [PreserveSig]
    void SetDumpIntermediates(int enable);

    [PreserveSig]
    void SetDumpIntermediatePrefix(string prefix);

    [PreserveSig]
    void SetLineDirectiveMode(Unmanaged.LineDirectiveMode mode);

    [PreserveSig]
    void SetCodeGenTarget(Unmanaged.CompileTarget target);

    [PreserveSig]
    int AddCodeGenTarget(Unmanaged.CompileTarget target);

    [PreserveSig]
    void SetTargetProfile(int targetIndex, Unmanaged.ProfileID profile);

    [PreserveSig]
    void SetTargetFlags(int targetIndex, TargetFlags flags);

    [PreserveSig]
    void SetTargetFloatingPointMode(int targetIndex, Unmanaged.FloatingPointMode mode);

    [PreserveSig]
    void SetTargetMatrixLayoutMode(int targetIndex, Unmanaged.MatrixLayoutMode mode);

    [PreserveSig]
    void SetMatrixLayoutMode(Unmanaged.MatrixLayoutMode mode);

    [PreserveSig]
    void SetDebugInfoLevel(Unmanaged.DebugInfoLevel level);

    [PreserveSig]
    void SetOptimizationLevel(Unmanaged.OptimizationLevel level);

    [PreserveSig]
    void SetOutputContainerFormat(Unmanaged.ContainerFormat format);

    [PreserveSig]
    void SetPassThrough(Unmanaged.PassThrough passThrough);

    [PreserveSig]
    void SetDiagnosticCallback(Unmanaged.SlangDiagnosticCallback callback, string userData);

    [PreserveSig]
    void SetWriter(Unmanaged.WriterChannel channel, IWriter writer);

    [PreserveSig]
    IWriter? GetWriter(Unmanaged.WriterChannel channel);

    [PreserveSig]
    void AddSearchPath(string searchDir);

    [PreserveSig]
    void AddPreprocessorDefine(string key, string value);

    [PreserveSig]
    SlangResult ProcessCommandLineArguments([MarshalUsing(CountElementName = "argCount")] Span<string> args, int argCount);

    [PreserveSig]
    int AddTranslationUnit(Unmanaged.SourceLanguage language, string name);

    [PreserveSig]
    void SetDefaultModuleName(string defaultModuleName);

    [PreserveSig]
    void AddTranslationUnitPreprocessorDefine(int translationUnitIndex, string key, string value);

    [PreserveSig]
    void AddTranslationUnitSourceFile(int translationUnitIndex, string path);

    [PreserveSig]
    void AddTranslationUnitSourceString(int translationUnitIndex, string path, string source);

    [PreserveSig]
    SlangResult AddLibraryReference(string basePath,
                                    [MarshalUsing(CountElementName = "libDataSize")] Span<byte> libData,
                                    nuint libDataSize);

    [PreserveSig]
    void AddTranslationUnitSourceStringSpan(int translationUnitIndex, string path, string source, nint unused = 0);

    [PreserveSig]
    void AddTranslationUnitSourceBlob(int translationUnitIndex, string path, IBlob sourceBlob);

    [PreserveSig]
    int AddEntryPoint(int translationUnitIndex, string name, Unmanaged.Stage stage);

    [PreserveSig]
    int AddEntryPointEx(int translationUnitIndex,
                        string name,
                        Unmanaged.Stage stage,
                        int genericArgCount,
                        [MarshalUsing(CountElementName = "genericArgCount")] Span<string> genericArgs);

    [PreserveSig]
    SlangResult SetGlobalGenericArgs(int genericArgCount,
                                     [MarshalUsing(CountElementName = "genericArgCount")] Span<string> genericArgs);

    [PreserveSig]
    SlangResult SetTypeNameForGlobalExistentialTypeParam(int slotIndex, string typeName);

    [PreserveSig]
    SlangResult SetTypeNameForEntryPointExistentialTypeParam(int entryPointIndex, int slotIndex, string typeName);

    [PreserveSig]
    void SetAllowGlslInput([MarshalAs(UnmanagedType.I1)] bool value);

    [PreserveSig]
    SlangResult Compile();

    [PreserveSig]
    string? GetDiagnosticOutput();

    [PreserveSig]
    SlangResult GetDiagnosticOutputBlob(out IBlob outBlob);

    [PreserveSig]
    int GetDependencyFileCount();

    [PreserveSig]
    string? GetDependencyFilePath(int index);

    [PreserveSig]
    int GetTranslationUnitCount();

    [PreserveSig]
    string? GetEntryPointSource(int entryPointIndex);

    [PreserveSig]
    [return: MarshalUsing(CountElementName = "outSize")]
    ReadOnlySpan<byte> GetEntryPointCode(int entryPointIndex, out nuint outSize);

    [PreserveSig]
    SlangResult GetEntryPointCodeBlob(int entryPointIndex, int targetIndex, out IBlob outBlob);

    [PreserveSig]
    SlangResult GetEntryPointHostCallable(int entryPointIndex, int targetIndex, out ISlangSharedLibrary outSharedLibrary);

    [PreserveSig]
    SlangResult GetTargetCodeBlob(int targetIndex, out IBlob outBlob);

    [PreserveSig]
    SlangResult GetTargetHostCallable(int targetIndex, out ISlangSharedLibrary outSharedLibrary);

    [PreserveSig]
    [return: MarshalUsing(CountElementName = "outSize")]
    ReadOnlySpan<byte> GetCompileRequestCode(out nuint outSize);

    [PreserveSig]
    IMutableFileSystem GetCompileRequestResultAsFileSystem();

    [PreserveSig]
    SlangResult GetContainerCode(out IBlob outBlob);

    [PreserveSig]
    SlangResult LoadRepro(IFileSystem fileSystem,
                          [MarshalUsing(CountElementName = "size")] ReadOnlySpan<byte> data,
                          nuint size);

    [PreserveSig]
    SlangResult SaveRepro(out IBlob outBlob);

    [PreserveSig]
    SlangResult EnableReproCapture();

    [PreserveSig]
    SlangResult GetProgram(out IComponentType outProgram);

    [PreserveSig]
    SlangResult GetEntryPoint(nint entryPointIndex, out IComponentType outEntryPoint);

    [PreserveSig]
    SlangResult GetModule(nint translationUnitIndex, out IModule outModule);

    [PreserveSig]
    SlangResult GetSession(out ISession outSession);

    [PreserveSig]
    [return: MarshalUsing(typeof(NullableHandleStructMarshaller<ShaderReflection>))]
    ShaderReflection? GetReflection();

    [PreserveSig]
    void SetCommandLineCompilerMode();

    [PreserveSig]
    SlangResult AddTargetCapability(nint targetIndex, Unmanaged.CapabilityID capability);

    [PreserveSig]
    SlangResult GetProgramWithEntryPoints(out IComponentType outProgram);

    [PreserveSig]
    SlangResult IsParameterLocationUsed(nint entryPointIndex,
                                        nint targetIndex,
                                        ParameterCategory category,
                                        nuint spaceIndex,
                                        nuint registerIndex,
                                        [MarshalAs(UnmanagedType.I1)] out bool outUsed);

    [PreserveSig]
    void SetTargetLineDirectiveMode(nint targetIndex, Unmanaged.LineDirectiveMode mode);

    [PreserveSig]
    void SetTargetForceGlslScalarBufferLayout(int targetIndex, [MarshalAs(UnmanagedType.I1)] bool forceScalarLayout);

    [PreserveSig]
    void OverrideDiagnosticSeverity(nint messageId, Unmanaged.Severity overrideSeverity);

    [PreserveSig]
    DiagnosticFlags GetDiagnosticFlags();

    [PreserveSig]
    void SetDiagnosticFlags(DiagnosticFlags flags);

    [PreserveSig]
    void SetDebugInfoFormat(Unmanaged.DebugInfoFormat debugFormat);

    [PreserveSig]
    void SetEnableEffectAnnotations([MarshalAs(UnmanagedType.I1)] bool value);

    [PreserveSig]
    void SetReportDownstreamTime([MarshalAs(UnmanagedType.I1)] bool value);

    [PreserveSig]
    void SetReportPerfBenchmark([MarshalAs(UnmanagedType.I1)] bool value);

    [PreserveSig]
    void SetSkipSpirvValidation([MarshalAs(UnmanagedType.I1)] bool value);

    [PreserveSig]
    void SetTargetUseMinimumSlangOptimization(int targetIndex, [MarshalAs(UnmanagedType.I1)] bool value);

    [PreserveSig]
    void SetIgnoreCapabilityCheck([MarshalAs(UnmanagedType.I1)] bool value);

    [PreserveSig]
    SlangResult GetCompileTimeProfile(out IProfiler compileTimeProfile, [MarshalAs(UnmanagedType.I1)] bool shouldClear);

    [PreserveSig]
    void SetTargetGenerateWholeProgram(int targetIndex, [MarshalAs(UnmanagedType.I1)] bool value);

    [PreserveSig]
    void SetTargetForceDxLayout(int targetIndex, [MarshalAs(UnmanagedType.I1)] bool value);

    [PreserveSig]
    void SetTargetEmbedDownstreamIr(int targetIndex, [MarshalAs(UnmanagedType.I1)] bool value);
}