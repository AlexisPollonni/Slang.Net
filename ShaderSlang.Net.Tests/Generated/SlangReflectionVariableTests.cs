using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="SlangReflectionVariable" /> struct.</summary>
public static unsafe partial class SlangReflectionVariableTests
{
    /// <summary>Validates that the <see cref="SlangReflectionVariable" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(SlangReflectionVariable), Marshal.SizeOf<SlangReflectionVariable>());
    }

    /// <summary>Validates that the <see cref="SlangReflectionVariable" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(SlangReflectionVariable).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="SlangReflectionVariable" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(SlangReflectionVariable));
    }
}
