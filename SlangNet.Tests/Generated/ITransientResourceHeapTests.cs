using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ITransientResourceHeap" /> struct.</summary>
public static unsafe partial class ITransientResourceHeapTests
{
    /// <summary>Validates that the <see cref="ITransientResourceHeap" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ITransientResourceHeap), Marshal.SizeOf<ITransientResourceHeap>());
    }

    /// <summary>Validates that the <see cref="ITransientResourceHeap" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ITransientResourceHeap).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ITransientResourceHeap" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(ITransientResourceHeap));
        }
        else
        {
            Assert.Equal(4, sizeof(ITransientResourceHeap));
        }
    }
}
