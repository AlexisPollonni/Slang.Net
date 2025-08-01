using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ShaderReflection" /> struct.</summary>
public static unsafe partial class ShaderReflectionTests
{
    /// <summary>Validates that the <see cref="ShaderReflection" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ShaderReflection), Marshal.SizeOf<ShaderReflection>());
    }

    /// <summary>Validates that the <see cref="ShaderReflection" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ShaderReflection).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ShaderReflection" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(ShaderReflection));
    }
}
