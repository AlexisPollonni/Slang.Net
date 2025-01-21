using System.Runtime.InteropServices;
using NUnit.Framework;

namespace SlangNet.Bindings.Generated.Slang.UnitTests;

/// <summary>Provides validation of the <see cref="GenericArgReflection" /> struct.</summary>
public static unsafe partial class GenericArgReflectionTests
{
    /// <summary>Validates that the <see cref="GenericArgReflection" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<GenericArgReflection>(), Is.EqualTo(sizeof(GenericArgReflection)));
    }

    /// <summary>Validates that the <see cref="GenericArgReflection" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutExplicitTest()
    {
        Assert.That(typeof(GenericArgReflection).IsExplicitLayout, Is.True);
    }

    /// <summary>Validates that the <see cref="GenericArgReflection" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(GenericArgReflection), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(GenericArgReflection), Is.EqualTo(4));
        }
    }
}
