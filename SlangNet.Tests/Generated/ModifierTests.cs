using System.Runtime.InteropServices;
using Xunit;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="Modifier" /> struct.</summary>
public static unsafe partial class ModifierTests
{
    /// <summary>Validates that the <see cref="Modifier" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(Modifier), Marshal.SizeOf<Modifier>());
    }

    /// <summary>Validates that the <see cref="Modifier" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(Modifier).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="Modifier" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        Assert.Equal(1, sizeof(Modifier));
    }
}
