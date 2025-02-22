using NUnit.Framework;
using System;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IShaderCache" /> struct.</summary>
public static unsafe partial class IShaderCacheTests
{
    /// <summary>Validates that the <see cref="IShaderCache" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<IShaderCache>(), Is.EqualTo(sizeof(IShaderCache)));
    }

    /// <summary>Validates that the <see cref="IShaderCache" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(IShaderCache).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="IShaderCache" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(IShaderCache), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(IShaderCache), Is.EqualTo(4));
        }
    }
}
