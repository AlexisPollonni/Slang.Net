using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using static SlangNet.Bindings.Generated.GfxApi;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IRenderCommandEncoder" /> struct.</summary>
public static unsafe partial class IRenderCommandEncoderTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="IRenderCommandEncoder" /> struct is correct.</summary>
    [Test]
    public static void GuidOfTest()
    {
        Assert.That(typeof(IRenderCommandEncoder).GUID, Is.EqualTo(IID_IRenderCommandEncoder));
    }

    /// <summary>Validates that the <see cref="IRenderCommandEncoder" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<IRenderCommandEncoder>(), Is.EqualTo(sizeof(IRenderCommandEncoder)));
    }

    /// <summary>Validates that the <see cref="IRenderCommandEncoder" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(IRenderCommandEncoder).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="IRenderCommandEncoder" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(IRenderCommandEncoder), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(IRenderCommandEncoder), Is.EqualTo(4));
        }
    }
}
