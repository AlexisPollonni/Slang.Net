using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IInputLayout" /> struct.</summary>
public static unsafe partial class IInputLayoutTests
{
    /// <summary>Validates that the <see cref="IInputLayout" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IInputLayout), Marshal.SizeOf<IInputLayout>());
    }

    /// <summary>Validates that the <see cref="IInputLayout" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IInputLayout).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IInputLayout" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IInputLayout));
        }
        else
        {
            Assert.Equal(4, sizeof(IInputLayout));
        }
    }
}
