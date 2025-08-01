using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="SlangReflectionModifier" /> struct.</summary>
public static unsafe partial class SlangReflectionModifierTests
{
    /// <summary>Validates that the <see cref="SlangReflectionModifier" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(SlangReflectionModifier), Marshal.SizeOf<SlangReflectionModifier>());
    }

    /// <summary>Validates that the <see cref="SlangReflectionModifier" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(SlangReflectionModifier).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="SlangReflectionModifier" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(SlangReflectionModifier));
    }
}
