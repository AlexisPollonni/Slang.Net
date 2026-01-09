using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="SlangReflectionGenericArg" /> struct.</summary>
public static unsafe partial class SlangReflectionGenericArgTests
{
    /// <summary>Validates that the <see cref="SlangReflectionGenericArg" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(SlangReflectionGenericArg), Marshal.SizeOf<SlangReflectionGenericArg>());
    }

    /// <summary>Validates that the <see cref="SlangReflectionGenericArg" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutExplicitTest()
    {
        Assert.True(typeof(SlangReflectionGenericArg).IsExplicitLayout);
    }

    /// <summary>Validates that the <see cref="SlangReflectionGenericArg" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(SlangReflectionGenericArg));
        }
        else
        {
            Assert.Equal(4, sizeof(SlangReflectionGenericArg));
        }
    }
}
