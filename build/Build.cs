using Nuke.Common;
using Nuke.Common.IO;

class Build : NukeBuild
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

    readonly BuildSlangBindings SlangBindings = new()
    {
        SrcOutputDir = RootDirectory / "SlangNet.Bindings" / "Generated",
        XmlOutputDir = RootDirectory / "SlangNet" / "GeneratedDoc",
        TestsOutputDir = RootDirectory / "SlangNet.Tests" / "SlangNet.Tests.Shared" / "Generated",
        SlangRepoPath = RootDirectory / "slang"
    };

    Target Clean =>
        d => d
             .Before(Restore)
             .Executes(() =>
             {
                 SlangBindings.SrcOutputDir.CreateOrCleanDirectory();
                 SlangBindings.XmlOutputDir.CreateOrCleanDirectory();
                 SlangBindings.TestsOutputDir.CreateOrCleanDirectory();
             });

    Target GenerateSlangBindings =>
        d =>
            d.DependsOn(Clean)
             .Executes(() => SlangBindings.Build());

    Target Restore =>
        d => d
             .DependsOn(GenerateSlangBindings)
             .Executes(() => { });

    Target Compile =>
        d => d
             .DependsOn(Restore)
             .Executes(() => { });
}