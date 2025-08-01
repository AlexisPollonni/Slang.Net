using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="FormatInfo" /> struct.</summary>
public static unsafe partial class FormatInfoTests
{
    /// <summary>Validates that the <see cref="FormatInfo" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(FormatInfo), Marshal.SizeOf<FormatInfo>());
    }

    /// <summary>Validates that the <see cref="FormatInfo" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(FormatInfo).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="FormatInfo" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(32, sizeof(FormatInfo));
        }
        else
        {
            Assert.Equal(24, sizeof(FormatInfo));
        }
    }
}
