using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="CompilerOptionEntry" /> struct.</summary>
public static unsafe partial class CompilerOptionEntryTests
{
    /// <summary>Validates that the <see cref="CompilerOptionEntry" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(CompilerOptionEntry), Marshal.SizeOf<CompilerOptionEntry>());
    }

    /// <summary>Validates that the <see cref="CompilerOptionEntry" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(CompilerOptionEntry).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="CompilerOptionEntry" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(40, sizeof(CompilerOptionEntry));
        }
        else
        {
            Assert.Equal(24, sizeof(CompilerOptionEntry));
        }
    }
}
