using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="SlangAttribute" /> struct.</summary>
public static unsafe partial class SlangAttributeTests
{
    /// <summary>Validates that the <see cref="SlangAttribute" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(SlangAttribute), Marshal.SizeOf<SlangAttribute>());
    }

    /// <summary>Validates that the <see cref="SlangAttribute" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(SlangAttribute).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="SlangAttribute" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(SlangAttribute));
    }
}
