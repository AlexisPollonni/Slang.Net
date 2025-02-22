using NUnit.Framework;
using System;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ComputePipelineStateDesc" /> struct.</summary>
public static unsafe partial class ComputePipelineStateDescTests
{
    /// <summary>Validates that the <see cref="ComputePipelineStateDesc" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<ComputePipelineStateDesc>(), Is.EqualTo(sizeof(ComputePipelineStateDesc)));
    }

    /// <summary>Validates that the <see cref="ComputePipelineStateDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(ComputePipelineStateDesc).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="ComputePipelineStateDesc" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(ComputePipelineStateDesc), Is.EqualTo(16));
        }
        else
        {
            Assert.That(sizeof(ComputePipelineStateDesc), Is.EqualTo(8));
        }
    }
}
