using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="VariableReflection" /> struct.</summary>
public static unsafe partial class VariableReflectionTests
{
    /// <summary>Validates that the <see cref="VariableReflection" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(VariableReflection), Marshal.SizeOf<VariableReflection>());
    }

    /// <summary>Validates that the <see cref="VariableReflection" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(VariableReflection).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="VariableReflection" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(VariableReflection));
    }
}
