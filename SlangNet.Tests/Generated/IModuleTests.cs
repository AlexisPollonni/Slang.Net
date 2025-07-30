using System.Runtime.InteropServices;
using Xunit;
using static SlangNet.Bindings.Generated.SlangApi;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IModule" /> struct.</summary>
public static unsafe partial class IModuleTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="IModule" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(IModule).GUID, IID_IModule);
    }

    /// <summary>Validates that the <see cref="IModule" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IModule), Marshal.SizeOf<IModule>());
    }

    /// <summary>Validates that the <see cref="IModule" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IModule).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IModule" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IModule));
        }
        else
        {
            Assert.Equal(4, sizeof(IModule));
        }
    }
}
