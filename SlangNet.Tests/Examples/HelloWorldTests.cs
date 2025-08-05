using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;
using SlangNet.Bindings.Generated;
using SlangNet.ComWrappers.Gfx.Descriptions;
using SlangNet.ComWrappers.Gfx.Interfaces;
using SlangNet.ComWrappers.Interfaces;
using SlangNet.Gfx.Extensions;
using SlangNet.Gfx.Tools;
using SlangNet.Tests.Common.Tools;
using Xunit;
using IBufferResource = SlangNet.ComWrappers.Gfx.Interfaces.IBufferResource;
using ICommandQueue = SlangNet.Bindings.Generated.ICommandQueue;
using IComponentType = SlangNet.ComWrappers.Interfaces.IComponentType;
using IDevice = SlangNet.ComWrappers.Gfx.Interfaces.IDevice;
using IPipelineState = SlangNet.ComWrappers.Gfx.Interfaces.IPipelineState;
using IResource = SlangNet.Bindings.Generated.IResource;
using IResourceView = SlangNet.Bindings.Generated.IResourceView;
using IShaderProgram = SlangNet.ComWrappers.Gfx.Interfaces.IShaderProgram;

namespace SlangNet.Tests.Examples;

public class HelloWorldTests(ILogger<HelloWorldTests> logger)
{
    private const int ElementCount = 16;
    private const int BufferSize = sizeof(float) * ElementCount;

    [Theory]
    // TODO: Blocked by https://github.com/shader-slang/slang-rhi/issues/289 and similar
    //[InlineData(DeviceType.DirectX12)]
    [InlineData(DeviceType.Metal)]
    [InlineData(DeviceType.Vulkan)]
    public void HelloWorld(DeviceType type)
    {
        var (device, program) = LoadModuleAndCreateDevice(type);
        var pipeline = CreatePipelineFromProgram(device, program);
        CreateBuffers(device, out var inputBuffer0, out var inputBuffer1, out var outputBuffer);
        
        DispatchCompute(device, pipeline, inputBuffer0, inputBuffer1, outputBuffer);
        PrintComputeResults(device, outputBuffer);
    }

    private (IDevice device, IShaderProgram program) LoadModuleAndCreateDevice(DeviceType type)
    {
        // First a global session is necessary
        var globalSession = SharedHelpers.CreateTestGlobalSession();

        // Next a session to generate SPIRV code is created
        var session = globalSession.CreateSessionOrThrow(new()
        {
            SearchPaths = [Path.Combine(SharedHelpers.RunningExePath, "Examples", "Assets")],
            Targets =
            [
                new()
                {
                    Format = CompileTarget.Spirv,
                    Profile = globalSession.FindProfile("spirv_1_5")
                }
            ],
        });


        // Once the session has been obtained, we can start loading code into it.
        var module = session.LoadModule("hello-world", out var diag);

        logger.LogDiagnostics(diag);
        Assert.NotNull(module);

        logger.LogInformation("Slang API Version : {Version}", globalSession.GetBuildTagString());
        logger.LogInformation("Module filepath: {Path}", module.GetFilePath());

        for (var i = 0; i < module.GetDefinedEntryPointCount(); i++)
        {
            var e = module.GetDefinedEntryPointOrThrow(i);

            var func = e.GetFunctionReflection();

            logger.LogDebug("Entry point {Index}: {EntryPointName}", i, func?.Name);
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
        var composedProgram
            = session.CreateCompositeComponentTypeOrThrow(componentTypes, componentTypes.Length, out var diagString);

        logger.LogDiagnostics(diagString);
        Assert.NotNull(composedProgram);

        // Now we can call `composedProgram->getEntryPointCode()` to retrieve the
        // compiled SPIRV code that we will use to create a vulkan compute pipeline.
        // This will trigger the final Slang compilation and spirv code generation.
        var spirvCode = composedProgram.GetEntryPointCodeOrThrow(0, 0, out diagString);

        logger.LogDiagnostics(diagString);
        Assert.NotNull(spirvCode);

        var device = SharedHelpers.CreateTestDevice(globalSession, logger: logger, 
                                                    deviceType: type,
                                                    allowCpuDevice: false); // Choosing a CPU device for this test with this shader will not work. Slang segfaults on pipeline bind with that shader program. TODO: Report this.

        var program = device.CreateProgramOrThrow(new(GlobalScope: composedProgram), out diagString);
        logger.LogDiagnostics(diagString);
        Assert.NotNull(program);

        return (device, program);
    }

    private IPipelineState CreatePipelineFromProgram(IDevice device, IShaderProgram program)
    {
        return device.CreateComputePipelineStateOrThrow(new(program));
    }

    private static void CreateBuffers(IDevice device,
                                      out IBufferResource inputBuffer0,
                                      out IBufferResource inputBuffer1,
                                      out IBufferResource outputBuffer)
    {
        var description = new BufferResourceDescription
        {
            Base = new()
            {
                Type = IResource.ResourceType.Buffer,
                AllowedStates = new(ResourceState.ShaderResource,
                                    ResourceState.UnorderedAccess,
                                    ResourceState.CopyDestination),
                DefaultState = ResourceState.UnorderedAccess,
                MemoryType = MemoryType.DeviceLocal,
            },
            SizeInBytes = BufferSize,
            ElementSize = sizeof(float),
        };

        ref var nullData = ref Unsafe.NullRef<byte>();
        var initData = Enumerable.Range(0, ElementCount).Select(i => (float)i).ToArray();
        device.CreateBufferResource(out inputBuffer0, description.Base, initData).ThrowIfFailed();
        device.CreateBufferResource(out inputBuffer1, description.Base, initData).ThrowIfFailed();

        outputBuffer = device.CreateBufferResourceOrThrow(description with
                                                          {
                                                              Base = description.Base with
                                                              {
                                                                  AllowedStates = new(ResourceState.ShaderResource,
                                                                                      ResourceState.UnorderedAccess,
                                                                                      ResourceState.CopySource)
                                                              }
                                                          },
                                                          nullData);
    }

    private static void DispatchCompute(IDevice device,
                                        IPipelineState pipeline,
                                        IBufferResource inputBuffer0,
                                        IBufferResource inputBuffer1,
                                        IBufferResource outputBuffer)
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
                Format = Format.Unknown
            };
            
            var bufferView = device.CreateBufferViewOrThrow(buffer, null, bufferViewDesc);
            cursor.SetResource(bufferView).ThrowIfFailed();
        }
    }

    private void PrintComputeResults(IDevice device, IBufferResource outputBuffer)
    {
        device.ReadBufferResource(outputBuffer, Range.All, out BlobMemory<float> data).ThrowIfFailed();

        for (var i = 0; i < ElementCount; i++) logger.LogInformation("[{Index}] = {Value}", i, data.AsReadOnlySpan()[i]);
    }
}