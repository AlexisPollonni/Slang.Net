using System;
using System.Runtime.InteropServices;
using Xunit;
using static ShaderSlang.Net.Bindings.Generated.SlangApi;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IMetadata" /> struct.</summary>
public static unsafe partial class IMetadataTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="IMetadata" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(IMetadata).GUID, IID_IMetadata);
    }

    /// <summary>Validates that the <see cref="IMetadata" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IMetadata), Marshal.SizeOf<IMetadata>());
    }

    /// <summary>Validates that the <see cref="IMetadata" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IMetadata).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IMetadata" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IMetadata));
        }
        else
        {
            Assert.Equal(4, sizeof(IMetadata));
        }
    }
}
