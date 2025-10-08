using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="VMExecOperand" /> struct.</summary>
public static unsafe partial class VMExecOperandTests
{
    /// <summary>Validates that the <see cref="VMExecOperand" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(VMExecOperand), Marshal.SizeOf<VMExecOperand>());
    }

    /// <summary>Validates that the <see cref="VMExecOperand" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(VMExecOperand).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="VMExecOperand" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(16, sizeof(VMExecOperand));
        }
        else
        {
            Assert.Equal(12, sizeof(VMExecOperand));
        }
    }
}
