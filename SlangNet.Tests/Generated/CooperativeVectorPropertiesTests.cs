using System.Runtime.InteropServices;
using NUnit.Framework;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="CooperativeVectorProperties" /> struct.</summary>
public static unsafe partial class CooperativeVectorPropertiesTests
{
    /// <summary>Validates that the <see cref="CooperativeVectorProperties" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<CooperativeVectorProperties>(), Is.EqualTo(sizeof(CooperativeVectorProperties)));
    }

    /// <summary>Validates that the <see cref="CooperativeVectorProperties" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(CooperativeVectorProperties).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="CooperativeVectorProperties" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        Assert.That(sizeof(CooperativeVectorProperties), Is.EqualTo(24));
    }
}
