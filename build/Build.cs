using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NuGet.Packaging;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Serilog;

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

    [Solution(GenerateProjects = true)] readonly Solution Solution;

    readonly BuildSlangBindings SlangBindings = new()
    {
        SrcOutputDir = RootDirectory / "SlangNet.Bindings" / "Generated",
        XmlOutputDir = RootDirectory / "SlangNet" / "GeneratedDoc",
        TestsOutputDir = RootDirectory / "SlangNet.Tests" / "Generated",
        SlangRepoPath = RootDirectory / "slang"
    };

    Target Clean =>
        d => d
            .Executes(() =>
            {
                DotNetTasks.DotNetClean(s => s.SetProject(Solution));
            });

    Target GenerateSlangBindings =>
        d =>
            d.Executes(() =>
            {
                SlangBindings.SrcOutputDir.CreateOrCleanDirectory();
                SlangBindings.XmlOutputDir.CreateOrCleanDirectory();
                SlangBindings.TestsOutputDir.CreateOrCleanDirectory();

                SlangBindings.Build();
            });

    Target DownloadSlangBinaries =>
        d =>
            d.Executes(async () =>
            {
                Project[] nativeProjects =
                [
                    Solution.Native.SlangNet_Native_win_x64,
                    Solution.Native.SlangNet_Native_win_x86,
                    Solution.Native.SlangNet_Native_win_arm64,

                    Solution.Native.SlangNet_Native_linux_x64,

                    Solution.Native.SlangNet_Native_osx_x64,
                    Solution.Native.SlangNet_Native_osx_arm64
                ];


                foreach (var project in nativeProjects)
                {
                    foreach (var framework in project.GetTargetFrameworks().NotNull())
                    {
                        await DownloadSlangBinariesForProject(project, framework);
                    }
                }

                return;

                async Task DownloadSlangBinariesForProject(Project project, string targetFramework)
                {
                    Log.Information(
                        "Started downloading native binaries for project {Project}, target framework : {TargetFramework}",
                        project, targetFramework);
                    var msProject = project.GetMSBuildProject(Configuration, targetFramework);

                    var outputDir = project.Directory / msProject.GetProperty("OutputPath").EvaluatedValue;
                    var intermediateOutputDir
                        = project.Directory / msProject.GetProperty("IntermediateOutputPath").EvaluatedValue;

                    var nativeNames = msProject.GetItems("SlangNativeNames")
                                               .Select(item => item.EvaluatedInclude)
                                               .ToList();
                    var slangRuntime = project.GetProperty("SlangRuntime").NotNull();
                    var slangDownloadRuntime = project.GetProperty("SlangDownloadRuntime").NotNull();
                    var slangNativeDir = project.GetProperty("SlangNativeDir").NotNull();

                    var slangTempArchiveName = msProject.GetProperty("SlangTempArchiveName").NotNull().EvaluatedValue;
                    var slangTempArchivePath = project.Directory /
                                               msProject.GetProperty("SlangTempArchivePath").NotNull().EvaluatedValue;
                    var slangTempOutputPath = project.Directory /
                                              msProject.GetProperty("SlangTempOutputPath").NotNull().EvaluatedValue;

                    var slangVersion = msProject.GetProperty("SlangVersion").NotNull().EvaluatedValue;

                    var slangNativeRepo = msProject.GetProperty("SlangNativeRepo").NotNull().EvaluatedValue;
                    var sourceUrl
                        = $"{slangNativeRepo}/releases/download/v{slangVersion}/slang-{slangVersion}-{slangDownloadRuntime}.zip";

                    if (!slangTempArchivePath.Exists("*file"))
                    {
                        using var httpClient = new HttpClient();
                        Log.Information("Downloading archive from {Url}", sourceUrl);
                        var stream = await httpClient.GetStreamAsync(new Uri(sourceUrl));

                        Log.Information("Writing archive to {Path}", slangTempArchivePath);
                        stream.CopyToFile(slangTempArchivePath);
                    }
                    else Log.Information("{Path} already exists, skipping download...", slangTempArchivePath);

                    Log.Information("Unzipping archive to directory {Path}", slangTempArchivePath);
                    slangTempArchivePath.UnZipTo(slangTempOutputPath);
                }
            });

    Target Restore =>
        d => d
             .DependsOn(GenerateSlangBindings)
             .DependsOn(DownloadSlangBinaries)
             .Executes(() =>
             {
                 DotNetTasks.DotNetRestore(s => s.SetProjectFile(Solution));
             });

    Target Compile =>
        d => d
             .DependsOn(Restore)
             .Executes(() =>
             {
                 DotNetTasks.DotNetBuild(s =>
                                             s.SetNoRestore(true)
                                              .SetProjectFile(Solution));
             });
}