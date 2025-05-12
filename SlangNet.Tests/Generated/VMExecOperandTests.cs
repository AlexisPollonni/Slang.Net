using System.Runtime.InteropServices;
using NUnit.Framework;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="VMExecOperand" /> struct.</summary>
public static unsafe partial class VMExecOperandTests
{
    /// <summary>Validates that the <see cref="VMExecOperand" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<VMExecOperand>(), Is.EqualTo(sizeof(VMExecOperand)));
    }

    /// <summary>Validates that the <see cref="VMExecOperand" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(VMExecOperand).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="VMExecOperand" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(VMExecOperand), Is.EqualTo(16));
        }
        else
        {
            Assert.That(sizeof(VMExecOperand), Is.EqualTo(12));
        }
    }
}
