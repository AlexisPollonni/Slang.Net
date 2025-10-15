using Microsoft.Extensions.Logging;
using ShaderSlang.Net.Bindings.Generated;
using ShaderSlang.Net.ComWrappers.Gfx.Descriptions;
using ShaderSlang.Net.ComWrappers.Gfx.Interfaces;
using ShaderSlang.Net.ComWrappers.Interfaces;
using ShaderSlang.Net.Pretty.Gfx.Extensions;
using ShaderSlang.Net.Pretty.Gfx.Tools;
using ShaderSlang.Net.Tests.Common.Tools;
using Xunit;
using IBufferResource = ShaderSlang.Net.ComWrappers.Gfx.Interfaces.IBufferResource;
using ICommandQueue = ShaderSlang.Net.Bindings.Generated.ICommandQueue;
using IComponentType = ShaderSlang.Net.ComWrappers.Interfaces.IComponentType;
using IDevice = ShaderSlang.Net.ComWrappers.Gfx.Interfaces.IDevice;
using IPipelineState = ShaderSlang.Net.ComWrappers.Gfx.Interfaces.IPipelineState;
using IResource = ShaderSlang.Net.Bindings.Generated.IResource;
using IResourceView = ShaderSlang.Net.Bindings.Generated.IResourceView;
using IShaderProgram = ShaderSlang.Net.ComWrappers.Gfx.Interfaces.IShaderProgram;

namespace ShaderSlang.Net.Tests.Examples;

