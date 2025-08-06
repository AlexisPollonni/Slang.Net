using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="AccelerationStructureQueryDesc" /> struct.</summary>
public static unsafe partial class AccelerationStructureQueryDescTests
{
    /// <summary>Validates that the <see cref="AccelerationStructureQueryDesc" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(AccelerationStructureQueryDesc), Marshal.SizeOf<AccelerationStructureQueryDesc>());
    }

    /// <summary>Validates that the <see cref="AccelerationStructureQueryDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(AccelerationStructureQueryDesc).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="AccelerationStructureQueryDesc" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(24, sizeof(AccelerationStructureQueryDesc));
        }
        else
        {
            Assert.Equal(12, sizeof(AccelerationStructureQueryDesc));
        }
    }
}
