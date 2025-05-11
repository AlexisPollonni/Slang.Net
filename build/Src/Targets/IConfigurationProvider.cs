using Nuke.Common;

namespace SlangNet.Build.Targets;

interface IConfigurationProvider : INukeBuild
{
    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    Configuration Config =>
        TryGetValue(() => Config) ?? (IsLocalBuild ? Configuration.Debug : Configuration.Release);

}