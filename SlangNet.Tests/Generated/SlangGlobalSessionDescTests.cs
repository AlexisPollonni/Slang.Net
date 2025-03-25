using NUnit.Framework;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="SlangGlobalSessionDesc" /> struct.</summary>
public static unsafe partial class SlangGlobalSessionDescTests
{
    /// <summary>Validates that the <see cref="SlangGlobalSessionDesc" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<SlangGlobalSessionDesc>(), Is.EqualTo(sizeof(SlangGlobalSessionDesc)));
    }

    /// <summary>Validates that the <see cref="SlangGlobalSessionDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(SlangGlobalSessionDesc).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="SlangGlobalSessionDesc" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        Assert.That(sizeof(SlangGlobalSessionDesc), Is.EqualTo(80));
    }
}
