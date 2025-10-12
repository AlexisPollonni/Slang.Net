using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="SlangReflectionFunction" /> struct.</summary>
public static unsafe partial class SlangReflectionFunctionTests
{
    /// <summary>Validates that the <see cref="SlangReflectionFunction" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(SlangReflectionFunction), Marshal.SizeOf<SlangReflectionFunction>());
    }

    /// <summary>Validates that the <see cref="SlangReflectionFunction" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(SlangReflectionFunction).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="SlangReflectionFunction" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(SlangReflectionFunction));
    }
}
