using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IFramebuffer" /> struct.</summary>
public static unsafe partial class IFramebufferTests
{
    /// <summary>Validates that the <see cref="IFramebuffer" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IFramebuffer), Marshal.SizeOf<IFramebuffer>());
    }

    /// <summary>Validates that the <see cref="IFramebuffer" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IFramebuffer).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IFramebuffer" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IFramebuffer));
        }
        else
        {
            Assert.Equal(4, sizeof(IFramebuffer));
        }
    }
}
