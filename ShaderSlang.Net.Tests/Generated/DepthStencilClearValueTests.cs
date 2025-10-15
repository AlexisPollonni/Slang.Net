using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="DepthStencilClearValue" /> struct.</summary>
public static unsafe partial class DepthStencilClearValueTests
{
    /// <summary>Validates that the <see cref="DepthStencilClearValue" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(DepthStencilClearValue), Marshal.SizeOf<DepthStencilClearValue>());
    }

    /// <summary>Validates that the <see cref="DepthStencilClearValue" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(DepthStencilClearValue).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="DepthStencilClearValue" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(8, sizeof(DepthStencilClearValue));
    }
}
