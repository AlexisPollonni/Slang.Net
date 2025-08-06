using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="VariableLayoutReflection" /> struct.</summary>
public static unsafe partial class VariableLayoutReflectionTests
{
    /// <summary>Validates that the <see cref="VariableLayoutReflection" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(VariableLayoutReflection), Marshal.SizeOf<VariableLayoutReflection>());
    }

    /// <summary>Validates that the <see cref="VariableLayoutReflection" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(VariableLayoutReflection).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="VariableLayoutReflection" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(VariableLayoutReflection));
    }
}
