using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IDevice" /> struct.</summary>
public static unsafe partial class IDeviceTests
{
    /// <summary>Validates that the <see cref="IDevice" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IDevice), Marshal.SizeOf<IDevice>());
    }

    /// <summary>Validates that the <see cref="IDevice" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IDevice).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IDevice" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IDevice));
        }
        else
        {
            Assert.Equal(4, sizeof(IDevice));
        }
    }
}
