using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ICommandBufferD3D12" /> struct.</summary>
public static unsafe partial class ICommandBufferD3D12Tests
{
    /// <summary>Validates that the <see cref="ICommandBufferD3D12" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ICommandBufferD3D12), Marshal.SizeOf<ICommandBufferD3D12>());
    }

    /// <summary>Validates that the <see cref="ICommandBufferD3D12" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ICommandBufferD3D12).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ICommandBufferD3D12" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(ICommandBufferD3D12));
        }
        else
        {
            Assert.Equal(4, sizeof(ICommandBufferD3D12));
        }
    }
}
