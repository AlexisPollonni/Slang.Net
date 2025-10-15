using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ShaderOffset" /> struct.</summary>
public static unsafe partial class ShaderOffsetTests
{
    /// <summary>Validates that the <see cref="ShaderOffset" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ShaderOffset), Marshal.SizeOf<ShaderOffset>());
    }

    /// <summary>Validates that the <see cref="ShaderOffset" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ShaderOffset).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ShaderOffset" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(16, sizeof(ShaderOffset));
        }
        else
        {
            Assert.Equal(12, sizeof(ShaderOffset));
        }
    }
}
