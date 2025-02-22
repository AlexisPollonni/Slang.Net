using NUnit.Framework;
using System;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ISwapchain" /> struct.</summary>
public static unsafe partial class ISwapchainTests
{
    /// <summary>Validates that the <see cref="ISwapchain" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<ISwapchain>(), Is.EqualTo(sizeof(ISwapchain)));
    }

    /// <summary>Validates that the <see cref="ISwapchain" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(ISwapchain).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="ISwapchain" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(ISwapchain), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(ISwapchain), Is.EqualTo(4));
        }
    }
}
