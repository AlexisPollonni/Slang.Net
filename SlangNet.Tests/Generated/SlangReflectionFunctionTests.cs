using NUnit.Framework;
using System.Runtime.InteropServices;

namespace SlangNet.Unsafe.UnitTests;

/// <summary>Provides validation of the <see cref="SlangReflectionFunction" /> struct.</summary>
public static unsafe partial class SlangReflectionFunctionTests
{
    /// <summary>Validates that the <see cref="SlangReflectionFunction" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<SlangReflectionFunction>(), Is.EqualTo(sizeof(SlangReflectionFunction)));
    }

    /// <summary>Validates that the <see cref="SlangReflectionFunction" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(SlangReflectionFunction).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="SlangReflectionFunction" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        Assert.That(sizeof(SlangReflectionFunction), Is.EqualTo(1));
    }
}
