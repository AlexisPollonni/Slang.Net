#!/usr/local/share/dotnet/dotnet run

#:sdk Cake.Sdk

#:package Cake.FileHelpers
#:package Cake.APT.Module
#:package ClangSharp
#:package ClangSharp.PInvokeGenerator
#:package libclang
#:package libClangSharp
#:package Humanizer

#:project ./Shared/ShaderSlang.Net.Scripts.Shared.csproj

#:property UseCurrentRuntimeIdentifier=true

using ClangSharp;
using ClangSharp.Interop;
using Humanizer;
using ShaderSlang.Net.Scripts.Shared;
using Shouldly;
using static ClangAstExtensions;
using static ClangSharp.Interop.CXTranslationUnit_Flags;
using static ClangSharp.PInvokeGeneratorConfigurationOptions;
using LogLevel = Cake.Core.Diagnostics.LogLevel;
using StrDic = System.Collections.Generic.Dictionary<string, string>;
using StrList = System.Collections.Generic.IList<string>;

var target = Argument("target", "");

var slangRepo = Argument<DirectoryPath>("slang-repo");
var bindingsOutput = Argument<DirectoryPath?>("bindings-output", null);

var testsOutput = Argument<DirectoryPath?>("tests-output", null);
var docsOutput = Argument<DirectoryPath?>("docs-output", null);

Task("Bindings")
    .Description("Generate C# P/Invoke bindings for the Slang API")
    .WithCriteria(() => bindingsOutput is not null)
    .Does(() =>
    {
        bindingsOutput.ShouldNotBeNull();
        InstallDependencies();

        DirectoryExists(slangRepo)
            .ShouldBeTrue($"Slang repository path '{slangRepo}' does not exist.");

        var (slangHeaderPath, slangGfxHeaderPath, slangDeprHeaderPath) = GetSlangPaths(slangRepo);

        var slangConfig = GetSlangConfig(slangRepo);

        var gfxConfig = GetGfxConfig(slangRepo);

        PrintClangVersion();

        CleanDirectory(bindingsOutput);
        if (testsOutput is not null)
            CleanDirectory(testsOutput);

        var genFiles = Generate([slangHeaderPath], bindingsOutput, slangConfig, testsOutput)
            .Concat(Generate([slangGfxHeaderPath], bindingsOutput, gfxConfig, testsOutput))
            .DistinctBy(pair => pair.Key)
            .ToDictionary();

        WriteFilesToDisk(genFiles);
    });

Task("Docs")
    .Description("Generate XML documentation for the Slang API")
    .WithCriteria(() => docsOutput is not null)
    .Does(() =>
    {
        docsOutput.ShouldNotBeNull();
        InstallDependencies();

        DirectoryExists(slangRepo)
            .ShouldBeTrue($"Slang repository path '{slangRepo}' does not exist.");

        var (slangHeaderPath, slangGfxHeaderPath, slangDeprHeaderPath) = GetSlangPaths(slangRepo);

        var slangConfig = GetSlangConfig(slangRepo);
        var gfxConfig = GetGfxConfig(slangRepo);

        CleanDirectory(docsOutput);

        Information("Generating XML documentation files...");
        var genFiles = Generate(
                [slangHeaderPath],
                docsOutput,
                slangConfig,
                mode: PInvokeGeneratorOutputMode.Xml
            )
            .Concat(
                Generate(
                    [slangGfxHeaderPath],
                    docsOutput,
                    gfxConfig,
                    mode: PInvokeGeneratorOutputMode.Xml
                )
            )
            .ToDictionary();

        WriteFilesToDisk(genFiles);
    });

if (target.IsWhiteSpace())
{
    Information("No target specified, running full generation.");
    RunTarget("Bindings");
    RunTarget("Docs");
}
else
    RunTarget(target);

static BuildConfig GetSlangConfig(DirectoryPath slangRepo) =>
    BuildConfig.GetBuildConfig("SlangApi", "slang") with
    {
        TraversalNames =
        [
            GetSlangPaths(slangRepo).SlangDeprHeaderPath,
            GetSlangPaths(slangRepo).SlangHeaderPath,
        ],
    };

