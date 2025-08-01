using System.Runtime.InteropServices;
using Xunit;
using static SlangNet.Bindings.Generated.GfxApi;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IRayTracingCommandEncoder" /> struct.</summary>
public static unsafe partial class IRayTracingCommandEncoderTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="IRayTracingCommandEncoder" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(IRayTracingCommandEncoder).GUID, IID_IRayTracingCommandEncoder);
    }

    /// <summary>Validates that the <see cref="IRayTracingCommandEncoder" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IRayTracingCommandEncoder), Marshal.SizeOf<IRayTracingCommandEncoder>());
    }

    /// <summary>Validates that the <see cref="IRayTracingCommandEncoder" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IRayTracingCommandEncoder).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IRayTracingCommandEncoder" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IRayTracingCommandEncoder));
        }
        else
        {
            Assert.Equal(4, sizeof(IRayTracingCommandEncoder));
        }
    }
}
