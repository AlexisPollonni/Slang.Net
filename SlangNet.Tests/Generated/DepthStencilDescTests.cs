using NUnit.Framework;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="DepthStencilDesc" /> struct.</summary>
public static unsafe partial class DepthStencilDescTests
{
    /// <summary>Validates that the <see cref="DepthStencilDesc" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<DepthStencilDesc>(), Is.EqualTo(sizeof(DepthStencilDesc)));
    }

    /// <summary>Validates that the <see cref="DepthStencilDesc" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(DepthStencilDesc).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="DepthStencilDesc" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        Assert.That(sizeof(DepthStencilDesc), Is.EqualTo(24));
    }
}
