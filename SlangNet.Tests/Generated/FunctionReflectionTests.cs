using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="FunctionReflection" /> struct.</summary>
public static unsafe partial class FunctionReflectionTests
{
    /// <summary>Validates that the <see cref="FunctionReflection" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(FunctionReflection), Marshal.SizeOf<FunctionReflection>());
    }

    /// <summary>Validates that the <see cref="FunctionReflection" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(FunctionReflection).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="FunctionReflection" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(FunctionReflection));
    }
}
