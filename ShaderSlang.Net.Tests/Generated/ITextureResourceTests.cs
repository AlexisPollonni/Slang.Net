using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ITextureResource" /> struct.</summary>
public static unsafe partial class ITextureResourceTests
{
    /// <summary>Validates that the <see cref="ITextureResource" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ITextureResource), Marshal.SizeOf<ITextureResource>());
    }

    /// <summary>Validates that the <see cref="ITextureResource" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ITextureResource).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ITextureResource" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(ITextureResource));
        }
        else
        {
            Assert.Equal(4, sizeof(ITextureResource));
        }
    }
}
