using NUnit.Framework;
using System;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ShaderOffset" /> struct.</summary>
public static unsafe partial class ShaderOffsetTests
{
    /// <summary>Validates that the <see cref="ShaderOffset" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<ShaderOffset>(), Is.EqualTo(sizeof(ShaderOffset)));
    }

    /// <summary>Validates that the <see cref="ShaderOffset" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(ShaderOffset).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="ShaderOffset" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(ShaderOffset), Is.EqualTo(16));
        }
        else
        {
            Assert.That(sizeof(ShaderOffset), Is.EqualTo(12));
        }
    }
}
