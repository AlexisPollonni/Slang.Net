using NUnit.Framework;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="BlendDesc" /> struct.</summary>
public static unsafe partial class BlendDescTests
{
    /// <summary>Validates that the <see cref="BlendDesc" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<BlendDesc>(), Is.EqualTo(sizeof(BlendDesc)));
    }

    /// <summary>Validates that the <see cref="BlendDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(BlendDesc).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="BlendDesc" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        Assert.That(sizeof(BlendDesc), Is.EqualTo(296));
    }
}
