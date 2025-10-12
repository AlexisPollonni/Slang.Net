using System;
using System.Runtime.InteropServices;
using Xunit;
using static ShaderSlang.Net.Bindings.Generated.SlangApi;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ISlangBlob" /> struct.</summary>
public static unsafe partial class ISlangBlobTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="ISlangBlob" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(ISlangBlob).GUID, IID_ISlangBlob);
    }

    /// <summary>Validates that the <see cref="ISlangBlob" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ISlangBlob), Marshal.SizeOf<ISlangBlob>());
    }

    /// <summary>Validates that the <see cref="ISlangBlob" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ISlangBlob).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ISlangBlob" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(ISlangBlob));
        }
        else
        {
            Assert.Equal(4, sizeof(ISlangBlob));
        }
    }
}
