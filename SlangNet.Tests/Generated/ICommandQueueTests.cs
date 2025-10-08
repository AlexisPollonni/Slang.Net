using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ICommandQueue" /> struct.</summary>
public static unsafe partial class ICommandQueueTests
{
    /// <summary>Validates that the <see cref="ICommandQueue" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ICommandQueue), Marshal.SizeOf<ICommandQueue>());
    }

    /// <summary>Validates that the <see cref="ICommandQueue" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ICommandQueue).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ICommandQueue" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(ICommandQueue));
        }
        else
        {
            Assert.Equal(4, sizeof(ICommandQueue));
        }
    }
}
