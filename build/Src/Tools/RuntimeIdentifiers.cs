using System;
using System.Runtime.InteropServices;
using Intellenum;

namespace SlangNet.Build.Tools;

[Intellenum<string>]
[Member("LinuxArm64", "linux-aarch64")]
[Member("Linux64", "linux-x86_64")]
[Member("MacOsArm64", "macos-aarch64")]
[Member("MacOs64", "macos-x86_64")]
[Member("WinArm64", "windows-aarch64")]
[Member("Win64", "windows-x86_64")]
public partial class SlangRuntimeId
{
    public DotnetRuntimeId ToDotnetRuntimeId()
    {
        return Value switch
        {
            LinuxArm64Value => DotnetRuntimeId.LinuxArm64,
            Linux64Value => DotnetRuntimeId.Linux64,
            MacOsArm64Value => DotnetRuntimeId.MacOsArm64,
            MacOs64Value => DotnetRuntimeId.MacOs64,
            WinArm64Value => DotnetRuntimeId.WinArm64,
            Win64Value => DotnetRuntimeId.Win64,
            _ => throw new ArgumentOutOfRangeException(nameof(Value), "Unexpected Slang Rid value")
        };
    }
}

[Intellenum<string>]
//Rids taken from https://learn.microsoft.com/en-us/dotnet/core/rid-catalog
[Member("Win64", "win-x64")]
[Member("Win32", "win-x86")]
[Member("WinArm64", "win-arm64")]

[Member("Linux64", "linux-x64")]
[Member("LinuxMusl64", "linux-musl-x64")]
[Member("LinuxMuslArm64", "linux-musl-arm64")]
[Member("LinuxArm", "linux-arm")]
[Member("LinuxArm64", "linux-arm64")]
[Member("LinuxBionicArm64", "linux-bionic-arm64")]
[Member("LinuxLoongArch64", "linux-loongarch64")]

[Member("MacOs64", "osx-64")]
[Member("MacOsArm64", "osx-arm64")]

[Member("IosArm64", "ios-arm64")]
[Member("IosSimulatorArm64", "iossimulator-arm64")]
[Member("IosSimulator64", "iossimulator-x64")]

[Member("AndroidArm64", "android-arm64")]
[Member("AndroidArm", "android-arm")]
[Member("Android64", "android-x64")]
[Member("Android32", "android-x86")]
public partial class DotnetRuntimeId
{
    public static DotnetRuntimeId Current => FromValue(RuntimeInformation.RuntimeIdentifier);
    
    public SlangRuntimeId ToSlangRuntimeId()
    {
        return Value switch
        {
            Win64Value => SlangRuntimeId.Win64,
            WinArm64Value => SlangRuntimeId.WinArm64,
            Linux64Value => SlangRuntimeId.Linux64,
            LinuxArm64Value => SlangRuntimeId.LinuxArm64,
            MacOs64Value => SlangRuntimeId.MacOs64,
            MacOsArm64Value => SlangRuntimeId.MacOsArm64,
            _ => throw new ArgumentOutOfRangeException(nameof(Value),
                                                       "Dotnet runtime identifier value is not convertible to SlangRuntimeId"),
        };
    }
}