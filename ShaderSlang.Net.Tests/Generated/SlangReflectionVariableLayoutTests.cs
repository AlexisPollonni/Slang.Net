using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="SlangReflectionVariableLayout" /> struct.</summary>
public static unsafe partial class SlangReflectionVariableLayoutTests
{
    /// <summary>Validates that the <see cref="SlangReflectionVariableLayout" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(
            sizeof(SlangReflectionVariableLayout),
            Marshal.SizeOf<SlangReflectionVariableLayout>()
        );
    }

    /// <summary>Validates that the <see cref="SlangReflectionVariableLayout" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(SlangReflectionVariableLayout).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="SlangReflectionVariableLayout" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(SlangReflectionVariableLayout));
    }
}
