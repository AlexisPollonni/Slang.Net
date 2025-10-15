using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="AspectBlendDesc" /> struct.</summary>
public static unsafe partial class AspectBlendDescTests
{
    /// <summary>Validates that the <see cref="AspectBlendDesc" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(AspectBlendDesc), Marshal.SizeOf<AspectBlendDesc>());
    }

    /// <summary>Validates that the <see cref="AspectBlendDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(AspectBlendDesc).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="AspectBlendDesc" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(12, sizeof(AspectBlendDesc));
    }
}
