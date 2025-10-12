using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IShaderCache" /> struct.</summary>
public static unsafe partial class IShaderCacheTests
{
    /// <summary>Validates that the <see cref="IShaderCache" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IShaderCache), Marshal.SizeOf<IShaderCache>());
    }

    /// <summary>Validates that the <see cref="IShaderCache" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IShaderCache).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IShaderCache" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IShaderCache));
        }
        else
        {
            Assert.Equal(4, sizeof(IShaderCache));
        }
    }
}
