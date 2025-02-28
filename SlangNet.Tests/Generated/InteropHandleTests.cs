using NUnit.Framework;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="InteropHandle" /> struct.</summary>
public static unsafe partial class InteropHandleTests
{
    /// <summary>Validates that the <see cref="InteropHandle" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<InteropHandle>(), Is.EqualTo(sizeof(InteropHandle)));
    }

    /// <summary>Validates that the <see cref="InteropHandle" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(InteropHandle).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="InteropHandle" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        Assert.That(sizeof(InteropHandle), Is.EqualTo(16));
    }
}
