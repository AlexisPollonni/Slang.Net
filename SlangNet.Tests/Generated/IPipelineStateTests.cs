using NUnit.Framework;
using System;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IPipelineState" /> struct.</summary>
public static unsafe partial class IPipelineStateTests
{
    /// <summary>Validates that the <see cref="IPipelineState" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<IPipelineState>(), Is.EqualTo(sizeof(IPipelineState)));
    }

    /// <summary>Validates that the <see cref="IPipelineState" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(IPipelineState).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="IPipelineState" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(IPipelineState), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(IPipelineState), Is.EqualTo(4));
        }
    }
}
