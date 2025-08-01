using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IndirectDrawIndexedArguments" /> struct.</summary>
public static unsafe partial class IndirectDrawIndexedArgumentsTests
{
    /// <summary>Validates that the <see cref="IndirectDrawIndexedArguments" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IndirectDrawIndexedArguments), Marshal.SizeOf<IndirectDrawIndexedArguments>());
    }

    /// <summary>Validates that the <see cref="IndirectDrawIndexedArguments" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IndirectDrawIndexedArguments).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IndirectDrawIndexedArguments" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(20, sizeof(IndirectDrawIndexedArguments));
    }
}
