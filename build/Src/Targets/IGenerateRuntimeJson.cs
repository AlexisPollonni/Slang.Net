using NuGet.RuntimeModel;
using NuGet.Versioning;
using Nuke.Common;
using Nuke.Common.IO;
using Serilog;
using SlangNet.Build.Tools;

namespace SlangNet.Build.Targets;

interface IGenerateRuntimeJson : IDownloadSlangBinaries
{
    [Parameter]
    Version VersionPrefix => TryGetValue(() => VersionPrefix)!;

    [Parameter]
    string? VersionSuffix => TryGetValue(() => VersionSuffix);

    [Parameter]
    string BasePackageName => TryGetValue(() => BasePackageName)!;

    [Parameter]
    AbsolutePath RuntimeJsonOutputDirectory => TryGetValue(() => RuntimeJsonOutputDirectory)!;

    Target GenerateRuntimeJson =>
        d => d
             .Unlisted()
             .Requires(() => TargetRids)
             .Requires(() => VersionPrefix)
             .Requires(() => BasePackageName)
             .Requires(() => RuntimeJsonOutputDirectory)
             .DependsOn(DownloadSlangBinaries) // required to ensure necessary binaries for packing are downloaded for each RIDs
             .Executes(() =>
             {
                 var packageVersion = new NuGetVersion(VersionPrefix, VersionSuffix);

                 var rids = TargetRids.Except([DotnetRuntimeId.Any]).ToArray();

                 var anyDesc = CreateRuntimeDescription(DotnetRuntimeId.Any, rids, packageVersion);
                 var descriptions = rids.Select(rid => CreateRuntimeDescription(rid, [rid], packageVersion))
                                        .Append(anyDesc);

                 var runtimeJsonPath = WriteRuntimeJson(RuntimeJsonOutputDirectory, descriptions);

                 Log.Information("Generated runtime.json at {Path}", runtimeJsonPath);
             });

    static AbsolutePath WriteRuntimeJson(AbsolutePath outputDirectory, IEnumerable<RuntimeDescription> descriptions)
    {
        var jsonFilePath = outputDirectory.CreateDirectory() / RuntimeGraph.RuntimeGraphFileName;

        var graph = new RuntimeGraph(descriptions);

        JsonRuntimeFormat.WriteRuntimeGraph(jsonFilePath, graph);

        return jsonFilePath.ExistingFile().NotNull();
    }

    RuntimeDescription CreateRuntimeDescription(DotnetRuntimeId targetRid,
                                                IEnumerable<DotnetRuntimeId> dependencyRids,
                                                NuGetVersion packageVersion)
    {
        var versionRange = new VersionRange(minVersion: packageVersion,
                                            maxVersion: packageVersion,
                                            includeMaxVersion: true);

        var dependencyIds = dependencyRids.Select(GetNativePackageIdName);

        var dependencies = dependencyIds.Select(id => new RuntimePackageDependency(id, versionRange));

        var dependencySet = new RuntimeDependencySet(GetNativePackageIdName(), dependencies);
        return new(targetRid.Value, [dependencySet]);
    }

    private string GetNativePackageIdName(DotnetRuntimeId? runtime = null) =>
        runtime is null ? BasePackageName : $"{BasePackageName}.{runtime.Value}";
}