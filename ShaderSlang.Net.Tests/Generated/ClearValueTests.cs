using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ClearValue" /> struct.</summary>
public static unsafe partial class ClearValueTests
{
    /// <summary>Validates that the <see cref="ClearValue" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ClearValue), Marshal.SizeOf<ClearValue>());
    }

    /// <summary>Validates that the <see cref="ClearValue" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ClearValue).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ClearValue" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(24, sizeof(ClearValue));
    }
}
