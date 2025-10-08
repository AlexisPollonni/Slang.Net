using System.Runtime.InteropServices;
using Xunit;
using static SlangNet.Bindings.Generated.SlangApi;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IComponentType" /> struct.</summary>
public static unsafe partial class IComponentTypeTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="IComponentType" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(IComponentType).GUID, IID_IComponentType);
    }

    /// <summary>Validates that the <see cref="IComponentType" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IComponentType), Marshal.SizeOf<IComponentType>());
    }

    /// <summary>Validates that the <see cref="IComponentType" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IComponentType).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IComponentType" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IComponentType));
        }
        else
        {
            Assert.Equal(4, sizeof(IComponentType));
        }
    }
}
