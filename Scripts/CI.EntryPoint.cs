#!/usr/local/share/dotnet/dotnet run

#:sdk Cake.Sdk

#:package Cake.FileHelpers

#:project ./Shared/ShaderSlang.Net.Scripts.Shared.csproj

using ShaderSlang.Net.Scripts.Shared;
using Shouldly;

var target = Argument("target", "Pack");
var configuration = Argument("configuration", "Release");
var IsNightly = Argument("is-nightly", false);

var findRes = Context
    .FileSystem.GetDirectory(Context.Environment.WorkingDirectory)
    .GetFiles("*.slnx", SearchScope.Recursive);

var slnFile = findRes.Single();

Task("Restore")
    .Does(() =>
    {
        DotNetRestore(slnFile.Path.FullPath);
    });

Task("Format")
    .IsDependentOn("Restore")
    .ContinueOnError()
    .Does(() =>
    {
        DotNetTool("restore");
        DotNetTool(
            "csharpier",
            new()
            {
                DiagnosticOutput = true,
                ArgumentCustomization = args => args.Append("check").Append("."),
            }
        );
    });

Task("Clean")
    .IsDependentOn("Restore")
    .Does(() =>
    {
        DotNetClean(slnFile.Path.FullPath, new() { Configuration = configuration });
    })
    .ContinueOnError();

Task("Build")
    .IsDependentOn("Restore")
    .Does(async () =>
    {
        var isGitHubDebug =
            GitHubActions.IsRunningOnGitHubActions
            && (
                EnvironmentVariable("ACTIONS_RUNNER_DEBUG", false)
                || EnvironmentVariable("ACTIONS_STEP_DEBUG", false)
            );

        var isDebugMode = Context.Log.Verbosity >= Verbosity.Diagnostic || isGitHubDebug;

        var binlogPath = Context.Environment.WorkingDirectory.Combine("artifacts/build.binlog");

        var msbuildSettings = new DotNetMSBuildSettings { ContinuousIntegrationBuild = true };
        msbuildSettings.Properties.Add("CSharpier_Bypass", ["true"]);

        if (isDebugMode)
        {
            msbuildSettings.BinaryLogger = new MSBuildBinaryLoggerSettings
            {
                Enabled = true,
                FileName = binlogPath.FullPath,
            };
        }

        DotNetBuild(
            slnFile.Path.FullPath,
            new()
            {
                Configuration = configuration,
                NoRestore = true,
                MSBuildSettings = msbuildSettings,
            }
        );

        if (isDebugMode && GitHubActions.IsRunningOnGitHubActions)
        {
            await GitHubActions.Commands.UploadArtifact(binlogPath, "build-binlog");
        }
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() =>
    {
        DotNetTest(
            slnFile.Path.FullPath,
            new()
            {
                Configuration = configuration,
                NoRestore = true,
                NoBuild = true,
            }
        );
    });

Task("Pack")
    .IsDependentOn("Build")
    .Does(() =>
    {
        DotNetPack(
            slnFile.Path.FullPath,
            new()
            {
                Configuration = configuration,
                NoRestore = true,
                NoBuild = true,
            }
        );
    });

Task("PublishToGithub")
    .IsDependentOn("Pack")
    .WithCriteria(() => IsNightly && GitHubActions.IsRunningOnGitHubActions)
    .Does(() =>
    {
        var artifacts = Context
            .FileSystem.GetDirectory(Context.Environment.WorkingDirectory)
            .GetFiles("*.nupkg", SearchScope.Recursive)
            .ToList();

        artifacts.ShouldNotBeEmpty("No artifacts found to publish");

        foreach (var artifact in artifacts)
        {
            Information("Publishing {0}", artifact.Path);
            DotNetNuGetPush(
                artifact.Path,
                new()
                {
                    Source = "https://nuget.pkg.github.com/AlexisPollonni/index.json",
                    ApiKey = GitHubActions.Environment.Runtime.Token,
                    SkipDuplicate = true,
                }
            );
        }
    });

RunTarget(target);

// Register services with script host integration
static partial class Program
{
    static partial void RegisterServices(IServiceCollection services)
    {
        services.AddSharedScriptServices();
    }
}
