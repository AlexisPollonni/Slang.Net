using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IResource" /> struct.</summary>
public static unsafe partial class IResourceTests
{
    /// <summary>Validates that the <see cref="IResource" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IResource), Marshal.SizeOf<IResource>());
    }

    /// <summary>Validates that the <see cref="IResource" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IResource).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IResource" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IResource));
        }
        else
        {
            Assert.Equal(4, sizeof(IResource));
        }
    }
}
