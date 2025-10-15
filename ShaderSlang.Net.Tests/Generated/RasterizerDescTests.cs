using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="RasterizerDesc" /> struct.</summary>
public static unsafe partial class RasterizerDescTests
{
    /// <summary>Validates that the <see cref="RasterizerDesc" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(RasterizerDesc), Marshal.SizeOf<RasterizerDesc>());
    }

    /// <summary>Validates that the <see cref="RasterizerDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(RasterizerDesc).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="RasterizerDesc" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(28, sizeof(RasterizerDesc));
    }
}
