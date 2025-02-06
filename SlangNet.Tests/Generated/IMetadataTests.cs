using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using static SlangNet.Bindings.Generated.SlangApi;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IMetadata" /> struct.</summary>
public static unsafe partial class IMetadataTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="IMetadata" /> struct is correct.</summary>
    [Test]
    public static void GuidOfTest()
    {
        Assert.That(typeof(IMetadata).GUID, Is.EqualTo(IID_IMetadata));
    }

    /// <summary>Validates that the <see cref="IMetadata" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<IMetadata>(), Is.EqualTo(sizeof(IMetadata)));
    }

    /// <summary>Validates that the <see cref="IMetadata" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(IMetadata).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="IMetadata" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(IMetadata), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(IMetadata), Is.EqualTo(4));
        }
    }
}
