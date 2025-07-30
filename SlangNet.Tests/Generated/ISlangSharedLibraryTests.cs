using System.Runtime.InteropServices;
using Xunit;
using static SlangNet.Bindings.Generated.SlangApi;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ISlangSharedLibrary" /> struct.</summary>
public static unsafe partial class ISlangSharedLibraryTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="ISlangSharedLibrary" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(ISlangSharedLibrary).GUID, IID_ISlangSharedLibrary);
    }

    /// <summary>Validates that the <see cref="ISlangSharedLibrary" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ISlangSharedLibrary), Marshal.SizeOf<ISlangSharedLibrary>());
    }

    /// <summary>Validates that the <see cref="ISlangSharedLibrary" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ISlangSharedLibrary).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ISlangSharedLibrary" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(ISlangSharedLibrary));
        }
        else
        {
            Assert.Equal(4, sizeof(ISlangSharedLibrary));
        }
    }
}
