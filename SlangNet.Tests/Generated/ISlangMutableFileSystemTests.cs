using System.Runtime.InteropServices;
using NUnit.Framework;
using static SlangNet.Bindings.Generated.Slang.SlangApi;

namespace SlangNet.Bindings.Generated.Slang.UnitTests;

/// <summary>Provides validation of the <see cref="ISlangMutableFileSystem" /> struct.</summary>
public static unsafe partial class ISlangMutableFileSystemTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="ISlangMutableFileSystem" /> struct is correct.</summary>
    [Test]
    public static void GuidOfTest()
    {
        Assert.That(typeof(ISlangMutableFileSystem).GUID, Is.EqualTo(IID_ISlangMutableFileSystem));
    }

    /// <summary>Validates that the <see cref="ISlangMutableFileSystem" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<ISlangMutableFileSystem>(), Is.EqualTo(sizeof(ISlangMutableFileSystem)));
    }

    /// <summary>Validates that the <see cref="ISlangMutableFileSystem" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(ISlangMutableFileSystem).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="ISlangMutableFileSystem" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(ISlangMutableFileSystem), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(ISlangMutableFileSystem), Is.EqualTo(4));
        }
    }
}