static BuildConfig GetGfxConfig(DirectoryPath slangRepo) =>
    BuildConfig.GetBuildConfig("GfxApi", "gfx") with
    {
        TraversalNames = [GetSlangPaths(slangRepo).SlangGfxHeaderPath],
    };

void PrintClangVersion()
{
    using var ver = clang.getClangVersion();
    using var ver2 = clangsharp.getVersion();

    Information("Generating CSharp bindings...");
    Information("CLANG VERSION: {0}", ver);
    Information("CLANGSHARP VERSION: {0}", ver2);
}

static void InstallDependencies()
{
    if (IsRunningOnLinux())
    {
        try
        {
            InstallTools("apt:?package=libc++-dev", "apt:?package=libc++abi-dev")
                .ShouldNotBeNull()
                .Length.ShouldBe(2);
        }
        catch (Exception e)
        {
            Warning("Failed to install libc++-dev or libc++abi-dev generation might fail: {0}", e);
        }
    }
}

static (
    FilePath SlangHeaderPath,
    FilePath SlangGfxHeaderPath,
    FilePath SlangDeprHeaderPath
) GetSlangPaths(DirectoryPath slangRepo) =>
    (
        slangRepo.Combine("include").CombineWithFilePath("slang.h"),
        slangRepo.Combine("include").CombineWithFilePath("slang-gfx.h"),
        slangRepo.Combine("include").CombineWithFilePath("slang-deprecated.h")
    );

Dictionary<FilePath, string> Generate(
    FilePath[] files,
    DirectoryPath outputDir,
    BuildConfig config,
    DirectoryPath? testsOutputDir = null,
    PInvokeGeneratorOutputMode mode = PInvokeGeneratorOutputMode.CSharp
)
{
    var outputStreamDictionary = new Dictionary<string, StreamToStringWrapper>();

    {
        using var generator = new PInvokeGenerator(
            config.ToGeneratorConfiguration(
                outputDir,
                mode is PInvokeGeneratorOutputMode.CSharp ? testsOutputDir : null,
                mode
            ),
            s =>
            {
                var stringStream = new StreamToStringWrapper();

                outputStreamDictionary.Add(s, stringStream);

                return stringStream;
            }
        );

        // ReSharper disable BitwiseOperatorOnEnumWithoutFlags
        const CXTranslationUnit_Flags translationFlags =
            CXTranslationUnit_IncludeAttributedTypes
            | CXTranslationUnit_VisitImplicitAttributes
            | CXTranslationUnit_DetailedPreprocessingRecord;
        // ReSharper restore BitwiseOperatorOnEnumWithoutFlags
        var clangCmdArgs = config.GetClangCmdLineArgsForConfig();

        var error = false;
        foreach (var filePath in files)
        {
            var translationUnit = CreateTranslationUnitForFile(
                filePath,
                generator.IndexHandle,
                clangCmdArgs.ToArray(),
                translationFlags
            );

            if (translationUnit is null)
            {
                Warning("Skipping \'{0}\' due to one or more errors listed above", filePath);
                error = true;
                continue;
            }

            var additionalRemapped = GetAdditionalRemappedNames(translationUnit);

            var remapDict = (StrDic)generator.Config.RemappedNames;
            foreach (var (before, after) in additionalRemapped)
                remapDict.TryAdd(before, after);

            var additionalGuids = GetComStyleClassUuids(translationUnit);

            var withGuidsDict = (Dictionary<string, Guid>)generator.Config.WithGuids;
            foreach (var (typeName, guid) in additionalGuids)
                withGuidsDict.TryAdd(typeName, guid);

            try
            {
                Information("Processing \'{0}\'", filePath);
                generator.GenerateBindings(
                    translationUnit,
                    MakeAbsolute(filePath).ToString(),
                    [.. clangCmdArgs],
                    translationFlags
                );
            }
            catch (Exception e)
            {
                Error("Failed to generate bindings for \'{0}\' : {1}", filePath, e);
                error = true;
            }
        }

        error.ShouldBeFalse("Bindings Generation failed, see logs for details");
    }

    return outputStreamDictionary
        .Select(pair => (File(pair.Key).Path, pair.Value.ToString().ReplaceLineEndings("\r\n")))
        .ToDictionary();
}

