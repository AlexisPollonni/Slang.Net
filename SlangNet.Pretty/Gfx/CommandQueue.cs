using System;
using System.Runtime.CompilerServices;
using SlangNet.Bindings.Generated;
using SlangNet.Internal;
using SlangNet.Gfx;
using SlangNet.Gfx.Desc;
using System.Collections.Generic;

namespace SlangNet.Gfx;

[GenerateThrowingMethods]
public partial class CommandQueue : COMObject<ICommandQueue>
{
    internal unsafe CommandQueue(ICommandQueue* pointer) : base(pointer)
    { }

    public unsafe CommandQueueDesc GetDesc()
    {
        var ptr = Pointer->getDesc();
        CommandQueueDesc.CreateFromNative(*ptr, out var desc);
        return desc;
    }

    public unsafe void ExecuteCommandBuffers(IReadOnlyCollection<CommandBuffer> commandBuffers, Fence? fenceToSignal = null, ulong newFenceValue = 0)
    {
        if (commandBuffers.Count == 0)
            return;

        //TODO: Use MarshalToNative or new equivalent
        var cmdBuffersPtr = stackalloc ICommandBuffer*[commandBuffers.Count];
        var i = 0;
        foreach (var cmdBuffer in commandBuffers)
        {
            cmdBuffersPtr[i] = cmdBuffer.Pointer;
            i++;
        }

        Pointer->executeCommandBuffers(commandBuffers.Count, cmdBuffersPtr, fenceToSignal.AsNullablePtr(), newFenceValue);
    }

    public unsafe void ExecuteCommandBuffer(CommandBuffer commandBuffer, Fence? fenceToSignal = null, ulong newFenceValue = 0)
    {
        ExecuteCommandBuffers([commandBuffer], fenceToSignal, newFenceValue);
    }

    public unsafe SlangResult TryGetNativeHandle(out InteropHandle handle)
    {
        fixed (InteropHandle* ptr = &handle)
        {
            return Pointer->getNativeHandle(ptr).ToSlangResult();
        }
    }

    public unsafe void WaitOnHost()
    {
        Pointer->waitOnHost();
    }

    public unsafe SlangResult TryWaitForFenceValuesOnDevice(ReadOnlySpan<(Fence Fence, ulong WaitValue)> fenceValues)
    {
        if (fenceValues.IsEmpty)
            return default;

        var nativeFences = stackalloc IFence*[fenceValues.Length];
        var nativeValues = stackalloc ulong[fenceValues.Length];

        for (int i = 0; i < fenceValues.Length; i++)
        {
            nativeFences[i] = fenceValues[i].Fence.Pointer;
            nativeValues[i] = fenceValues[i].WaitValue;
        }

        return Pointer->waitForFenceValuesOnDevice(fenceValues.Length, nativeFences, nativeValues).ToSlangResult();
    }
}
