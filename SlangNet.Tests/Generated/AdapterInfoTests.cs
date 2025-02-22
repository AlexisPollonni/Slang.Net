using NUnit.Framework;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="AdapterInfo" /> struct.</summary>
public static unsafe partial class AdapterInfoTests
{
    /// <summary>Validates that the <see cref="AdapterInfo" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<AdapterInfo>(), Is.EqualTo(sizeof(AdapterInfo)));
    }

    /// <summary>Validates that the <see cref="AdapterInfo" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(AdapterInfo).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="AdapterInfo" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        Assert.That(sizeof(AdapterInfo), Is.EqualTo(152));
    }
}
