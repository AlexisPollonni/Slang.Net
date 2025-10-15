using System;
using System.Runtime.InteropServices;
using Xunit;
using static ShaderSlang.Net.Bindings.Generated.SlangApi;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ISlangClonable" /> struct.</summary>
public static unsafe partial class ISlangClonableTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="ISlangClonable" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(ISlangClonable).GUID, IID_ISlangClonable);
    }

    /// <summary>Validates that the <see cref="ISlangClonable" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ISlangClonable), Marshal.SizeOf<ISlangClonable>());
    }

    /// <summary>Validates that the <see cref="ISlangClonable" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ISlangClonable).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ISlangClonable" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(ISlangClonable));
        }
        else
        {
            Assert.Equal(4, sizeof(ISlangClonable));
        }
    }
}
