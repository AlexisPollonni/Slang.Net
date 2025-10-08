using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="SlangReflectionType" /> struct.</summary>
public static unsafe partial class SlangReflectionTypeTests
{
    /// <summary>Validates that the <see cref="SlangReflectionType" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(SlangReflectionType), Marshal.SizeOf<SlangReflectionType>());
    }

    /// <summary>Validates that the <see cref="SlangReflectionType" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(SlangReflectionType).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="SlangReflectionType" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(SlangReflectionType));
    }
}
