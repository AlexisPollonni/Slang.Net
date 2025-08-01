using System.Runtime.InteropServices;
using Xunit;
using static SlangNet.Bindings.Generated.SlangApi;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ISlangMutableFileSystem" /> struct.</summary>
public static unsafe partial class ISlangMutableFileSystemTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="ISlangMutableFileSystem" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(ISlangMutableFileSystem).GUID, IID_ISlangMutableFileSystem);
    }

    /// <summary>Validates that the <see cref="ISlangMutableFileSystem" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ISlangMutableFileSystem), Marshal.SizeOf<ISlangMutableFileSystem>());
    }

    /// <summary>Validates that the <see cref="ISlangMutableFileSystem" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ISlangMutableFileSystem).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ISlangMutableFileSystem" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(ISlangMutableFileSystem));
        }
        else
        {
            Assert.Equal(4, sizeof(ISlangMutableFileSystem));
        }
    }
}
