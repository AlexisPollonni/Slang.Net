using NUnit.Framework;
using System;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.UnitTests;

/// <summary>Provides validation of the <see cref="ICommandBufferD3D12" /> struct.</summary>
public static unsafe partial class ICommandBufferD3D12Tests
{
    /// <summary>Validates that the <see cref="ICommandBufferD3D12" /> struct is blittable.</summary>
    [Test]
    public static void IsBlittableTest()
    {
        Assert.That(Marshal.SizeOf<ICommandBufferD3D12>(), Is.EqualTo(sizeof(ICommandBufferD3D12)));
    }

    /// <summary>Validates that the <see cref="ICommandBufferD3D12" /> struct has the right <see cref="LayoutKind" />.</summary>
    [Test]
    public static void IsLayoutSequentialTest()
    {
        Assert.That(typeof(ICommandBufferD3D12).IsLayoutSequential, Is.True);
    }

    /// <summary>Validates that the <see cref="ICommandBufferD3D12" /> struct has the correct size.</summary>
    [Test]
    public static void SizeOfTest()
    {
        if (Environment.Is64BitProcess)
        {
            Assert.That(sizeof(ICommandBufferD3D12), Is.EqualTo(8));
        }
        else
        {
            Assert.That(sizeof(ICommandBufferD3D12), Is.EqualTo(4));
        }
    }
}
