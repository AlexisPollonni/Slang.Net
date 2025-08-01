using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IFence" /> struct.</summary>
public static unsafe partial class IFenceTests
{
    /// <summary>Validates that the <see cref="IFence" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IFence), Marshal.SizeOf<IFence>());
    }

    /// <summary>Validates that the <see cref="IFence" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IFence).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IFence" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IFence));
        }
        else
        {
            Assert.Equal(4, sizeof(IFence));
        }
    }
}
