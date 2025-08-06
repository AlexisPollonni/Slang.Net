// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Logging;
using SlangNet.Bindings.Generated;
using SlangNet.ComWrappers.Gfx.Interfaces;
using SlangNet.Gfx.Extensions;
using SlangNet.Gfx.Tools;
using SlangNet.Tests.Common.Tools;
using Xunit;
using ICommandQueue = SlangNet.Bindings.Generated.ICommandQueue;
using IResourceView = SlangNet.Bindings.Generated.IResourceView;

namespace SlangNet.Tests.Examples;

public class ShaderObjectTests(ILogger<ShaderObjectTests> logger)
{
    [Fact]
    public void ShaderObject()
    {
        var globalSession = SharedHelpers.CreateTestGlobalSession();
        var device = SharedHelpers.CreateTestDevice(globalSession, logger: logger);

        var heap = device.CreateTransientResourceHeapOrThrow(new(ConstantBufferSize: 4096));

        var shaderPair = SharedHelpers.LoadShaderProgram(device, "shader-object", logger);

        var pipelineState = device.CreateComputePipelineStateOrThrow(new(shaderPair.program));

        ReadOnlySpan<float> initialData = [0, 1, 2, 3];

        device.CreateBufferResource(out var numbersBuffer,
                                    new()
                                    {
                                        AllowedStates = new(ResourceState.ShaderResource,
                                                            ResourceState.UnorderedAccess,
                                                            ResourceState.CopyDestination,
                                                            ResourceState.CopySource),
                                        DefaultState = ResourceState.UnorderedAccess,
                                        MemoryType = MemoryType.DeviceLocal,
                                    },
                                    initialData).ThrowIfFailed();

        var bufferView = device.CreateBufferViewOrThrow(numbersBuffer,
                                null,
                                new()
                                {
                                    Type = IResourceView.ResourceViewType.UnorderedAccess,
                                    Format = Format.Unknown
                                });

        var queue = device.CreateCommandQueueOrThrow(new(ICommandQueue.QueueType.Graphics));

        var cmdBuffer = heap.CreateCommandBufferOrThrow();

        cmdBuffer.EncodeComputeCommands(out var encoder);

        var rootObject = encoder.BindPipelineOrThrow(pipelineState);

        var addTransformerType = shaderPair.programLayout.FindTypeByName("AddTransformer");

        Assert.NotNull(addTransformerType);
        
        var transformer = device.CreateShaderObjectOrThrow(addTransformerType.Value, ShaderObjectContainerType.None);

        const float c = 1.0f;

        new ShaderCursor(transformer).GetPath("c").SetData(c).ThrowIfFailed();

        var entryPoint = rootObject.GetEntryPointOrThrow(0);
        var entryPointCursor = new ShaderCursor(entryPoint);

        entryPointCursor.GetPath("buffer").SetResource(bufferView).ThrowIfFailed();
        entryPointCursor.GetPath("transformer").SetObject(transformer).ThrowIfFailed();

        encoder.DispatchComputeOrThrow(1, 1, 1);
        encoder.EndEncoding();
        cmdBuffer.Close();
        queue.ExecuteCommandBuffers(1, [cmdBuffer]);
        queue.WaitOnHost();

        device.ReadBufferResource(numbersBuffer, Range.All, out BlobMemory<float> data).ThrowIfFailed();

        foreach (var item in data.AsReadOnlySpan())
            logger.LogInformation("Data[{Index}] = {Value}", item, item);
        
        Assert.Equal([11, 12, 13, 14], data.AsReadOnlySpan());
    }
}