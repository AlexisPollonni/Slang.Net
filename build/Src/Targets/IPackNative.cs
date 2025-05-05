using System.Collections.Generic;
using System.IO;
using System.Linq;
using NuGet.Frameworks;
using NuGet.Packaging;
using NuGet.Packaging.Licenses;
using NuGet.RuntimeModel;
using NuGet.Versioning;
using Nuke.Common;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.NuGet;
using Nuke.Common.Utilities;
using Serilog;
using SlangNet.Build.Tools;

namespace SlangNet.Build.Targets;

public interface IPackNative : IDownloadSlangBinaries
{
    [Parameter]
    NuGetVersion NativePackageVersion => TryGetValue(() => NativePackageVersion) ?? new(SlangVersion);

    [Parameter]
    AbsolutePath PackageOutputDirectory => TryGetValue(() => PackageOutputDirectory) ?? TemporaryDirectory / "packages";

    GitRepository SlangRepository => GitRepository.FromLocalDirectory(RootDirectory / "slang");

    Target InitLocalFeed =>
        d => d
             .OnlyWhenStatic(() => IsLocalBuild)
             .DependsOn<IPackNative>(b => b.PackNative)
             .Triggers<global::Build>(b => b.Restore)
             .Executes(() =>
             {
                 var localFeedDirectory = PackageOutputDirectory / "localFeed";

                 localFeedDirectory.CreateOrCleanDirectory();

                 NuGetTasks.NuGet($"init {PackageOutputDirectory} {localFeedDirectory}");
                 NuGetTasks.NuGetSourcesList();

                 //Delete the Nuget global cache entry, so on the next restore the correct package is chosen
                 var output = NuGetTasks.NuGet("locals global-packages -list").EnsureOnlyStd().StdToText();
                 var globalPackagesDir = AbsolutePath.Create(output.TrimStart("global-packages: ")).ExistingDirectory();

                 var cacheToDelete = globalPackagesDir.GlobDirectories($"{GetNativePackageId()}*");
                 if (cacheToDelete.Count > 0)
                 {
                     cacheToDelete.DeleteDirectories();
                     Log.Information("Deleted NuGet cache directories {CacheDirectories}", cacheToDelete);
                 }
             });

    Target PackNative =>
        d => d
             .Consumes<IDownloadSlangBinaries>(t => t.DownloadSlangBinaries)
             .DependsOn<IDownloadSlangBinaries>(t => t.DownloadSlangBinaries)
             .Produces(PackageOutputDirectory / "**/*.nupkg")
             .Executes(() =>
             {
                 var rids = (OutputBinDirectory / SlangVersion).GetDirectories()
                                                               .Select(path => DotnetRuntimeId.FromValue(path.Name))
                                                               .ToArray();

                 var runtimeInfo = new RuntimeInfo(rids, NativePackageVersion);

                 var runtimeJson = runtimeInfo.WriteRuntimeJson(TemporaryDirectory);

                 var readmeFile = RootDirectory / GetNativePackageId() / "NativePackageReadme.md";
                 var packages = rids.Select(id => new PackageInfo(SlangRepository,
                                                                  id,
                                                                  NativePackageVersion,
                                                                  readmeFile,
                                                                  (OutputBinDirectory / SlangVersion / id.Value).GlobFiles(
                                                                      "*.dll", "*.dylib", "*.so")))
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
                         .WithDegreeOfParallelism(packages.Count)
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