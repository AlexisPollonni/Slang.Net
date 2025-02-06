using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using static SlangNet.Bindings.Generated.SlangApi;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IModulePrecompileService_Experimental" /> struct.</summary>
public static unsafe partial class IModulePrecompileService_ExperimentalTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="IModulePrecompileService_Experimental" /> struct is correct.</summary>
    [Test]
    public static void GuidOfTest()
    {
        Assert.That(typeof(IModulePrecompileService_Experimental).GUID, Is.EqualTo(IID_IModulePrecompileService_Experimental));
    }

    /// <summary>Validates that the <see cref="IModulePrecompileService_Experimental" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<IModulePrecompileService_Experimental>(), Is.EqualTo(sizeof(IModulePrecompileService_Experimental)));
    }

    /// <summary>Validates that the <see cref="IModulePrecompileService_Experimental" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(IModulePrecompileService_Experimental).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="IModulePrecompileService_Experimental" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(IModulePrecompileService_Experimental), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(IModulePrecompileService_Experimental), Is.EqualTo(4));
        }
    }
}
