using NUnit.Framework;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="TargetBlendDesc" /> struct.</summary>
public static unsafe partial class TargetBlendDescTests
{
    /// <summary>Validates that the <see cref="TargetBlendDesc" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<TargetBlendDesc>(), Is.EqualTo(sizeof(TargetBlendDesc)));
    }

    /// <summary>Validates that the <see cref="TargetBlendDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(TargetBlendDesc).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="TargetBlendDesc" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        Assert.That(sizeof(TargetBlendDesc), Is.EqualTo(36));
    }
}
