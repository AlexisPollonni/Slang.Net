using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="CooperativeVectorProperties" /> struct.</summary>
public static unsafe partial class CooperativeVectorPropertiesTests
{
    /// <summary>Validates that the <see cref="CooperativeVectorProperties" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(
            sizeof(CooperativeVectorProperties),
            Marshal.SizeOf<CooperativeVectorProperties>()
        );
    }

    /// <summary>Validates that the <see cref="CooperativeVectorProperties" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(CooperativeVectorProperties).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="CooperativeVectorProperties" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(24, sizeof(CooperativeVectorProperties));
    }
}
