using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="AdapterLUID" /> struct.</summary>
public static unsafe partial class AdapterLUIDTests
{
    /// <summary>Validates that the <see cref="AdapterLUID" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(AdapterLUID), Marshal.SizeOf<AdapterLUID>());
    }

    /// <summary>Validates that the <see cref="AdapterLUID" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(AdapterLUID).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="AdapterLUID" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(16, sizeof(AdapterLUID));
    }
}
