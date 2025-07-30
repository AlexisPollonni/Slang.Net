using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="BufferReflection" /> struct.</summary>
public static unsafe partial class BufferReflectionTests
{
    /// <summary>Validates that the <see cref="BufferReflection" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(BufferReflection), Marshal.SizeOf<BufferReflection>());
    }

    /// <summary>Validates that the <see cref="BufferReflection" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(BufferReflection).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="BufferReflection" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(BufferReflection));
    }
}
