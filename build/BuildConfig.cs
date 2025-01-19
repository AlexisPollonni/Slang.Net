using System.Collections.Generic;
using System.Linq;
using ClangSharp;
using JetBrains.Annotations;
using Nuke.Common.IO;
using StrDictionary = System.Collections.Generic.Dictionary<string, string>;
using static ClangSharp.PInvokeGeneratorConfigurationOptions;

internal record struct BuildConfig()
{
    public string Language { get; } = "c++";
    public string DefaultNamespace { get; } = "SlangNet.Bindings.Generated";

    // Remove the function prefixes, also fix over-removing of prefixes
    public string PrefixStrip { get; } = "sp";

    public AbsolutePath? GeneratedTestsDir { get; set; } = null;

    public PInvokeGeneratorConfigurationOptions Options { get; set; } = GeneratePreviewCode
                                                                        | GenerateMultipleFiles
                                                                        | GenerateFileScopedNamespaces
                                                                        | GenerateDocIncludes
                                                                        | GenerateHelperTypes
                                                                        | GenerateMacroBindings
                                                                        | GenerateAggressiveInlining
                                                                        | GenerateExplicitVtbls

                                                                        | ExcludeFnptrCodegen // No Fnptr code gen with latest or preview
                                                                        | ExcludeFunctionsWithBody
                                                                        | ExcludeComProxies
                                                                        | ExcludeEnumOperators

                                                                        | StripEnumMemberTypeName
                                                                        | LogPotentialTypedefRemappings;

    public List<string> DefineMacros { get; } =
    [
        // Prevent platform-specific macros
        "SLANG_COMPILER",
        "__clang__",
        "SLANG_CLANG"
    ];

    public IReadOnlyCollection<string> TraversalNames { get; init; }

    public string[] Excludes { get; } =
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
    ];

    public StrDictionary WithTypes = new()
    {
        // This fixes a ClangSharp issue with TypeReflection::Kind causing compile errors
        { "Kind", "uint" }
    };

    public StrDictionary WithNamespace = new()
    {
        // For the pretty bindings we rewrite everything but some of the enums and PODs
        { "BindingType", "SlangNet" },
        { "ContainerType", "SlangNet" },
        { "LayoutRules", "SlangNet" },
        { "ParameterCategory", "SlangNet" },
        { "PathKind", "SlangNet" },
        { "OSPathKind", "SlangNet" },
    };

    public StrDictionary Remap = new()
    {
        { "specialize", "spspecialize" },
        { "specializeType", "spspecializeType" },
        { "Attribute", "SlangAttribute" }, // Resolves name conflict with dotnet Attribute type
        { "Kind", "TypeKind" }, // Use generated trimmed name
        
        {"SlangMatrixLayoutMode::SLANG_MATRIX_LAYOUT_ROW_MAJOR", "RowMajor"},
        {"SlangMatrixLayoutMode::SLANG_MATRIX_LAYOUT_COLUMN_MAJOR", "ColumnMajor"},
    };

    public string[] ClangCmdArgs =>
    [
        $"--language={Language}", // Treat subsequent input files as having type <language>
        "-Wno-pragma-once-outside-header", // We are processing files which may be header files

        "-Wno-deprecated-declarations",
        ..DefineMacros.Select(s => $"--define-macro={s}")
    ];

    public readonly PInvokeGeneratorConfiguration ToGeneratorConfiguration(AbsolutePath outputDir,
                                                                           PInvokeGeneratorOutputMode mode)
    {
        var opts = Options;
        if (GeneratedTestsDir?.Exists() ?? false)
        {
            opts |= GenerateTestsNUnit;
        }

        return new(Language, "", DefaultNamespace, outputDir, "", mode, opts)
        {
            DefaultClass = "Slang",
            LibraryPath = "slang",
            TestOutputLocation = GeneratedTestsDir,
            ExcludedNames = Excludes,
            MethodPrefixToStrip = PrefixStrip,
            WithTypes = WithTypes,
            WithNamespaces = WithNamespace,
            RemappedNames = Remap,
            TraversalNames = TraversalNames
        };
    }
};