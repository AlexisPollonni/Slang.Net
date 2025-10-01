using Microsoft.Build.Evaluation;
using Nuke.Common;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using SlangNet.Build.Targets;

namespace SlangNet.Build;

[GitHubActions("pack", GitHubActionsImage.WindowsLatest,
               On = [GitHubActionsTrigger.WorkflowDispatch],
               InvokedTargets = ["Pack"],
               EnableGitHubToken = true)]
[GitHubActions("continuous", 
               GitHubActionsImage.WindowsLatest, 
               GitHubActionsImage.MacOsLatest,
               GitHubActionsImage.UbuntuLatest,
               On = [GitHubActionsTrigger.Push],
               InvokedTargets = ["Compile", "RunTests"],
               PublishArtifacts = false,
               EnableGitHubToken = true)]
class Build : NukeBuild, IGenerateSlangBindings, IPackNative, IConfigurationProvider
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode
    public static int Main() =>
        Execute<Build>();

    //TODO: Change when Nuke supports .snlx : https://github.com/nuke-build/nuke/issues/1520
    [Solution("SlangNet.slnx", GenerateProjects = true)]
    public Solution? Solution { get; set; }

    private IConfigurationProvider ConfigProvider => this;

    Version GetRootProjectAndParseVersion()
    {
        
        var props = ProjectCollection.GlobalProjectCollection.LoadProject(RootDirectory / "Directory.Build.props");

        return new(props.GetPropertyValue(nameof(SlangVersion)).NotNullOrWhiteSpace());
    }
    
    [Parameter]
    public Version SlangVersion => GetRootProjectAndParseVersion();

    internal Target Restore =>
        d => d
             .DependsOn<IPackNative>(d => d.InitLocalFeed)
             .Executes(() =>
             {
                 DotNetTasks.DotNetRestore(s => s.SetProjectFile(Solution));
             });

    Target Clean =>
        d => d
             // Clean the temp directories after dotnet clean to avoid missing files
             .Triggers<IPackNative>(n => n.CleanDownloadDir, n => n.CleanGlobalCache, n => n.CleanPackageCache)
             .Executes(() => DotNetTasks.DotNetClean(s => s
                                                          .SetConfiguration(ConfigProvider.Config)
                                                          .SetProject(Solution)))
             .ProceedAfterFailure();

    Target Compile =>
        d => d
             .DependsOn(Restore)
             .Executes(() =>
             {
                 DotNetTasks.DotNetBuild(s =>
                                             s.SetNoRestore(true)
                                              .SetConfiguration(ConfigProvider.Config)
                                              .SetProjectFile(Solution));
             });

    Target RunTests =>
        d => d
             .DependsOn(Compile)
             .Executes(() => DotNetTasks.DotNetTest(c => c
                                                         .SetNoRestore(true)
                                                         .SetNoBuild(true)
                                                         .SetConfiguration(ConfigProvider.Config)
                                                         .SetProjectFile(Solution)));

    Target Pack =>
        d => d
             .DependsOn(Compile)
             .Produces(((IPackNative)this).PackageOutputDirectory / "*.nupkg")
             .Executes(() =>
             {
                 DotNetTasks.DotNetPack(c => c
                                             .SetNoRestore(true)
                                             .SetNoBuild(true)
                                             .SetConfiguration(ConfigProvider.Config)
                                             .SetOutputDirectory(((IPackNative)this).PackageOutputDirectory)
                                             .SetProject(Solution.NotNull()!.Path.NotNull().Parent));
             });
}