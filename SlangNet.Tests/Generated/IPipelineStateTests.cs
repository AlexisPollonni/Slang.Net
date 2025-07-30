using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IPipelineState" /> struct.</summary>
public static unsafe partial class IPipelineStateTests
{
    /// <summary>Validates that the <see cref="IPipelineState" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IPipelineState), Marshal.SizeOf<IPipelineState>());
    }

    /// <summary>Validates that the <see cref="IPipelineState" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IPipelineState).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IPipelineState" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IPipelineState));
        }
        else
        {
            Assert.Equal(4, sizeof(IPipelineState));
        }
    }
}
