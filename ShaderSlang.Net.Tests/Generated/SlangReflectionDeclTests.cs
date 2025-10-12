using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="SlangReflectionDecl" /> struct.</summary>
public static unsafe partial class SlangReflectionDeclTests
{
    /// <summary>Validates that the <see cref="SlangReflectionDecl" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(SlangReflectionDecl), Marshal.SizeOf<SlangReflectionDecl>());
    }

    /// <summary>Validates that the <see cref="SlangReflectionDecl" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(SlangReflectionDecl).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="SlangReflectionDecl" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(SlangReflectionDecl));
    }
}
