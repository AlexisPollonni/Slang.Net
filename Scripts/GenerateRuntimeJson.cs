#!/usr/local/share/dotnet/dotnet run

#:sdk Cake.Sdk

#:package ConsoleAppFramework
#:package ConsoleAppFramework.Abstractions
#:package NuGet.Packaging
#:package NuGet.Versioning

#:project ./Shared/Slang.Net.Scripts.Shared.csproj

using ConsoleAppFramework;
using Microsoft.Extensions.Logging;
using NuGet.RuntimeModel;
using NuGet.Versioning;
using Shouldly;
using Slang.Net.Scripts.Shared;

var app = ConsoleHost.Create(args).ToConsoleAppBuilder();

app.UseFilter<CommandTracingFilter>();

await app.RunAsync(args);

[RegisterCommands]
class RootCommand(ILogger<RootCommand> logger)
{
    /// <summary>
    /// Generates a runtime.json file for the specified version and output path.
    /// </summary>
    /// <param name="outputJsonDirectory">-o, The output directory for the generated runtime.json file.</param>
    /// <param name="versionPrefix">-vp, The version prefix (e.g. 1.0.0).</param>
    /// <param name="basePackageName">-n, The base package name (e.g. Slang.Net.Runtime).</param>
    /// <param name="targetRids">-r, The target RIDs to include in the runtime.json file.</param>
    /// <param name="versionSuffix">-vs, The version suffix in case of a pre-release (e.g. beta1).</param>
    [Command("")]
    public void Run(
        [Dir] DirectoryPath outputJsonDirectory,
        Version versionPrefix,
        string basePackageName,
        DotnetRuntimeId[] targetRids,
        string? versionSuffix = null
    )
    {
        var packageVersion = new NuGetVersion(versionPrefix, versionSuffix);

        var rids = targetRids.Except([DotnetRuntimeId.Any]).ToArray();

        var anyDesc = CreateRuntimeDescription(DotnetRuntimeId.Any, rids, packageVersion);
        var descriptions = rids.Select(rid => CreateRuntimeDescription(rid, [rid], packageVersion))
            .Append(anyDesc);

        var runtimeJsonPath = WriteRuntimeJson(outputJsonDirectory, descriptions);

        logger.LogInformation("Generated runtime.json at {Path}", runtimeJsonPath);

        static FilePath WriteRuntimeJson(
            DirectoryPath outputDirectory,
            IEnumerable<RuntimeDescription> descriptions
        )
        {
            EnsureDirectoryExists(outputDirectory);
            var jsonFilePath = MakeAbsolute(
                outputDirectory.CombineWithFilePath(RuntimeGraph.RuntimeGraphFileName)
            );

            var graph = new RuntimeGraph(descriptions);

            JsonRuntimeFormat.WriteRuntimeGraph(jsonFilePath.FullPath, graph);

            FileExists(jsonFilePath)
                .ShouldBeTrue($"Expected runtime.json to be created at {jsonFilePath}");
            return jsonFilePath;
        }

        RuntimeDescription CreateRuntimeDescription(
            DotnetRuntimeId targetRid,
            IEnumerable<DotnetRuntimeId> dependencyRids,
            NuGetVersion packageVersion
        )
        {
            var versionRange = new VersionRange(
                minVersion: packageVersion,
                maxVersion: packageVersion,
                includeMaxVersion: true
            );

            var dependencyIds = dependencyRids.Select(GetNativePackageIdName);

            var dependencies = dependencyIds.Select(id => new RuntimePackageDependency(
                id,
                versionRange
            ));

            var dependencySet = new RuntimeDependencySet(GetNativePackageIdName(), dependencies);
            return new(targetRid.Value, [dependencySet]);
        }

        string GetNativePackageIdName(DotnetRuntimeId? runtime = null) =>
            runtime is null ? basePackageName : $"{basePackageName}.{runtime.Value}";
    }
}
