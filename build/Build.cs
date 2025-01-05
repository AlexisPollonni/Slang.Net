using System;
using System.Diagnostics;
using ClangSharp;
using ClangSharp.Interop;
using Nuke.Common;
using Nuke.Common.IO;
using Serilog;
using Serilog.Events;
using static ClangSharp.Interop.CXTranslationUnit_Flags;
using static ClangSharp.PInvokeGeneratorConfigurationOptions;
using static Nuke.Common.EnvironmentInfo;

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
                 var srcOutputDir = RootDirectory / "SlangNet.Bindings" / "Generated";
                 var xmlOutputDir = RootDirectory / "SlangNet" / "GeneratedDoc";
                 var testsOutputDir = RootDirectory / "SlangNet.Tests" / "SlangNet.Tests.Shared" / "Generated";
                 var slangRepoPath = RootDirectory / "slang";
                 var slangHeaderPath = slangRepoPath / "include" / "slang.h";

                 AbsolutePath[] files =
                 [
                     slangHeaderPath
                 ];

                 var config = new BuildConfig
                 {
                     GeneratedTestsDir = testsOutputDir
                 };

                 if (IsWin) config.Options |= GenerateUnixTypes;
                 
                 Log.Information("Generating CSharp bindings...");
                 GenerateSlangBindings(files, srcOutputDir, config);
                 
                 config.GeneratedTestsDir = null;
                 Log.Information("Generating XML documentation files...");
                 GenerateSlangBindings(files, xmlOutputDir, config, PInvokeGeneratorOutputMode.Xml);
             });

    private void GenerateSlangBindings(AbsolutePath[] files,
                                       AbsolutePath outputDir,
                                       in BuildConfig config,
                                       PInvokeGeneratorOutputMode mode = PInvokeGeneratorOutputMode.CSharp)
    {
        using var generator = new PInvokeGenerator(config.ToGeneratorConfiguration(outputDir, mode));

        // ReSharper disable BitwiseOperatorOnEnumWithoutFlags
        const CXTranslationUnit_Flags translationFlags = CXTranslationUnit_IncludeAttributedTypes
                                                         | CXTranslationUnit_VisitImplicitAttributes
                                                         | CXTranslationUnit_DetailedPreprocessingRecord;
        // ReSharper restore BitwiseOperatorOnEnumWithoutFlags

        foreach (var filePath in files)
        {
            var translationUnitError = CXTranslationUnit.TryParse(generator.IndexHandle, filePath,
                                                                  config.ClangCmdArgs, [], translationFlags,
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


            try
            {
                using var translationUnit = TranslationUnit.GetOrCreate(handle);
                Debug.Assert(translationUnit is not null);

                Log.Information("Processing \'{FilePath}\'", filePath);
                generator.GenerateBindings(translationUnit, filePath, config.ClangCmdArgs, translationFlags);
            }
            catch (Exception e)
            {
                Log.Error(e, "Failed to generate bindings for \'{FilePath}\'", filePath);
            }
        }
    }
}