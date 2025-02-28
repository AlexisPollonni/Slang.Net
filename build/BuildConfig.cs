using System;
using System.Collections.Generic;
using System.Linq;
using ClangSharp;
using Nuke.Common;
using Nuke.Common.IO;
using StrDic = System.Collections.Generic.Dictionary<string, string>;
using StrList = System.Collections.Generic.IList<string>;
using static ClangSharp.PInvokeGeneratorConfigurationOptions;
using static Nuke.Common.EnvironmentInfo;

internal record BuildConfig(
    string Language,
    string DefaultClass,
    string LibraryPath,
    string DefaultNamespace,
    string PrefixStrip,
    PInvokeGeneratorConfigurationOptions Options,
    StrList DefineMacros,
    StrList Excludes,
    StrDic Remap,
    StrDic WithTypes,
    StrDic WithNamespaces,
    Dictionary<string, Guid> WithGuids,
    StrList? TraversalNames = null
)
{
    public StrList TraversalNames { get; set; } = TraversalNames ?? [];

    public IReadOnlyList<string> GetClangCmdLineArgsForConfig()
    {
        string[] linuxIncludeDirectories =
        [
            "/usr/lib/gcc/x86_64-linux-gnu/12/include/",
            "/usr/lib/gcc/x86_64-linux-gnu/11/include/",
            "/usr/lib/gcc/x86_64-linux-gnu/10/include/",
            "/usr/lib/gcc/x86_64-linux-gnu/9/include/",
            "/usr/include/x86_64-linux-gnu/c++/11",
            "/usr/include/x86_64-linux-gnu",
            "/usr/include/c++/11",
            "/usr/include"
        ];
        //Add additional include directories for linux systems to resolve stddef.h

        var includeDirectories = IsLinux ? linuxIncludeDirectories : [];

        return
        [
            $"--language={Language}", // Treat subsequent input files as having type <language>
            "-stdlib=libc++",
            "-Wno-pragma-once-outside-header", // We are processing files which may be header files

            "-Wno-deprecated-declarations",
            ..DefineMacros
                .Concat(["SLANG_PLATFORM", GetSlangPlatformDefine()])
                .Select(s => $"--define-macro={s}"),
            ..includeDirectories.Select(s => $"--include-directory={s}"),
        ];
    }

    public PInvokeGeneratorConfiguration ToGeneratorConfiguration(AbsolutePath outputDir,
        AbsolutePath? testsOutputDir = null, PInvokeGeneratorOutputMode mode = PInvokeGeneratorOutputMode.CSharp)
    {
        var opts = Options;
        if (testsOutputDir?.DirectoryExists() ?? false)
        {
            opts |= GenerateTestsNUnit;
        }

        if (IsUnix) opts |= GenerateUnixTypes;
        
        return new(Language, "c++17", DefaultNamespace, outputDir, null, mode, opts)
        {
            DefaultClass = DefaultClass,
            LibraryPath = LibraryPath,
            MethodPrefixToStrip = PrefixStrip,
            TraversalNames = TraversalNames.AsReadOnly(),
            ExcludedNames = Excludes.AsReadOnly(),
            RemappedNames = Remap.AsReadOnly(),
            WithTypes = WithTypes.AsReadOnly(),
            WithNamespaces = WithNamespaces.AsReadOnly(),
            WithGuids = WithGuids.AsReadOnly(),
            TestOutputLocation = testsOutputDir,
        };
    }

    string GetSlangPlatformDefine()
    {
        var errMsg = $"Platform {Platform} not supported for binding generation";
        if (Is64Bit)
        {
            if (IsWin)
                return "SLANG_WIN64";
            if (IsLinux)
                return "SLANG_LINUX";
            if (IsOsx)
                return "SLANG_OSX";

            Assert.Fail(errMsg);
        }
        else if (Is32Bit)
        {
            if (IsWin)
                return "SLANG_WIN32";

            Assert.Fail(errMsg);
        }

        Assert.Fail(errMsg);
        return null!;
    }


    public static readonly BuildConfig SlangConfig = new(
        "c++", "SlangApi", "slang",
        "SlangNet.Bindings.Generated",
        "sp", // Remove the function prefixes, also fix over-removing of prefixes
        GeneratePreviewCode
        | GenerateMultipleFiles
        | GenerateFileScopedNamespaces
        | GenerateDocIncludes
        | GenerateHelperTypes
        | GenerateMacroBindings
        | GenerateAggressiveInlining
        | GenerateExplicitVtbls
        | GenerateNativeInheritanceAttribute
        | GenerateGenericPointerWrapper
        
        | ExcludeFnptrCodegen // No Fnptr code gen with latest or preview
        | ExcludeFunctionsWithBody
        | ExcludeComProxies
        | ExcludeEnumOperators
        
        | StripEnumMemberTypeName
        | LogPotentialTypedefRemappings,
        
        [
            // Prevent platform-specific macros
            "SLANG_COMPILER",
            "__clang__",
            "SLANG_CLANG"
        ],
        [
            // Remove the rest of the platform-specific macros
            "SLANG_ENABLE_DIRECTX",
            "SLANG_ENABLE_DXGI_DEBUG",
            "SLANG_ENABLE_DXBC_SUPPORT",
            "SLANG_ENABLE_PIX",
            "SLANG_ENABLE_DXVK",
            "SLANG_ENABLE_VKD3D",
            "SLANG_HAS_EXCEPTIONS",
            "SLANG_HAS_ENUM_CLASS",
            "SLANG_HAS_MOVE_SEMANTICS",
            "SLANG_PROCESSOR_X86_64",
            "SLANG_PROCESSOR_ARM",
            "SLANG_PROCESSOR_ARM_64",
            "SLANG_PROCESSOR_X86",
            "SLANG_PROCESSOR_POWER_PC",
            "SLANG_PROCESSOR_POWER_PC_64",
            "SLANG_PROCESSOR_FAMILY_X86",
            "SLANG_PROCESSOR_FAMILY_ARM",
            "SLANG_PROCESSOR_FAMILY_POWER_PC",
            "SLANG_PTR_IS_64",
            "SLANG_PTR_IS_32",
            "SLANG_LITTLE_ENDIAN",
            "SLANG_BIG_ENDIAN",
            "SLANG_UNALIGNED_ACCESS",

            //Remove the UUIDs, they are generated incorrectly
            "_GUID",
            "SLANG_UUID_ISlangUnknown",
            "SLANG_UUID_ISlangBlob",
            "SLANG_UUID_ISlangFileSystem",
            "SLANG_UUID_ISlangSharedLibrary",
            "SLANG_UUID_ISlangSharedLibrary_Dep1",
            "SLANG_UUID_ISlangSharedLibraryLoader",
            "SLANG_UUID_ISlangFileSystemExt",
            "SLANG_UUID_ISlangMutableFileSystem",
            "SLANG_UUID_ISlangWriter",
            "SLANG_UUID_ISlangProfiler",

            // These ones are just broken
            "SLANG_UNBOUNDED_SIZE",
            "createCompileRequest",
            "kDefaultTargetFlags",
            "kRemainingTextureSize",
            "kRemainingTextureSize",
            "kTimeoutInfinite",
            "gfx::AdapterList::m_blob",

            // Silence ClangSharp warnings
            "SLANG_OFFSET_OF",
            "SLANG_BREAKPOINT",
            "SLANG_ALIGN_OF",
            "SLANG_INT64",
            "SLANG_UINT64",
            "SLANG_COMPILE_TIME_ASSERT",
            "SLANG_COUNT_OF",
            "SLANG_STRINGIZE_HELPER",
            "SLANG_STRINGIZE",
            "SLANG_CONCAT_HELPER",
            "SLANG_CONCAT",
            "SLANG_UNUSED",
            "SLANG_FAILED",
            "SLANG_SUCCEEDED",
            "SLANG_GET_RESULT_FACILITY",
            "SLANG_GET_RESULT_CODE",
            "SLANG_MAKE_ERROR",
            "SLANG_MAKE_SUCCESS",
            "SLANG_MAKE_WIN_GENERAL_ERROR",
            "SLANG_MAKE_CORE_ERROR",
            "SLANG_COM_INTERFACE",
            "SLANG_CLASS_GUID",
            "SLANG_IID_PPV_ARGS",

            // Exclude redefined enums in TypeReflection struct
            "slang::TypeReflection::Kind",
            "slang::TypeReflection::ScalarType",
            "slang::DeclReflection::Kind",
            "slang::ParameterCategory",
            "slang::BindingType",
            "slang::LayoutRules",
        ],
        new()
        {
            { "specialize", "spspecialize" },
            { "specializeType", "spspecializeType" },
            { "Attribute", "SlangAttribute" }, // Resolves name conflict with dotnet Attribute type
            { "Kind", "TypeKind" }, // Use generated trimmed name

            { "SlangMatrixLayoutMode::SLANG_MATRIX_LAYOUT_ROW_MAJOR", "RowMajor" },
            { "SlangMatrixLayoutMode::SLANG_MATRIX_LAYOUT_COLUMN_MAJOR", "ColumnMajor" },
        },
        new()
        {
            // This fixes a ClangSharp issue with TypeReflection::Kind causing compile errors
            { "Kind", "uint" }
        },
        new()
        {
            // For the pretty bindings we rewrite everything but some of the enums and PODs
            { "BindingType", "SlangNet" },
            { "ContainerType", "SlangNet" },
            { "LayoutRules", "SlangNet" },
            { "ParameterCategory", "SlangNet" },
            { "PathKind", "SlangNet" },
            { "OSPathKind", "SlangNet" },
        },
        new()
    );
}