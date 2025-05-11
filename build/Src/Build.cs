using Nuke.Common;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using SlangNet.Build.Targets;

namespace SlangNet.Build;

[GitHubActions("pack", GitHubActionsImage.WindowsLatest, 
               On = [GitHubActionsTrigger.WorkflowDispatch], 
               InvokedTargets = ["Pack"])]
class Build : NukeBuild, IGenerateSlangBindings, IPackNative, IConfigurationProvider
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode
    public static int Main() =>
        Execute<Build>();

    [Solution(GenerateProjects = true)]
    public Solution? Solution { get; set; }

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
                                                          .SetConfiguration(((IConfigurationProvider)this).Config)
                                                          .SetProject(Solution)))
             .ProceedAfterFailure();

    Target Compile =>
        d => d
             .DependsOn(Restore)
             .Executes(() =>
             {
                 DotNetTasks.DotNetBuild(s =>
                                             s.SetNoRestore(true)
                                              .SetConfiguration(((IConfigurationProvider)this).Config)
                                              .SetProjectFile(Solution));
             });

    Target Pack =>
        d => d
             .DependsOn<IPackNative>(t => t.PackNative)
             .Produces(((IPackNative)this).PackageOutputDirectory / "*.nupkg")
             .Executes(() =>
             {
                 DotNetTasks.DotNetPack(c => c
                                           .SetOutputDirectory(((IPackNative)this).PackageOutputDirectory)
                                           .SetProject(Solution.NotNull()!.Path.NotNull().Parent));
             });
}