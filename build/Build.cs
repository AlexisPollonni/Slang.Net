using System;
using System.Diagnostics;
using System.Linq;
using ClangSharp;
using ClangSharp.Interop;
using Nuke.Common;
using Nuke.Common.IO;
using Serilog;
using Serilog.Events;
using static ClangSharp.PInvokeGeneratorConfigurationOptions;
using static Nuke.Common.EnvironmentInfo;
using StrDictionary = System.Collections.Generic.Dictionary<string, string>;

class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode
    public static int Main() =>
        Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    Target Clean =>
        _ => _
             .Before(Restore)
             .Executes(() => { });

    Target Restore =>
        _ => _
            .Executes(() => { });

    Target Compile =>
        _ => _
             .DependsOn(Restore)
             .Executes(() =>
             {
                 var outputDir = RootDirectory / "SlangNet.Bindings" / "Generated";
                 var slangRepoPath = RootDirectory / "slang";
                 var slangHeaderPath = slangRepoPath / "include" / "slang.h";
                 
                 AbsolutePath[] files =
                 [
                     slangHeaderPath
                 ];

                 const string language = "c++";
                 const string defaultNamespace = "SlangNet.Bindings.Generated";

                 var opts = IsWin ? None : GenerateUnixTypes;

                 opts |= GenerateLatestCode
                         | GenerateFileScopedNamespaces
                         | GenerateDocIncludes
                         | GenerateHelperTypes
                         | GenerateMacroBindings
                         | GenerateAggressiveInlining
                         | ExcludeFunctionsWithBody
                         | ExcludeComProxies
                         | ExcludeEnumOperators
                         | GenerateTrimmableVtbls
                         | GenerateMultipleFiles
                         | LogPotentialTypedefRemappings
                         | StripEnumMemberTypeName;

                 string[] defineMacros =
                 [
                     // Prevent platform-specific macros
                     "SLANG_COMPILER",
                     "SLANG_PLATFORM",
                     "SLANG_WIN64"
                 ];

                 string[] excludes =
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

                     // This one  is just broken
                     "SLANG_UNBOUNDED_SIZE",
                     "createCompileRequest",

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
                 ];

                 // Remove the function prefixes, also fix over-removing of prefixes
                 var prefixStrip = "sp";

                 var withType = new StrDictionary
                 {
                     // This fixes a ClangSharp issue with TypeReflection::Kind causing compile errors
                     { "Kind", "uint" }
                 };

                 var withNamespace = new StrDictionary
                 {
                     // For the pretty bindings we rewrite everything but some of the enums and PODs
                     { "BindingType", "SlangNet" },
                     { "ContainerType", "SlangNet" },
                     { "LayoutRules", "SlangNet" },
                     { "ParameterCategory", "SlangNet" },
                     { "PathKind", "SlangNet" },
                     { "OSPathKind", "SlangNet" },
                 };

                 var remap = new StrDictionary
                 {
                     { "specialize", "spspecialize" },
                     { "specializeType", "spspecializeType" },
                     { "Attribute", "SlangAttribute" } // Resolves name conflict with dotnet Attribute type
                 };


                 string[] clangOptions =
                 [
                     $"--language={language}", // Treat subsequent input files as having type <language>
                     "-Wno-pragma-once-outside-header", // We are processing files which may be header files

                     "-Wno-deprecated-declarations",
                     ..defineMacros.Select(s => $"--define-macro={s}")
                 ];

                 var config = new PInvokeGeneratorConfiguration(language, "", defaultNamespace,
                                                                outputDir, "",
                                                                PInvokeGeneratorOutputMode.CSharp, opts)
                 {
                     DefaultClass = "Slang",
                     LibraryPath = "slang",
                     ExcludedNames = excludes,
                     MethodPrefixToStrip = prefixStrip,
                     WithTypes = withType,
                     WithNamespaces = withNamespace,
                     RemappedNames = remap,
                 };


                 using var generator = new PInvokeGenerator(config);


                 const CXTranslationUnit_Flags translationFlags
                     = CXTranslationUnit_Flags.CXTranslationUnit_IncludeAttributedTypes
                       | CXTranslationUnit_Flags.CXTranslationUnit_VisitImplicitAttributes
                       | CXTranslationUnit_Flags.CXTranslationUnit_DetailedPreprocessingRecord;


                 foreach (var filePath in files)
                 {
                     var translationUnitError = CXTranslationUnit.TryParse(generator.IndexHandle, filePath,
                                                                           clangOptions, [], translationFlags,
                                                                           out var handle);
                     var skipProcessing = false;

                     if (translationUnitError != CXErrorCode.CXError_Success)
                     {
                         Log.Error("Parsing failed for '{FilePath}' due to '{TranslationUnitError}'", filePath,
                                   translationUnitError);
                         skipProcessing = true;
                     }
                     else if (handle.NumDiagnostics != 0)
                     {
                         Log.Information("Diagnostics for '{FilePath}':", filePath);

                         for (uint i = 0; i < handle.NumDiagnostics; ++i)
                         {
                             using var diagnostic = handle.GetDiagnostic(i);

                             var diagStr = diagnostic.Format(CXDiagnostic.DefaultDisplayOptions).ToString();

                             var level = diagnostic.Severity switch
                             {
                                 CXDiagnosticSeverity.CXDiagnostic_Ignored => LogEventLevel.Debug,
                                 CXDiagnosticSeverity.CXDiagnostic_Note => LogEventLevel.Information,
                                 CXDiagnosticSeverity.CXDiagnostic_Warning => LogEventLevel.Warning,
                                 CXDiagnosticSeverity.CXDiagnostic_Error => LogEventLevel.Error,
                                 CXDiagnosticSeverity.CXDiagnostic_Fatal => LogEventLevel.Fatal,
                                 _ => throw new ArgumentOutOfRangeException()
                             };

                             Log.Write(level, "#{Index} : {Diagnostic}", i, diagStr);

                             skipProcessing |= diagnostic.Severity == CXDiagnosticSeverity.CXDiagnostic_Error;
                             skipProcessing |= diagnostic.Severity == CXDiagnosticSeverity.CXDiagnostic_Fatal;
                         }
                     }

                     if (skipProcessing)
                     {
                         Log.Warning("Skipping \'{FilePath}\' due to one or more errors listed above", filePath);
                         continue;
                     }

#pragma warning disable CA1031 // Do not catch general exception types

                     try
                     {
                         using var translationUnit = TranslationUnit.GetOrCreate(handle);
                         Debug.Assert(translationUnit is not null);

                         Log.Information("Processing \'{FilePath}\'", filePath);
                         generator.GenerateBindings(translationUnit, filePath, clangOptions, translationFlags);
                     }
                     catch (Exception e)
                     {
                         Log.Error(e, "Failed to generate bindings for \'{FilePath}\'", filePath);
                     }

#pragma warning restore CA1031 // Do not catch general exception types
                 }
             });
}