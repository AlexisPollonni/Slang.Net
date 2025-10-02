using NuGet.Frameworks;
using NuGet.Packaging;
using NuGet.Packaging.Licenses;
using NuGet.RuntimeModel;
using NuGet.Versioning;
using Nuke.Common;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using Serilog;
using SlangNet.Build.Tools;

namespace SlangNet.Build.Targets;

interface IPackNative : IDownloadSlangBinaries
{
    [Parameter]
    NuGetVersion NativePackageVersion => TryGetValue(() => NativePackageVersion) ?? new(SlangVersion);

    [Parameter]
    AbsolutePath PackageOutputDirectory => TryGetValue(() => PackageOutputDirectory) ?? TemporaryDirectory / "packages";

    AbsolutePath LocalPackageCacheDirectory => TemporaryDirectory / "PackageCache";
    AbsolutePath LocalFeedDirectory => LocalPackageCacheDirectory / ".localFeed";

    GitRepository SlangRepository => GitRepository.FromLocalDirectory(RootDirectory / "slang");

    Target CleanPackageCache =>
        d => d
             .Unlisted()
             .ProceedAfterFailure()
             .DependsOn(CleanGlobalCache)
             .Executes(() =>
             {
                 Log.Information("Cleaning local feed directory {LocalFeedDir}", LocalFeedDirectory);
                 LocalFeedDirectory.CreateOrCleanDirectory();

                 Log.Information("Cleaning package output directory {PackageDirectory}", PackageOutputDirectory);
                 PackageOutputDirectory.CreateOrCleanDirectory();

                 Log.Information("Cleaning NuGet package cache directory in {LocalPackageCacheDir}",
                                 LocalPackageCacheDirectory);
                 LocalPackageCacheDirectory
                     .GetDirectories("slangnet*")
                     .Where(path => path != LocalFeedDirectory)
                     .ForEachLazy(path => Log.Debug("Deleting cache directory {PackageCacheDir}",
                                                    RootDirectory.GetRelativePathTo(path)))
                     .DeleteDirectories();
             });

    Target CleanGlobalCache =>
        d => d
            .Executes(() =>
            {
                var cachedPackagesDirectories = LocalPackageCacheDirectory.GlobDirectories($"{GetNativePackageId()}*");

                Log.Information("Deleting Nuget cache directories {CacheDirectories}", cachedPackagesDirectories);

                cachedPackagesDirectories.DeleteDirectories();
            });

    Target InitLocalFeed =>
        d => d
             .Unlisted()
             .DependsOn<IPackNative>(b => b.PackNative)
             .Triggers<Build>(b => b.Restore)
             .Executes(() =>
             {
                 LocalFeedDirectory.CreateOrCleanDirectory();

                 // Copy packages to the feed directory
                 PackageOutputDirectory.GlobFiles("*.nupkg")
                                       .ForEach(pkg => pkg.Copy(LocalFeedDirectory / pkg.Name));

                 Log.Information("Adding local feed {LocalFeedDir} to nuget sources", LocalFeedDirectory);


                 DotNetTasks.DotNetNuGetAddSource(opts => opts.SetSource(LocalFeedDirectory)
                                                              .SetName("LocalFeed")
                                                              .DisableProcessExitHandling());
                 DotNetTasks.DotNet("nuget list source");
             });

    Target PackNative =>
        d => d
             .DependsOn<IDownloadSlangBinaries>(t => t.DownloadSlangBinaries)
             .Produces(PackageOutputDirectory / "**/*.nupkg")
             .Executes(() =>
             {
                 var rids = TargetRids.ToArray();

                 var runtimeInfo = new RuntimeInfo(rids, NativePackageVersion);

                 var runtimeJson = runtimeInfo.WriteRuntimeJson(TemporaryDirectory);

                 var readmeFile = RootDirectory / GetNativePackageId() / "NativePackageReadme.md";
                 var packages = rids.Select(id => new PackageInfo(SlangRepository,
                                                                  id,
                                                                  NativePackageVersion,
                                                                  readmeFile,
                                                                  GetBinariesForPlatform(id)))
                                    .ToList();

                 var metaPackage = new PackageInfo(SlangRepository,
                                                   null,
                                                   NativePackageVersion,
                                                   readmeFile,
                                                   [],
                                                   [
                                                       new()
                                                       {
                                                           Source = runtimeJson,
                                                           Target = runtimeJson.Name
                                                       }
                                                   ]);

                 packages.Add(metaPackage);
                 packages.AsParallel()
                         .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                         .ForAll(info => info.WritePackage(PackageOutputDirectory));
             });

