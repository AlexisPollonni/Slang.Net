using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="WindowHandle" /> struct.</summary>
public static unsafe partial class WindowHandleTests
{
    /// <summary>Validates that the <see cref="WindowHandle" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(WindowHandle), Marshal.SizeOf<WindowHandle>());
    }

    /// <summary>Validates that the <see cref="WindowHandle" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(WindowHandle).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="WindowHandle" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(24, sizeof(WindowHandle));
        }
        else
        {
            Assert.Equal(12, sizeof(WindowHandle));
        }
    }
}
