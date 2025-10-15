using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ByteCodeFuncInfo" /> struct.</summary>
public static unsafe partial class ByteCodeFuncInfoTests
{
    /// <summary>Validates that the <see cref="ByteCodeFuncInfo" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(ByteCodeFuncInfo), Marshal.SizeOf<ByteCodeFuncInfo>());
    }

    /// <summary>Validates that the <see cref="ByteCodeFuncInfo" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(ByteCodeFuncInfo).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="ByteCodeFuncInfo" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(8, sizeof(ByteCodeFuncInfo));
    }
}
