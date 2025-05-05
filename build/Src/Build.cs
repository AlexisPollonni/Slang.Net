using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using SlangNet.Build.Targets;

//[GitHubActions("pack", GitHubActionsImage.WindowsLatest, On = [GitHubActionsTrigger.Push],)]
class Build : NukeBuild, IGenerateSlangBindings, IPackNative
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode
    public static int Main() =>
        Execute<Build>();

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Solution(GenerateProjects = true)]
    public Solution? Solution { get; set; }

    Target Clean =>
        d => d
             .Executes(() =>
             {
                 TemporaryDirectory.CreateOrCleanDirectory();
                 DotNetTasks.DotNetClean(s => s
                                              .SetConfiguration(Configuration)
                                              .SetProject(Solution));
             });

    internal Target Restore =>
        d => d
             .DependsOn<IPackNative>(d => d.PackNative)
             .Executes(() =>
             {
                 DotNetTasks.DotNetRestore(s => s.SetProjectFile(Solution));
             });

    Target Compile =>
        d => d
             .DependsOn(Restore)
             .Executes(() =>
             {
                 DotNetTasks.DotNetBuild(s =>
                                             s.SetNoRestore(true)
                                              .SetConfiguration(Configuration)
                                              .SetProjectFile(Solution));
             });
    
    Target Pack =>
        d => d
             .DependsOn<IPackNative>(n => n.PackNative)
             .Executes(() =>
             {
                 //NuGetTasks.NuGetPack(c => c.SetTargetPath())
             });
}