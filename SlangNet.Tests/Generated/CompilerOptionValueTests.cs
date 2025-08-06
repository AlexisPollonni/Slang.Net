using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="CompilerOptionValue" /> struct.</summary>
public static unsafe partial class CompilerOptionValueTests
{
    /// <summary>Validates that the <see cref="CompilerOptionValue" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(CompilerOptionValue), Marshal.SizeOf<CompilerOptionValue>());
    }

    /// <summary>Validates that the <see cref="CompilerOptionValue" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(CompilerOptionValue).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="CompilerOptionValue" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(32, sizeof(CompilerOptionValue));
        }
        else
        {
            Assert.Equal(20, sizeof(CompilerOptionValue));
        }
    }
}
