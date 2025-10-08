using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="TargetBlendDesc" /> struct.</summary>
public static unsafe partial class TargetBlendDescTests
{
    /// <summary>Validates that the <see cref="TargetBlendDesc" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(TargetBlendDesc), Marshal.SizeOf<TargetBlendDesc>());
    }

    /// <summary>Validates that the <see cref="TargetBlendDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(TargetBlendDesc).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="TargetBlendDesc" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(36, sizeof(TargetBlendDesc));
    }
}
