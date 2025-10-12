using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="CompileCoreModuleFlag" /> struct.</summary>
public static unsafe partial class CompileCoreModuleFlagTests
{
    /// <summary>Validates that the <see cref="CompileCoreModuleFlag" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(CompileCoreModuleFlag), Marshal.SizeOf<CompileCoreModuleFlag>());
    }

    /// <summary>Validates that the <see cref="CompileCoreModuleFlag" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(CompileCoreModuleFlag).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="CompileCoreModuleFlag" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(CompileCoreModuleFlag));
    }
}
