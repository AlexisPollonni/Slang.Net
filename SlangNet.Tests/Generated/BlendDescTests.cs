using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="BlendDesc" /> struct.</summary>
public static unsafe partial class BlendDescTests
{
    /// <summary>Validates that the <see cref="BlendDesc" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(BlendDesc), Marshal.SizeOf<BlendDesc>());
    }

    /// <summary>Validates that the <see cref="BlendDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(BlendDesc).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="BlendDesc" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(296, sizeof(BlendDesc));
    }
}
