using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using static SlangNet.Bindings.Generated.Slang.SlangApi;

namespace SlangNet.Bindings.Generated.Slang.UnitTests;

/// <summary>Provides validation of the <see cref="ISlangSharedLibrary" /> struct.</summary>
public static unsafe partial class ISlangSharedLibraryTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="ISlangSharedLibrary" /> struct is correct.</summary>
    [Test]
    public static void GuidOfTest()
    {
        Assert.That(typeof(ISlangSharedLibrary).GUID, Is.EqualTo(IID_ISlangSharedLibrary));
    }

    /// <summary>Validates that the <see cref="ISlangSharedLibrary" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<ISlangSharedLibrary>(), Is.EqualTo(sizeof(ISlangSharedLibrary)));
    }

    /// <summary>Validates that the <see cref="ISlangSharedLibrary" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(ISlangSharedLibrary).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="ISlangSharedLibrary" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(ISlangSharedLibrary), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(ISlangSharedLibrary), Is.EqualTo(4));
        }
    }
}
