using System;
using System.Runtime.InteropServices;
using Xunit;
using static ShaderSlang.Net.Bindings.Generated.SlangApi;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ISlangFileSystem" /> struct.</summary>
public static unsafe partial class ISlangFileSystemTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="ISlangFileSystem" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(ISlangFileSystem).GUID, IID_ISlangFileSystem);
    }

    /// <summary>Validates that the <see cref="ISlangFileSystem" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ISlangFileSystem), Marshal.SizeOf<ISlangFileSystem>());
    }

    /// <summary>Validates that the <see cref="ISlangFileSystem" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ISlangFileSystem).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ISlangFileSystem" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(ISlangFileSystem));
        }
        else
        {
            Assert.Equal(4, sizeof(ISlangFileSystem));
        }
    }
}
