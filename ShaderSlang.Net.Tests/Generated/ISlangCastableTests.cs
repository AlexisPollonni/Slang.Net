using System;
using System.Runtime.InteropServices;
using Xunit;
using static ShaderSlang.Net.Bindings.Generated.SlangApi;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ISlangCastable" /> struct.</summary>
public static unsafe partial class ISlangCastableTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="ISlangCastable" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(ISlangCastable).GUID, IID_ISlangCastable);
    }

    /// <summary>Validates that the <see cref="ISlangCastable" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ISlangCastable), Marshal.SizeOf<ISlangCastable>());
    }

    /// <summary>Validates that the <see cref="ISlangCastable" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ISlangCastable).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ISlangCastable" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(ISlangCastable));
        }
        else
        {
            Assert.Equal(4, sizeof(ISlangCastable));
        }
    }
}
