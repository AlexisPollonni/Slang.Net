using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="SlangReflectionGeneric" /> struct.</summary>
public static unsafe partial class SlangReflectionGenericTests
{
    /// <summary>Validates that the <see cref="SlangReflectionGeneric" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(SlangReflectionGeneric), Marshal.SizeOf<SlangReflectionGeneric>());
    }

    /// <summary>Validates that the <see cref="SlangReflectionGeneric" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(SlangReflectionGeneric).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="SlangReflectionGeneric" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(SlangReflectionGeneric));
    }
}
