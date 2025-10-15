using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IFramebufferLayout" /> struct.</summary>
public static unsafe partial class IFramebufferLayoutTests
{
    /// <summary>Validates that the <see cref="IFramebufferLayout" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IFramebufferLayout), Marshal.SizeOf<IFramebufferLayout>());
    }

    /// <summary>Validates that the <see cref="IFramebufferLayout" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IFramebufferLayout).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IFramebufferLayout" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IFramebufferLayout));
        }
        else
        {
            Assert.Equal(4, sizeof(IFramebufferLayout));
        }
    }
}
