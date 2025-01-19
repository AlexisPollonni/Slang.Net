using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NuGet.Packaging;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Utilities.Collections;
using Serilog;

public interface IDownloadSlangBinaries : INukeBuild
{
    [Parameter] Configuration Configuration => TryGetValue(() => Configuration) ?? Configuration.Debug;

    [Solution] internal Solution? Solution => TryGetValue(() => Solution);

    Target DownloadSlangBinaries => _ => _
        .Executes(async () =>
        {
            Solution.NotNull();

            Project[] nativeProjects =
            [
                Solution!.Native.SlangNet_Native_win_x64,
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
                    .ToArray();

                if (nativeNames.IsEmpty())
                {
                    nativeNames =
                    [
                        msProject.GetProperty("SlangNativeName")
                            .NotNull($"No SlangNativeName property or items found in project {project}")
                            .EvaluatedValue
                    ];
                }

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

                var slangPathToBinaries = slangTempOutputPath / slangNativeDir;
                if (SlangBinariesExists())
                {
                    Log.Information("Slang binaries are already saved to {Path}, skipping...", slangTempOutputPath);
                    return;
                }

                if (!slangTempArchivePath.FileExists())
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

                if (!SlangBinariesExists())
                {
                    var filesNotFound = nativeNames.Select(s => slangPathToBinaries / s)
                        .Where(f => !f.FileExists())
                        .ToArray();
                    Log.Error("Theses slang binaries could not be found : {Binaries}", filesNotFound);
                }

                return;

                bool SlangBinariesExists() =>
                    slangPathToBinaries.DirectoryExists() &&
                    nativeNames.All(n => slangPathToBinaries.ContainsFile(n));
            }
        });
}