using System;
using System.Runtime.InteropServices;
using Xunit;
using static ShaderSlang.Net.Bindings.Generated.GfxApi;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IResourceCommandEncoder" /> struct.</summary>
public static unsafe partial class IResourceCommandEncoderTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="IResourceCommandEncoder" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(IResourceCommandEncoder).GUID, IID_IResourceCommandEncoder);
    }

    /// <summary>Validates that the <see cref="IResourceCommandEncoder" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IResourceCommandEncoder), Marshal.SizeOf<IResourceCommandEncoder>());
    }

    /// <summary>Validates that the <see cref="IResourceCommandEncoder" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IResourceCommandEncoder).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IResourceCommandEncoder" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IResourceCommandEncoder));
        }
        else
        {
            Assert.Equal(4, sizeof(IResourceCommandEncoder));
        }
    }
}
