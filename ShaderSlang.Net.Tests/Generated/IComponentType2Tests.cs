using System;
using System.Runtime.InteropServices;
using Xunit;
using static ShaderSlang.Net.Bindings.Generated.SlangApi;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IComponentType2" /> struct.</summary>
public static unsafe partial class IComponentType2Tests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="IComponentType2" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(IComponentType2).GUID, IID_IComponentType2);
    }

    /// <summary>Validates that the <see cref="IComponentType2" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IComponentType2), Marshal.SizeOf<IComponentType2>());
    }

    /// <summary>Validates that the <see cref="IComponentType2" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IComponentType2).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IComponentType2" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IComponentType2));
        }
        else
        {
            Assert.Equal(4, sizeof(IComponentType2));
        }
    }
}
