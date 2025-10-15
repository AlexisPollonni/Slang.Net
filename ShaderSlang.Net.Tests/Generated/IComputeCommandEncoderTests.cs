using System;
using System.Runtime.InteropServices;
using Xunit;
using static ShaderSlang.Net.Bindings.Generated.GfxApi;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IComputeCommandEncoder" /> struct.</summary>
public static unsafe partial class IComputeCommandEncoderTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="IComputeCommandEncoder" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(IComputeCommandEncoder).GUID, IID_IComputeCommandEncoder);
    }

    /// <summary>Validates that the <see cref="IComputeCommandEncoder" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IComputeCommandEncoder), Marshal.SizeOf<IComputeCommandEncoder>());
    }

    /// <summary>Validates that the <see cref="IComputeCommandEncoder" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IComputeCommandEncoder).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IComputeCommandEncoder" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IComputeCommandEncoder));
        }
        else
        {
            Assert.Equal(4, sizeof(IComputeCommandEncoder));
        }
    }
}
