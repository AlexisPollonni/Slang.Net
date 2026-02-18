#!/usr/local/share/dotnet/dotnet run

#:sdk Cake.Sdk

#:package ConsoleAppFramework
#:package ConsoleAppFramework.Abstractions
#:package Octokit

#:project ./Shared/ShaderSlang.Net.Scripts.Shared.csproj

using ConsoleAppFramework;
using Microsoft.Extensions.Logging;
using Octokit;
using ShaderSlang.Net.Scripts.Shared;
using Shouldly;
using ProductHeaderValue = Octokit.ProductHeaderValue;

var builder = ConsoleHost.Create(args);

builder.Services.AddScoped(p => new GitHubClient(new ProductHeaderValue("ShaderSlang.Net")));

var app = builder.ToConsoleAppBuilder();

app.UseFilter<CommandTracingFilter>();

await app.RunAsync(args);

[RegisterCommands]
class RootCommand(ILogger<RootCommand> logger, GitHubClient client)
{
    /// <summary>
    /// Downloads the slang binaries from GitHub the specified version and output path.
    /// </summary>
    /// <param name="targetRids">-r, The target RIDs to include in the runtime.json file.</param>
    /// <param name="slangVersion">-v, The version of slang to download.</param>
    /// <param name="outputDir">-o, The output directory to copy the downloaded binaries.</param>
    [Command("")]
    public async Task Download(
        DotnetRuntimeId[] targetRids,
        Version slangVersion,
        [Dir] DirectoryPath? outputDir = null
    )
    {
        DirectoryPath? cache = null;

        if (GitHubActions.IsRunningOnGitHubActions)
        {
            var token = EnvironmentVariable("GITHUB_TOKEN");
            token.ShouldNotBeNullOrWhiteSpace(
                "GITHUB_TOKEN environment variable is required to download Slang binaries from GitHub releases"
            );
            client.Credentials = new(token);
            logger.LogInformation("Added github-actions token to octokit client");

            cache = GitHubActions.Environment.Home;
        }

        var release = await client.Repository.Release.Get(
            "shader-slang",
            "slang",
            "v" + slangVersion
        );

        var assetNameStart = $"slang-{slangVersion}-";
        var platformReleases = release.Assets.Where(asset =>
            asset.Name.StartsWith(assetNameStart)
            && asset.Name.EndsWith(".zip")
            && !asset.Name.Contains("debug-info")
            && !asset.Name.Contains("glibc")
        );

        static SlangRuntimeId GetRidFromAssetName(string assetName)
        {
            assetName.ShouldNotBeNullOrWhiteSpace();

            return SlangRuntimeId
                .List()
                .FirstOrDefault(id => assetName.Contains(id.Value))
                .ShouldNotBeNull($"Could not determine SlangRuntimeId from asset name {assetName}");
        }

        platformReleases
            .AsParallel()
            .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
            .Select(asset =>
                (
                    ArchivePath: GetDownloadCacheDirectory().CombineWithFilePath(asset.Name),
                    RuntimeId: GetRidFromAssetName(asset.Name).ToDotnetRuntimeId(),
                    asset.BrowserDownloadUrl
                )
            )
            .Where(tuple => targetRids.Contains(tuple.RuntimeId))
            .ForAll(tuple =>
            {
                if (FileExists(tuple.ArchivePath))
                {
                    logger.LogInformation(
                        "Slang binary are already saved to {Path}, skipping download...",
                        tuple.ArchivePath
                    );
                }
                else
                {
                    logger.LogInformation(
                        "Downloading archive from {Url} and saving to {ArchivePath}",
                        tuple.BrowserDownloadUrl,
                        tuple.ArchivePath
                    );

                    EnsureDirectoryExists(tuple.ArchivePath.GetDirectory());
                    DownloadFile(tuple.BrowserDownloadUrl, tuple.ArchivePath);
                }

                var runtimeId = tuple.RuntimeId;
                var assetFolderPath = GetReleaseFolderForRid(runtimeId);

                if (DirectoryExists(assetFolderPath))
                    logger.LogInformation(
                        "{AssetPath} already exists, skipping archive unzipping...",
                        assetFolderPath
                    );
                else
                {
                    logger.LogInformation(
                        "Unzipping {ArchivePath} to directory {AssetPath}",
                        tuple.ArchivePath,
                        assetFolderPath
                    );
                    Unzip(tuple.ArchivePath, assetFolderPath);
                }

                var libFiles = GetBinariesForPlatform(runtimeId).ToArray();

                logger.LogInformation(
                    "Found in slang release {Version}-{RuntimeId} shared library file {Files}",
                    slangVersion,
                    tuple.RuntimeId,
                    libFiles.Select(p => p.GetFilename())
                );

                string[] reqSlangBinNames = ["slang", "gfx"];

                var filesMissing = reqSlangBinNames
                    .Except(
                        libFiles.Select(path =>
                        {
                            var filename = path.GetFilenameWithoutExtension().FullPath;
                            return filename.StartsWith("lib") ? filename[3..] : filename;
                        })
                    )
                    .ToArray();

                filesMissing.ShouldBeEmpty(
                    $"Missing slang binaries: {filesMissing} in release {slangVersion}"
                );

                if (outputDir is null)
                    return;

                EnsureDirectoryExists(outputDir);

                logger.LogInformation(
                    "Copying binaries to output directory {OutputDir}",
                    outputDir
                );
                CopyFiles(libFiles, outputDir);
            });

        IEnumerable<FilePath> GetBinariesForPlatform(DotnetRuntimeId rid)
        {
            var binDir = GetBinFolderForRid(rid);

            DirectoryExists(binDir)
                .ShouldBeTrue($"Expected bin directory {binDir} to exist for RID {rid}");

            return GetFiles($"{binDir}/*")
                .Where(f =>
                {
                    var ext = f.GetExtension();
                    return ext.EndsWith(".dll")
                        || ext.EndsWith(".dylib")
                        || f.GetFilename().ToString().Contains(".so"); // Recently linux releases were renamed to add the version in the extension, e.g. .so.2.34, so we check if the extension contains .so instead of checking for an exact match
                });
        }

        DirectoryPath GetReleaseFolderForRid(DotnetRuntimeId rid) =>
            GetDownloadCacheDirectory().Combine($"slang-{slangVersion}-{rid.Value}");

        DirectoryPath GetBinFolderForRid(DotnetRuntimeId rid) =>
            GetReleaseFolderForRid(rid)
                .Combine(
                    rid == DotnetRuntimeId.Win64 || rid == DotnetRuntimeId.WinArm64 ? "bin" : "lib"
                );
    }

    public void Clean()
    {
        var cacheDir = GetDownloadCacheDirectory();
        EnsureDirectoryDoesNotExist(cacheDir);
        logger.LogInformation("Cleaned download cache directory {CacheDir}", cacheDir);
    }

    private static DirectoryPath GetDownloadCacheDirectory()
    {
        DirectoryPath? cache = GitHubActions?.Environment?.Home;

        cache ??= Context.Environment.GetSpecialPath(SpecialPath.LocalTemp).ShouldNotBeNull();

        return cache.Combine(".slangdlcache");
    }
}
