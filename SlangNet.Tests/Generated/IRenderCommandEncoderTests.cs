using System.Runtime.InteropServices;
using Xunit;
using static SlangNet.Bindings.Generated.GfxApi;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IRenderCommandEncoder" /> struct.</summary>
public static unsafe partial class IRenderCommandEncoderTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="IRenderCommandEncoder" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(IRenderCommandEncoder).GUID, IID_IRenderCommandEncoder);
    }

    /// <summary>Validates that the <see cref="IRenderCommandEncoder" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IRenderCommandEncoder), Marshal.SizeOf<IRenderCommandEncoder>());
    }

    /// <summary>Validates that the <see cref="IRenderCommandEncoder" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IRenderCommandEncoder).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IRenderCommandEncoder" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IRenderCommandEncoder));
        }
        else
        {
            Assert.Equal(4, sizeof(IRenderCommandEncoder));
        }
    }
}
