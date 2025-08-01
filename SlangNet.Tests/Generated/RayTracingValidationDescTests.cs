using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="RayTracingValidationDesc" /> struct.</summary>
public static unsafe partial class RayTracingValidationDescTests
{
    /// <summary>Validates that the <see cref="RayTracingValidationDesc" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(RayTracingValidationDesc), Marshal.SizeOf<RayTracingValidationDesc>());
    }

    /// <summary>Validates that the <see cref="RayTracingValidationDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(RayTracingValidationDesc).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="RayTracingValidationDesc" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(8, sizeof(RayTracingValidationDesc));
    }
}
