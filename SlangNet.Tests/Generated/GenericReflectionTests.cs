using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="GenericReflection" /> struct.</summary>
public static unsafe partial class GenericReflectionTests
{
    /// <summary>Validates that the <see cref="GenericReflection" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(GenericReflection), Marshal.SizeOf<GenericReflection>());
    }

    /// <summary>Validates that the <see cref="GenericReflection" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(GenericReflection).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="GenericReflection" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(GenericReflection));
    }
}
