using System.Runtime.InteropServices;
using NUnit.Framework;
using static SlangNet.Bindings.Generated.Slang.SlangApi;

namespace SlangNet.Bindings.Generated.Slang.UnitTests;

/// <summary>Provides validation of the <see cref="IComponentType" /> struct.</summary>
public static unsafe partial class IComponentTypeTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="IComponentType" /> struct is correct.</summary>
    [Test]
    public static void GuidOfTest()
    {
        Assert.That(typeof(IComponentType).GUID, Is.EqualTo(IID_IComponentType));
    }

    /// <summary>Validates that the <see cref="IComponentType" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<IComponentType>(), Is.EqualTo(sizeof(IComponentType)));
    }

    /// <summary>Validates that the <see cref="IComponentType" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(IComponentType).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="IComponentType" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(IComponentType), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(IComponentType), Is.EqualTo(4));
        }
    }
}
