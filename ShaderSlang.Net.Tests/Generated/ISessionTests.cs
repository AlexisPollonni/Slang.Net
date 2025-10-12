using System;
using System.Runtime.InteropServices;
using Xunit;
using static ShaderSlang.Net.Bindings.Generated.SlangApi;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ISession" /> struct.</summary>
public static unsafe partial class ISessionTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="ISession" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(ISession).GUID, IID_ISession);
    }

    /// <summary>Validates that the <see cref="ISession" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ISession), Marshal.SizeOf<ISession>());
    }

    /// <summary>Validates that the <see cref="ISession" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ISession).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ISession" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(ISession));
        }
        else
        {
            Assert.Equal(4, sizeof(ISession));
        }
    }
}
