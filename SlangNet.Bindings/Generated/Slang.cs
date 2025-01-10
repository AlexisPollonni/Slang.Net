using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

public static unsafe partial class Slang
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

    /// <include file='Slang.xml' path='doc/member[@name="Slang.GetBuildTagString"]/*' />
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

    public const int kSessionFlags_None = 0;

    /// <include file='Slang.xml' path='doc/member[@name="Slang.slang_createGlobalSession"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int slang_createGlobalSession([NativeTypeName("SlangInt")] long apiVersion, [NativeTypeName("slang::IGlobalSession **")] IGlobalSession** outGlobalSession);

    /// <include file='Slang.xml' path='doc/member[@name="Slang.slang_createGlobalSessionWithoutCoreModule"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int slang_createGlobalSessionWithoutCoreModule([NativeTypeName("SlangInt")] long apiVersion, [NativeTypeName("slang::IGlobalSession **")] IGlobalSession** outGlobalSession);

    /// <include file='Slang.xml' path='doc/member[@name="Slang.slang_getEmbeddedCoreModule"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, EntryPoint = "?slang_getEmbeddedCoreModule@@YAPEAUISlangBlob@@XZ", ExactSpelling = true)]
    public static extern ISlangBlob* slang_getEmbeddedCoreModule();

    /// <include file='Slang.xml' path='doc/member[@name="Slang.slang_shutdown"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void slang_shutdown();

    /// <include file='Slang.xml' path='doc/member[@name="Slang.slang_getLastInternalErrorMessage"]/*' />
    [DllImport("slang", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* slang_getLastInternalErrorMessage();
}
