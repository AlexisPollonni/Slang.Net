using System.Runtime.InteropServices;
using NUnit.Framework;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="SlangEntryPoint" /> struct.</summary>
public static unsafe partial class SlangEntryPointTests
{
    /// <summary>Validates that the <see cref="SlangEntryPoint" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<SlangEntryPoint>(), Is.EqualTo(sizeof(SlangEntryPoint)));
    }

    /// <summary>Validates that the <see cref="SlangEntryPoint" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(SlangEntryPoint).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="SlangEntryPoint" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        Assert.That(sizeof(SlangEntryPoint), Is.EqualTo(1));
    }
}
