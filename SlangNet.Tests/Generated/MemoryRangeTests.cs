using NUnit.Framework;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="MemoryRange" /> struct.</summary>
public static unsafe partial class MemoryRangeTests
{
    /// <summary>Validates that the <see cref="MemoryRange" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<MemoryRange>(), Is.EqualTo(sizeof(MemoryRange)));
    }

    /// <summary>Validates that the <see cref="MemoryRange" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(MemoryRange).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="MemoryRange" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        Assert.That(sizeof(MemoryRange), Is.EqualTo(16));
    }
}
