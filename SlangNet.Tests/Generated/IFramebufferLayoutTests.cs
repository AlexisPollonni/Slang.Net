using NUnit.Framework;
using System;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IFramebufferLayout" /> struct.</summary>
public static unsafe partial class IFramebufferLayoutTests
{
    /// <summary>Validates that the <see cref="IFramebufferLayout" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<IFramebufferLayout>(), Is.EqualTo(sizeof(IFramebufferLayout)));
    }

    /// <summary>Validates that the <see cref="IFramebufferLayout" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(IFramebufferLayout).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="IFramebufferLayout" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(IFramebufferLayout), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(IFramebufferLayout), Is.EqualTo(4));
        }
    }
}