    private static string GetNativePackageId(DotnetRuntimeId? runtime = null) =>
        runtime is null ? "SlangNet.Native" : $"SlangNet.Native.Runtime.{runtime}";

    private record RuntimeInfo(IEnumerable<DotnetRuntimeId> RuntimeIdentifiers, NuGetVersion NativePackageVersion)
    {
        public AbsolutePath WriteRuntimeJson(AbsolutePath outputDirectory)
        {
            var jsonFilePath = outputDirectory.CreateDirectory() / RuntimeGraph.RuntimeGraphFileName;

            var anyDesc = CreateRuntimeDescription(DotnetRuntimeId.Any, RuntimeIdentifiers);
            var descriptions = RuntimeIdentifiers.Select(rid => CreateRuntimeDescription(rid))
                                                 .Append(anyDesc);

            var graph = new RuntimeGraph(descriptions);

            JsonRuntimeFormat.WriteRuntimeGraph(jsonFilePath, graph);

            return jsonFilePath.ExistingFile().NotNull();
        }

        RuntimeDescription CreateRuntimeDescription(DotnetRuntimeId targetRid,
                                                    IEnumerable<DotnetRuntimeId>? dependencyRids = null)
        {
            var versionRange = new VersionRange(minVersion: NativePackageVersion,
                                                maxVersion: NativePackageVersion,
                                                includeMaxVersion: true);
            var depRids = dependencyRids ?? [targetRid];

            var dependencies = depRids.Select(id => new RuntimePackageDependency(GetNativePackageId(id), versionRange));
            var dependencySet = new RuntimeDependencySet(GetNativePackageId(), dependencies);
            return new(targetRid, [dependencySet]);
        }
    }

    private record PackageInfo(
        GitRepository SlangRepo,
        DotnetRuntimeId? RuntimeId,
        NuGetVersion PackageVersion,
        AbsolutePath Readme,
        IEnumerable<AbsolutePath> NativeDepFiles,
        IEnumerable<ManifestFile>? AdditionalFiles = null)
    {
        public void WritePackage(AbsolutePath outputDirectory)
        {
            var packageId = GetNativePackageId(RuntimeId);
            Log.Information("Creating .nupkg manifest for native package {PackageId}", packageId);

            var outFilePath = outputDirectory.CreateDirectory() / $"{packageId}.nupkg";

            var manifestFiles = NativeDepFiles.Select(p => new ManifestFile
                                              {
                                                  Source = p,
                                                  Target = Path.Combine("runtimes", RuntimeId, "native",
                                                                        p.ExistingFile().NotNull().Name)
                                              })
                                              .ToList();

            manifestFiles.Add(new() { Source = Readme, Target = "readme.md" });
            if (AdditionalFiles is not null) manifestFiles.AddRange(AdditionalFiles);

            var builder = new PackageBuilder(true, new NugetLogger())
            {
                MinClientVersion = new(2, 12),
                Id = packageId,
                Title = RuntimeId is null
                    ? "SlangNet - Native binaries meta package"
                    : $"SlangNet - Native binaries for {RuntimeId.Value} platform",
                Description = RuntimeId is null
                    ? """
                      This is a meta-package containing native binaries for the SlangNet package, a .NET bindings library for shader-slang.
                      Dotnet should resolve the correct specific binaries for your platform, in case of issues make sure to specify a runtime identifier in your project file.
                      For SlangNet see https://github.com/Helco/SlangNet
                      For shader-slang see https://github.com/shader-slang/slang
                      """
                    : $"""
                       These are the native binaries of a single platform ({RuntimeId.Value}) for the SlangNet package, a .NET bindings library for shader-slang.
                       For SlangNet see https://github.com/Helco/SlangNet
                       For shader-slang see https://github.com/shader-slang/slang
                       """,
                Readme = "readme.md",
                Version = PackageVersion,
                LicenseMetadata = new(LicenseType.Expression, "MIT", NuGetLicenseExpression.Parse("MIT"), [],
                                      LicenseMetadata.EmptyVersion),
                Repository = new("git", "https://github.com/shader-slang/slang",
                                 SlangRepo.RemoteBranch,
                                 SlangRepo.Commit),
                DependencyGroups = { new(FrameworkConstants.CommonFrameworks.NetStandard20, []) },
            };

            builder.Authors.AddRange(["Helco", "AlexisPollonni"]);
            builder.Owners.Add("Helco");
            builder.Tags.AddRange(["slang", "shader", "C#", "csharp", "native"]);

            builder.PopulateFiles(outputDirectory, manifestFiles);

            using var filestream = new FileStream(outFilePath, FileMode.Create);
            builder.Save(filestream);
        }
    }
}