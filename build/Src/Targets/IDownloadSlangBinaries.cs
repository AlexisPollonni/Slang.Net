using System.Linq;
using System.Threading.Tasks;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Octokit;
using Serilog;
using SlangNet.Build.Tools;

namespace SlangNet.Build.Targets;

public interface IDownloadSlangBinaries : INukeBuild
{
    [Parameter]
    Configuration Configuration => TryGetValue(() => Configuration) ?? Configuration.Debug;

    [Solution]
    internal Solution? Solution => TryGetValue(() => Solution);
    
    [Parameter]
    DotnetRuntimeId? CurrentRid => TryGetValue(() => CurrentRid) ?? DotnetRuntimeId.Current;

    [Parameter]
    public string SlangVersion => TryGetValue(() => SlangVersion) ?? "2025.7.1";

    [Parameter]
    AbsolutePath OutputBinDirectory => TryGetValue(() => OutputBinDirectory) ?? TemporaryDirectory / "bin";
    AbsolutePath DownloadCacheDirectory => TemporaryDirectory / "DownloadCache";

    Target DownloadSlangBinaries =>
        _ => _
             .Produces(OutputBinDirectory / "**/*.dll", OutputBinDirectory / "**/*.so", OutputBinDirectory / "**/*.dylib")
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


                 var archiveLocations = platformReleases
                                        .Select(asset => (ArchivePath: DownloadCacheDirectory / asset.Name,
                                                          RuntimeId: SlangRuntimeId.FromValue(
                                                              asset.Name
                                                                   .TrimStart(assetNameStart)
                                                                   .TrimEnd(".zip")),
                                                          asset.BrowserDownloadUrl))
                                        .ToArray();

                 if (IsLocalBuild && CurrentRid is not null) archiveLocations = archiveLocations.Where(tuple => tuple.RuntimeId == CurrentRid.ToSlangRuntimeId()).ToArray();

                 archiveLocations.Where(tuple => tuple.ArchivePath.FileExists())
                                 .ForEach(skipped => Log.Information("Slang binary are already saved to {Path}, skipping...",
                                                                     skipped.ArchivePath));


                 var downloadTasks = archiveLocations
                                     .Where(tuple => !tuple.ArchivePath.FileExists())
                                     .Select(tuple =>
                                     {
                                         Log.Information("Downloading archive from {Url} and saving to {ArchivePath}",
                                                         tuple.BrowserDownloadUrl, tuple.ArchivePath);
                                         return HttpTasks.HttpDownloadFileAsync(tuple.BrowserDownloadUrl, tuple.ArchivePath);
                                     });

                 await Task.WhenAll(downloadTasks);

                 var binaryFiles = archiveLocations.Select(tuple => (tuple.RuntimeId, tuple.ArchivePath,
                                                                     AssetFolderPath: DownloadCacheDirectory /
                                                                                      $"slang-{SlangVersion}-{tuple.RuntimeId.Value}"))
                                                   .ForEachLazy(tuple =>
                                                   {
                                                       if (tuple.AssetFolderPath.DirectoryExists())
                                                       {
                                                           Log.Information("{AssetPath} already exists, skipping...", tuple.AssetFolderPath);
                                                           return;
                                                       }

                                                       Log.Information("Unzipping {ArchivePath} to directory {AssetPath}",
                                                                       tuple.ArchivePath,
                                                                       tuple.AssetFolderPath);
                                                       tuple.ArchivePath.UnZipTo(tuple.AssetFolderPath);
                                                   })
                                                   .Select(tuple =>
                                                   {
                                                       var binDir = tuple.RuntimeId == SlangRuntimeId.Win64 || tuple.RuntimeId == SlangRuntimeId.WinArm64
                                                           ? tuple.AssetFolderPath / "bin"
                                                           : tuple.AssetFolderPath / "lib";


                                                       return (tuple.RuntimeId,
                                                               LibFiles: binDir.ExistingDirectory()
                                                                               .NotNull()
                                                                               .GlobFiles("*.dll", "*.dylib", "*.so"));
                                                   })
                                                   .ForEachLazy(tuple =>
                                                   {
                                                       Log.Information(
                                                           "Found in slang release {Version}-{RuntimeId} shared library file {Files}",
                                                           SlangVersion,
                                                           tuple.RuntimeId,
                                                           tuple.LibFiles.Select(p => p.Name));

                                                       string[] reqSlangBinNames = ["slang", "gfx"];

                                                       var filesMissing = reqSlangBinNames.Except(
                                                                                              tuple.LibFiles.Select(path =>
                                                                                                                        path.NameWithoutExtension.TrimStart(
                                                                                                                            "lib")))
                                                                                          .ToArray();

                                                       Assert.Empty(filesMissing,
                                                                    $"Missing slang binaries: {filesMissing} in release");
                                                   })
                                                   .ToArray();

                 foreach (var pair in binaryFiles)
                 {
                     var dstFolder = OutputBinDirectory / SlangVersion / pair.RuntimeId.ToDotnetRuntimeId().Value;
                     foreach (var binFile in pair.LibFiles)
                     {
                         Log.Information("Copying slang lib {SrcBinFile} to {DestBinFile}", binFile,
                                         dstFolder / binFile.Name);

                         binFile.CopyToDirectory(dstFolder, ExistsPolicy.MergeAndOverwriteIfNewer);
                     }
                 }
             });
}