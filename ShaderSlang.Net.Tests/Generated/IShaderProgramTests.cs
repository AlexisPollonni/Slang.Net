using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IShaderProgram" /> struct.</summary>
public static unsafe partial class IShaderProgramTests
{
    /// <summary>Validates that the <see cref="IShaderProgram" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IShaderProgram), Marshal.SizeOf<IShaderProgram>());
    }

    /// <summary>Validates that the <see cref="IShaderProgram" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IShaderProgram).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IShaderProgram" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IShaderProgram));
        }
        else
        {
            Assert.Equal(4, sizeof(IShaderProgram));
        }
    }
}
