using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="TargetDesc" /> struct.</summary>
public static unsafe partial class TargetDescTests
{
    /// <summary>Validates that the <see cref="TargetDesc" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(TargetDesc), Marshal.SizeOf<TargetDesc>());
    }

    /// <summary>Validates that the <see cref="TargetDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(TargetDesc).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="TargetDesc" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(48, sizeof(TargetDesc));
        }
        else
        {
            Assert.Equal(36, sizeof(TargetDesc));
        }
    }
}
