using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="SlangReflectionTypeParameter" /> struct.</summary>
public static unsafe partial class SlangReflectionTypeParameterTests
{
    /// <summary>Validates that the <see cref="SlangReflectionTypeParameter" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(
            sizeof(SlangReflectionTypeParameter),
            Marshal.SizeOf<SlangReflectionTypeParameter>()
        );
    }

    /// <summary>Validates that the <see cref="SlangReflectionTypeParameter" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(SlangReflectionTypeParameter).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="SlangReflectionTypeParameter" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(SlangReflectionTypeParameter));
    }
}
