using System.Runtime.InteropServices;
using Xunit;

namespace ShaderSlang.Net.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="SlangEntryPointLayout" /> struct.</summary>
public static unsafe partial class SlangEntryPointLayoutTests
{
    /// <summary>Validates that the <see cref="SlangEntryPointLayout" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(SlangEntryPointLayout), Marshal.SizeOf<SlangEntryPointLayout>());
    }

    /// <summary>Validates that the <see cref="SlangEntryPointLayout" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(SlangEntryPointLayout).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="SlangEntryPointLayout" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(SlangEntryPointLayout));
    }
}
