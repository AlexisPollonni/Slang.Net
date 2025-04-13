using System;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

public static unsafe partial class SlangApi
{
    public const int SLANG_DIAGNOSTIC_FLAG_VERBOSE_PATHS = 0x01;
    public const int SLANG_DIAGNOSTIC_FLAG_TREAT_WARNINGS_AS_ERRORS = 0x02;

    public const int SLANG_COMPILE_FLAG_NO_MANGLING = 1 << 3;
    public const int SLANG_COMPILE_FLAG_NO_CODEGEN = 1 << 4;
    public const int SLANG_COMPILE_FLAG_OBFUSCATE = 1 << 5;
    public const int SLANG_COMPILE_FLAG_NO_CHECKING = 0;
    public const int SLANG_COMPILE_FLAG_SPLIT_MIXED_TYPES = 0;

    public const int SLANG_TARGET_FLAG_PARAMETER_BLOCKS_USE_REGISTER_SPACES = 1 << 4;
    public const int SLANG_TARGET_FLAG_GENERATE_WHOLE_PROGRAM = 1 << 8;
    public const int SLANG_TARGET_FLAG_DUMP_IR = 1 << 9;
    public const int SLANG_TARGET_FLAG_GENERATE_SPIRV_DIRECTLY = 1 << 10;

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.GetBuildTagString"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spGetBuildTagString", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* GetBuildTagString();

    [NativeTypeName("#define SLANG_FACILITY_WIN_GENERAL 0")]
    public const int SLANG_FACILITY_WIN_GENERAL = 0;

    [NativeTypeName("#define SLANG_FACILITY_WIN_INTERFACE 4")]
    public const int SLANG_FACILITY_WIN_INTERFACE = 4;

    [NativeTypeName("#define SLANG_FACILITY_WIN_API 7")]
    public const int SLANG_FACILITY_WIN_API = 7;

    [NativeTypeName("#define SLANG_FACILITY_BASE 0x200")]
    public const int SLANG_FACILITY_BASE = 0x200;

    [NativeTypeName("#define SLANG_FACILITY_CORE SLANG_FACILITY_BASE")]
    public const int SLANG_FACILITY_CORE = 0x200;

    [NativeTypeName("#define SLANG_FACILITY_INTERNAL SLANG_FACILITY_BASE + 1")]
    public const int SLANG_FACILITY_INTERNAL = 0x200 + 1;

    [NativeTypeName("#define SLANG_FACILITY_EXTERNAL_BASE 0x210")]
    public const int SLANG_FACILITY_EXTERNAL_BASE = 0x210;

    [NativeTypeName("#define SLANG_OK 0")]
    public const int SLANG_OK = 0;

    [NativeTypeName("#define SLANG_FAIL SLANG_MAKE_ERROR(SLANG_FACILITY_WIN_GENERAL, 0x4005)")]
    public const int SLANG_FAIL = unchecked((((int)(0)) << 16) | ((int)(0x4005)) | (int)(0x80000000));

    [NativeTypeName("#define SLANG_E_NOT_IMPLEMENTED SLANG_MAKE_WIN_GENERAL_ERROR(0x4001)")]
    public const int SLANG_E_NOT_IMPLEMENTED = unchecked((((int)(0)) << 16) | ((int)(0x4001)) | (int)(0x80000000));

    [NativeTypeName("#define SLANG_E_NO_INTERFACE SLANG_MAKE_WIN_GENERAL_ERROR(0x4002)")]
    public const int SLANG_E_NO_INTERFACE = unchecked((((int)(0)) << 16) | ((int)(0x4002)) | (int)(0x80000000));

    [NativeTypeName("#define SLANG_E_ABORT SLANG_MAKE_WIN_GENERAL_ERROR(0x4004)")]
    public const int SLANG_E_ABORT = unchecked((((int)(0)) << 16) | ((int)(0x4004)) | (int)(0x80000000));

    [NativeTypeName("#define SLANG_E_INVALID_HANDLE SLANG_MAKE_ERROR(SLANG_FACILITY_WIN_API, 6)")]
    public const int SLANG_E_INVALID_HANDLE = unchecked((((int)(7)) << 16) | ((int)(6)) | (int)(0x80000000));

    [NativeTypeName("#define SLANG_E_INVALID_ARG SLANG_MAKE_ERROR(SLANG_FACILITY_WIN_API, 0x57)")]
    public const int SLANG_E_INVALID_ARG = unchecked((((int)(7)) << 16) | ((int)(0x57)) | (int)(0x80000000));

    [NativeTypeName("#define SLANG_E_OUT_OF_MEMORY SLANG_MAKE_ERROR(SLANG_FACILITY_WIN_API, 0xe)")]
    public const int SLANG_E_OUT_OF_MEMORY = unchecked((((int)(7)) << 16) | ((int)(0xe)) | (int)(0x80000000));

    [NativeTypeName("#define SLANG_E_BUFFER_TOO_SMALL SLANG_MAKE_CORE_ERROR(1)")]
    public const int SLANG_E_BUFFER_TOO_SMALL = unchecked((((int)(0x200)) << 16) | ((int)(1)) | (int)(0x80000000));

    [NativeTypeName("#define SLANG_E_UNINITIALIZED SLANG_MAKE_CORE_ERROR(2)")]
    public const int SLANG_E_UNINITIALIZED = unchecked((((int)(0x200)) << 16) | ((int)(2)) | (int)(0x80000000));

    [NativeTypeName("#define SLANG_E_PENDING SLANG_MAKE_CORE_ERROR(3)")]
    public const int SLANG_E_PENDING = unchecked((((int)(0x200)) << 16) | ((int)(3)) | (int)(0x80000000));

    [NativeTypeName("#define SLANG_E_CANNOT_OPEN SLANG_MAKE_CORE_ERROR(4)")]
    public const int SLANG_E_CANNOT_OPEN = unchecked((((int)(0x200)) << 16) | ((int)(4)) | (int)(0x80000000));

    [NativeTypeName("#define SLANG_E_NOT_FOUND SLANG_MAKE_CORE_ERROR(5)")]
    public const int SLANG_E_NOT_FOUND = unchecked((((int)(0x200)) << 16) | ((int)(5)) | (int)(0x80000000));

    [NativeTypeName("#define SLANG_E_INTERNAL_FAIL SLANG_MAKE_CORE_ERROR(6)")]
    public const int SLANG_E_INTERNAL_FAIL = unchecked((((int)(0x200)) << 16) | ((int)(6)) | (int)(0x80000000));

    [NativeTypeName("#define SLANG_E_NOT_AVAILABLE SLANG_MAKE_CORE_ERROR(7)")]
    public const int SLANG_E_NOT_AVAILABLE = unchecked((((int)(0x200)) << 16) | ((int)(7)) | (int)(0x80000000));

    [NativeTypeName("#define SLANG_E_TIME_OUT SLANG_MAKE_CORE_ERROR(8)")]
    public const int SLANG_E_TIME_OUT = unchecked((((int)(0x200)) << 16) | ((int)(8)) | (int)(0x80000000));

    [NativeTypeName("#define SLANG_API_VERSION 0")]
    public const int SLANG_API_VERSION = 0;

    [NativeTypeName("#define SLANG_ERROR_INSUFFICIENT_BUFFER SLANG_E_BUFFER_TOO_SMALL")]
    public const int SLANG_ERROR_INSUFFICIENT_BUFFER = unchecked((((int)(0x200)) << 16) | ((int)(1)) | (int)(0x80000000));

