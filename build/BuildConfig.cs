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
    public IReadOnlyList<string> GetClangCmdLineArgsForConfig()
    {
        //Add additional include directories for linux systems to resolve stddef.h
        string[] linuxIncludeDirectories =
        [
            "/usr/lib/gcc/x86_64-linux-gnu/12/include/",
            "/usr/lib/gcc/x86_64-linux-gnu/11/include/",
            "/usr/lib/gcc/x86_64-linux-gnu/10/include/",
            "/usr/lib/gcc/x86_64-linux-gnu/9/include/",
            "/usr/include/x86_64-linux-gnu",
            "/usr/include"
        ];

        var includeDirectories = IsLinux ? linuxIncludeDirectories : [];

        return
        [
            $"--language={Language}", // Treat subsequent input files as having type <language>
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

        return new(Language, "", DefaultNamespace, outputDir, null, mode, opts)
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
        "SlangNet.Bindings.Generated.Slang",
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
        {
            {"ISlangUnknown" , new(0x00000000, 0x0000, 0x0000, 0xC0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46)},
            {"ISlangCastable", new(0x87ede0e1, 0x4852, 0x44b0, 0x8b, 0xf2, 0xcb, 0x31, 0x87, 0x4d, 0xe2, 0x39)},
            {"ISlangClonable", new(0x1ec36168, 0xe9f4, 0x430d, 0xbb, 0x17, 0x4, 0x8a, 0x80, 0x46, 0xb3, 0x1f)},
            {"ISlangBlob", new(0x8BA5FB08, 0x5195, 0x40e2, 0xAC, 0x58, 0x0D, 0x98, 0x9C, 0x3A, 0x01, 0x02)},
            {"SlangTerminatedChars", new(0xbe0db1a8, 0x3594, 0x4603, 0xa7, 0x8b, 0xc4, 0x86, 0x84, 0x30, 0xdf, 0xbb)},
            {"ISlangFileSystem", new(0x003A09FC, 0x3A4D, 0x4BA0, 0xAD, 0x60, 0x1F, 0xD8, 0x63, 0xA9, 0x15, 0xAB)},
            {"ISlangSharedLibrary_Dep1", new(0x9c9d5bc5, 0xeb61, 0x496f, 0x80, 0xd7, 0xd1, 0x47, 0xc4, 0xa2, 0x37, 0x30)},
            {"ISlangSharedLibrary", new(0x70dbc7c4, 0xdc3b, 0x4a07, 0xae, 0x7e, 0x75, 0x2a, 0xf6, 0xa8, 0x15, 0x55)},
            {"ISlangSharedLibraryLoader", new(0x6264ab2b, 0xa3e8, 0x4a06, 0x97, 0xf1, 0x49, 0xbc, 0x2d, 0x2a, 0xb1, 0x4d)},
            {"ISlangFileSystemExt", new(0x5fb632d2, 0x979d, 0x4481, 0x9f, 0xee, 0x66, 0x3c, 0x3f, 0x14, 0x49, 0xe1)},
            {"ISlangMutableFileSystem", new(0xa058675c, 0x1d65, 0x452a, 0x84, 0x58, 0xcc, 0xde, 0xd1, 0x42, 0x71, 0x5)},
            {"ISlangWriter", new(0xec457f0e, 0x9add, 0x4e6b, 0x85, 0x1c, 0xd7, 0xfa, 0x71, 0x6d, 0x15, 0xfd)},
            {"IGlobalSession", new(0xc140b5fd, 0xc78, 0x452e, 0xba, 0x7c, 0x1a, 0x1e, 0x70, 0xc7, 0xf7, 0x1c)},
            {"ISession", new(0x67618701, 0xd116, 0x468f, 0xab, 0x3b, 0x47, 0x4b, 0xed, 0xce, 0xe, 0x3d)},
            {"IComponentType", new(0x5bc42be8, 0x5c50, 0x4929, 0x9e, 0x5e, 0xd1, 0x5e, 0x7c, 0x24, 0x1, 0x5f)},
            {"IEntryPoint", new(0x8f241361, 0xf5bd, 0x4ca0, 0xa3, 0xac, 0x2, 0xf7, 0xfa, 0x24, 0x2, 0xb8)},
            {"ITypeConformance", new(0x73eb3147, 0xe544, 0x41b5, 0xb8, 0xf0, 0xa2, 0x44, 0xdf, 0x21, 0x94, 0xb)},
            {"IModule", new(0xc720e64, 0x8722, 0x4d31, 0x89, 0x90, 0x63, 0x8a, 0x98, 0xb1, 0xc2, 0x79)},
            {"ISlangProfiler", new(0x197772c7, 0x0155, 0x4b91, 0x84, 0xe8, 0x66, 0x68, 0xba, 0xff, 0x06, 0x19)},
        }
    );

    public StrList TraversalNames { get; set; } = TraversalNames ?? [];
}