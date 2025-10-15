#!/usr/local/share/dotnet/dotnet run

#:sdk Cake.Sdk

#:package Cake.FileHelpers

#:project ./Shared/ShaderSlang.Net.Scripts.Shared.csproj

using System.Runtime.InteropServices;
using ShaderSlang.Net.Scripts.Shared;
using Shouldly;

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var githubToken = EnvironmentVariable("GITHUB_TOKEN", "");

var findRes = Context
    .FileSystem.GetDirectory(Context.Environment.WorkingDirectory)
    .GetFiles("*.slnx", SearchScope.Recursive);

var slnFile = findRes.Single();

DotNetMSBuildSettings CreateMSBuildSettings(string? binlogName = null)
{
    var settings = new DotNetMSBuildSettings { ContinuousIntegrationBuild = true };
    settings.Properties.Add("CSharpier_Bypass", ["true"]);

    if (
        (GitHubActions.IsRunningOnGitHubActions || Context.Log.Verbosity >= Verbosity.Diagnostic)
        && !string.IsNullOrEmpty(binlogName)
    )
    {
        var binlogPath = Context.Environment.WorkingDirectory.Combine(
            $"artifacts/{binlogName}.binlog"
        );
        settings.BinaryLogger = new MSBuildBinaryLoggerSettings
        {
            Enabled = true,
            FileName = binlogPath.FullPath,
            Imports = MSBuildBinaryLoggerImports.Embed,
        };
    }

    return settings;
}

async Task UploadBinlogIfExists(string binlogName)
{
    if (GitHubActions.IsRunningOnGitHubActions)
    {
        var binlogPath = new FilePath(
            Context.Environment.WorkingDirectory.Combine($"artifacts/{binlogName}.binlog").FullPath
        );

        if (FileExists(binlogPath))
        {
            await GitHubActions.Commands.UploadArtifact(
                binlogPath,
                $"{RuntimeInformation.RuntimeIdentifier}-msbuild-failed-{binlogName}"
            );
            return;
        }

        Information("No binlog found at {0}", binlogPath.FullPath);
    }
}

async Task RunAndUploadBinlogOnException(Action action, string binlogName)
{
    try
    {
        action();
    }
    catch
    {
        await UploadBinlogIfExists(binlogName);
        throw;
    }
}

Task("Default").IsDependentOn("PublishToGithub");

Task("Restore")
    .Does(async () =>
    {
        Command(
            ["dotnet", "dotnet.exe"],
            new ProcessArgumentBuilder().Append("tool").Append("restore")
        );

        await RunAndUploadBinlogOnException(
            () =>
            {
                DotNetRestore(
                    slnFile.Path.FullPath,
                    new() { MSBuildSettings = CreateMSBuildSettings("restore") }
                );
            },
            "restore"
        );
    });

Task("Format")
    .IsDependentOn("Restore")
    .ContinueOnError()
    .Does(() =>
    {
        ProcessArgumentBuilder ArgsCustom(ProcessArgumentBuilder args)
        {
            if (GitHubActions.IsRunningOnGitHubActions)
            {
                return args.Append("check").Append(".");
            }
            else
            {
                return args.Append("format").Append(".");
            }
        }

        DotNetTool("csharpier", new() { ArgumentCustomization = ArgsCustom });
    });

Task("Clean")
    .IsDependentOn("Restore")
    .Does(async () =>
    {
        await RunAndUploadBinlogOnException(
            () =>
            {
                DotNetClean(
                    slnFile.Path.FullPath,
                    new()
                    {
                        Configuration = configuration,
                        MSBuildSettings = CreateMSBuildSettings("clean"),
                    }
                );
            },
            "clean"
        );
    })
    .ContinueOnError();

Task("Build")
    .IsDependentOn("Format")
    .IsDependentOn("Restore")
    .Does(async () =>
    {
        await RunAndUploadBinlogOnException(
            () =>
            {
                DotNetBuild(
                    slnFile.Path.FullPath,
                    new()
                    {
                        Configuration = configuration,
                        NoRestore = true,
                        MSBuildSettings = CreateMSBuildSettings("build"),
                    }
                );
            },
            "build"
        );
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(async () =>
    {
        await RunAndUploadBinlogOnException(
            () =>
            {
                DotNetTest(
                    slnFile.Path.FullPath,
                    new()
                    {
                        Configuration = configuration,
                        NoRestore = true,
                        NoBuild = true,
                        MSBuildSettings = CreateMSBuildSettings("test"),
                    }
                );
            },
            "test"
        );
    });

Task("Pack")
    .IsDependentOn("Build")
    .Does(async () =>
    {
        await RunAndUploadBinlogOnException(
            () =>
            {
                DotNetPack(
                    slnFile.Path.FullPath,
                    new()
                    {
                        Configuration = configuration,
                        NoRestore = true,
                        NoBuild = true,
                        MSBuildSettings = CreateMSBuildSettings("pack"),
                    }
                );
            },
            "pack"
        );
    });

Task("PublishToGithub")
    .IsDependentOn("Pack")
    .ContinueOnError()
    .WithCriteria(() =>
        GitHubActions.IsRunningOnGitHubActions
        && GitHubActions.Environment.Workflow.RefName == "master"
        && DotnetRuntimeId.Current == DotnetRuntimeId.Win64
    )
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
                    ApiKey = githubToken,
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
