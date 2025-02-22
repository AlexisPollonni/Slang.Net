using NUnit.Framework;
using System;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ISamplerState" /> struct.</summary>
public static unsafe partial class ISamplerStateTests
{
    /// <summary>Validates that the <see cref="ISamplerState" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<ISamplerState>(), Is.EqualTo(sizeof(ISamplerState)));
    }

    /// <summary>Validates that the <see cref="ISamplerState" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(ISamplerState).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="ISamplerState" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(ISamplerState), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(ISamplerState), Is.EqualTo(4));
        }
    }
}
