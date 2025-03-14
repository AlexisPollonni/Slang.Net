using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using static SlangNet.Bindings.Generated.GfxApi;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IComputeCommandEncoder" /> struct.</summary>
public static unsafe partial class IComputeCommandEncoderTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="IComputeCommandEncoder" /> struct is correct.</summary>
    [Test]
    public static void GuidOfTest()
    {
        Assert.That(typeof(IComputeCommandEncoder).GUID, Is.EqualTo(IID_IComputeCommandEncoder));
    }

    /// <summary>Validates that the <see cref="IComputeCommandEncoder" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<IComputeCommandEncoder>(), Is.EqualTo(sizeof(IComputeCommandEncoder)));
    }

    /// <summary>Validates that the <see cref="IComputeCommandEncoder" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(IComputeCommandEncoder).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="IComputeCommandEncoder" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(IComputeCommandEncoder), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(IComputeCommandEncoder), Is.EqualTo(4));
        }
    }
}
