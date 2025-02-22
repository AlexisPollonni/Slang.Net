using NUnit.Framework;
using System;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="RayTracingPipelineStateDesc" /> struct.</summary>
public static unsafe partial class RayTracingPipelineStateDescTests
{
    /// <summary>Validates that the <see cref="RayTracingPipelineStateDesc" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<RayTracingPipelineStateDesc>(), Is.EqualTo(sizeof(RayTracingPipelineStateDesc)));
    }

    /// <summary>Validates that the <see cref="RayTracingPipelineStateDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(RayTracingPipelineStateDesc).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="RayTracingPipelineStateDesc" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(RayTracingPipelineStateDesc), Is.EqualTo(56));
        }
        else
        {
            Assert.That(sizeof(RayTracingPipelineStateDesc), Is.EqualTo(28));
        }
    }
}
