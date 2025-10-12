using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="DepthStencilOpDesc" /> struct.</summary>
public static unsafe partial class DepthStencilOpDescTests
{
    /// <summary>Validates that the <see cref="DepthStencilOpDesc" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(DepthStencilOpDesc), Marshal.SizeOf<DepthStencilOpDesc>());
    }

    /// <summary>Validates that the <see cref="DepthStencilOpDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(DepthStencilOpDesc).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="DepthStencilOpDesc" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(4, sizeof(DepthStencilOpDesc));
    }
}
