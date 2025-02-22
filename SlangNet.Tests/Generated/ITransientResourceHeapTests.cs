using NUnit.Framework;
using System;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ITransientResourceHeap" /> struct.</summary>
public static unsafe partial class ITransientResourceHeapTests
{
    /// <summary>Validates that the <see cref="ITransientResourceHeap" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<ITransientResourceHeap>(), Is.EqualTo(sizeof(ITransientResourceHeap)));
    }

    /// <summary>Validates that the <see cref="ITransientResourceHeap" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(ITransientResourceHeap).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="ITransientResourceHeap" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(ITransientResourceHeap), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(ITransientResourceHeap), Is.EqualTo(4));
        }
    }
}
