using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="InputElementDesc" /> struct.</summary>
public static unsafe partial class InputElementDescTests
{
    /// <summary>Validates that the <see cref="InputElementDesc" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(InputElementDesc), Marshal.SizeOf<InputElementDesc>());
    }

    /// <summary>Validates that the <see cref="InputElementDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(InputElementDesc).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="InputElementDesc" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(32, sizeof(InputElementDesc));
        }
        else
        {
            Assert.Equal(20, sizeof(InputElementDesc));
        }
    }
}
