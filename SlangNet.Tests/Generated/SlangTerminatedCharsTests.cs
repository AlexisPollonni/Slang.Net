using System.Runtime.InteropServices;
using Xunit;
using static SlangNet.Bindings.Generated.SlangApi;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="SlangTerminatedChars" /> struct.</summary>
public static unsafe partial class SlangTerminatedCharsTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="SlangTerminatedChars" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(SlangTerminatedChars).GUID, IID_SlangTerminatedChars);
    }

    /// <summary>Validates that the <see cref="SlangTerminatedChars" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(SlangTerminatedChars), Marshal.SizeOf<SlangTerminatedChars>());
    }

    /// <summary>Validates that the <see cref="SlangTerminatedChars" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(SlangTerminatedChars).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="SlangTerminatedChars" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(SlangTerminatedChars));
    }
}
