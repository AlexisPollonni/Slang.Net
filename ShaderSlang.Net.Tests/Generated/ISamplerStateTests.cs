using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ISamplerState" /> struct.</summary>
public static unsafe partial class ISamplerStateTests
{
    /// <summary>Validates that the <see cref="ISamplerState" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ISamplerState), Marshal.SizeOf<ISamplerState>());
    }

    /// <summary>Validates that the <see cref="ISamplerState" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ISamplerState).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ISamplerState" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(ISamplerState));
        }
        else
        {
            Assert.Equal(4, sizeof(ISamplerState));
        }
    }
}
