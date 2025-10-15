using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IBufferResource" /> struct.</summary>
public static unsafe partial class IBufferResourceTests
{
    /// <summary>Validates that the <see cref="IBufferResource" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IBufferResource), Marshal.SizeOf<IBufferResource>());
    }

    /// <summary>Validates that the <see cref="IBufferResource" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IBufferResource).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IBufferResource" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IBufferResource));
        }
        else
        {
            Assert.Equal(4, sizeof(IBufferResource));
        }
    }
}
