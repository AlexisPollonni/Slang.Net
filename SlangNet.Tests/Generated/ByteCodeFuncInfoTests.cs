using System.Runtime.InteropServices;
using NUnit.Framework;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ByteCodeFuncInfo" /> struct.</summary>
public static unsafe partial class ByteCodeFuncInfoTests
{
    /// <summary>Validates that the <see cref="ByteCodeFuncInfo" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<ByteCodeFuncInfo>(), Is.EqualTo(sizeof(ByteCodeFuncInfo)));
    }

    /// <summary>Validates that the <see cref="ByteCodeFuncInfo" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(ByteCodeFuncInfo).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="ByteCodeFuncInfo" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        Assert.That(sizeof(ByteCodeFuncInfo), Is.EqualTo(8));
    }
}
