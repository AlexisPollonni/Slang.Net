using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="HitGroupDesc" /> struct.</summary>
public static unsafe partial class HitGroupDescTests
{
    /// <summary>Validates that the <see cref="HitGroupDesc" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(HitGroupDesc), Marshal.SizeOf<HitGroupDesc>());
    }

    /// <summary>Validates that the <see cref="HitGroupDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(HitGroupDesc).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="HitGroupDesc" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(32, sizeof(HitGroupDesc));
        }
        else
        {
            Assert.Equal(16, sizeof(HitGroupDesc));
        }
    }
}
