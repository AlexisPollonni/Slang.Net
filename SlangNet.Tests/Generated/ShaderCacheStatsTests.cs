using NUnit.Framework;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ShaderCacheStats" /> struct.</summary>
public static unsafe partial class ShaderCacheStatsTests
{
    /// <summary>Validates that the <see cref="ShaderCacheStats" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<ShaderCacheStats>(), Is.EqualTo(sizeof(ShaderCacheStats)));
    }

    /// <summary>Validates that the <see cref="ShaderCacheStats" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(ShaderCacheStats).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="ShaderCacheStats" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        Assert.That(sizeof(ShaderCacheStats), Is.EqualTo(12));
    }
}
