using System;
using System.Runtime.InteropServices;
using Xunit;
using static ShaderSlang.Net.Bindings.Generated.GfxApi;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ICommandEncoder" /> struct.</summary>
public static unsafe partial class ICommandEncoderTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="ICommandEncoder" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(ICommandEncoder).GUID, IID_ICommandEncoder);
    }

    /// <summary>Validates that the <see cref="ICommandEncoder" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ICommandEncoder), Marshal.SizeOf<ICommandEncoder>());
    }

    /// <summary>Validates that the <see cref="ICommandEncoder" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ICommandEncoder).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ICommandEncoder" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(ICommandEncoder));
        }
        else
        {
            Assert.Equal(4, sizeof(ICommandEncoder));
        }
    }
}
