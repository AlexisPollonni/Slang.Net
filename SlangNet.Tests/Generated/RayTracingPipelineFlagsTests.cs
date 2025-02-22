using NUnit.Framework;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="RayTracingPipelineFlags" /> struct.</summary>
public static unsafe partial class RayTracingPipelineFlagsTests
{
    /// <summary>Validates that the <see cref="RayTracingPipelineFlags" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<RayTracingPipelineFlags>(), Is.EqualTo(sizeof(RayTracingPipelineFlags)));
    }

    /// <summary>Validates that the <see cref="RayTracingPipelineFlags" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(RayTracingPipelineFlags).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="RayTracingPipelineFlags" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        Assert.That(sizeof(RayTracingPipelineFlags), Is.EqualTo(1));
    }
}
