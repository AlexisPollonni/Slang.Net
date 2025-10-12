using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="DeclReflection" /> struct.</summary>
public static unsafe partial class DeclReflectionTests
{
    /// <summary>Validates that the <see cref="DeclReflection" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(DeclReflection), Marshal.SizeOf<DeclReflection>());
    }

    /// <summary>Validates that the <see cref="DeclReflection" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(DeclReflection).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="DeclReflection" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(DeclReflection));
    }
}
