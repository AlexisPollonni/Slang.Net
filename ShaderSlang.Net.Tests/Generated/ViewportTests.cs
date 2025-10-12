using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="Viewport" /> struct.</summary>
public static unsafe partial class ViewportTests
{
    /// <summary>Validates that the <see cref="Viewport" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(Viewport), Marshal.SizeOf<Viewport>());
    }

    /// <summary>Validates that the <see cref="Viewport" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(Viewport).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="Viewport" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(24, sizeof(Viewport));
    }
}
