using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ISwapchain" /> struct.</summary>
public static unsafe partial class ISwapchainTests
{
    /// <summary>Validates that the <see cref="ISwapchain" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ISwapchain), Marshal.SizeOf<ISwapchain>());
    }

    /// <summary>Validates that the <see cref="ISwapchain" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ISwapchain).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ISwapchain" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(ISwapchain));
        }
        else
        {
            Assert.Equal(4, sizeof(ISwapchain));
        }
    }
}
