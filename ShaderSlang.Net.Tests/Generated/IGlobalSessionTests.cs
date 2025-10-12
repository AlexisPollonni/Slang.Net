using System;
using System.Runtime.InteropServices;
using Xunit;
using static ShaderSlang.Net.Bindings.Generated.SlangApi;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IGlobalSession" /> struct.</summary>
public static unsafe partial class IGlobalSessionTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="IGlobalSession" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(IGlobalSession).GUID, IID_IGlobalSession);
    }

    /// <summary>Validates that the <see cref="IGlobalSession" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IGlobalSession), Marshal.SizeOf<IGlobalSession>());
    }

    /// <summary>Validates that the <see cref="IGlobalSession" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IGlobalSession).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IGlobalSession" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IGlobalSession));
        }
        else
        {
            Assert.Equal(4, sizeof(IGlobalSession));
        }
    }
}
