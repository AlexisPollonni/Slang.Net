using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="GraphicsPipelineStateDesc" /> struct.</summary>
public static unsafe partial class GraphicsPipelineStateDescTests
{
    /// <summary>Validates that the <see cref="GraphicsPipelineStateDesc" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(
            sizeof(GraphicsPipelineStateDesc),
            Marshal.SizeOf<GraphicsPipelineStateDesc>()
        );
    }

    /// <summary>Validates that the <see cref="GraphicsPipelineStateDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(GraphicsPipelineStateDesc).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="GraphicsPipelineStateDesc" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(376, sizeof(GraphicsPipelineStateDesc));
        }
        else
        {
            Assert.Equal(364, sizeof(GraphicsPipelineStateDesc));
        }
    }
}
