using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IndirectDispatchArguments" /> struct.</summary>
public static unsafe partial class IndirectDispatchArgumentsTests
{
    /// <summary>Validates that the <see cref="IndirectDispatchArguments" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(
            sizeof(IndirectDispatchArguments),
            Marshal.SizeOf<IndirectDispatchArguments>()
        );
    }

    /// <summary>Validates that the <see cref="IndirectDispatchArguments" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IndirectDispatchArguments).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IndirectDispatchArguments" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(12, sizeof(IndirectDispatchArguments));
    }
}
