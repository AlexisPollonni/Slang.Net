using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="SessionDesc" /> struct.</summary>
public static unsafe partial class SessionDescTests
{
    /// <summary>Validates that the <see cref="SessionDesc" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(SessionDesc), Marshal.SizeOf<SessionDesc>());
    }

    /// <summary>Validates that the <see cref="SessionDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(SessionDesc).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="SessionDesc" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(96, sizeof(SessionDesc));
        }
        else
        {
            Assert.Equal(56, sizeof(SessionDesc));
        }
    }
}
