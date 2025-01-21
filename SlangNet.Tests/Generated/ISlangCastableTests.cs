using System.Runtime.InteropServices;
using NUnit.Framework;
using static SlangNet.Bindings.Generated.Slang.SlangApi;

namespace SlangNet.Bindings.Generated.Slang.UnitTests;

/// <summary>Provides validation of the <see cref="ISlangCastable" /> struct.</summary>
public static unsafe partial class ISlangCastableTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="ISlangCastable" /> struct is correct.</summary>
    [Test]
    public static void GuidOfTest()
    {
        Assert.That(typeof(ISlangCastable).GUID, Is.EqualTo(IID_ISlangCastable));
    }

    /// <summary>Validates that the <see cref="ISlangCastable" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<ISlangCastable>(), Is.EqualTo(sizeof(ISlangCastable)));
    }

    /// <summary>Validates that the <see cref="ISlangCastable" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(ISlangCastable).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="ISlangCastable" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(ISlangCastable), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(ISlangCastable), Is.EqualTo(4));
        }
    }
}
