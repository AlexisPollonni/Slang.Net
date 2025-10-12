using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IDebugCallback" /> struct.</summary>
public static unsafe partial class IDebugCallbackTests
{
    /// <summary>Validates that the <see cref="IDebugCallback" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IDebugCallback), Marshal.SizeOf<IDebugCallback>());
    }

    /// <summary>Validates that the <see cref="IDebugCallback" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IDebugCallback).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IDebugCallback" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IDebugCallback));
        }
        else
        {
            Assert.Equal(4, sizeof(IDebugCallback));
        }
    }
}
