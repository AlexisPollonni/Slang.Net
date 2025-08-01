using System.Runtime.InteropServices;
using Xunit;
using static SlangNet.Bindings.Generated.SlangApi;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ITypeConformance" /> struct.</summary>
public static unsafe partial class ITypeConformanceTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="ITypeConformance" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(ITypeConformance).GUID, IID_ITypeConformance);
    }

    /// <summary>Validates that the <see cref="ITypeConformance" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ITypeConformance), Marshal.SizeOf<ITypeConformance>());
    }

    /// <summary>Validates that the <see cref="ITypeConformance" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ITypeConformance).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ITypeConformance" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(ITypeConformance));
        }
        else
        {
            Assert.Equal(4, sizeof(ITypeConformance));
        }
    }
}
