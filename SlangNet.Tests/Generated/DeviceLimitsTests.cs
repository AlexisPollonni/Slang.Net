using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="DeviceLimits" /> struct.</summary>
public static unsafe partial class DeviceLimitsTests
{
    /// <summary>Validates that the <see cref="DeviceLimits" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(DeviceLimits), Marshal.SizeOf<DeviceLimits>());
    }

    /// <summary>Validates that the <see cref="DeviceLimits" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(DeviceLimits).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="DeviceLimits" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(92, sizeof(DeviceLimits));
    }
}
