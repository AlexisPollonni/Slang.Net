using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="SpecializationArg" /> struct.</summary>
public static unsafe partial class SpecializationArgTests
{
    /// <summary>Validates that the <see cref="SpecializationArg" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(SpecializationArg), Marshal.SizeOf<SpecializationArg>());
    }

    /// <summary>Validates that the <see cref="SpecializationArg" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(SpecializationArg).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="SpecializationArg" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(16, sizeof(SpecializationArg));
        }
        else
        {
            Assert.Equal(8, sizeof(SpecializationArg));
        }
    }
}
