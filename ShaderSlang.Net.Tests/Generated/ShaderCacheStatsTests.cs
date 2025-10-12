using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ShaderCacheStats" /> struct.</summary>
public static unsafe partial class ShaderCacheStatsTests
{
    /// <summary>Validates that the <see cref="ShaderCacheStats" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ShaderCacheStats), Marshal.SizeOf<ShaderCacheStats>());
    }

    /// <summary>Validates that the <see cref="ShaderCacheStats" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ShaderCacheStats).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ShaderCacheStats" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(12, sizeof(ShaderCacheStats));
    }
}
