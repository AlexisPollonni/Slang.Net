using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IShaderObject" /> struct.</summary>
public static unsafe partial class IShaderObjectTests
{
    /// <summary>Validates that the <see cref="IShaderObject" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IShaderObject), Marshal.SizeOf<IShaderObject>());
    }

    /// <summary>Validates that the <see cref="IShaderObject" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IShaderObject).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IShaderObject" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IShaderObject));
        }
        else
        {
            Assert.Equal(4, sizeof(IShaderObject));
        }
    }
}
