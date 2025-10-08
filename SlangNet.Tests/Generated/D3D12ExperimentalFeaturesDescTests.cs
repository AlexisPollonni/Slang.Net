using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="D3D12ExperimentalFeaturesDesc" /> struct.</summary>
public static unsafe partial class D3D12ExperimentalFeaturesDescTests
{
    /// <summary>Validates that the <see cref="D3D12ExperimentalFeaturesDesc" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(D3D12ExperimentalFeaturesDesc), Marshal.SizeOf<D3D12ExperimentalFeaturesDesc>());
    }

    /// <summary>Validates that the <see cref="D3D12ExperimentalFeaturesDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(D3D12ExperimentalFeaturesDesc).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="D3D12ExperimentalFeaturesDesc" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(32, sizeof(D3D12ExperimentalFeaturesDesc));
        }
        else
        {
            Assert.Equal(20, sizeof(D3D12ExperimentalFeaturesDesc));
        }
    }
}
