using NUnit.Framework;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="SlangProgramLayout" /> struct.</summary>
public static unsafe partial class SlangProgramLayoutTests
{
    /// <summary>Validates that the <see cref="SlangProgramLayout" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<SlangProgramLayout>(), Is.EqualTo(sizeof(SlangProgramLayout)));
    }

    /// <summary>Validates that the <see cref="SlangProgramLayout" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(SlangProgramLayout).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="SlangProgramLayout" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        Assert.That(sizeof(SlangProgramLayout), Is.EqualTo(1));
    }
}
