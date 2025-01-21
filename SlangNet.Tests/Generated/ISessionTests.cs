using System.Runtime.InteropServices;
using NUnit.Framework;
using static SlangNet.Bindings.Generated.Slang.SlangApi;

namespace SlangNet.Bindings.Generated.Slang.UnitTests;

/// <summary>Provides validation of the <see cref="ISession" /> struct.</summary>
public static unsafe partial class ISessionTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="ISession" /> struct is correct.</summary>
    [Test]
    public static void GuidOfTest()
    {
        Assert.That(typeof(ISession).GUID, Is.EqualTo(IID_ISession));
    }

    /// <summary>Validates that the <see cref="ISession" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<ISession>(), Is.EqualTo(sizeof(ISession)));
    }

    /// <summary>Validates that the <see cref="ISession" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(ISession).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="ISession" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(ISession), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(ISession), Is.EqualTo(4));
        }
    }
}
