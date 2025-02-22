using NUnit.Framework;
using System;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IResourceView" /> struct.</summary>
public static unsafe partial class IResourceViewTests
{
    /// <summary>Validates that the <see cref="IResourceView" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<IResourceView>(), Is.EqualTo(sizeof(IResourceView)));
    }

    /// <summary>Validates that the <see cref="IResourceView" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(IResourceView).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="IResourceView" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(IResourceView), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(IResourceView), Is.EqualTo(4));
        }
    }
}
