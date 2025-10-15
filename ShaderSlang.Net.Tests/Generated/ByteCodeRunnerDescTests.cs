using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ByteCodeRunnerDesc" /> struct.</summary>
public static unsafe partial class ByteCodeRunnerDescTests
{
    /// <summary>Validates that the <see cref="ByteCodeRunnerDesc" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ByteCodeRunnerDesc), Marshal.SizeOf<ByteCodeRunnerDesc>());
    }

    /// <summary>Validates that the <see cref="ByteCodeRunnerDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ByteCodeRunnerDesc).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ByteCodeRunnerDesc" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(ByteCodeRunnerDesc));
        }
        else
        {
            Assert.Equal(4, sizeof(ByteCodeRunnerDesc));
        }
    }
}
