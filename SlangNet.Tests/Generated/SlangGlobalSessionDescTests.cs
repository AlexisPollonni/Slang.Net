using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="SlangGlobalSessionDesc" /> struct.</summary>
public static unsafe partial class SlangGlobalSessionDescTests
{
    /// <summary>Validates that the <see cref="SlangGlobalSessionDesc" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(SlangGlobalSessionDesc), Marshal.SizeOf<SlangGlobalSessionDesc>());
    }

    /// <summary>Validates that the <see cref="SlangGlobalSessionDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(SlangGlobalSessionDesc).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="SlangGlobalSessionDesc" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(80, sizeof(SlangGlobalSessionDesc));
    }
}
