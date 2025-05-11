using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Octokit;
using Serilog;
using SlangNet.Build.Tools;

namespace SlangNet.Build.Targets;

interface IDownloadSlangBinaries : INukeBuild
{
    [Parameter]
    Configuration Configuration => TryGetValue(() => Configuration) ?? Configuration.Debug;

    [Parameter(List = true)]
    DotnetRuntimeId[] TargetRids =>
        TryGetValue(() => TargetRids)
        ?? (IsLocalBuild ? [DotnetRuntimeId.Current] : SlangRuntimeId.List().Select(id => id.ToDotnetRuntimeId()).ToArray());

    [Parameter]
    Version SlangVersion => TryGetValue(() => SlangVersion) ?? new("2025.7.1");

    AbsolutePath DownloadCacheDirectory => TemporaryDirectory / "DownloadCache";

    IEnumerable<AbsolutePath> GetBinariesForPlatform(DotnetRuntimeId rid)
    {
        var binDir = GetBinFolderForRid(rid);
        
        return binDir.ExistingDirectory()
                     .NotNull()
                     .GlobFiles("*.dll", "*.dylib", "*.so");
    }

    private AbsolutePath GetReleaseFolderForRid(DotnetRuntimeId rid) =>
        DownloadCacheDirectory / $"slang-{SlangVersion}-{rid.Value}";

    private AbsolutePath GetBinFolderForRid(DotnetRuntimeId rid) =>
        GetReleaseFolderForRid(rid) / (rid == DotnetRuntimeId.Win64 || rid == DotnetRuntimeId.WinArm64
            ? "bin"
            : "lib");

    private string[] GetBinariesForAllPlatform() =>
        TargetRids.Select(GetBinFolderForRid)
                  .SelectMany<AbsolutePath, string>(p => [p / "*.dll", p / "*.dylib", p / "*.so"])
                  .ToArray();

    Target CleanDownloadDir =>
        d => d
             .Unlisted()
             .Executes(() =>
             {
                 Log.Information("Cleaning download cache {CacheDir}", DownloadCacheDirectory);
                 DownloadCacheDirectory.CreateOrCleanDirectory();
             });
    
    Target DownloadSlangBinaries =>
        _ => _
             .Produces(GetBinariesForAllPlatform())
             .Executes(async () =>
             {
                 var client = new GitHubClient(new ProductHeaderValue("SlangNet"));

                 var release = await client.Repository.Release.Get(
                     "shader-slang", "slang", "v" + SlangVersion);

                 var assetNameStart = $"slang-{SlangVersion}-";
                 var platformReleases
                     = release.Assets.Where(asset => asset.Name.StartsWith(assetNameStart) &&
                                                     asset.Name.EndsWith(".zip") &&
                                                     !asset.Name.Contains("debug-info") &&
                                                     !asset.Name.Contains("glibc"));


                 platformReleases
                     .AsParallel()
                     .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                     .Select(asset => (ArchivePath: DownloadCacheDirectory / asset.Name,
                                       RuntimeId: SlangRuntimeId.FromValue(
                                                                    asset.Name
                                                                         .TrimStart(assetNameStart)
                                                                         .TrimEnd(".zip"))
                                                                .ToDotnetRuntimeId(),
                                       asset.BrowserDownloadUrl))
                     .Where(tuple => TargetRids.Contains(tuple.RuntimeId))
                     .ForAll(tuple =>
                     {
                         if (tuple.ArchivePath.FileExists())
                         {
                             Log.Information(
                                 "Slang binary are already saved to {Path}, skipping download...",
                                 tuple.ArchivePath);
                         }
                         else
                         {
                             Log.Information("Downloading archive from {Url} and saving to {ArchivePath}",
                                             tuple.BrowserDownloadUrl, tuple.ArchivePath);
                             HttpTasks.HttpDownloadFile(tuple.BrowserDownloadUrl, tuple.ArchivePath);
                         }

                         var runtimeId = tuple.RuntimeId;
                         var assetFolderPath = GetReleaseFolderForRid(runtimeId);

                         if (assetFolderPath.DirectoryExists())
                             Log.Information("{AssetPath} already exists, skipping archive unzipping...", assetFolderPath);
                         else
                         {
                             Log.Information("Unzipping {ArchivePath} to directory {AssetPath}",
                                             tuple.ArchivePath,
                                             assetFolderPath);
                             tuple.ArchivePath.UnZipTo(assetFolderPath);
                         }

                         var libFiles = GetBinariesForPlatform(runtimeId).ToArray();

                         Log.Information(
                             "Found in slang release {Version}-{RuntimeId} shared library file {Files}",
                             SlangVersion,
                             tuple.RuntimeId,
                             libFiles.Select(p => p.Name));

                         string[] reqSlangBinNames = ["slang", "gfx"];

                         var filesMissing = reqSlangBinNames.Except(libFiles.Select(path =>
                                                                                        path.NameWithoutExtension
                                                                                            .TrimStart("lib")))
                                                            .ToArray();

                         Assert.Empty(filesMissing, $"Missing slang binaries: {filesMissing} in release");
                     });
             });
}