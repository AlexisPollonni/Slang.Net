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
using Nuke.Common.Tools.NuGet;
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
             .Executes(() =>
             {
                 var localFeedDirectory = PackageOutputDirectory / "localFeed";

                 localFeedDirectory.CreateOrCleanDirectory();
                 
                 NuGetTasks.NuGet($"init {PackageOutputDirectory} {localFeedDirectory}");
                 NuGetTasks.NuGetSourcesList();
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

                 var readmeFile = RootDirectory / GetRuntimePackageId(null) / "NativePackageReadme.md";
                 var packages = rids.Select(id => new PackageInfo(SlangRepository,
                                                                  id,
                                                                  NativePackageVersion,
                                                                  readmeFile,
                                                                  (OutputBinDirectory / SlangVersion / id.Value).GlobFiles(
                                                                      "*.dll", "*.dylib", "*.so")))
                                    .ToArray();

                 foreach (var packageInfo in packages) packageInfo.WritePackage(PackageOutputDirectory);

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

                 metaPackage.WritePackage(PackageOutputDirectory);
             });

    private static string GetRuntimePackageId(DotnetRuntimeId? identifier) =>
        identifier is null ? "SlangNet.Native" : $"SlangNet.Native.Runtime.{identifier}";

    record RuntimeInfo(IEnumerable<DotnetRuntimeId> RuntimeIdentifiers, NuGetVersion NativePackageVersion)
    {
        public AbsolutePath WriteRuntimeJson(AbsolutePath outputDirectory)
        {
            var jsonFilePath = outputDirectory.CreateDirectory() / RuntimeGraph.RuntimeGraphFileName;

            var descriptions = RuntimeIdentifiers.Select(rid =>
            {
                var packageDependency
                    = new RuntimePackageDependency(GetRuntimePackageId(rid),
                                                   new(minVersion: NativePackageVersion, maxVersion: NativePackageVersion, includeMaxVersion:true));
                var runtimeDependency = new RuntimeDependencySet("SlangNet.Native", [packageDependency]);
                return new RuntimeDescription(rid, [runtimeDependency]);
            });

            var graph = new RuntimeGraph(descriptions);

            JsonRuntimeFormat.WriteRuntimeGraph(jsonFilePath, graph);

            return jsonFilePath.ExistingFile().NotNull();
        }
    }

    record PackageInfo(
        GitRepository SlangRepo,
        DotnetRuntimeId? RuntimeId,
        NuGetVersion PackageVersion,
        AbsolutePath Readme,
        IEnumerable<AbsolutePath> NativeDepFiles,
        IEnumerable<ManifestFile>? AdditionalFiles = null)
    {
        public void WritePackage(AbsolutePath outputDirectory)
        {
            var packageId = GetRuntimePackageId(RuntimeId);
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
                DependencyGroups = { new(FrameworkConstants.CommonFrameworks.NetStandard20, []) }
            };

            builder.Authors.AddRange(["Helco", "AlexisPollonni"]);
            builder.Owners.Add("Helco");
            builder.Tags.AddRange(["slang", "shader", "C#", "csharp"]);

            builder.PopulateFiles(outputDirectory, manifestFiles);

            using var filestream = new FileStream(outFilePath, FileMode.Create);
            builder.Save(filestream);
        }
    }
}