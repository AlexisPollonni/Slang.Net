using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using static SlangNet.Bindings.Generated.GfxApi;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IResourceCommandEncoder" /> struct.</summary>
public static unsafe partial class IResourceCommandEncoderTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="IResourceCommandEncoder" /> struct is correct.</summary>
    [Test]
    public static void GuidOfTest()
    {
        Assert.That(typeof(IResourceCommandEncoder).GUID, Is.EqualTo(IID_IResourceCommandEncoder));
    }

    /// <summary>Validates that the <see cref="IResourceCommandEncoder" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<IResourceCommandEncoder>(), Is.EqualTo(sizeof(IResourceCommandEncoder)));
    }

    /// <summary>Validates that the <see cref="IResourceCommandEncoder" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(IResourceCommandEncoder).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="IResourceCommandEncoder" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(IResourceCommandEncoder), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(IResourceCommandEncoder), Is.EqualTo(4));
        }
    }
}
