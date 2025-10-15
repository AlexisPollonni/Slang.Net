using System;
using System.Runtime.InteropServices;
using Xunit;
using static ShaderSlang.Net.Bindings.Generated.SlangApi;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ICompileRequest" /> struct.</summary>
public static unsafe partial class ICompileRequestTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="ICompileRequest" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(ICompileRequest).GUID, IID_ICompileRequest);
    }

    /// <summary>Validates that the <see cref="ICompileRequest" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ICompileRequest), Marshal.SizeOf<ICompileRequest>());
    }

    /// <summary>Validates that the <see cref="ICompileRequest" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ICompileRequest).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ICompileRequest" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(ICompileRequest));
        }
        else
        {
            Assert.Equal(4, sizeof(ICompileRequest));
        }
    }
}