public sealed class HelloWorldTests(ITestOutputHelper testOutputHelper, DefaultTestFixture fixture)
    : TestBase<HelloWorldTests>(testOutputHelper, fixture)
{
    private const int ElementCount = 16;

    [Theory]
    [InlineData(DeviceType.DirectX12)]
    [InlineData(DeviceType.Metal)]
    [InlineData(DeviceType.Vulkan)]
    [InlineData(DeviceType.CPU)]
    public void HelloWorld(DeviceType type)
    {
        var (device, program) = LoadModuleAndCreateDevice(type);
        var pipeline = CreatePipelineFromProgram(device, program);

        var inputData = Enumerable.Range(0, ElementCount).Select(i => (float)i).ToArray();
        var expected = inputData.Select(i => i + i).ToArray();

        CreateBuffers(
            device,
            inputData,
            out var inputBuffer0,
            out var inputBuffer1,
            out var outputBuffer
        );

        DispatchCompute(device, pipeline, inputBuffer0, inputBuffer1, outputBuffer);
        PrintComputeResults(device, outputBuffer);

        device
            .ReadBufferResource<float>(outputBuffer, Range.All, out var outputData)
            .ThrowIfFailed();

        Assert.Equal(expected, outputData.AsReadOnlySpan());
    }

    private (IDevice device, IShaderProgram program) LoadModuleAndCreateDevice(DeviceType type)
    {
        // First a global session is necessary
        var globalSession = SharedHelpers.CreateTestGlobalSession();

        var device = SharedHelpers.CreateTestDevice(
            globalSession,
            logger: Logger,
            deviceType: type,
            allowCpuDevice: true
        );

        // Next a session to generate SPIRV code is created
        var session = device.GetSlangSessionOrThrow();

        // Once the session has been obtained, we can start loading code into it.
        var module = session.LoadModule("hello-world", out var diag);

        Logger.LogDiagnostics(diag);
        Assert.NotNull(module);

        Logger.LogInformation("Slang API Version : {Version}", globalSession.GetBuildTagString());
        Logger.LogInformation("Module filepath: {Path}", module.GetFilePath());

        for (var i = 0; i < module.GetDefinedEntryPointCount(); i++)
        {
            var e = module.GetDefinedEntryPointOrThrow(i);

            var func = e.GetFunctionReflection();

            Logger.LogDebug("Entry point {Index}: {EntryPointName}", i, func?.Name);
        }

        // Now that the module is loaded we can look up those entry points by name.
        var entryPoint = module.FindEntryPointByNameOrThrow("computeMain");

        // A single Slang module could contain many different entry points (e.g.,
        // four vertex entry points, three fragment entry points, and two compute
        // shaders), and before we try to generate output code for our target API
        // we need to identify which entry points we plan to use together.
        var componentTypes = new IComponentType[] { module, entryPoint };

        // Actually creating the composite component type is a single operation
        // on the Slang session, but the operation could potentially fail if
        // something about the composite was invalid (e.g., you are trying to
        // combine multiple copies of the same module), so we need to deal
        // with the possibility of diagnostic output.
        var composedProgram = session.CreateCompositeComponentTypeOrThrow(
            componentTypes,
            componentTypes.Length,
            out var diagString
        );

        Logger.LogDiagnostics(diagString);
        Assert.NotNull(composedProgram);

        var program = device.CreateProgramOrThrow(
            new(GlobalScope: composedProgram),
            out diagString
        );
        Logger.LogDiagnostics(diagString);
        Assert.NotNull(program);

        return (device, program);
    }

    private IPipelineState CreatePipelineFromProgram(IDevice device, IShaderProgram program)
    {
        return device.CreateComputePipelineStateOrThrow(new(program));
    }

    private static void CreateBuffers(
        IDevice device,
        IEnumerable<float> inputData,
        out IBufferResource inputBuffer0,
        out IBufferResource inputBuffer1,
        out IBufferResource outputBuffer
    )
    {
        var initData = inputData.ToArray();

        var description = new ResourceDescriptionBase
        {
            Type = IResource.ResourceType.Buffer,
            AllowedStates = new(
                ResourceState.ShaderResource,
                ResourceState.UnorderedAccess,
                ResourceState.CopyDestination
            ),
            DefaultState = ResourceState.UnorderedAccess,
            MemoryType = MemoryType.DeviceLocal,
        };

        device.CreateBufferResource(out inputBuffer0, description, initData).ThrowIfFailed();
        device.CreateBufferResource(out inputBuffer1, description, initData).ThrowIfFailed();

        device.CreateBufferResource(
            out outputBuffer,
            description with
            {
                AllowedStates = new(
                    ResourceState.ShaderResource,
                    ResourceState.UnorderedAccess,
                    ResourceState.CopySource
                ),
            },
            GC.AllocateUninitializedArray<float>(initData.Length)
        );
    }

    private static void DispatchCompute(
        IDevice device,
        IPipelineState pipeline,
        IBufferResource inputBuffer0,
        IBufferResource inputBuffer1,
        IBufferResource outputBuffer
    )
    {
        var heap = device.CreateTransientResourceHeapOrThrow(new());

        var queue = device.CreateCommandQueueOrThrow(new(ICommandQueue.QueueType.Graphics));

        var cmdBuffer = heap.CreateCommandBufferOrThrow();

        cmdBuffer.EncodeComputeCommands(out var encoder);

        var rootObject = encoder.BindPipelineOrThrow(pipeline);
        var rootCursor = new ShaderCursor(rootObject);

        SetBuffer(rootCursor.GetPath("buffer0"), inputBuffer0);
        SetBuffer(rootCursor.GetPath("buffer1"), inputBuffer1);
        SetBuffer(rootCursor.GetPath("result"), outputBuffer);

        encoder.DispatchComputeOrThrow(ElementCount, 1, 1);
        encoder.EndEncoding();
        cmdBuffer.Close();
        queue.ExecuteCommandBuffers(1, [cmdBuffer]);
        queue.WaitOnHost();

        void SetBuffer(ShaderCursor cursor, IBufferResource buffer)
        {
            var bufferViewDesc = new ResourceViewDescription
            {
                Type = IResourceView.ResourceViewType.UnorderedAccess,
                Format = Format.Unknown,
            };

            var bufferView = device.CreateBufferViewOrThrow(buffer, null, bufferViewDesc);
            cursor.SetResource(bufferView).ThrowIfFailed();
        }
    }

    private void PrintComputeResults(IDevice device, IBufferResource outputBuffer)
    {
        device
            .ReadBufferResource(outputBuffer, Range.All, out BlobMemory<float> data)
            .ThrowIfFailed();

        for (var i = 0; i < ElementCount; i++)
            Logger.LogInformation("[{Index}] = {Value}", i, data.AsReadOnlySpan()[i]);
    }
}
