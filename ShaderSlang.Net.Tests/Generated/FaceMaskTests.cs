using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="FaceMask" /> struct.</summary>
public static unsafe partial class FaceMaskTests
{
    /// <summary>Validates that the <see cref="FaceMask" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(FaceMask), Marshal.SizeOf<FaceMask>());
    }

    /// <summary>Validates that the <see cref="FaceMask" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(FaceMask).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="FaceMask" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(FaceMask));
    }
}
