using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IResourceView" /> struct.</summary>
public static unsafe partial class IResourceViewTests
{
    /// <summary>Validates that the <see cref="IResourceView" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IResourceView), Marshal.SizeOf<IResourceView>());
    }

    /// <summary>Validates that the <see cref="IResourceView" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IResourceView).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IResourceView" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IResourceView));
        }
        else
        {
            Assert.Equal(4, sizeof(IResourceView));
        }
    }
}
