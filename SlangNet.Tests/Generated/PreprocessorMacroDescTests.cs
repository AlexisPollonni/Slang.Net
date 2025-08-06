using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="PreprocessorMacroDesc" /> struct.</summary>
public static unsafe partial class PreprocessorMacroDescTests
{
    /// <summary>Validates that the <see cref="PreprocessorMacroDesc" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(PreprocessorMacroDesc), Marshal.SizeOf<PreprocessorMacroDesc>());
    }

    /// <summary>Validates that the <see cref="PreprocessorMacroDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(PreprocessorMacroDesc).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="PreprocessorMacroDesc" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(16, sizeof(PreprocessorMacroDesc));
        }
        else
        {
            Assert.Equal(8, sizeof(PreprocessorMacroDesc));
        }
    }
}
