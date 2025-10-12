using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ScissorRect" /> struct.</summary>
public static unsafe partial class ScissorRectTests
{
    /// <summary>Validates that the <see cref="ScissorRect" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ScissorRect), Marshal.SizeOf<ScissorRect>());
    }

    /// <summary>Validates that the <see cref="ScissorRect" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ScissorRect).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ScissorRect" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(16, sizeof(ScissorRect));
    }
}
