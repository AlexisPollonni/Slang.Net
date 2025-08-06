using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IndirectDrawArguments" /> struct.</summary>
public static unsafe partial class IndirectDrawArgumentsTests
{
    /// <summary>Validates that the <see cref="IndirectDrawArguments" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IndirectDrawArguments), Marshal.SizeOf<IndirectDrawArguments>());
    }

    /// <summary>Validates that the <see cref="IndirectDrawArguments" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IndirectDrawArguments).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IndirectDrawArguments" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(16, sizeof(IndirectDrawArguments));
    }
}
