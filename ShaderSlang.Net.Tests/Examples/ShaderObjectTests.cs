// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Logging;
using ShaderSlang.Net.Tests.Common.Tools;
using ShaderSlang.Net.Bindings.Generated;
using ShaderSlang.Net.ComWrappers.Gfx.Interfaces;
using ShaderSlang.Net.Pretty.Gfx.Extensions;
using ShaderSlang.Net.Pretty.Gfx.Tools;
using Xunit;
using ICommandQueue = ShaderSlang.Net.Bindings.Generated.ICommandQueue;
using IResourceView = ShaderSlang.Net.Bindings.Generated.IResourceView;

namespace ShaderSlang.Net.Tests.Examples;

public class ShaderObjectTests(ITestOutputHelper testOutputHelper, DefaultTestFixture fixture)
    : TestBase<ShaderObjectTests>(testOutputHelper, fixture)
{
    [Fact]
    public void ShaderObject()
    {
        var globalSession = SharedHelpers.CreateTestGlobalSession();
        var device = SharedHelpers.CreateTestDevice(globalSession, logger: Logger);

        var heap = device.CreateTransientResourceHeapOrThrow(new(ConstantBufferSize: 4096));

        var shaderPair = SharedHelpers.LoadShaderProgram(device, "shader-object", Logger);

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
                                    initialData)
              .ThrowIfFailed();

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

        foreach (var item in data.AsReadOnlySpan()) Logger.LogInformation("Data[{Index}] = {Value}", item, item);

        Assert.Equal([11, 12, 13, 14], data.AsReadOnlySpan());
    }
}