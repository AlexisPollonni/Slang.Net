using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ColorClearValue" /> struct.</summary>
public static unsafe partial class ColorClearValueTests
{
    /// <summary>Validates that the <see cref="ColorClearValue" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ColorClearValue), Marshal.SizeOf<ColorClearValue>());
    }

    /// <summary>Validates that the <see cref="ColorClearValue" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutExplicitTest()
    {
        Assert.True(typeof(ColorClearValue).IsExplicitLayout);
    }

    /// <summary>Validates that the <see cref="ColorClearValue" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(16, sizeof(ColorClearValue));
    }
}
