using System.Runtime.InteropServices;
using Xunit;
using static SlangNet.Bindings.Generated.SlangApi;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IEntryPoint" /> struct.</summary>
public static unsafe partial class IEntryPointTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="IEntryPoint" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(IEntryPoint).GUID, IID_IEntryPoint);
    }

    /// <summary>Validates that the <see cref="IEntryPoint" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IEntryPoint), Marshal.SizeOf<IEntryPoint>());
    }

    /// <summary>Validates that the <see cref="IEntryPoint" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IEntryPoint).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IEntryPoint" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IEntryPoint));
        }
        else
        {
            Assert.Equal(4, sizeof(IEntryPoint));
        }
    }
}
