using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="BufferRange" /> struct.</summary>
public static unsafe partial class BufferRangeTests
{
    /// <summary>Validates that the <see cref="BufferRange" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(BufferRange), Marshal.SizeOf<BufferRange>());
    }

    /// <summary>Validates that the <see cref="BufferRange" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(BufferRange).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="BufferRange" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(16, sizeof(BufferRange));
        }
        else
        {
            Assert.Equal(8, sizeof(BufferRange));
        }
    }
}
