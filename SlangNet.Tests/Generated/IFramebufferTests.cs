using NUnit.Framework;
using System;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IFramebuffer" /> struct.</summary>
public static unsafe partial class IFramebufferTests
{
    /// <summary>Validates that the <see cref="IFramebuffer" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<IFramebuffer>(), Is.EqualTo(sizeof(IFramebuffer)));
    }

    /// <summary>Validates that the <see cref="IFramebuffer" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(IFramebuffer).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="IFramebuffer" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(IFramebuffer), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(IFramebuffer), Is.EqualTo(4));
        }
    }
}
