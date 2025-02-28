using NUnit.Framework;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ResourceStateSet" /> struct.</summary>
public static unsafe partial class ResourceStateSetTests
{
    /// <summary>Validates that the <see cref="ResourceStateSet" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<ResourceStateSet>(), Is.EqualTo(sizeof(ResourceStateSet)));
    }

    /// <summary>Validates that the <see cref="ResourceStateSet" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(ResourceStateSet).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="ResourceStateSet" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        Assert.That(sizeof(ResourceStateSet), Is.EqualTo(8));
    }
}
