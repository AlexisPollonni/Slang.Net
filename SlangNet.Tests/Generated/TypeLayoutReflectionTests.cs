using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="TypeLayoutReflection" /> struct.</summary>
public static unsafe partial class TypeLayoutReflectionTests
{
    /// <summary>Validates that the <see cref="TypeLayoutReflection" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(TypeLayoutReflection), Marshal.SizeOf<TypeLayoutReflection>());
    }

    /// <summary>Validates that the <see cref="TypeLayoutReflection" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(TypeLayoutReflection).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="TypeLayoutReflection" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(TypeLayoutReflection));
    }
}
