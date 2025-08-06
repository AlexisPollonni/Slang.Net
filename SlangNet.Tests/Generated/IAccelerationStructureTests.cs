using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IAccelerationStructure" /> struct.</summary>
public static unsafe partial class IAccelerationStructureTests
{
    /// <summary>Validates that the <see cref="IAccelerationStructure" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IAccelerationStructure), Marshal.SizeOf<IAccelerationStructure>());
    }

    /// <summary>Validates that the <see cref="IAccelerationStructure" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IAccelerationStructure).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IAccelerationStructure" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IAccelerationStructure));
        }
        else
        {
            Assert.Equal(4, sizeof(IAccelerationStructure));
        }
    }
}
