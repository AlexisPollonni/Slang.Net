using System;
using System.Runtime.InteropServices;
using Xunit;
using static ShaderSlang.Net.Bindings.Generated.SlangApi;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ISlangWriter" /> struct.</summary>
public static unsafe partial class ISlangWriterTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="ISlangWriter" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(ISlangWriter).GUID, IID_ISlangWriter);
    }

    /// <summary>Validates that the <see cref="ISlangWriter" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ISlangWriter), Marshal.SizeOf<ISlangWriter>());
    }

    /// <summary>Validates that the <see cref="ISlangWriter" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ISlangWriter).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ISlangWriter" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(ISlangWriter));
        }
        else
        {
            Assert.Equal(4, sizeof(ISlangWriter));
        }
    }
}
