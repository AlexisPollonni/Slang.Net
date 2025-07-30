using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="RayTracingPipelineStateDesc" /> struct.</summary>
public static unsafe partial class RayTracingPipelineStateDescTests
{
    /// <summary>Validates that the <see cref="RayTracingPipelineStateDesc" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(RayTracingPipelineStateDesc), Marshal.SizeOf<RayTracingPipelineStateDesc>());
    }

    /// <summary>Validates that the <see cref="RayTracingPipelineStateDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(RayTracingPipelineStateDesc).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="RayTracingPipelineStateDesc" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(56, sizeof(RayTracingPipelineStateDesc));
        }
        else
        {
            Assert.Equal(28, sizeof(RayTracingPipelineStateDesc));
        }
    }
}
