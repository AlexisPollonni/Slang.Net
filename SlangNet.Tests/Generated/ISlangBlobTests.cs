using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using static SlangNet.Bindings.Generated.Slang.SlangApi;

namespace SlangNet.Bindings.Generated.Slang.UnitTests;

/// <summary>Provides validation of the <see cref="ISlangBlob" /> struct.</summary>
public static unsafe partial class ISlangBlobTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="ISlangBlob" /> struct is correct.</summary>
    [Test]
    public static void GuidOfTest()
    {
        Assert.That(typeof(ISlangBlob).GUID, Is.EqualTo(IID_ISlangBlob));
    }

    /// <summary>Validates that the <see cref="ISlangBlob" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<ISlangBlob>(), Is.EqualTo(sizeof(ISlangBlob)));
    }

    /// <summary>Validates that the <see cref="ISlangBlob" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(ISlangBlob).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="ISlangBlob" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(ISlangBlob), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(ISlangBlob), Is.EqualTo(4));
        }
    }
}
