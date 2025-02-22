using NUnit.Framework;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ClearResourceViewFlags" /> struct.</summary>
public static unsafe partial class ClearResourceViewFlagsTests
{
    /// <summary>Validates that the <see cref="ClearResourceViewFlags" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<ClearResourceViewFlags>(), Is.EqualTo(sizeof(ClearResourceViewFlags)));
    }

    /// <summary>Validates that the <see cref="ClearResourceViewFlags" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(ClearResourceViewFlags).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="ClearResourceViewFlags" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        Assert.That(sizeof(ClearResourceViewFlags), Is.EqualTo(1));
    }
}
