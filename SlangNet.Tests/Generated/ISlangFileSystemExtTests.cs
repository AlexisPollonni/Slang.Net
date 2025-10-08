using System.Runtime.InteropServices;
using Xunit;
using static SlangNet.Bindings.Generated.SlangApi;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ISlangFileSystemExt" /> struct.</summary>
public static unsafe partial class ISlangFileSystemExtTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="ISlangFileSystemExt" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(ISlangFileSystemExt).GUID, IID_ISlangFileSystemExt);
    }

    /// <summary>Validates that the <see cref="ISlangFileSystemExt" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ISlangFileSystemExt), Marshal.SizeOf<ISlangFileSystemExt>());
    }

    /// <summary>Validates that the <see cref="ISlangFileSystemExt" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ISlangFileSystemExt).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ISlangFileSystemExt" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(ISlangFileSystemExt));
        }
        else
        {
            Assert.Equal(4, sizeof(ISlangFileSystemExt));
        }
    }
}
