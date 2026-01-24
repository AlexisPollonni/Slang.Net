using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="InteropHandle" /> struct.</summary>
public static unsafe partial class InteropHandleTests
{
    /// <summary>Validates that the <see cref="InteropHandle" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(InteropHandle), Marshal.SizeOf<InteropHandle>());
    }

    /// <summary>Validates that the <see cref="InteropHandle" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(InteropHandle).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="InteropHandle" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(16, sizeof(InteropHandle));
    }
}
