using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using static SlangNet.Bindings.Generated.GfxApi;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IRayTracingCommandEncoder" /> struct.</summary>
public static unsafe partial class IRayTracingCommandEncoderTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="IRayTracingCommandEncoder" /> struct is correct.</summary>
    [Test]
    public static void GuidOfTest()
    {
        Assert.That(typeof(IRayTracingCommandEncoder).GUID, Is.EqualTo(IID_IRayTracingCommandEncoder));
    }

    /// <summary>Validates that the <see cref="IRayTracingCommandEncoder" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<IRayTracingCommandEncoder>(), Is.EqualTo(sizeof(IRayTracingCommandEncoder)));
    }

    /// <summary>Validates that the <see cref="IRayTracingCommandEncoder" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(IRayTracingCommandEncoder).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="IRayTracingCommandEncoder" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(IRayTracingCommandEncoder), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(IRayTracingCommandEncoder), Is.EqualTo(4));
        }
    }
}
