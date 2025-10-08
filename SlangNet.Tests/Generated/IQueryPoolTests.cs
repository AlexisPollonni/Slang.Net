using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IQueryPool" /> struct.</summary>
public static unsafe partial class IQueryPoolTests
{
    /// <summary>Validates that the <see cref="IQueryPool" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IQueryPool), Marshal.SizeOf<IQueryPool>());
    }

    /// <summary>Validates that the <see cref="IQueryPool" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IQueryPool).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IQueryPool" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IQueryPool));
        }
        else
        {
            Assert.Equal(4, sizeof(IQueryPool));
        }
    }
}
