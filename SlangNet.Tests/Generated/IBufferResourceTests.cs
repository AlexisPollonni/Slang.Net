using NUnit.Framework;
using System;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IBufferResource" /> struct.</summary>
public static unsafe partial class IBufferResourceTests
{
    /// <summary>Validates that the <see cref="IBufferResource" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<IBufferResource>(), Is.EqualTo(sizeof(IBufferResource)));
    }

    /// <summary>Validates that the <see cref="IBufferResource" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(IBufferResource).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="IBufferResource" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(IBufferResource), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(IBufferResource), Is.EqualTo(4));
        }
    }
}
