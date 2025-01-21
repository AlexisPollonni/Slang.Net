using System.Runtime.InteropServices;
using NUnit.Framework;

namespace SlangNet.Bindings.Generated.Slang.UnitTests;

/// <summary>Provides validation of the <see cref="SlangAttribute" /> struct.</summary>
public static unsafe partial class SlangAttributeTests
{
    /// <summary>Validates that the <see cref="SlangAttribute" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<SlangAttribute>(), Is.EqualTo(sizeof(SlangAttribute)));
    }

    /// <summary>Validates that the <see cref="SlangAttribute" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(SlangAttribute).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="SlangAttribute" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        Assert.That(sizeof(SlangAttribute), Is.EqualTo(1));
    }
}
