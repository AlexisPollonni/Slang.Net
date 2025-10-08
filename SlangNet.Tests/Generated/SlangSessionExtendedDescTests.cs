using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="SlangSessionExtendedDesc" /> struct.</summary>
public static unsafe partial class SlangSessionExtendedDescTests
{
    /// <summary>Validates that the <see cref="SlangSessionExtendedDesc" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(SlangSessionExtendedDesc), Marshal.SizeOf<SlangSessionExtendedDesc>());
    }

    /// <summary>Validates that the <see cref="SlangSessionExtendedDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(SlangSessionExtendedDesc).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="SlangSessionExtendedDesc" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(16, sizeof(SlangSessionExtendedDesc));
        }
        else
        {
            Assert.Equal(12, sizeof(SlangSessionExtendedDesc));
        }
    }
}
