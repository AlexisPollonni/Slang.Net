using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IShaderTable" /> struct.</summary>
public static unsafe partial class IShaderTableTests
{
    /// <summary>Validates that the <see cref="IShaderTable" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IShaderTable), Marshal.SizeOf<IShaderTable>());
    }

    /// <summary>Validates that the <see cref="IShaderTable" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IShaderTable).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IShaderTable" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IShaderTable));
        }
        else
        {
            Assert.Equal(4, sizeof(IShaderTable));
        }
    }
}
