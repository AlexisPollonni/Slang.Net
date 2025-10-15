using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="SubresourceRange" /> struct.</summary>
public static unsafe partial class SubresourceRangeTests
{
    /// <summary>Validates that the <see cref="SubresourceRange" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(SubresourceRange), Marshal.SizeOf<SubresourceRange>());
    }

    /// <summary>Validates that the <see cref="SubresourceRange" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(SubresourceRange).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="SubresourceRange" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(20, sizeof(SubresourceRange));
    }
}
