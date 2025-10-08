using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="SlangReflectionUserAttribute" /> struct.</summary>
public static unsafe partial class SlangReflectionUserAttributeTests
{
    /// <summary>Validates that the <see cref="SlangReflectionUserAttribute" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(SlangReflectionUserAttribute), Marshal.SizeOf<SlangReflectionUserAttribute>());
    }

    /// <summary>Validates that the <see cref="SlangReflectionUserAttribute" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(SlangReflectionUserAttribute).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="SlangReflectionUserAttribute" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(SlangReflectionUserAttribute));
    }
}
