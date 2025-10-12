using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="SlangProgramLayout" /> struct.</summary>
public static unsafe partial class SlangProgramLayoutTests
{
    /// <summary>Validates that the <see cref="SlangProgramLayout" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(SlangProgramLayout), Marshal.SizeOf<SlangProgramLayout>());
    }

    /// <summary>Validates that the <see cref="SlangProgramLayout" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(SlangProgramLayout).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="SlangProgramLayout" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(SlangProgramLayout));
    }
}
