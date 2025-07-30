using System.Runtime.InteropServices;
using Xunit;
using static SlangNet.Bindings.Generated.SlangApi;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="IByteCodeRunner" /> struct.</summary>
public static unsafe partial class IByteCodeRunnerTests
{
    /// <summary>Validates that the <see cref="Guid" /> of the <see cref="IByteCodeRunner" /> struct is correct.</summary>
    [Fact]
    public static void GuidOfTest()
    {
        Assert.Equal(typeof(IByteCodeRunner).GUID, IID_IByteCodeRunner);
    }

    /// <summary>Validates that the <see cref="IByteCodeRunner" /> struct is blittable.</summary>
    [Fact]
    public static void IsBlittableTest()
    {
        Assert.Equal(sizeof(IByteCodeRunner), Marshal.SizeOf<IByteCodeRunner>());
    }

    /// <summary>Validates that the <see cref="IByteCodeRunner" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Fact]
    public static void IsLayoutSequentialTest()
    {
        Assert.True(typeof(IByteCodeRunner).IsLayoutSequential);
    }

    /// <summary>Validates that the <see cref="IByteCodeRunner" /> struct has the correct size.</summary>
    [Fact]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.Equal(8, sizeof(IByteCodeRunner));
        }
        else
        {
            Assert.Equal(4, sizeof(IByteCodeRunner));
        }
    }
}