void WriteFilesToDisk(IDictionary<FilePath, string> outputFiles)
{
    foreach (var (path, textBody) in outputFiles)
    {
        Debug("Writing file \'{0}\' to disk", path);

        FileWriteText(path, textBody);
    }
}

TranslationUnit? CreateTranslationUnitForFile(
    FilePath filePath,
    CXIndex index,
    ReadOnlySpan<string> clangCmdArgs,
    CXTranslationUnit_Flags flags
)
{
    var translationUnitError = CXTranslationUnit.TryParse(
        index,
        MakeAbsolute(filePath).ToString(),
        clangCmdArgs,
        [],
        flags,
        out var handle
    );

    if (translationUnitError != CXErrorCode.CXError_Success)
    {
        Error("Parsing failed for '{0}' due to '{1}'", filePath, translationUnitError);
        return null;
    }

    var isSkipping = false;
    if (handle.NumDiagnostics != 0)
    {
        Information("Diagnostics for '{0}':", filePath);

        for (uint i = 0; i < handle.NumDiagnostics; ++i)
        {
            using var diagnostic = handle.GetDiagnostic(i);

            var diagStr = diagnostic.Format(CXDiagnostic.DefaultDisplayOptions).ToString();

            var level = diagnostic.Severity switch
            {
                CXDiagnosticSeverity.CXDiagnostic_Ignored => LogLevel.Debug,
                CXDiagnosticSeverity.CXDiagnostic_Note => LogLevel.Information,
                CXDiagnosticSeverity.CXDiagnostic_Warning => LogLevel.Warning,
                CXDiagnosticSeverity.CXDiagnostic_Error => LogLevel.Error,
                CXDiagnosticSeverity.CXDiagnostic_Fatal => LogLevel.Fatal,
                _ => throw new ArgumentOutOfRangeException(),
            };

            Context.Log.Write(Verbosity.Normal, level, "#{0} : {1}", i, diagStr);

            if (diagnostic.Severity is CXDiagnosticSeverity.CXDiagnostic_Error)
                isSkipping = true;
        }
    }

    if (isSkipping)
        return null;

    var translationUnit = TranslationUnit.GetOrCreate(handle).ShouldNotBeNull();

    return translationUnit;
}

// Register services with script host integration
static partial class Program
{
    static partial void RegisterServices(IServiceCollection services)
    {
        services.AddSharedScriptServices();
    }
}

static class ClangAstExtensions
{
    public static StrDic GetAdditionalRemappedNames(TranslationUnit translationUnit)
    {
        var rootCursor = translationUnit.TranslationUnitDecl;
        var externCursors = FindAllChildrenOfKind<LinkageSpecDecl>(rootCursor)
            .ShouldNotBeNull()
            .ToArray();

        return GetEnumAdditionalRemappedNames(externCursors)
            .Concat(GetDisambiguatedRemappedNames(rootCursor))
            .ToDictionary();
    }

    public static IEnumerable<(string, string)> GetEnumAdditionalRemappedNames(
        IEnumerable<LinkageSpecDecl> linkageSpecDecls
    )
    {
        var foundEnums = linkageSpecDecls
            .SelectMany(FindAllChildrenOfKind<EnumDecl>)
            .Where(decl => decl.Spelling.StartsWith("Slang"))
            .ToArray();

        var remappedEnumNames = foundEnums.Select(decl =>
        {
            var qualifiedName = GetFullQualifiedNameFromCursor(decl);
            var formatedName = decl.Spelling.StartsWith("Slang")
                ? decl.Spelling[5..]
                : decl.Spelling;

            return (qualifiedName, formatedName.Pascalize());
        });

        var remappedEnumMembers = foundEnums
            .SelectMany(decl => decl.CursorChildren)
            .Where(decl => decl is EnumConstantDecl)
            .Cast<EnumConstantDecl>()
            .Select(decl =>
            {
                var qualifiedName = GetFullQualifiedNameFromCursor(decl);

                var parentEnumName = decl.SemanticParentCursor?.Spelling;

                var parentEnumNameWords = parentEnumName
                    .Humanize()
                    .Transform(To.LowerCase)
                    .Split(' ');

                var declWords = decl.Spelling.Humanize().Transform(To.LowerCase).Split(' ');

                var humanizeDeclWords = declWords
                    .Index()
                    .Except(parentEnumNameWords.Index())
                    .Select(pair => pair.Item)
                    .ToArray();

                var pascalCaseTrimmed = string.Join(" ", humanizeDeclWords).Pascalize();

                return (qualifiedName, pascalCaseTrimmed);
            });

        return remappedEnumNames.Concat(remappedEnumMembers);
    }

