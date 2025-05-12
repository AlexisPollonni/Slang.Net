using System.Runtime.InteropServices;
using NUnit.Framework;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="VMExecInstHeader" /> struct.</summary>
public static unsafe partial class VMExecInstHeaderTests
{
    /// <summary>Validates that the <see cref="VMExecInstHeader" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<VMExecInstHeader>(), Is.EqualTo(sizeof(VMExecInstHeader)));
    }

    /// <summary>Validates that the <see cref="VMExecInstHeader" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(VMExecInstHeader).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="VMExecInstHeader" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(VMExecInstHeader), Is.EqualTo(16));
        }
        else
        {
            Assert.That(sizeof(VMExecInstHeader), Is.EqualTo(12));
        }
    }
}
