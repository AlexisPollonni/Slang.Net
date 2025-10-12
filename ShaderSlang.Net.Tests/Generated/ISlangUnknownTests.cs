using System;
using System.Runtime.InteropServices;
using Xunit;
using static ShaderSlang.Net.Bindings.Generated.SlangApi;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ISlangUnknown" /> struct.</summary>
public static unsafe partial class ISlangUnknownTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="ISlangUnknown" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(ISlangUnknown).GUID, IID_ISlangUnknown);
    }

    /// <summary>Validates that the <see cref="ISlangUnknown" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ISlangUnknown), Marshal.SizeOf<ISlangUnknown>());
    }

    /// <summary>Validates that the <see cref="ISlangUnknown" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ISlangUnknown).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ISlangUnknown" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(ISlangUnknown));
        }
        else
        {
            Assert.Equal(4, sizeof(ISlangUnknown));
        }
    }
}
