using System;
using System.Runtime.InteropServices;
using Xunit;
using static ShaderSlang.Net.Bindings.Generated.SlangApi;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ISlangProfiler" /> struct.</summary>
public static unsafe partial class ISlangProfilerTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="ISlangProfiler" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(ISlangProfiler).GUID, IID_ISlangProfiler);
    }

    /// <summary>Validates that the <see cref="ISlangProfiler" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ISlangProfiler), Marshal.SizeOf<ISlangProfiler>());
    }

    /// <summary>Validates that the <see cref="ISlangProfiler" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ISlangProfiler).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ISlangProfiler" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(ISlangProfiler));
        }
        else
        {
            Assert.Equal(4, sizeof(ISlangProfiler));
        }
    }
}
