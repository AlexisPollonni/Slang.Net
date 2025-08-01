using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="VertexStreamDesc" /> struct.</summary>
public static unsafe partial class VertexStreamDescTests
{
    /// <summary>Validates that the <see cref="VertexStreamDesc" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(VertexStreamDesc), Marshal.SizeOf<VertexStreamDesc>());
    }

    /// <summary>Validates that the <see cref="VertexStreamDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(VertexStreamDesc).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="VertexStreamDesc" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(16, sizeof(VertexStreamDesc));
        }
        else
        {
            Assert.Equal(12, sizeof(VertexStreamDesc));
        }
    }
}
