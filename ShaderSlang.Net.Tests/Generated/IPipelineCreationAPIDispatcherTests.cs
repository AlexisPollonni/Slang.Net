using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IPipelineCreationAPIDispatcher" /> struct.</summary>
public static unsafe partial class IPipelineCreationAPIDispatcherTests
{
    /// <summary>Validates that the <see cref="IPipelineCreationAPIDispatcher" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IPipelineCreationAPIDispatcher), Marshal.SizeOf<IPipelineCreationAPIDispatcher>());
    }

    /// <summary>Validates that the <see cref="IPipelineCreationAPIDispatcher" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IPipelineCreationAPIDispatcher).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IPipelineCreationAPIDispatcher" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IPipelineCreationAPIDispatcher));
        }
        else
        {
            Assert.Equal(4, sizeof(IPipelineCreationAPIDispatcher));
        }
    }
}
