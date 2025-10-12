using System;
using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="VMExecInstHeader" /> struct.</summary>
public static unsafe partial class VMExecInstHeaderTests
{
    /// <summary>Validates that the <see cref="VMExecInstHeader" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(VMExecInstHeader), Marshal.SizeOf<VMExecInstHeader>());
    }

    /// <summary>Validates that the <see cref="VMExecInstHeader" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(VMExecInstHeader).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="VMExecInstHeader" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(16, sizeof(VMExecInstHeader));
        }
        else
        {
            Assert.Equal(12, sizeof(VMExecInstHeader));
        }
    }
}