    public static IEnumerable<(string, string)> GetDisambiguatedRemappedNames(
        TranslationUnitDecl translationUnit
    )
    {
        var gfxNamespace = FindAllChildrenOfKind<NamespaceDecl>(translationUnit)
            .Where(decl => decl.Spelling == "gfx")
            .ToArray();

        var comInterfaces = gfxNamespace
            .SelectMany(FindAllChildrenOfKind<RecordDecl>)
            .Where(decl => decl.IsClass && decl.Spelling.StartsWith('I'))
            .ToArray(); //Find all the COM interfaces

        var childStructs = comInterfaces.SelectMany(FindAllChildrenOfKind<RecordDecl>).ToArray();

        var descStructs = childStructs
            .Where(decl => decl.IsStruct && decl.Spelling == "Desc")
            .ToArray();

        return descStructs.Select(decl =>
        {
            var qualifiedName = GetFullQualifiedNameFromCursor(decl);

            var parentInterfaceName = decl.SemanticParentCursor?.Spelling;

            var trimmedParentName = parentInterfaceName![1..];

            return (qualifiedName, $"{trimmedParentName}Desc");
        });
    }

    public static Dictionary<string, Guid> GetComStyleClassUuids(TranslationUnit translationUnit)
    {
        var comStructs = FindAllChildrenOfKind<RecordDecl>(translationUnit.TranslationUnitDecl);

        var guidMethods = comStructs
            .SelectMany(FindAllChildrenOfKind<CXXMethodDecl>)
            .Where(m => m.Name == "getTypeGuid")
            .ToArray();

        var guids = guidMethods
            .Select(m => (m.Parent.ShouldNotBeNull().Name, GetGuidFromTypeGuidMethod(m)))
            .ToDictionary();

        return guids;

        Guid GetGuidFromTypeGuidMethod(CXXMethodDecl method)
        {
            var l = FindAllChildrenOfKind<IntegerLiteral>(method)
                .Select(l => l.Value)
                .Reverse()
                .ToArray();

            l.Length.ShouldBe(11, "Parsed interface type UUID invalid!");

            var guid = new Guid(
                (uint)l[0],
                (ushort)l[1],
                (ushort)l[2],
                (byte)l[3],
                (byte)l[4],
                (byte)l[5],
                (byte)l[6],
                (byte)l[7],
                (byte)l[8],
                (byte)l[9],
                (byte)l[10]
            );

            return guid;
        }
    }

    public static T? FindFirstChildOfKind<T>(this Cursor cursor)
        where T : Cursor
    {
        return FindAllChildrenOfKind<T>(cursor).FirstOrDefault();
    }

    public static IEnumerable<T> FindAllChildrenOfKind<T>(this Cursor cursor)
        where T : Cursor
    {
        var stack = new Stack<Cursor>(cursor.CursorChildren);

        while (stack.TryPop(out var currentCursor))
        {
            if (currentCursor is T foundCursor && !currentCursor.Location.IsInSystemHeader)
            {
                yield return foundCursor;
                continue;
            }

            foreach (var c in currentCursor.CursorChildren)
                stack.Push(c);
        }
    }

