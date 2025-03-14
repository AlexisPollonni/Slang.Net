using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using static SlangNet.Bindings.Generated.GfxApi;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ICommandEncoder" /> struct.</summary>
public static unsafe partial class ICommandEncoderTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="ICommandEncoder" /> struct is correct.</summary>
    [Test]
    public static void GuidOfTest()
    {
        Assert.That(typeof(ICommandEncoder).GUID, Is.EqualTo(IID_ICommandEncoder));
    }

    /// <summary>Validates that the <see cref="ICommandEncoder" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<ICommandEncoder>(), Is.EqualTo(sizeof(ICommandEncoder)));
    }

    /// <summary>Validates that the <see cref="ICommandEncoder" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(ICommandEncoder).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="ICommandEncoder" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(ICommandEncoder), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(ICommandEncoder), Is.EqualTo(4));
        }
    }
}
