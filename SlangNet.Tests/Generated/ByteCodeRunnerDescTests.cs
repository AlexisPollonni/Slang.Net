using System.Runtime.InteropServices;
using NUnit.Framework;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ByteCodeRunnerDesc" /> struct.</summary>
public static unsafe partial class ByteCodeRunnerDescTests
{
    /// <summary>Validates that the <see cref="ByteCodeRunnerDesc" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<ByteCodeRunnerDesc>(), Is.EqualTo(sizeof(ByteCodeRunnerDesc)));
    }

    /// <summary>Validates that the <see cref="ByteCodeRunnerDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(ByteCodeRunnerDesc).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="ByteCodeRunnerDesc" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(ByteCodeRunnerDesc), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(ByteCodeRunnerDesc), Is.EqualTo(4));
        }
    }
}
