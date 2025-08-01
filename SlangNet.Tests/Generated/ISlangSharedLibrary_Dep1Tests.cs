using System.Runtime.InteropServices;
using Xunit;
using static SlangNet.Bindings.Generated.SlangApi;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ISlangSharedLibrary_Dep1" /> struct.</summary>
public static unsafe partial class ISlangSharedLibrary_Dep1Tests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="ISlangSharedLibrary_Dep1" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(ISlangSharedLibrary_Dep1).GUID, IID_ISlangSharedLibrary_Dep1);
    }

    /// <summary>Validates that the <see cref="ISlangSharedLibrary_Dep1" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ISlangSharedLibrary_Dep1), Marshal.SizeOf<ISlangSharedLibrary_Dep1>());
    }

    /// <summary>Validates that the <see cref="ISlangSharedLibrary_Dep1" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ISlangSharedLibrary_Dep1).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ISlangSharedLibrary_Dep1" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(ISlangSharedLibrary_Dep1));
        }
        else
        {
            Assert.Equal(4, sizeof(ISlangSharedLibrary_Dep1));
        }
    }
}
