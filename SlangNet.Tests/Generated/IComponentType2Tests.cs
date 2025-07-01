using System.Runtime.InteropServices;
using NUnit.Framework;
using static SlangNet.Bindings.Generated.SlangApi;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IComponentType2" /> struct.</summary>
public static unsafe partial class IComponentType2Tests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="IComponentType2" /> struct is correct.</summary>
    [Test]
    public static void GuidOfTest()
    {
        Assert.That(typeof(IComponentType2).GUID, Is.EqualTo(IID_IComponentType2));
    }

    /// <summary>Validates that the <see cref="IComponentType2" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<IComponentType2>(), Is.EqualTo(sizeof(IComponentType2)));
    }

    /// <summary>Validates that the <see cref="IComponentType2" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(IComponentType2).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="IComponentType2" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(IComponentType2), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(IComponentType2), Is.EqualTo(4));
        }
    }
}
