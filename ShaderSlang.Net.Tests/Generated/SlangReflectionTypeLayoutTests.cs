using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="SlangReflectionTypeLayout" /> struct.</summary>
public static unsafe partial class SlangReflectionTypeLayoutTests
{
    /// <summary>Validates that the <see cref="SlangReflectionTypeLayout" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(
            sizeof(SlangReflectionTypeLayout),
            Marshal.SizeOf<SlangReflectionTypeLayout>()
        );
    }

    /// <summary>Validates that the <see cref="SlangReflectionTypeLayout" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(SlangReflectionTypeLayout).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="SlangReflectionTypeLayout" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(SlangReflectionTypeLayout));
    }
}
