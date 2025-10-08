using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="TypeParameterReflection" /> struct.</summary>
public static unsafe partial class TypeParameterReflectionTests
{
    /// <summary>Validates that the <see cref="TypeParameterReflection" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(TypeParameterReflection), Marshal.SizeOf<TypeParameterReflection>());
    }

    /// <summary>Validates that the <see cref="TypeParameterReflection" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(TypeParameterReflection).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="TypeParameterReflection" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(TypeParameterReflection));
    }
}
