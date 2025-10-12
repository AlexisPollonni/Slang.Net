using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ClearResourceViewFlags" /> struct.</summary>
public static unsafe partial class ClearResourceViewFlagsTests
{
    /// <summary>Validates that the <see cref="ClearResourceViewFlags" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ClearResourceViewFlags), Marshal.SizeOf<ClearResourceViewFlags>());
    }

    /// <summary>Validates that the <see cref="ClearResourceViewFlags" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ClearResourceViewFlags).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ClearResourceViewFlags" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(ClearResourceViewFlags));
    }
}
