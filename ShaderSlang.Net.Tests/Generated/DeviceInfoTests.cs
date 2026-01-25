using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="DeviceInfo" /> struct.</summary>
public static unsafe partial class DeviceInfoTests
{
    /// <summary>Validates that the <see cref="DeviceInfo" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(DeviceInfo), Marshal.SizeOf<DeviceInfo>());
    }

    /// <summary>Validates that the <see cref="DeviceInfo" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(DeviceInfo).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="DeviceInfo" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(192, sizeof(DeviceInfo));
        }
        else
        {
            Assert.Equal(184, sizeof(DeviceInfo));
        }
    }
}
