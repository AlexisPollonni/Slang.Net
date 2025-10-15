using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="AdapterInfo" /> struct.</summary>
public static unsafe partial class AdapterInfoTests
{
    /// <summary>Validates that the <see cref="AdapterInfo" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(AdapterInfo), Marshal.SizeOf<AdapterInfo>());
    }

    /// <summary>Validates that the <see cref="AdapterInfo" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(AdapterInfo).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="AdapterInfo" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(152, sizeof(AdapterInfo));
    }
}
