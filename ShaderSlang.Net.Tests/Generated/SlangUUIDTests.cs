using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="SlangUUID" /> struct.</summary>
public static unsafe partial class SlangUUIDTests
{
    /// <summary>Validates that the <see cref="SlangUUID" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(SlangUUID), Marshal.SizeOf<SlangUUID>());
    }

    /// <summary>Validates that the <see cref="SlangUUID" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(SlangUUID).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="SlangUUID" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(16, sizeof(SlangUUID));
    }
}
