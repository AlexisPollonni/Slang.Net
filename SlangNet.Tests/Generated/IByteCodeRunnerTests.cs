using System.Runtime.InteropServices;
using NUnit.Framework;
using static SlangNet.Bindings.Generated.SlangApi;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IByteCodeRunner" /> struct.</summary>
public static unsafe partial class IByteCodeRunnerTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="IByteCodeRunner" /> struct is correct.</summary>
    [Test]
    public static void GuidOfTest()
    {
        Assert.That(typeof(IByteCodeRunner).GUID, Is.EqualTo(IID_IByteCodeRunner));
    }

    /// <summary>Validates that the <see cref="IByteCodeRunner" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<IByteCodeRunner>(), Is.EqualTo(sizeof(IByteCodeRunner)));
    }

    /// <summary>Validates that the <see cref="IByteCodeRunner" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(IByteCodeRunner).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="IByteCodeRunner" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(IByteCodeRunner), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(IByteCodeRunner), Is.EqualTo(4));
        }
    }
}
