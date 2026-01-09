using System;
using System.Runtime.InteropServices;
using Xunit;
using static ShaderSlang.Net.Bindings.Generated.SlangApi;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IModulePrecompileService_Experimental" /> struct.</summary>
public static unsafe partial class IModulePrecompileService_ExperimentalTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="IModulePrecompileService_Experimental" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(IModulePrecompileService_Experimental).GUID, IID_IModulePrecompileService_Experimental);
    }

    /// <summary>Validates that the <see cref="IModulePrecompileService_Experimental" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IModulePrecompileService_Experimental), Marshal.SizeOf<IModulePrecompileService_Experimental>());
    }

    /// <summary>Validates that the <see cref="IModulePrecompileService_Experimental" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IModulePrecompileService_Experimental).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IModulePrecompileService_Experimental" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IModulePrecompileService_Experimental));
        }
        else
        {
            Assert.Equal(4, sizeof(IModulePrecompileService_Experimental));
        }
    }
}
