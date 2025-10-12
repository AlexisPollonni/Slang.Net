using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IRenderPassLayout" /> struct.</summary>
public static unsafe partial class IRenderPassLayoutTests
{
    /// <summary>Validates that the <see cref="IRenderPassLayout" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IRenderPassLayout), Marshal.SizeOf<IRenderPassLayout>());
    }

    /// <summary>Validates that the <see cref="IRenderPassLayout" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IRenderPassLayout).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IRenderPassLayout" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IRenderPassLayout));
        }
        else
        {
            Assert.Equal(4, sizeof(IRenderPassLayout));
        }
    }
}
