using System.Runtime.InteropServices;
using Xunit;
using static SlangNet.Bindings.Generated.SlangApi;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ISlangSharedLibraryLoader" /> struct.</summary>
public static unsafe partial class ISlangSharedLibraryLoaderTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="ISlangSharedLibraryLoader" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(ISlangSharedLibraryLoader).GUID, IID_ISlangSharedLibraryLoader);
    }

    /// <summary>Validates that the <see cref="ISlangSharedLibraryLoader" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ISlangSharedLibraryLoader), Marshal.SizeOf<ISlangSharedLibraryLoader>());
    }

    /// <summary>Validates that the <see cref="ISlangSharedLibraryLoader" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ISlangSharedLibraryLoader).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ISlangSharedLibraryLoader" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(ISlangSharedLibraryLoader));
        }
        else
        {
            Assert.Equal(4, sizeof(ISlangSharedLibraryLoader));
        }
    }
}
