using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="DepthStencilDesc" /> struct.</summary>
public static unsafe partial class DepthStencilDescTests
{
    /// <summary>Validates that the <see cref="DepthStencilDesc" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(DepthStencilDesc), Marshal.SizeOf<DepthStencilDesc>());
    }

    /// <summary>Validates that the <see cref="DepthStencilDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(DepthStencilDesc).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="DepthStencilDesc" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(24, sizeof(DepthStencilDesc));
    }
}
