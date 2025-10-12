using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="SlangEntryPoint" /> struct.</summary>
public static unsafe partial class SlangEntryPointTests
{
    /// <summary>Validates that the <see cref="SlangEntryPoint" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(SlangEntryPoint), Marshal.SizeOf<SlangEntryPoint>());
    }

    /// <summary>Validates that the <see cref="SlangEntryPoint" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(SlangEntryPoint).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="SlangEntryPoint" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(SlangEntryPoint));
    }
}
