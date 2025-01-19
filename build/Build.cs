using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NuGet.Packaging;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using Serilog;

class Build : NukeBuild, IGenerateSlangBindings, IDownloadSlangBinaries
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode
    public static int Main() =>
        Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;
    
    [Solution(GenerateProjects = true)] public Solution? Solution { get; set; }

    Target Clean =>
        d => d
            .DependsOn<IGenerateSlangBindings>(b => b.CleanSlangBindings)
            .Executes(() =>
            {
                DotNetTasks.DotNetClean(s => s
                    .SetConfiguration(Configuration)
                    .SetProject(Solution));
            });

    Target Restore =>
        d => d
            .DependsOn<IGenerateSlangBindings>(b => b.GenerateSlangBindings)
            .DependsOn<IDownloadSlangBinaries>(d => d.DownloadSlangBinaries)
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
}