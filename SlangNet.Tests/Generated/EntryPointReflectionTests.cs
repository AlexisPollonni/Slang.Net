using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="EntryPointReflection" /> struct.</summary>
public static unsafe partial class EntryPointReflectionTests
{
    /// <summary>Validates that the <see cref="EntryPointReflection" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(EntryPointReflection), Marshal.SizeOf<EntryPointReflection>());
    }

    /// <summary>Validates that the <see cref="EntryPointReflection" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(EntryPointReflection).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="EntryPointReflection" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(EntryPointReflection));
    }
}