    [NativeTypeName("#define SLANG_ERROR_INVALID_PARAMETER SLANG_E_INVALID_ARG")]
    public const int SLANG_ERROR_INVALID_PARAMETER = unchecked((((int)(7)) << 16) | ((int)(0x57)) | (int)(0x80000000));

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.CreateSession"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spCreateSession", ExactSpelling = true)]
    [return: NativeTypeName("SlangSession *")]
    public static extern IGlobalSession* CreateSession([NativeTypeName("const char *")] sbyte* deprecated = null);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.DestroySession"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spDestroySession", ExactSpelling = true)]
    public static extern void DestroySession([NativeTypeName("SlangSession *")] IGlobalSession* session);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SessionSetSharedLibraryLoader"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSessionSetSharedLibraryLoader", ExactSpelling = true)]
    public static extern void SessionSetSharedLibraryLoader([NativeTypeName("SlangSession *")] IGlobalSession* session, ISlangSharedLibraryLoader* loader);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SessionGetSharedLibraryLoader"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSessionGetSharedLibraryLoader", ExactSpelling = true)]
    public static extern ISlangSharedLibraryLoader* SessionGetSharedLibraryLoader([NativeTypeName("SlangSession *")] IGlobalSession* session);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SessionCheckCompileTargetSupport"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSessionCheckCompileTargetSupport", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int SessionCheckCompileTargetSupport([NativeTypeName("SlangSession *")] IGlobalSession* session, [NativeTypeName("SlangCompileTarget")] CompileTarget target);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SessionCheckPassThroughSupport"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSessionCheckPassThroughSupport", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int SessionCheckPassThroughSupport([NativeTypeName("SlangSession *")] IGlobalSession* session, [NativeTypeName("SlangPassThrough")] PassThrough passThrough);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.AddBuiltins"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spAddBuiltins", ExactSpelling = true)]
    public static extern void AddBuiltins([NativeTypeName("SlangSession *")] IGlobalSession* session, [NativeTypeName("const char *")] sbyte* sourcePath, [NativeTypeName("const char *")] sbyte* sourceString);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.CreateCompileRequest"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spCreateCompileRequest", ExactSpelling = true)]
    [return: NativeTypeName("SlangCompileRequest *")]
    public static extern ICompileRequest* CreateCompileRequest([NativeTypeName("SlangSession *")] IGlobalSession* session);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.DestroyCompileRequest"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spDestroyCompileRequest", ExactSpelling = true)]
    public static extern void DestroyCompileRequest([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SetFileSystem"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSetFileSystem", ExactSpelling = true)]
    public static extern void SetFileSystem([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, ISlangFileSystem* fileSystem);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SetCompileFlags"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSetCompileFlags", ExactSpelling = true)]
    public static extern void SetCompileFlags([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("SlangCompileFlags")] uint flags);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.GetCompileFlags"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spGetCompileFlags", ExactSpelling = true)]
    [return: NativeTypeName("SlangCompileFlags")]
    public static extern uint GetCompileFlags([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SetDumpIntermediates"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSetDumpIntermediates", ExactSpelling = true)]
    public static extern void SetDumpIntermediates([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, int enable);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SetDumpIntermediatePrefix"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSetDumpIntermediatePrefix", ExactSpelling = true)]
    public static extern void SetDumpIntermediatePrefix([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("const char *")] sbyte* prefix);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SetLineDirectiveMode"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSetLineDirectiveMode", ExactSpelling = true)]
    public static extern void SetLineDirectiveMode([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("SlangLineDirectiveMode")] LineDirectiveMode mode);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SetTargetLineDirectiveMode"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSetTargetLineDirectiveMode", ExactSpelling = true)]
    public static extern void SetTargetLineDirectiveMode([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, int targetIndex, [NativeTypeName("SlangLineDirectiveMode")] LineDirectiveMode mode);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SetTargetForceGLSLScalarBufferLayout"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSetTargetForceGLSLScalarBufferLayout", ExactSpelling = true)]
    public static extern void SetTargetForceGLSLScalarBufferLayout([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, int targetIndex, [NativeTypeName("bool")] Boolean forceScalarLayout);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SetTargetUseMinimumSlangOptimization"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSetTargetUseMinimumSlangOptimization", ExactSpelling = true)]
    public static extern void SetTargetUseMinimumSlangOptimization([NativeTypeName("slang::ICompileRequest *")] ICompileRequest* request, int targetIndex, [NativeTypeName("bool")] Boolean val);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SetIgnoreCapabilityCheck"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSetIgnoreCapabilityCheck", ExactSpelling = true)]
    public static extern void SetIgnoreCapabilityCheck([NativeTypeName("slang::ICompileRequest *")] ICompileRequest* request, [NativeTypeName("bool")] Boolean val);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SetCodeGenTarget"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSetCodeGenTarget", ExactSpelling = true)]
    public static extern void SetCodeGenTarget([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("SlangCompileTarget")] CompileTarget target);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.AddCodeGenTarget"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spAddCodeGenTarget", ExactSpelling = true)]
    public static extern int AddCodeGenTarget([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("SlangCompileTarget")] CompileTarget target);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SetTargetProfile"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSetTargetProfile", ExactSpelling = true)]
    public static extern void SetTargetProfile([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, int targetIndex, [NativeTypeName("SlangProfileID")] ProfileID profile);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SetTargetFlags"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSetTargetFlags", ExactSpelling = true)]
    public static extern void SetTargetFlags([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, int targetIndex, [NativeTypeName("SlangTargetFlags")] uint flags);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SetTargetFloatingPointMode"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSetTargetFloatingPointMode", ExactSpelling = true)]
    public static extern void SetTargetFloatingPointMode([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, int targetIndex, [NativeTypeName("SlangFloatingPointMode")] FloatingPointMode mode);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.AddTargetCapability"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spAddTargetCapability", ExactSpelling = true)]
    public static extern void AddTargetCapability([NativeTypeName("slang::ICompileRequest *")] ICompileRequest* request, int targetIndex, [NativeTypeName("SlangCapabilityID")] CapabilityID capability);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SetTargetMatrixLayoutMode"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSetTargetMatrixLayoutMode", ExactSpelling = true)]
    public static extern void SetTargetMatrixLayoutMode([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, int targetIndex, [NativeTypeName("SlangMatrixLayoutMode")] MatrixLayoutMode mode);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SetMatrixLayoutMode"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSetMatrixLayoutMode", ExactSpelling = true)]
    public static extern void SetMatrixLayoutMode([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("SlangMatrixLayoutMode")] MatrixLayoutMode mode);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SetDebugInfoLevel"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSetDebugInfoLevel", ExactSpelling = true)]
    public static extern void SetDebugInfoLevel([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("SlangDebugInfoLevel")] DebugInfoLevel level);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SetDebugInfoFormat"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSetDebugInfoFormat", ExactSpelling = true)]
    public static extern void SetDebugInfoFormat([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("SlangDebugInfoFormat")] DebugInfoFormat format);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SetOptimizationLevel"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSetOptimizationLevel", ExactSpelling = true)]
    public static extern void SetOptimizationLevel([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("SlangOptimizationLevel")] OptimizationLevel level);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SetOutputContainerFormat"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSetOutputContainerFormat", ExactSpelling = true)]
    public static extern void SetOutputContainerFormat([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("SlangContainerFormat")] ContainerFormat format);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SetPassThrough"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSetPassThrough", ExactSpelling = true)]
    public static extern void SetPassThrough([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("SlangPassThrough")] PassThrough passThrough);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SetDiagnosticCallback"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSetDiagnosticCallback", ExactSpelling = true)]
    public static extern void SetDiagnosticCallback([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("SlangDiagnosticCallback")] IntPtr callback, [NativeTypeName("const void *")] void* userData);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SetWriter"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSetWriter", ExactSpelling = true)]
    public static extern void SetWriter([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("SlangWriterChannel")] WriterChannel channel, ISlangWriter* writer);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.GetWriter"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spGetWriter", ExactSpelling = true)]
    public static extern ISlangWriter* GetWriter([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("SlangWriterChannel")] WriterChannel channel);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.AddSearchPath"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spAddSearchPath", ExactSpelling = true)]
    public static extern void AddSearchPath([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("const char *")] sbyte* searchDir);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.AddPreprocessorDefine"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spAddPreprocessorDefine", ExactSpelling = true)]
    public static extern void AddPreprocessorDefine([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("const char *")] sbyte* key, [NativeTypeName("const char *")] sbyte* value);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ProcessCommandLineArguments"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spProcessCommandLineArguments", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int ProcessCommandLineArguments([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("const char *const *")] sbyte** args, int argCount);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.AddTranslationUnit"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spAddTranslationUnit", ExactSpelling = true)]
    public static extern int AddTranslationUnit([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("SlangSourceLanguage")] SourceLanguage language, [NativeTypeName("const char *")] sbyte* name);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SetDefaultModuleName"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSetDefaultModuleName", ExactSpelling = true)]
    public static extern void SetDefaultModuleName([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("const char *")] sbyte* defaultModuleName);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.TranslationUnit_addPreprocessorDefine"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spTranslationUnit_addPreprocessorDefine", ExactSpelling = true)]
    public static extern void TranslationUnit_addPreprocessorDefine([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, int translationUnitIndex, [NativeTypeName("const char *")] sbyte* key, [NativeTypeName("const char *")] sbyte* value);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.AddTranslationUnitSourceFile"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spAddTranslationUnitSourceFile", ExactSpelling = true)]
    public static extern void AddTranslationUnitSourceFile([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, int translationUnitIndex, [NativeTypeName("const char *")] sbyte* path);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.AddTranslationUnitSourceString"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spAddTranslationUnitSourceString", ExactSpelling = true)]
    public static extern void AddTranslationUnitSourceString([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, int translationUnitIndex, [NativeTypeName("const char *")] sbyte* path, [NativeTypeName("const char *")] sbyte* source);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.AddLibraryReference"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spAddLibraryReference", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int AddLibraryReference([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("const char *")] sbyte* basePath, [NativeTypeName("const void *")] void* libData, [NativeTypeName("size_t")] nuint libDataSize);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.AddTranslationUnitSourceStringSpan"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spAddTranslationUnitSourceStringSpan", ExactSpelling = true)]
    public static extern void AddTranslationUnitSourceStringSpan([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, int translationUnitIndex, [NativeTypeName("const char *")] sbyte* path, [NativeTypeName("const char *")] sbyte* sourceBegin, [NativeTypeName("const char *")] sbyte* sourceEnd);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.AddTranslationUnitSourceBlob"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spAddTranslationUnitSourceBlob", ExactSpelling = true)]
    public static extern void AddTranslationUnitSourceBlob([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, int translationUnitIndex, [NativeTypeName("const char *")] sbyte* path, ISlangBlob* sourceBlob);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.FindProfile"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spFindProfile", ExactSpelling = true)]
    [return: NativeTypeName("SlangProfileID")]
    public static extern ProfileID FindProfile([NativeTypeName("SlangSession *")] IGlobalSession* session, [NativeTypeName("const char *")] sbyte* name);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.FindCapability"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spFindCapability", ExactSpelling = true)]
    [return: NativeTypeName("SlangCapabilityID")]
    public static extern CapabilityID FindCapability([NativeTypeName("SlangSession *")] IGlobalSession* session, [NativeTypeName("const char *")] sbyte* name);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.AddEntryPoint"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spAddEntryPoint", ExactSpelling = true)]
    public static extern int AddEntryPoint([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, int translationUnitIndex, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("SlangStage")] Stage stage);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.AddEntryPointEx"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spAddEntryPointEx", ExactSpelling = true)]
    public static extern int AddEntryPointEx([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, int translationUnitIndex, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("SlangStage")] Stage stage, int genericArgCount, [NativeTypeName("const char **")] sbyte** genericArgs);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SetGlobalGenericArgs"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSetGlobalGenericArgs", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int SetGlobalGenericArgs([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, int genericArgCount, [NativeTypeName("const char **")] sbyte** genericArgs);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SetTypeNameForGlobalExistentialTypeParam"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSetTypeNameForGlobalExistentialTypeParam", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int SetTypeNameForGlobalExistentialTypeParam([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, int slotIndex, [NativeTypeName("const char *")] sbyte* typeName);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SetTypeNameForEntryPointExistentialTypeParam"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSetTypeNameForEntryPointExistentialTypeParam", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int SetTypeNameForEntryPointExistentialTypeParam([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, int entryPointIndex, int slotIndex, [NativeTypeName("const char *")] sbyte* typeName);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.Compile"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spCompile", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int Compile([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.GetDiagnosticOutput"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spGetDiagnosticOutput", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* GetDiagnosticOutput([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.GetDiagnosticOutputBlob"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spGetDiagnosticOutputBlob", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int GetDiagnosticOutputBlob([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, ISlangBlob** outBlob);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.GetDependencyFileCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spGetDependencyFileCount", ExactSpelling = true)]
    public static extern int GetDependencyFileCount([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.GetDependencyFilePath"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spGetDependencyFilePath", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* GetDependencyFilePath([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, int index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.GetTranslationUnitCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spGetTranslationUnitCount", ExactSpelling = true)]
    public static extern int GetTranslationUnitCount([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.GetEntryPointSource"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spGetEntryPointSource", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* GetEntryPointSource([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, int entryPointIndex);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.GetEntryPointCode"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spGetEntryPointCode", ExactSpelling = true)]
    [return: NativeTypeName("const void *")]
    public static extern void* GetEntryPointCode([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, int entryPointIndex, [NativeTypeName("size_t *")] nuint* outSize);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.GetEntryPointCodeBlob"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spGetEntryPointCodeBlob", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int GetEntryPointCodeBlob([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, int entryPointIndex, int targetIndex, ISlangBlob** outBlob);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.GetEntryPointHostCallable"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spGetEntryPointHostCallable", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int GetEntryPointHostCallable([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, int entryPointIndex, int targetIndex, ISlangSharedLibrary** outSharedLibrary);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.GetTargetCodeBlob"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spGetTargetCodeBlob", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int GetTargetCodeBlob([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, int targetIndex, ISlangBlob** outBlob);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.GetTargetHostCallable"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spGetTargetHostCallable", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int GetTargetHostCallable([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, int targetIndex, ISlangSharedLibrary** outSharedLibrary);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.GetCompileRequestCode"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spGetCompileRequestCode", ExactSpelling = true)]
    [return: NativeTypeName("const void *")]
    public static extern void* GetCompileRequestCode([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("size_t *")] nuint* outSize);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.GetContainerCode"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spGetContainerCode", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int GetContainerCode([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, ISlangBlob** outBlob);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.LoadRepro"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spLoadRepro", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int LoadRepro([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, ISlangFileSystem* fileSystem, [NativeTypeName("const void *")] void* data, [NativeTypeName("size_t")] nuint size);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SaveRepro"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSaveRepro", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int SaveRepro([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, ISlangBlob** outBlob);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.EnableReproCapture"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spEnableReproCapture", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int EnableReproCapture([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.GetCompileTimeProfile"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spGetCompileTimeProfile", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int GetCompileTimeProfile([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, ISlangProfiler** compileTimeProfile, [NativeTypeName("bool")] Boolean shouldClear);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ExtractRepro"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spExtractRepro", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int ExtractRepro([NativeTypeName("SlangSession *")] IGlobalSession* session, [NativeTypeName("const void *")] void* reproData, [NativeTypeName("size_t")] nuint reproDataSize, ISlangMutableFileSystem* fileSystem);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.LoadReproAsFileSystem"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spLoadReproAsFileSystem", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int LoadReproAsFileSystem([NativeTypeName("SlangSession *")] IGlobalSession* session, [NativeTypeName("const void *")] void* reproData, [NativeTypeName("size_t")] nuint reproDataSize, ISlangFileSystem* replaceFileSystem, ISlangFileSystemExt** outFileSystem);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.OverrideDiagnosticSeverity"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spOverrideDiagnosticSeverity", ExactSpelling = true)]
    public static extern void OverrideDiagnosticSeverity([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("SlangInt")] nint messageID, [NativeTypeName("SlangSeverity")] Severity overrideSeverity);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.GetDiagnosticFlags"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spGetDiagnosticFlags", ExactSpelling = true)]
    [return: NativeTypeName("SlangDiagnosticFlags")]
    public static extern int GetDiagnosticFlags([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.SetDiagnosticFlags"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spSetDiagnosticFlags", ExactSpelling = true)]
    public static extern void SetDiagnosticFlags([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("SlangDiagnosticFlags")] int flags);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.GetReflection"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spGetReflection", ExactSpelling = true)]
    [return: NativeTypeName("SlangReflection *")]
    public static extern SlangProgramLayout* GetReflection([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionUserAttribute_GetName"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionUserAttribute_GetName", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* ReflectionUserAttribute_GetName(SlangReflectionUserAttribute* attrib);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionUserAttribute_GetArgumentCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionUserAttribute_GetArgumentCount", ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint ReflectionUserAttribute_GetArgumentCount(SlangReflectionUserAttribute* attrib);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionUserAttribute_GetArgumentType"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionUserAttribute_GetArgumentType", ExactSpelling = true)]
    public static extern SlangReflectionType* ReflectionUserAttribute_GetArgumentType(SlangReflectionUserAttribute* attrib, [NativeTypeName("unsigned int")] uint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionUserAttribute_GetArgumentValueInt"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionUserAttribute_GetArgumentValueInt", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int ReflectionUserAttribute_GetArgumentValueInt(SlangReflectionUserAttribute* attrib, [NativeTypeName("unsigned int")] uint index, int* rs);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionUserAttribute_GetArgumentValueFloat"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionUserAttribute_GetArgumentValueFloat", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int ReflectionUserAttribute_GetArgumentValueFloat(SlangReflectionUserAttribute* attrib, [NativeTypeName("unsigned int")] uint index, float* rs);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionUserAttribute_GetArgumentValueString"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionUserAttribute_GetArgumentValueString", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* ReflectionUserAttribute_GetArgumentValueString(SlangReflectionUserAttribute* attrib, [NativeTypeName("unsigned int")] uint index, [NativeTypeName("size_t *")] nuint* outSize);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionType_GetKind"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionType_GetKind", ExactSpelling = true)]
    [return: NativeTypeName("SlangTypeKind")]
    public static extern TypeKind ReflectionType_GetKind(SlangReflectionType* type);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionType_GetUserAttributeCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionType_GetUserAttributeCount", ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint ReflectionType_GetUserAttributeCount(SlangReflectionType* type);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionType_GetUserAttribute"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionType_GetUserAttribute", ExactSpelling = true)]
    public static extern SlangReflectionUserAttribute* ReflectionType_GetUserAttribute(SlangReflectionType* type, [NativeTypeName("unsigned int")] uint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionType_FindUserAttributeByName"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionType_FindUserAttributeByName", ExactSpelling = true)]
    public static extern SlangReflectionUserAttribute* ReflectionType_FindUserAttributeByName(SlangReflectionType* type, [NativeTypeName("const char *")] sbyte* name);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionType_applySpecializations"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionType_applySpecializations", ExactSpelling = true)]
    public static extern SlangReflectionType* ReflectionType_applySpecializations(SlangReflectionType* type, SlangReflectionGeneric* generic);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionType_GetFieldCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionType_GetFieldCount", ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint ReflectionType_GetFieldCount(SlangReflectionType* type);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionType_GetFieldByIndex"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionType_GetFieldByIndex", ExactSpelling = true)]
    public static extern SlangReflectionVariable* ReflectionType_GetFieldByIndex(SlangReflectionType* type, [NativeTypeName("unsigned int")] uint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionType_GetElementCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionType_GetElementCount", ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint ReflectionType_GetElementCount(SlangReflectionType* type);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionType_GetElementType"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionType_GetElementType", ExactSpelling = true)]
    public static extern SlangReflectionType* ReflectionType_GetElementType(SlangReflectionType* type);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionType_GetRowCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionType_GetRowCount", ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint ReflectionType_GetRowCount(SlangReflectionType* type);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionType_GetColumnCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionType_GetColumnCount", ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint ReflectionType_GetColumnCount(SlangReflectionType* type);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionType_GetScalarType"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionType_GetScalarType", ExactSpelling = true)]
    [return: NativeTypeName("SlangScalarType")]
    public static extern ScalarType ReflectionType_GetScalarType(SlangReflectionType* type);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionType_GetResourceShape"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionType_GetResourceShape", ExactSpelling = true)]
    [return: NativeTypeName("SlangResourceShape")]
    public static extern ResourceShape ReflectionType_GetResourceShape(SlangReflectionType* type);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionType_GetResourceAccess"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionType_GetResourceAccess", ExactSpelling = true)]
    [return: NativeTypeName("SlangResourceAccess")]
    public static extern ResourceAccess ReflectionType_GetResourceAccess(SlangReflectionType* type);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionType_GetResourceResultType"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionType_GetResourceResultType", ExactSpelling = true)]
    public static extern SlangReflectionType* ReflectionType_GetResourceResultType(SlangReflectionType* type);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionType_GetName"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionType_GetName", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* ReflectionType_GetName(SlangReflectionType* type);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionType_GetFullName"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionType_GetFullName", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int ReflectionType_GetFullName(SlangReflectionType* type, ISlangBlob** outNameBlob);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionType_GetGenericContainer"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionType_GetGenericContainer", ExactSpelling = true)]
    public static extern SlangReflectionGeneric* ReflectionType_GetGenericContainer(SlangReflectionType* type);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_GetType"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_GetType", ExactSpelling = true)]
    public static extern SlangReflectionType* ReflectionTypeLayout_GetType(SlangReflectionTypeLayout* type);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getKind"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getKind", ExactSpelling = true)]
    [return: NativeTypeName("SlangTypeKind")]
    public static extern TypeKind ReflectionTypeLayout_getKind(SlangReflectionTypeLayout* type);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_GetSize"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_GetSize", ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint ReflectionTypeLayout_GetSize(SlangReflectionTypeLayout* type, [NativeTypeName("SlangParameterCategory")] ParameterCategory category);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_GetStride"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_GetStride", ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint ReflectionTypeLayout_GetStride(SlangReflectionTypeLayout* type, [NativeTypeName("SlangParameterCategory")] ParameterCategory category);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getAlignment"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getAlignment", ExactSpelling = true)]
    [return: NativeTypeName("int32_t")]
    public static extern int ReflectionTypeLayout_getAlignment(SlangReflectionTypeLayout* type, [NativeTypeName("SlangParameterCategory")] ParameterCategory category);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_GetFieldCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_GetFieldCount", ExactSpelling = true)]
    [return: NativeTypeName("uint32_t")]
    public static extern uint ReflectionTypeLayout_GetFieldCount(SlangReflectionTypeLayout* type);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_GetFieldByIndex"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_GetFieldByIndex", ExactSpelling = true)]
    public static extern SlangReflectionVariableLayout* ReflectionTypeLayout_GetFieldByIndex(SlangReflectionTypeLayout* type, [NativeTypeName("unsigned int")] uint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_findFieldIndexByName"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_findFieldIndexByName", ExactSpelling = true)]
    [return: NativeTypeName("SlangInt")]
    public static extern nint ReflectionTypeLayout_findFieldIndexByName(SlangReflectionTypeLayout* typeLayout, [NativeTypeName("const char *")] sbyte* nameBegin, [NativeTypeName("const char *")] sbyte* nameEnd);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_GetExplicitCounter"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_GetExplicitCounter", ExactSpelling = true)]
    public static extern SlangReflectionVariableLayout* ReflectionTypeLayout_GetExplicitCounter(SlangReflectionTypeLayout* typeLayout);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_GetElementStride"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_GetElementStride", ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint ReflectionTypeLayout_GetElementStride(SlangReflectionTypeLayout* type, [NativeTypeName("SlangParameterCategory")] ParameterCategory category);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_GetElementTypeLayout"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_GetElementTypeLayout", ExactSpelling = true)]
    public static extern SlangReflectionTypeLayout* ReflectionTypeLayout_GetElementTypeLayout(SlangReflectionTypeLayout* type);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_GetElementVarLayout"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_GetElementVarLayout", ExactSpelling = true)]
    public static extern SlangReflectionVariableLayout* ReflectionTypeLayout_GetElementVarLayout(SlangReflectionTypeLayout* type);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getContainerVarLayout"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getContainerVarLayout", ExactSpelling = true)]
    public static extern SlangReflectionVariableLayout* ReflectionTypeLayout_getContainerVarLayout(SlangReflectionTypeLayout* type);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_GetParameterCategory"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_GetParameterCategory", ExactSpelling = true)]
    [return: NativeTypeName("SlangParameterCategory")]
    public static extern ParameterCategory ReflectionTypeLayout_GetParameterCategory(SlangReflectionTypeLayout* type);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_GetCategoryCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_GetCategoryCount", ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint ReflectionTypeLayout_GetCategoryCount(SlangReflectionTypeLayout* type);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_GetCategoryByIndex"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_GetCategoryByIndex", ExactSpelling = true)]
    [return: NativeTypeName("SlangParameterCategory")]
    public static extern ParameterCategory ReflectionTypeLayout_GetCategoryByIndex(SlangReflectionTypeLayout* type, [NativeTypeName("unsigned int")] uint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_GetMatrixLayoutMode"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_GetMatrixLayoutMode", ExactSpelling = true)]
    [return: NativeTypeName("SlangMatrixLayoutMode")]
    public static extern MatrixLayoutMode ReflectionTypeLayout_GetMatrixLayoutMode(SlangReflectionTypeLayout* type);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getGenericParamIndex"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getGenericParamIndex", ExactSpelling = true)]
    public static extern int ReflectionTypeLayout_getGenericParamIndex(SlangReflectionTypeLayout* type);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getPendingDataTypeLayout"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getPendingDataTypeLayout", ExactSpelling = true)]
    public static extern SlangReflectionTypeLayout* ReflectionTypeLayout_getPendingDataTypeLayout(SlangReflectionTypeLayout* type);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getSpecializedTypePendingDataVarLayout"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getSpecializedTypePendingDataVarLayout", ExactSpelling = true)]
    public static extern SlangReflectionVariableLayout* ReflectionTypeLayout_getSpecializedTypePendingDataVarLayout(SlangReflectionTypeLayout* type);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionType_getSpecializedTypeArgCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionType_getSpecializedTypeArgCount", ExactSpelling = true)]
    [return: NativeTypeName("SlangInt")]
    public static extern nint ReflectionType_getSpecializedTypeArgCount(SlangReflectionType* type);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionType_getSpecializedTypeArgType"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionType_getSpecializedTypeArgType", ExactSpelling = true)]
    public static extern SlangReflectionType* ReflectionType_getSpecializedTypeArgType(SlangReflectionType* type, [NativeTypeName("SlangInt")] nint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getBindingRangeCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getBindingRangeCount", ExactSpelling = true)]
    [return: NativeTypeName("SlangInt")]
    public static extern nint ReflectionTypeLayout_getBindingRangeCount(SlangReflectionTypeLayout* typeLayout);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getBindingRangeType"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getBindingRangeType", ExactSpelling = true)]
    [return: NativeTypeName("SlangBindingType")]
    public static extern BindingType ReflectionTypeLayout_getBindingRangeType(SlangReflectionTypeLayout* typeLayout, [NativeTypeName("SlangInt")] nint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_isBindingRangeSpecializable"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_isBindingRangeSpecializable", ExactSpelling = true)]
    [return: NativeTypeName("SlangInt")]
    public static extern nint ReflectionTypeLayout_isBindingRangeSpecializable(SlangReflectionTypeLayout* typeLayout, [NativeTypeName("SlangInt")] nint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getBindingRangeBindingCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getBindingRangeBindingCount", ExactSpelling = true)]
    [return: NativeTypeName("SlangInt")]
    public static extern nint ReflectionTypeLayout_getBindingRangeBindingCount(SlangReflectionTypeLayout* typeLayout, [NativeTypeName("SlangInt")] nint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getBindingRangeLeafTypeLayout"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getBindingRangeLeafTypeLayout", ExactSpelling = true)]
    public static extern SlangReflectionTypeLayout* ReflectionTypeLayout_getBindingRangeLeafTypeLayout(SlangReflectionTypeLayout* typeLayout, [NativeTypeName("SlangInt")] nint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getBindingRangeLeafVariable"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getBindingRangeLeafVariable", ExactSpelling = true)]
    public static extern SlangReflectionVariable* ReflectionTypeLayout_getBindingRangeLeafVariable(SlangReflectionTypeLayout* typeLayout, [NativeTypeName("SlangInt")] nint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getBindingRangeImageFormat"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getBindingRangeImageFormat", ExactSpelling = true)]
    [return: NativeTypeName("SlangImageFormat")]
    public static extern ImageFormat ReflectionTypeLayout_getBindingRangeImageFormat(SlangReflectionTypeLayout* typeLayout, [NativeTypeName("SlangInt")] nint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getFieldBindingRangeOffset"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getFieldBindingRangeOffset", ExactSpelling = true)]
    [return: NativeTypeName("SlangInt")]
    public static extern nint ReflectionTypeLayout_getFieldBindingRangeOffset(SlangReflectionTypeLayout* typeLayout, [NativeTypeName("SlangInt")] nint fieldIndex);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getExplicitCounterBindingRangeOffset"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getExplicitCounterBindingRangeOffset", ExactSpelling = true)]
    [return: NativeTypeName("SlangInt")]
    public static extern nint ReflectionTypeLayout_getExplicitCounterBindingRangeOffset(SlangReflectionTypeLayout* inTypeLayout);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getBindingRangeDescriptorSetIndex"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getBindingRangeDescriptorSetIndex", ExactSpelling = true)]
    [return: NativeTypeName("SlangInt")]
    public static extern nint ReflectionTypeLayout_getBindingRangeDescriptorSetIndex(SlangReflectionTypeLayout* typeLayout, [NativeTypeName("SlangInt")] nint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getBindingRangeFirstDescriptorRangeIndex"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getBindingRangeFirstDescriptorRangeIndex", ExactSpelling = true)]
    [return: NativeTypeName("SlangInt")]
    public static extern nint ReflectionTypeLayout_getBindingRangeFirstDescriptorRangeIndex(SlangReflectionTypeLayout* typeLayout, [NativeTypeName("SlangInt")] nint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getBindingRangeDescriptorRangeCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getBindingRangeDescriptorRangeCount", ExactSpelling = true)]
    [return: NativeTypeName("SlangInt")]
    public static extern nint ReflectionTypeLayout_getBindingRangeDescriptorRangeCount(SlangReflectionTypeLayout* typeLayout, [NativeTypeName("SlangInt")] nint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getDescriptorSetCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getDescriptorSetCount", ExactSpelling = true)]
    [return: NativeTypeName("SlangInt")]
    public static extern nint ReflectionTypeLayout_getDescriptorSetCount(SlangReflectionTypeLayout* typeLayout);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getDescriptorSetSpaceOffset"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getDescriptorSetSpaceOffset", ExactSpelling = true)]
    [return: NativeTypeName("SlangInt")]
    public static extern nint ReflectionTypeLayout_getDescriptorSetSpaceOffset(SlangReflectionTypeLayout* typeLayout, [NativeTypeName("SlangInt")] nint setIndex);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getDescriptorSetDescriptorRangeCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getDescriptorSetDescriptorRangeCount", ExactSpelling = true)]
    [return: NativeTypeName("SlangInt")]
    public static extern nint ReflectionTypeLayout_getDescriptorSetDescriptorRangeCount(SlangReflectionTypeLayout* typeLayout, [NativeTypeName("SlangInt")] nint setIndex);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getDescriptorSetDescriptorRangeIndexOffset"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getDescriptorSetDescriptorRangeIndexOffset", ExactSpelling = true)]
    [return: NativeTypeName("SlangInt")]
    public static extern nint ReflectionTypeLayout_getDescriptorSetDescriptorRangeIndexOffset(SlangReflectionTypeLayout* typeLayout, [NativeTypeName("SlangInt")] nint setIndex, [NativeTypeName("SlangInt")] nint rangeIndex);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getDescriptorSetDescriptorRangeDescriptorCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getDescriptorSetDescriptorRangeDescriptorCount", ExactSpelling = true)]
    [return: NativeTypeName("SlangInt")]
    public static extern nint ReflectionTypeLayout_getDescriptorSetDescriptorRangeDescriptorCount(SlangReflectionTypeLayout* typeLayout, [NativeTypeName("SlangInt")] nint setIndex, [NativeTypeName("SlangInt")] nint rangeIndex);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getDescriptorSetDescriptorRangeType"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getDescriptorSetDescriptorRangeType", ExactSpelling = true)]
    [return: NativeTypeName("SlangBindingType")]
    public static extern BindingType ReflectionTypeLayout_getDescriptorSetDescriptorRangeType(SlangReflectionTypeLayout* typeLayout, [NativeTypeName("SlangInt")] nint setIndex, [NativeTypeName("SlangInt")] nint rangeIndex);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getDescriptorSetDescriptorRangeCategory"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getDescriptorSetDescriptorRangeCategory", ExactSpelling = true)]
    [return: NativeTypeName("SlangParameterCategory")]
    public static extern ParameterCategory ReflectionTypeLayout_getDescriptorSetDescriptorRangeCategory(SlangReflectionTypeLayout* typeLayout, [NativeTypeName("SlangInt")] nint setIndex, [NativeTypeName("SlangInt")] nint rangeIndex);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getSubObjectRangeCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getSubObjectRangeCount", ExactSpelling = true)]
    [return: NativeTypeName("SlangInt")]
    public static extern nint ReflectionTypeLayout_getSubObjectRangeCount(SlangReflectionTypeLayout* typeLayout);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getSubObjectRangeBindingRangeIndex"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getSubObjectRangeBindingRangeIndex", ExactSpelling = true)]
    [return: NativeTypeName("SlangInt")]
    public static extern nint ReflectionTypeLayout_getSubObjectRangeBindingRangeIndex(SlangReflectionTypeLayout* typeLayout, [NativeTypeName("SlangInt")] nint subObjectRangeIndex);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getSubObjectRangeSpaceOffset"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getSubObjectRangeSpaceOffset", ExactSpelling = true)]
    [return: NativeTypeName("SlangInt")]
    public static extern nint ReflectionTypeLayout_getSubObjectRangeSpaceOffset(SlangReflectionTypeLayout* typeLayout, [NativeTypeName("SlangInt")] nint subObjectRangeIndex);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeLayout_getSubObjectRangeOffset"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeLayout_getSubObjectRangeOffset", ExactSpelling = true)]
    public static extern SlangReflectionVariableLayout* ReflectionTypeLayout_getSubObjectRangeOffset(SlangReflectionTypeLayout* typeLayout, [NativeTypeName("SlangInt")] nint subObjectRangeIndex);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionVariable_GetName"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionVariable_GetName", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* ReflectionVariable_GetName(SlangReflectionVariable* var);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionVariable_GetType"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionVariable_GetType", ExactSpelling = true)]
    public static extern SlangReflectionType* ReflectionVariable_GetType(SlangReflectionVariable* var);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionVariable_FindModifier"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionVariable_FindModifier", ExactSpelling = true)]
    public static extern SlangReflectionModifier* ReflectionVariable_FindModifier(SlangReflectionVariable* var, [NativeTypeName("SlangModifierID")] ModifierID modifierID);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionVariable_GetUserAttributeCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionVariable_GetUserAttributeCount", ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint ReflectionVariable_GetUserAttributeCount(SlangReflectionVariable* var);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionVariable_GetUserAttribute"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionVariable_GetUserAttribute", ExactSpelling = true)]
    public static extern SlangReflectionUserAttribute* ReflectionVariable_GetUserAttribute(SlangReflectionVariable* var, [NativeTypeName("unsigned int")] uint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionVariable_FindUserAttributeByName"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionVariable_FindUserAttributeByName", ExactSpelling = true)]
    public static extern SlangReflectionUserAttribute* ReflectionVariable_FindUserAttributeByName(SlangReflectionVariable* var, [NativeTypeName("SlangSession *")] IGlobalSession* globalSession, [NativeTypeName("const char *")] sbyte* name);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionVariable_HasDefaultValue"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionVariable_HasDefaultValue", ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern Boolean ReflectionVariable_HasDefaultValue(SlangReflectionVariable* inVar);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionVariable_GetDefaultValueInt"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionVariable_GetDefaultValueInt", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int ReflectionVariable_GetDefaultValueInt(SlangReflectionVariable* inVar, [NativeTypeName("int64_t *")] long* rs);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionVariable_GetGenericContainer"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionVariable_GetGenericContainer", ExactSpelling = true)]
    public static extern SlangReflectionGeneric* ReflectionVariable_GetGenericContainer(SlangReflectionVariable* var);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionVariable_applySpecializations"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionVariable_applySpecializations", ExactSpelling = true)]
    public static extern SlangReflectionVariable* ReflectionVariable_applySpecializations(SlangReflectionVariable* var, SlangReflectionGeneric* generic);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionVariableLayout_GetVariable"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionVariableLayout_GetVariable", ExactSpelling = true)]
    public static extern SlangReflectionVariable* ReflectionVariableLayout_GetVariable(SlangReflectionVariableLayout* var);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionVariableLayout_GetTypeLayout"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionVariableLayout_GetTypeLayout", ExactSpelling = true)]
    public static extern SlangReflectionTypeLayout* ReflectionVariableLayout_GetTypeLayout(SlangReflectionVariableLayout* var);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionVariableLayout_GetOffset"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionVariableLayout_GetOffset", ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint ReflectionVariableLayout_GetOffset(SlangReflectionVariableLayout* var, [NativeTypeName("SlangParameterCategory")] ParameterCategory category);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionVariableLayout_GetSpace"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionVariableLayout_GetSpace", ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint ReflectionVariableLayout_GetSpace(SlangReflectionVariableLayout* var, [NativeTypeName("SlangParameterCategory")] ParameterCategory category);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionVariableLayout_GetImageFormat"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionVariableLayout_GetImageFormat", ExactSpelling = true)]
    [return: NativeTypeName("SlangImageFormat")]
    public static extern ImageFormat ReflectionVariableLayout_GetImageFormat(SlangReflectionVariableLayout* var);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionVariableLayout_GetSemanticName"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionVariableLayout_GetSemanticName", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* ReflectionVariableLayout_GetSemanticName(SlangReflectionVariableLayout* var);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionVariableLayout_GetSemanticIndex"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionVariableLayout_GetSemanticIndex", ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint ReflectionVariableLayout_GetSemanticIndex(SlangReflectionVariableLayout* var);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionFunction_asDecl"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionFunction_asDecl", ExactSpelling = true)]
    public static extern SlangReflectionDecl* ReflectionFunction_asDecl(SlangReflectionFunction* func);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionFunction_GetName"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionFunction_GetName", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* ReflectionFunction_GetName(SlangReflectionFunction* func);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionFunction_FindModifier"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionFunction_FindModifier", ExactSpelling = true)]
    public static extern SlangReflectionModifier* ReflectionFunction_FindModifier(SlangReflectionFunction* var, [NativeTypeName("SlangModifierID")] ModifierID modifierID);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionFunction_GetUserAttributeCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionFunction_GetUserAttributeCount", ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint ReflectionFunction_GetUserAttributeCount(SlangReflectionFunction* func);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionFunction_GetUserAttribute"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionFunction_GetUserAttribute", ExactSpelling = true)]
    public static extern SlangReflectionUserAttribute* ReflectionFunction_GetUserAttribute(SlangReflectionFunction* func, [NativeTypeName("unsigned int")] uint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionFunction_FindUserAttributeByName"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionFunction_FindUserAttributeByName", ExactSpelling = true)]
    public static extern SlangReflectionUserAttribute* ReflectionFunction_FindUserAttributeByName(SlangReflectionFunction* func, [NativeTypeName("SlangSession *")] IGlobalSession* globalSession, [NativeTypeName("const char *")] sbyte* name);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionFunction_GetParameterCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionFunction_GetParameterCount", ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint ReflectionFunction_GetParameterCount(SlangReflectionFunction* func);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionFunction_GetParameter"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionFunction_GetParameter", ExactSpelling = true)]
    public static extern SlangReflectionVariable* ReflectionFunction_GetParameter(SlangReflectionFunction* func, [NativeTypeName("unsigned int")] uint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionFunction_GetResultType"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionFunction_GetResultType", ExactSpelling = true)]
    public static extern SlangReflectionType* ReflectionFunction_GetResultType(SlangReflectionFunction* func);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionFunction_GetGenericContainer"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionFunction_GetGenericContainer", ExactSpelling = true)]
    public static extern SlangReflectionGeneric* ReflectionFunction_GetGenericContainer(SlangReflectionFunction* func);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionFunction_applySpecializations"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionFunction_applySpecializations", ExactSpelling = true)]
    public static extern SlangReflectionFunction* ReflectionFunction_applySpecializations(SlangReflectionFunction* func, SlangReflectionGeneric* generic);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionFunction_specializeWithArgTypes"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionFunction_specializeWithArgTypes", ExactSpelling = true)]
    public static extern SlangReflectionFunction* ReflectionFunction_specializeWithArgTypes(SlangReflectionFunction* func, [NativeTypeName("SlangInt")] nint argTypeCount, [NativeTypeName("SlangReflectionType *const *")] SlangReflectionType** argTypes);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionFunction_isOverloaded"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionFunction_isOverloaded", ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern Boolean ReflectionFunction_isOverloaded(SlangReflectionFunction* func);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionFunction_getOverloadCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionFunction_getOverloadCount", ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint ReflectionFunction_getOverloadCount(SlangReflectionFunction* func);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionFunction_getOverload"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionFunction_getOverload", ExactSpelling = true)]
    public static extern SlangReflectionFunction* ReflectionFunction_getOverload(SlangReflectionFunction* func, [NativeTypeName("unsigned int")] uint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionDecl_getChildrenCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionDecl_getChildrenCount", ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint ReflectionDecl_getChildrenCount(SlangReflectionDecl* parentDecl);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionDecl_getChild"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionDecl_getChild", ExactSpelling = true)]
    public static extern SlangReflectionDecl* ReflectionDecl_getChild(SlangReflectionDecl* parentDecl, [NativeTypeName("unsigned int")] uint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionDecl_getName"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionDecl_getName", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* ReflectionDecl_getName(SlangReflectionDecl* decl);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionDecl_getKind"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionDecl_getKind", ExactSpelling = true)]
    [return: NativeTypeName("SlangDeclKind")]
    public static extern DeclKind ReflectionDecl_getKind(SlangReflectionDecl* decl);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionDecl_castToFunction"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionDecl_castToFunction", ExactSpelling = true)]
    public static extern SlangReflectionFunction* ReflectionDecl_castToFunction(SlangReflectionDecl* decl);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionDecl_castToVariable"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionDecl_castToVariable", ExactSpelling = true)]
    public static extern SlangReflectionVariable* ReflectionDecl_castToVariable(SlangReflectionDecl* decl);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionDecl_castToGeneric"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionDecl_castToGeneric", ExactSpelling = true)]
    public static extern SlangReflectionGeneric* ReflectionDecl_castToGeneric(SlangReflectionDecl* decl);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.Reflection_getTypeFromDecl"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflection_getTypeFromDecl", ExactSpelling = true)]
    public static extern SlangReflectionType* Reflection_getTypeFromDecl(SlangReflectionDecl* decl);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionDecl_getParent"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionDecl_getParent", ExactSpelling = true)]
    public static extern SlangReflectionDecl* ReflectionDecl_getParent(SlangReflectionDecl* decl);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionGeneric_asDecl"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionGeneric_asDecl", ExactSpelling = true)]
    public static extern SlangReflectionDecl* ReflectionGeneric_asDecl(SlangReflectionGeneric* generic);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionGeneric_GetName"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionGeneric_GetName", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* ReflectionGeneric_GetName(SlangReflectionGeneric* generic);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionGeneric_GetTypeParameterCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionGeneric_GetTypeParameterCount", ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint ReflectionGeneric_GetTypeParameterCount(SlangReflectionGeneric* generic);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionGeneric_GetTypeParameter"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionGeneric_GetTypeParameter", ExactSpelling = true)]
    public static extern SlangReflectionVariable* ReflectionGeneric_GetTypeParameter(SlangReflectionGeneric* generic, [NativeTypeName("unsigned int")] uint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionGeneric_GetValueParameterCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionGeneric_GetValueParameterCount", ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint ReflectionGeneric_GetValueParameterCount(SlangReflectionGeneric* generic);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionGeneric_GetValueParameter"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionGeneric_GetValueParameter", ExactSpelling = true)]
    public static extern SlangReflectionVariable* ReflectionGeneric_GetValueParameter(SlangReflectionGeneric* generic, [NativeTypeName("unsigned int")] uint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionGeneric_GetTypeParameterConstraintCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionGeneric_GetTypeParameterConstraintCount", ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint ReflectionGeneric_GetTypeParameterConstraintCount(SlangReflectionGeneric* generic, SlangReflectionVariable* typeParam);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionGeneric_GetTypeParameterConstraintType"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionGeneric_GetTypeParameterConstraintType", ExactSpelling = true)]
    public static extern SlangReflectionType* ReflectionGeneric_GetTypeParameterConstraintType(SlangReflectionGeneric* generic, SlangReflectionVariable* typeParam, [NativeTypeName("unsigned int")] uint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionGeneric_GetInnerKind"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionGeneric_GetInnerKind", ExactSpelling = true)]
    [return: NativeTypeName("SlangDeclKind")]
    public static extern DeclKind ReflectionGeneric_GetInnerKind(SlangReflectionGeneric* generic);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionGeneric_GetInnerDecl"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionGeneric_GetInnerDecl", ExactSpelling = true)]
    public static extern SlangReflectionDecl* ReflectionGeneric_GetInnerDecl(SlangReflectionGeneric* generic);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionGeneric_GetOuterGenericContainer"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionGeneric_GetOuterGenericContainer", ExactSpelling = true)]
    public static extern SlangReflectionGeneric* ReflectionGeneric_GetOuterGenericContainer(SlangReflectionGeneric* generic);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionGeneric_GetConcreteType"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionGeneric_GetConcreteType", ExactSpelling = true)]
    public static extern SlangReflectionType* ReflectionGeneric_GetConcreteType(SlangReflectionGeneric* generic, SlangReflectionVariable* typeParam);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionGeneric_GetConcreteIntVal"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionGeneric_GetConcreteIntVal", ExactSpelling = true)]
    [return: NativeTypeName("int64_t")]
    public static extern long ReflectionGeneric_GetConcreteIntVal(SlangReflectionGeneric* generic, SlangReflectionVariable* valueParam);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionGeneric_applySpecializations"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionGeneric_applySpecializations", ExactSpelling = true)]
    public static extern SlangReflectionGeneric* ReflectionGeneric_applySpecializations(SlangReflectionGeneric* currGeneric, SlangReflectionGeneric* generic);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionVariableLayout_getStage"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionVariableLayout_getStage", ExactSpelling = true)]
    [return: NativeTypeName("SlangStage")]
    public static extern Stage ReflectionVariableLayout_getStage(SlangReflectionVariableLayout* var);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionVariableLayout_getPendingDataLayout"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionVariableLayout_getPendingDataLayout", ExactSpelling = true)]
    public static extern SlangReflectionVariableLayout* ReflectionVariableLayout_getPendingDataLayout(SlangReflectionVariableLayout* var);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionParameter_GetBindingIndex"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionParameter_GetBindingIndex", ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint ReflectionParameter_GetBindingIndex([NativeTypeName("SlangReflectionParameter *")] SlangReflectionVariableLayout* parameter);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionParameter_GetBindingSpace"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionParameter_GetBindingSpace", ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint ReflectionParameter_GetBindingSpace([NativeTypeName("SlangReflectionParameter *")] SlangReflectionVariableLayout* parameter);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.IsParameterLocationUsed"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spIsParameterLocationUsed", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int IsParameterLocationUsed([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("SlangInt")] nint entryPointIndex, [NativeTypeName("SlangInt")] nint targetIndex, [NativeTypeName("SlangParameterCategory")] ParameterCategory category, [NativeTypeName("SlangUInt")] nuint spaceIndex, [NativeTypeName("SlangUInt")] nuint registerIndex, [NativeTypeName("bool &")] Boolean* outUsed);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionEntryPoint_getName"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionEntryPoint_getName", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* ReflectionEntryPoint_getName([NativeTypeName("SlangReflectionEntryPoint *")] SlangEntryPointLayout* entryPoint);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionEntryPoint_getNameOverride"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionEntryPoint_getNameOverride", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* ReflectionEntryPoint_getNameOverride([NativeTypeName("SlangReflectionEntryPoint *")] SlangEntryPointLayout* entryPoint);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionEntryPoint_getFunction"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionEntryPoint_getFunction", ExactSpelling = true)]
    public static extern SlangReflectionFunction* ReflectionEntryPoint_getFunction([NativeTypeName("SlangReflectionEntryPoint *")] SlangEntryPointLayout* entryPoint);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionEntryPoint_getParameterCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionEntryPoint_getParameterCount", ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint ReflectionEntryPoint_getParameterCount([NativeTypeName("SlangReflectionEntryPoint *")] SlangEntryPointLayout* entryPoint);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionEntryPoint_getParameterByIndex"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionEntryPoint_getParameterByIndex", ExactSpelling = true)]
    public static extern SlangReflectionVariableLayout* ReflectionEntryPoint_getParameterByIndex([NativeTypeName("SlangReflectionEntryPoint *")] SlangEntryPointLayout* entryPoint, [NativeTypeName("unsigned int")] uint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionEntryPoint_getStage"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionEntryPoint_getStage", ExactSpelling = true)]
    [return: NativeTypeName("SlangStage")]
    public static extern Stage ReflectionEntryPoint_getStage([NativeTypeName("SlangReflectionEntryPoint *")] SlangEntryPointLayout* entryPoint);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionEntryPoint_getComputeThreadGroupSize"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionEntryPoint_getComputeThreadGroupSize", ExactSpelling = true)]
    public static extern void ReflectionEntryPoint_getComputeThreadGroupSize([NativeTypeName("SlangReflectionEntryPoint *")] SlangEntryPointLayout* entryPoint, [NativeTypeName("SlangUInt")] nuint axisCount, [NativeTypeName("SlangUInt *")] nuint* outSizeAlongAxis);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionEntryPoint_getComputeWaveSize"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionEntryPoint_getComputeWaveSize", ExactSpelling = true)]
    public static extern void ReflectionEntryPoint_getComputeWaveSize([NativeTypeName("SlangReflectionEntryPoint *")] SlangEntryPointLayout* entryPoint, [NativeTypeName("SlangUInt *")] nuint* outWaveSize);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionEntryPoint_usesAnySampleRateInput"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionEntryPoint_usesAnySampleRateInput", ExactSpelling = true)]
    public static extern int ReflectionEntryPoint_usesAnySampleRateInput([NativeTypeName("SlangReflectionEntryPoint *")] SlangEntryPointLayout* entryPoint);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionEntryPoint_getVarLayout"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionEntryPoint_getVarLayout", ExactSpelling = true)]
    public static extern SlangReflectionVariableLayout* ReflectionEntryPoint_getVarLayout([NativeTypeName("SlangReflectionEntryPoint *")] SlangEntryPointLayout* entryPoint);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionEntryPoint_getResultVarLayout"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionEntryPoint_getResultVarLayout", ExactSpelling = true)]
    public static extern SlangReflectionVariableLayout* ReflectionEntryPoint_getResultVarLayout([NativeTypeName("SlangReflectionEntryPoint *")] SlangEntryPointLayout* entryPoint);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionEntryPoint_hasDefaultConstantBuffer"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionEntryPoint_hasDefaultConstantBuffer", ExactSpelling = true)]
    public static extern int ReflectionEntryPoint_hasDefaultConstantBuffer([NativeTypeName("SlangReflectionEntryPoint *")] SlangEntryPointLayout* entryPoint);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeParameter_GetName"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeParameter_GetName", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* ReflectionTypeParameter_GetName(SlangReflectionTypeParameter* typeParam);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeParameter_GetIndex"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeParameter_GetIndex", ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint ReflectionTypeParameter_GetIndex(SlangReflectionTypeParameter* typeParam);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeParameter_GetConstraintCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeParameter_GetConstraintCount", ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint ReflectionTypeParameter_GetConstraintCount(SlangReflectionTypeParameter* typeParam);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ReflectionTypeParameter_GetConstraintByIndex"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflectionTypeParameter_GetConstraintByIndex", ExactSpelling = true)]
    public static extern SlangReflectionType* ReflectionTypeParameter_GetConstraintByIndex(SlangReflectionTypeParameter* typeParam, [NativeTypeName("unsigned int")] uint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.Reflection_ToJson"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflection_ToJson", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int Reflection_ToJson([NativeTypeName("SlangReflection *")] SlangProgramLayout* reflection, [NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, ISlangBlob** outBlob);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.Reflection_GetParameterCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflection_GetParameterCount", ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint Reflection_GetParameterCount([NativeTypeName("SlangReflection *")] SlangProgramLayout* reflection);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.Reflection_GetParameterByIndex"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflection_GetParameterByIndex", ExactSpelling = true)]
    [return: NativeTypeName("SlangReflectionParameter *")]
    public static extern SlangReflectionVariableLayout* Reflection_GetParameterByIndex([NativeTypeName("SlangReflection *")] SlangProgramLayout* reflection, [NativeTypeName("unsigned int")] uint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.Reflection_GetTypeParameterCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflection_GetTypeParameterCount", ExactSpelling = true)]
    [return: NativeTypeName("unsigned int")]
    public static extern uint Reflection_GetTypeParameterCount([NativeTypeName("SlangReflection *")] SlangProgramLayout* reflection);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.Reflection_GetTypeParameterByIndex"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflection_GetTypeParameterByIndex", ExactSpelling = true)]
    public static extern SlangReflectionTypeParameter* Reflection_GetTypeParameterByIndex([NativeTypeName("SlangReflection *")] SlangProgramLayout* reflection, [NativeTypeName("unsigned int")] uint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.Reflection_FindTypeParameter"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflection_FindTypeParameter", ExactSpelling = true)]
    public static extern SlangReflectionTypeParameter* Reflection_FindTypeParameter([NativeTypeName("SlangReflection *")] SlangProgramLayout* reflection, [NativeTypeName("const char *")] sbyte* name);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.Reflection_FindTypeByName"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflection_FindTypeByName", ExactSpelling = true)]
    public static extern SlangReflectionType* Reflection_FindTypeByName([NativeTypeName("SlangReflection *")] SlangProgramLayout* reflection, [NativeTypeName("const char *")] sbyte* name);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.Reflection_GetTypeLayout"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflection_GetTypeLayout", ExactSpelling = true)]
    public static extern SlangReflectionTypeLayout* Reflection_GetTypeLayout([NativeTypeName("SlangReflection *")] SlangProgramLayout* reflection, SlangReflectionType* reflectionType, [NativeTypeName("SlangLayoutRules")] LayoutRules rules);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.Reflection_FindFunctionByName"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflection_FindFunctionByName", ExactSpelling = true)]
    public static extern SlangReflectionFunction* Reflection_FindFunctionByName([NativeTypeName("SlangReflection *")] SlangProgramLayout* reflection, [NativeTypeName("const char *")] sbyte* name);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.Reflection_FindFunctionByNameInType"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflection_FindFunctionByNameInType", ExactSpelling = true)]
    public static extern SlangReflectionFunction* Reflection_FindFunctionByNameInType([NativeTypeName("SlangReflection *")] SlangProgramLayout* reflection, SlangReflectionType* reflType, [NativeTypeName("const char *")] sbyte* name);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.Reflection_FindVarByNameInType"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflection_FindVarByNameInType", ExactSpelling = true)]
    public static extern SlangReflectionVariable* Reflection_FindVarByNameInType([NativeTypeName("SlangReflection *")] SlangProgramLayout* reflection, SlangReflectionType* reflType, [NativeTypeName("const char *")] sbyte* name);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.Reflection_getEntryPointCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflection_getEntryPointCount", ExactSpelling = true)]
    [return: NativeTypeName("SlangUInt")]
    public static extern nuint Reflection_getEntryPointCount([NativeTypeName("SlangReflection *")] SlangProgramLayout* reflection);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.Reflection_getEntryPointByIndex"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflection_getEntryPointByIndex", ExactSpelling = true)]
    [return: NativeTypeName("SlangReflectionEntryPoint *")]
    public static extern SlangEntryPointLayout* Reflection_getEntryPointByIndex([NativeTypeName("SlangReflection *")] SlangProgramLayout* reflection, [NativeTypeName("SlangUInt")] nuint index);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.Reflection_findEntryPointByName"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflection_findEntryPointByName", ExactSpelling = true)]
    [return: NativeTypeName("SlangReflectionEntryPoint *")]
    public static extern SlangEntryPointLayout* Reflection_findEntryPointByName([NativeTypeName("SlangReflection *")] SlangProgramLayout* reflection, [NativeTypeName("const char *")] sbyte* name);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.Reflection_getGlobalConstantBufferBinding"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflection_getGlobalConstantBufferBinding", ExactSpelling = true)]
    [return: NativeTypeName("SlangUInt")]
    public static extern nuint Reflection_getGlobalConstantBufferBinding([NativeTypeName("SlangReflection *")] SlangProgramLayout* reflection);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.Reflection_getGlobalConstantBufferSize"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflection_getGlobalConstantBufferSize", ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint Reflection_getGlobalConstantBufferSize([NativeTypeName("SlangReflection *")] SlangProgramLayout* reflection);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.Reflection_specializeType"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflection_specializeType", ExactSpelling = true)]
    public static extern SlangReflectionType* Reflection_specializeType([NativeTypeName("SlangReflection *")] SlangProgramLayout* reflection, SlangReflectionType* type, [NativeTypeName("SlangInt")] nint specializationArgCount, [NativeTypeName("SlangReflectionType *const *")] SlangReflectionType** specializationArgs, ISlangBlob** outDiagnostics);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.Reflection_specializeGeneric"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflection_specializeGeneric", ExactSpelling = true)]
    public static extern SlangReflectionGeneric* Reflection_specializeGeneric([NativeTypeName("SlangReflection *")] SlangProgramLayout* inProgramLayout, SlangReflectionGeneric* generic, [NativeTypeName("SlangInt")] nint argCount, [NativeTypeName("const SlangReflectionGenericArgType *")] ReflectionGenericArgType* argTypes, [NativeTypeName("const SlangReflectionGenericArg *")] SlangReflectionGenericArg* args, ISlangBlob** outDiagnostics);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.Reflection_isSubType"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflection_isSubType", ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern Boolean Reflection_isSubType([NativeTypeName("SlangReflection *")] SlangProgramLayout* reflection, SlangReflectionType* subType, SlangReflectionType* superType);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.Reflection_getHashedStringCount"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflection_getHashedStringCount", ExactSpelling = true)]
    [return: NativeTypeName("SlangUInt")]
    public static extern nuint Reflection_getHashedStringCount([NativeTypeName("SlangReflection *")] SlangProgramLayout* reflection);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.Reflection_getHashedString"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflection_getHashedString", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* Reflection_getHashedString([NativeTypeName("SlangReflection *")] SlangProgramLayout* reflection, [NativeTypeName("SlangUInt")] nuint index, [NativeTypeName("size_t *")] nuint* outCount);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.ComputeStringHash"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spComputeStringHash", ExactSpelling = true)]
    [return: NativeTypeName("SlangUInt32")]
    public static extern uint ComputeStringHash([NativeTypeName("const char *")] sbyte* chars, [NativeTypeName("size_t")] nuint count);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.Reflection_getGlobalParamsTypeLayout"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflection_getGlobalParamsTypeLayout", ExactSpelling = true)]
    public static extern SlangReflectionTypeLayout* Reflection_getGlobalParamsTypeLayout([NativeTypeName("SlangReflection *")] SlangProgramLayout* reflection);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.Reflection_getGlobalParamsVarLayout"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spReflection_getGlobalParamsVarLayout", ExactSpelling = true)]
    public static extern SlangReflectionVariableLayout* Reflection_getGlobalParamsVarLayout([NativeTypeName("SlangReflection *")] SlangProgramLayout* reflection);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.GetTranslationUnitSource"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spGetTranslationUnitSource", ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* GetTranslationUnitSource([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, int translationUnitIndex);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.Reflection_GetSession"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?spReflection_GetSession@@YAPEAUISession@slang@@PEAUSlangProgramLayout@@@Z", ExactSpelling = true)]
    [return: NativeTypeName("slang::ISession *")]
    public static extern ISession* Reflection_GetSession([NativeTypeName("SlangReflection *")] SlangProgramLayout* reflection);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.CompileRequest_getProgram"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spCompileRequest_getProgram", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int CompileRequest_getProgram([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("slang::IComponentType **")] IComponentType** outProgram);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.CompileRequest_getProgramWithEntryPoints"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spCompileRequest_getProgramWithEntryPoints", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int CompileRequest_getProgramWithEntryPoints([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("slang::IComponentType **")] IComponentType** outProgram);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.CompileRequest_getEntryPoint"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spCompileRequest_getEntryPoint", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int CompileRequest_getEntryPoint([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("SlangInt")] nint entryPointIndex, [NativeTypeName("slang::IComponentType **")] IComponentType** outEntryPoint);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.CompileRequest_getModule"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spCompileRequest_getModule", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int CompileRequest_getModule([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("SlangInt")] nint translationUnitIndex, [NativeTypeName("slang::IModule **")] IModule** outModule);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.CompileRequest_getSession"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "spCompileRequest_getSession", ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int CompileRequest_getSession([NativeTypeName("SlangCompileRequest *")] ICompileRequest* request, [NativeTypeName("slang::ISession **")] ISession** outSession);

    public const int kSessionFlags_None = 0;

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.slang_createGlobalSession"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int slang_createGlobalSession([NativeTypeName("SlangInt")] nint apiVersion, [NativeTypeName("slang::IGlobalSession **")] IGlobalSession** outGlobalSession);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.slang_createGlobalSession2"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int slang_createGlobalSession2([NativeTypeName("const SlangGlobalSessionDesc *")] SlangGlobalSessionDesc* desc, [NativeTypeName("slang::IGlobalSession **")] IGlobalSession** outGlobalSession);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.slang_createGlobalSessionWithoutCoreModule"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int slang_createGlobalSessionWithoutCoreModule([NativeTypeName("SlangInt")] nint apiVersion, [NativeTypeName("slang::IGlobalSession **")] IGlobalSession** outGlobalSession);

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.slang_getEmbeddedCoreModule"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?slang_getEmbeddedCoreModule@@YAPEAUISlangBlob@@XZ", ExactSpelling = true)]
    public static extern ISlangBlob* slang_getEmbeddedCoreModule();

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.slang_shutdown"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void slang_shutdown();

    /// <include file='SlangApi.xml' path='doc/member[@name="SlangApi.slang_getLastInternalErrorMessage"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* slang_getLastInternalErrorMessage();

    public static readonly Guid IID_ISlangUnknown = new Guid(0x00000000, 0x0000, 0x0000, 0xC0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46);

    public static readonly Guid IID_ISlangCastable = new Guid(0x87EDE0E1, 0x4852, 0x44B0, 0x8B, 0xF2, 0xCB, 0x31, 0x87, 0x4D, 0xE2, 0x39);

    public static readonly Guid IID_ISlangClonable = new Guid(0x1EC36168, 0xE9F4, 0x430D, 0xBB, 0x17, 0x04, 0x8A, 0x80, 0x46, 0xB3, 0x1F);

    public static readonly Guid IID_ISlangBlob = new Guid(0x8BA5FB08, 0x5195, 0x40E2, 0xAC, 0x58, 0x0D, 0x98, 0x9C, 0x3A, 0x01, 0x02);

    public static readonly Guid IID_SlangTerminatedChars = new Guid(0xBE0DB1A8, 0x3594, 0x4603, 0xA7, 0x8B, 0xC4, 0x86, 0x84, 0x30, 0xDF, 0xBB);

    public static readonly Guid IID_ISlangFileSystem = new Guid(0x003A09FC, 0x3A4D, 0x4BA0, 0xAD, 0x60, 0x1F, 0xD8, 0x63, 0xA9, 0x15, 0xAB);

    public static readonly Guid IID_ISlangSharedLibrary_Dep1 = new Guid(0x9C9D5BC5, 0xEB61, 0x496F, 0x80, 0xD7, 0xD1, 0x47, 0xC4, 0xA2, 0x37, 0x30);

    public static readonly Guid IID_ISlangSharedLibrary = new Guid(0x70DBC7C4, 0xDC3B, 0x4A07, 0xAE, 0x7E, 0x75, 0x2A, 0xF6, 0xA8, 0x15, 0x55);

    public static readonly Guid IID_ISlangSharedLibraryLoader = new Guid(0x6264AB2B, 0xA3E8, 0x4A06, 0x97, 0xF1, 0x49, 0xBC, 0x2D, 0x2A, 0xB1, 0x4D);

    public static readonly Guid IID_ISlangFileSystemExt = new Guid(0x5FB632D2, 0x979D, 0x4481, 0x9F, 0xEE, 0x66, 0x3C, 0x3F, 0x14, 0x49, 0xE1);

    public static readonly Guid IID_ISlangMutableFileSystem = new Guid(0xA058675C, 0x1D65, 0x452A, 0x84, 0x58, 0xCC, 0xDE, 0xD1, 0x42, 0x71, 0x05);

    public static readonly Guid IID_ISlangWriter = new Guid(0xEC457F0E, 0x9ADD, 0x4E6B, 0x85, 0x1C, 0xD7, 0xFA, 0x71, 0x6D, 0x15, 0xFD);

    public static readonly Guid IID_ISlangProfiler = new Guid(0x197772C7, 0x0155, 0x4B91, 0x84, 0xE8, 0x66, 0x68, 0xBA, 0xFF, 0x06, 0x19);

    public static readonly Guid IID_ICompileRequest = new Guid(0x96D33993, 0x317C, 0x4DB5, 0xAF, 0xD8, 0x66, 0x6E, 0xE7, 0x72, 0x48, 0xE2);

    public static readonly Guid IID_IGlobalSession = new Guid(0xC140B5FD, 0x0C78, 0x452E, 0xBA, 0x7C, 0x1A, 0x1E, 0x70, 0xC7, 0xF7, 0x1C);

    public static readonly Guid IID_ISession = new Guid(0x67618701, 0xD116, 0x468F, 0xAB, 0x3B, 0x47, 0x4B, 0xED, 0xCE, 0x0E, 0x3D);

    public static readonly Guid IID_IMetadata = new Guid(0x8044A8A3, 0xDDC0, 0x4B7F, 0xAF, 0x8E, 0x02, 0x6E, 0x90, 0x5D, 0x73, 0x32);

    public static readonly Guid IID_IComponentType = new Guid(0x5BC42BE8, 0x5C50, 0x4929, 0x9E, 0x5E, 0xD1, 0x5E, 0x7C, 0x24, 0x01, 0x5F);

    public static readonly Guid IID_IEntryPoint = new Guid(0x8F241361, 0xF5BD, 0x4CA0, 0xA3, 0xAC, 0x02, 0xF7, 0xFA, 0x24, 0x02, 0xB8);

    public static readonly Guid IID_ITypeConformance = new Guid(0x73EB3147, 0xE544, 0x41B5, 0xB8, 0xF0, 0xA2, 0x44, 0xDF, 0x21, 0x94, 0x0B);

    public static readonly Guid IID_IModule = new Guid(0x0C720E64, 0x8722, 0x4D31, 0x89, 0x90, 0x63, 0x8A, 0x98, 0xB1, 0xC2, 0x79);

    public static readonly Guid IID_IModulePrecompileService_Experimental = new Guid(0x8E12E8E3, 0x5FCD, 0x433E, 0xAF, 0xCB, 0x13, 0xA0, 0x88, 0xBC, 0x5E, 0xE5);
}
