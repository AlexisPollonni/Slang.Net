using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="D3D12DeviceExtendedDesc" /> struct.</summary>
public static unsafe partial class D3D12DeviceExtendedDescTests
{
    /// <summary>Validates that the <see cref="D3D12DeviceExtendedDesc" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(D3D12DeviceExtendedDesc), Marshal.SizeOf<D3D12DeviceExtendedDesc>());
    }

    /// <summary>Validates that the <see cref="D3D12DeviceExtendedDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(D3D12DeviceExtendedDesc).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="D3D12DeviceExtendedDesc" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(24, sizeof(D3D12DeviceExtendedDesc));
        }
        else
        {
            Assert.Equal(16, sizeof(D3D12DeviceExtendedDesc));
        }
    }
}
