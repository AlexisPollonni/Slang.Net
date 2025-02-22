using NUnit.Framework;
using System;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ITextureResource" /> struct.</summary>
public static unsafe partial class ITextureResourceTests
{
    /// <summary>Validates that the <see cref="ITextureResource" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<ITextureResource>(), Is.EqualTo(sizeof(ITextureResource)));
    }

    /// <summary>Validates that the <see cref="ITextureResource" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(ITextureResource).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="ITextureResource" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(ITextureResource), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(ITextureResource), Is.EqualTo(4));
        }
    }
}
