using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ICommandBuffer" /> struct.</summary>
public static unsafe partial class ICommandBufferTests
{
    /// <summary>Validates that the <see cref="ICommandBuffer" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ICommandBuffer), Marshal.SizeOf<ICommandBuffer>());
    }

    /// <summary>Validates that the <see cref="ICommandBuffer" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ICommandBuffer).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ICommandBuffer" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(ICommandBuffer));
        }
        else
        {
            Assert.Equal(4, sizeof(ICommandBuffer));
        }
    }
}
