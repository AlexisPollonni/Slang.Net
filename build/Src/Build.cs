using Nuke.Common;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using SlangNet.Build.Targets;

namespace SlangNet.Build;

class Build : NukeBuild, IGenerateSlangBindings, IGenerateRuntimeJson, IConfigurationProvider
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode
    public static int Main() =>
        Execute<Build>(b => b.Pack);

    //TODO: Change when Nuke supports .snlx : https://github.com/nuke-build/nuke/issues/1520
    [Solution("SlangNet.slnx", GenerateProjects = true)]
    public Solution? Solution { get; set; }

    [Parameter]
    bool IsNightly { get; }

    private IConfigurationProvider ConfigProvider => this;

    Target Restore =>
        d => d
            .Executes(() =>
            {
                DotNetTasks.DotNetRestore(s => s.SetProjectFile(Solution));
            });

    Target Clean =>
        d => d
             // Clean the temp directories after dotnet clean to avoid missing files
             .Triggers<IDownloadSlangBinaries>(n => n.CleanDownloadDir)
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
             .Executes(() =>
             {
                 DotNetTasks.DotNetPack(c => c
                                             .SetNoRestore(true)
                                             .SetNoBuild(true)
                                             .SetConfiguration(ConfigProvider.Config)
                                             .SetProject(Solution.NotNull()!.Path.NotNull().Parent));
             });
    
    Target PublishToGithub =>
        d => d
             .OnlyWhenDynamic(() => IsNightly && IsServerBuild)
             .DependsOn(Pack)
             .Executes(() =>
             {
                 var packageFiles = (RootDirectory / "artifacts" / "release")
                     .GlobFiles("*.nupkg");
                 
                 Assert.NotEmpty(packageFiles);
                
                 foreach (var package in packageFiles)
                 {
                     DotNetTasks.DotNetNuGetPush(s => s.SetTargetPath(package)
                                                       .SetSource("https://nuget.pkg.github.com/AlexisPollonni/index.json")
                                                       .SetApiKey(GitHubActions.Instance.Token)
                                                       .SetSkipDuplicate(true));
                 }
             });
}