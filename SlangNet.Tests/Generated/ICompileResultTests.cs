using System.Runtime.InteropServices;
using NUnit.Framework;
using static SlangNet.Bindings.Generated.SlangApi;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ICompileResult" /> struct.</summary>
public static unsafe partial class ICompileResultTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="ICompileResult" /> struct is correct.</summary>
    [Test]
    public static void GuidOfTest()
    {
        Assert.That(typeof(ICompileResult).GUID, Is.EqualTo(IID_ICompileResult));
    }

    /// <summary>Validates that the <see cref="ICompileResult" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<ICompileResult>(), Is.EqualTo(sizeof(ICompileResult)));
    }

    /// <summary>Validates that the <see cref="ICompileResult" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(ICompileResult).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="ICompileResult" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(ICompileResult), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(ICompileResult), Is.EqualTo(4));
        }
    }
}
