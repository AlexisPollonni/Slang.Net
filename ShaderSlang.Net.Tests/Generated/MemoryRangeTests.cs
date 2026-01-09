using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="MemoryRange" /> struct.</summary>
public static unsafe partial class MemoryRangeTests
{
    /// <summary>Validates that the <see cref="MemoryRange" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(MemoryRange), Marshal.SizeOf<MemoryRange>());
    }

    /// <summary>Validates that the <see cref="MemoryRange" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(MemoryRange).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="MemoryRange" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(16, sizeof(MemoryRange));
        }
        else
        {
            Assert.Equal(8, sizeof(MemoryRange));
        }
    }
}