    public static string GetFullQualifiedNameFromCursor(this Cursor cursor)
    {
        var nameParts = new Stack<string>();

        var currentCursor = cursor;

        while (
            currentCursor is not null
            && currentCursor.CursorKind != CXCursorKind.CXCursor_TranslationUnit
        )
        {
            if (!string.IsNullOrWhiteSpace(currentCursor.Spelling))
                nameParts.Push(currentCursor.Spelling);

            currentCursor = currentCursor.SemanticParentCursor;
        }

        return string.Join("::", nameParts);
    }
}

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
    Dictionary<
        string,
        (string Name, PInvokeGeneratorTransparentStructKind Kind)
    > WithTransparentStructs,
    Dictionary<string, Guid> WithGuids,
    FilePathCollection? TraversalNames = null
)
{
    public FilePathCollection TraversalNames { get; set; } = TraversalNames ?? [];

    public IReadOnlyList<string> GetClangCmdLineArgsForConfig()
    {
        var linuxIncludeDirectories = new List<DirectoryPath>();

        var cppIncludes = GetDirectories("/usr/include/c++/*/").ToArray();
        var clangIncludes = GetDirectories("/usr/include/clang/*/include").ToArray();
        var gccIncludes = GetDirectories("/usr/lib/gcc/*/*/include").ToArray();

        if (cppIncludes.Length is not 0)
        {
            Array.Sort(cppIncludes, PathComparer.Default);

            Information("Found C++ includes:");
            foreach (var inc in cppIncludes)
                Information("  {0}", inc);

            var chosenDir = cppIncludes[^1];

            Information("Choosing C++ include directory: {0}", chosenDir);
            linuxIncludeDirectories.Add(chosenDir);

            foreach (var bitsDir in GetDirectories($"{chosenDir}/**/bits/"))
            {
                if (bitsDir is not null && bitsDir.GetParent() != chosenDir)
                {
                    Information("Also adding bits include directory: {0}", bitsDir.GetParent());
                    linuxIncludeDirectories.Add(bitsDir.GetParent());
                }
            }
        }
        if (clangIncludes.Length is not 0)
        {
            Array.Sort(clangIncludes, PathComparer.Default);

            Information("Found Clang includes:");
            foreach (var inc in clangIncludes)
                Information("  {0}", inc);

            Information("Choosing Clang include directory: {0}", clangIncludes[^1]);
            linuxIncludeDirectories.Add(clangIncludes[^1]);
        }
        if (gccIncludes.Length is not 0)
        {
            Array.Sort(gccIncludes, PathComparer.Default);

            Information("Found GCC includes:");
            foreach (var inc in gccIncludes)
                Information("  {0}", inc);

            Information("Choosing GCC include directory: {0}", gccIncludes[^1]);
            linuxIncludeDirectories.Add(gccIncludes[^1]);
        }
        if (linuxIncludeDirectories.Count is 0)
        {
            Warning(
                "No standard include directories found for linux system, generation might fail!"
            );
        }

        linuxIncludeDirectories.AddRange([
            "/usr/include/x86_64-linux-gnu",
            "/usr/include/linux",
            "/usr/include",
        ]);

        //Add additional include directories for linux systems to resolve stddef.h
        var includeDirectories = IsRunningOnLinux() ? linuxIncludeDirectories : [];

        Information("Include directories for Clang: {0}", string.Join(", ", includeDirectories));

        return
        [
            $"--language={Language}", // Treat subsequent input files as having type <language>
            "-stdlib=libc++",
            "-Wno-pragma-once-outside-header", // We are processing files which may be header files
            "-Wno-deprecated-declarations",
            .. DefineMacros
                .Concat(["SLANG_PLATFORM", GetSlangPlatformDefine()])
                .Select(s => $"-D {s}"),
            .. includeDirectories.Select(s => $"-I{s}"),
        ];
    }

    public PInvokeGeneratorConfiguration ToGeneratorConfiguration(
        DirectoryPath outputDir,
        DirectoryPath? testsOutputDir = null,
        PInvokeGeneratorOutputMode mode = PInvokeGeneratorOutputMode.CSharp
    )
    {
        var opts = Options;
        if (testsOutputDir is not null && DirectoryExists(testsOutputDir))
        {
            opts |= GenerateTestsXUnit;
        }

        if (IsRunningOnUnix())
            opts |= GenerateUnixTypes;

        return new(
            Language,
            "c++17",
            DefaultNamespace,
            MakeAbsolute(outputDir).ToString(),
            null,
            mode,
            opts
        )
        {
            DefaultClass = DefaultClass,
            LibraryPath = LibraryPath,
            MethodPrefixToStrip = PrefixStrip,
            TraversalNames =
            [
                .. TraversalNames.Select(t => t.MakeAbsolute(Context.Environment).ToString()),
            ],
            ExcludedNames = Excludes.AsReadOnly(),
            RemappedNames = Remap.AsReadOnly(),
            WithTypes = WithTypes.AsReadOnly(),
            WithNamespaces = WithNamespaces.AsReadOnly(),
            WithGuids = WithGuids.AsReadOnly(),
            TestOutputLocation = testsOutputDir?.MakeAbsolute(Context.Environment).ToString(),
            WithTransparentStructs = WithTransparentStructs.AsReadOnly(),
        };
    }

    static string GetSlangPlatformDefine()
    {
        if (Context.Environment.Platform.Is64Bit)
        {
            if (IsRunningOnWindows())
                return "SLANG_WIN64";
            if (IsRunningOnLinux())
                return "SLANG_LINUX";
            if (IsRunningOnMacOs())
                return "SLANG_OSX";
        }
        else
        {
            if (IsRunningOnWindows())
                return "SLANG_WIN32";
        }

        throw new PlatformNotSupportedException(
            $"Unsupported platform for Slang bindings generation {Context.Environment.Platform}"
        );
    }

    public static BuildConfig GetBuildConfig(string defClass, string libPath) =>
        new(
            "c++",
            defClass,
            libPath,
            "ShaderSlang.Net.Bindings.Generated",
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
                | LogPotentialTypedefRemappings
                | DontUseUsingStaticsForEnums,
            [
                // Prevent platform-specific macros
                "SLANG_COMPILER",
                "__clang__",
                "SLANG_CLANG",
                "SLANG_STDCALL=__stdcall", // we force stdcall conv for now
                // TODO: change later when implemented conditionnal call conv
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
                // Exclude ResourceStateSet we reimplement it fully
                "gfx::ResourceStateSet",
                // Generates as an empty struct and fails tests so remove, gets reimplemented anyway
                "gfx::AdapterList",
            ],
            new()
            {
                { "specialize", "spspecialize" },
                { "specializeType", "spspecializeType" },
                { "Attribute", "SlangAttribute" }, // Resolves name conflict with dotnet Attribute type
                { "Kind", "TypeKind" }, // Use generated trimmed name
                { "SlangMatrixLayoutMode::SLANG_MATRIX_LAYOUT_ROW_MAJOR", "RowMajor" },
                { "SlangMatrixLayoutMode::SLANG_MATRIX_LAYOUT_COLUMN_MAJOR", "ColumnMajor" },
                { "gfx::RayTracingPipelineFlags::Enum", "RayTracingPipelineFlagsEnum" },
                { "gfx::ITransientResourceHeap::Flags::Enum", "TransientResourceHeapFlagsEnum" },
                { "gfx::IAccelerationStructure::BuildFlags::Enum", "AccelerationStructBuildFlags" },
                {
                    "gfx::IAccelerationStructure::GeometryFlags::Enum",
                    "AccelerationStructGeometryFlags"
                },
                {
                    "gfx::IAccelerationStructure::GeometryInstanceFlags::Enum",
                    "AccelerationStructGeometryInstanceFlags"
                },
                // Reimplement ResourceStateSet as a ulong since we have a custom implementation
                { "gfx::ResourceStateSet", "ulong" },
                { "gfx::IResource::Type", "ResourceType" },
                { "gfx::IResourceView::Type", "ResourceViewType" },
                { "bool", "Boolean" },
                { "SlangBool", "Boolean" },
                { "SlangInt", "nint" },
                { "SlangUInt", "nuint" },
                { "SlangSSizeT", "nint" },
                { "SlangSizeT", "nuint" },
                { "uint64_t", "ulong" },
            },
            new()
            {
                // This fixes a ClangSharp issue with TypeReflection::Kind causing compile errors
                { "Kind", "uint" },
            },
            new()
            {
                // For the pretty bindings we rewrite everything but some of the enums and PODs
                { "BindingType", "ShaderSlang.Net" },
                { "ContainerType", "ShaderSlang.Net" },
                { "LayoutRules", "ShaderSlang.Net" },
                { "ParameterCategory", "ShaderSlang.Net" },
                { "PathKind", "ShaderSlang.Net" },
                { "OSPathKind", "ShaderSlang.Net" },
            },
            [],
            []
        );
}
