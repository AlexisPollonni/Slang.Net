using NUnit.Framework;
using System;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IRenderPassLayout" /> struct.</summary>
public static unsafe partial class IRenderPassLayoutTests
{
    /// <summary>Validates that the <see cref="IRenderPassLayout" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<IRenderPassLayout>(), Is.EqualTo(sizeof(IRenderPassLayout)));
    }

    /// <summary>Validates that the <see cref="IRenderPassLayout" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(IRenderPassLayout).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="IRenderPassLayout" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(IRenderPassLayout), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(IRenderPassLayout), Is.EqualTo(4));
        }
    }
}
