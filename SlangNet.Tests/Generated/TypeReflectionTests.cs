using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="TypeReflection" /> struct.</summary>
public static unsafe partial class TypeReflectionTests
{
    /// <summary>Validates that the <see cref="TypeReflection" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(TypeReflection), Marshal.SizeOf<TypeReflection>());
    }

    /// <summary>Validates that the <see cref="TypeReflection" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(TypeReflection).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="TypeReflection" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(TypeReflection));
    }
}
