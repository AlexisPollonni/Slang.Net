using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="GenericArgReflection" /> struct.</summary>
public static unsafe partial class GenericArgReflectionTests
{
    /// <summary>Validates that the <see cref="GenericArgReflection" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(GenericArgReflection), Marshal.SizeOf<GenericArgReflection>());
    }

    /// <summary>Validates that the <see cref="GenericArgReflection" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutExplicitTest()
    {
        Assert.True(typeof(GenericArgReflection).IsExplicitLayout);
    }

    /// <summary>Validates that the <see cref="GenericArgReflection" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(GenericArgReflection));
        }
        else
        {
            Assert.Equal(4, sizeof(GenericArgReflection));
        }
    }
}
