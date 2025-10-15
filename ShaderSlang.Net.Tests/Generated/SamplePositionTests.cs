using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="SamplePosition" /> struct.</summary>
public static unsafe partial class SamplePositionTests
{
    /// <summary>Validates that the <see cref="SamplePosition" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(SamplePosition), Marshal.SizeOf<SamplePosition>());
    }

    /// <summary>Validates that the <see cref="SamplePosition" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(SamplePosition).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="SamplePosition" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(2, sizeof(SamplePosition));
    }
}
