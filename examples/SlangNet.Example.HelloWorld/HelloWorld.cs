using Microsoft.Extensions.Logging;
using SlangNet.Bindings.Generated;
using SlangNet.Gfx;
using SlangNet.Gfx.Desc;
using SlangNet.Internal;

namespace SlangNet.Example.HelloWorld;

internal static class HelloWorld
{
    private const int ElementCount = 16;
    private const int BufferSize = sizeof(float) * ElementCount;


    static SlangResult LoadShaderProgram(Device device, out ShaderProgram program, out ShaderReflection slangReflection)
    {
        var slangSession = device.GetSlangSession();

        var module = slangSession.LoadModule("shader-object"u8);

        var computeEntryPoint = module.GetEntryPointByName("computeMain"u8);

        var componentTypes = new ComponentType[] { module, computeEntryPoint };

        var composedProgram = slangSession.CreateCompositeComponentType(componentTypes);

        slangReflection = composedProgram.GetLayout();

        var programDesc = new ShaderProgramDesc(GlobalScope: composedProgram);
    
        program = device.CreateProgram(programDesc);

        return SlangResult.Ok;
    }
    
    private static unsafe void Main(string[] args)
    {
        var factory = LoggerFactory.Create(builder => builder.AddConsole());
        var logger = factory.CreateLogger("Gfx");
#if DEBUG
            Api.EnableDebugLayer();
    
            Api.TrySetDebugCallback((type, source, message) =>
            {
                var level = type switch
                {
                    DebugMessageType.Info => LogLevel.Information,
                    DebugMessageType.Warning => LogLevel.Warning,
                    DebugMessageType.Error => LogLevel.Error,
                    _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
                };
                
                logger.Log(level, "{Source}: {Message}",  source, message);
            }).ThrowIfFailed();
#endif

        var shaderIncludePath = Path.GetDirectoryName(typeof(HelloWorld).Assembly.Location);
        var devDesc1 = new DeviceDesc
        {
            DeviceType = DeviceType.Default,
            Slang = new()
            {
                TargetFlags = TargetFlags.GenerateSPIRVDirectly,
                OptimizationLevel = OptimizationLevel.None,
                DefaultMatrixLayoutMode = MatrixLayoutMode.RowMajor,
                TargetProfile = "glsl440",
                SearchPaths = [ shaderIncludePath ]
            },
            ShaderCache = new()
            {
                Path = "./ShaderCache",
            }
        };
        
        var device = Device.Create(devDesc1);


        var heap = device.CreateTransientResourceHeap(new(ConstantBufferSize: 4096));

        LoadShaderProgram(device, out var program, out var slangReflection).ThrowIfFailed();

        var pipelineState = device.CreateComputePipelineState(new(program));

        const int numberCount = 4;
        float[] initialData = [0, 1, 2, 3];

        var bufferDesc = new BufferResourceDesc
        {
            Base = new() 
            {
                AllowedStates = new(ResourceState.ShaderResource, ResourceState.UnorderedAccess, ResourceState.CopyDestination, ResourceState.CopySource),
                DefaultState = ResourceState.UnorderedAccess,
                MemoryType = MemoryType.DeviceLocal,
            },
            Format = Format.Unknown,
            ElementSize = sizeof(float),
            SizeInBytes = numberCount * sizeof(float)
        };

        device.TryCreateBufferResource(bufferDesc, initialData.AsSpan(), out var buffer).ThrowIfFailed();

        var bufferView = device.CreateBufferView(buffer, null, new()
        {
            Type = IResourceView.ResourceViewType.UnorderedAccess,
            Format = Format.Unknown
        });

        

        var queue = device.CreateCommandQueue(new(ICommandQueue.QueueType.Graphics));

        var cmdBuffer = heap.CreateCommandBuffer();

        var encoder = cmdBuffer.EncodeComputeCommands();

        var rootObject = encoder.BindPipeline(pipelineState);

        var addTransformerType = slangReflection.FindTypeByName("AddTransformer").Value;

        var transformer = device.CreateShaderObject(addTransformerType, ShaderObjectContainerType.None);



        // try
        // {
        //     LoadModuleAndCreatePipeline();
        //     CreateBuffers();
        //     DispatchCompute();
        //     PrintComputeResults();

        // }
        // finally
        // {
        //     inputBuffer0?.Dispose();
        //     inputBuffer1?.Dispose();
        //     outputBuffer?.Dispose();
        //     shader?.Dispose();
        //     resourceLayout?.Dispose();
        //     pipeline?.Dispose();
        //     graphicsDevice?.Dispose();
        // }
    }

    // private static void LoadModuleAndCreatePipeline()
    // {
    //     // First a global session is necessary
    //     using var globalSession = GlobalSession.Create();
    //
    //     // Next a session to generate SPIRV code is created
    //     using var session = globalSession.CreateSession(new()
    //     {
    //         Targets =
    //         {
    //             new()
    //             {
    //                 Format = CompileTarget.Spirv,
    //                 Flags = TargetFlags.GenerateSPIRVDirectly,
    //                 Profile = globalSession.FindProfile("glsl440"u8)
    //             }
    //         }
    //     });
    //
    //     // Once the session has been obtained, we can start loading code into it.
    //     Environment.CurrentDirectory = Path.GetDirectoryName(typeof(HelloWorldUnsafe).Assembly.Location);
    //     using var module = session.LoadModule("hello-world"u8);
    //
    //     // Now that the module is loaded we can look up those entry points by name.
    //     using var entryPoint = module.GetEntryPointByName("computeMain"u8);
    //
    //     // A single Slang module could contain many different entry points (e.g.,
    //     // four vertex entry points, three fragment entry points, and two compute
    //     // shaders), and before we try to generate output code for our target API
    //     // we need to identify which entry points we plan to use together.
    //     var componentTypes = new ComponentType[] { module, entryPoint };
    //
    //     // Actually creating the composite component type is a single operation
    //     // on the Slang session, but the operation could potentially fail if
    //     // something about the composite was invalid (e.g., you are trying to
    //     // combine multiple copies of the same module), so we need to deal
    //     // with the possibility of diagnostic output.
    //     using var composedProgram = session.CreateCompositeComponentType(componentTypes);
    //
    //     // Now we can call `composedProgram->getEntryPointCode()` to retrieve the
    //     // compiled SPIRV code that we will use to create a vulkan compute pipeline.
    //     // This will trigger the final Slang compilation and spirv code generation.
    //     using var spirvCode = composedProgram.GetEntryPointCode(0, 0);
    //
    //     CreatePipelineFromSpirv(spirvCode.Memory.Span);
    // }

    // private static void CreatePipelineFromSpirv(ReadOnlySpan<byte> spirvCode)
    // {
    //     shader = ResourceFactory.CreateShader(new()
    //     {
    //         Debug = true,
    //         EntryPoint = "main",
    //         Stage = ShaderStages.Compute,
    //         ShaderBytes = spirvCode.ToArray()
    //     });

    //     resourceLayout = ResourceFactory.CreateResourceLayout(new(
    //         new ResourceLayoutElementDescription("buffer0", ResourceKind.StructuredBufferReadOnly, ShaderStages.Compute),
    //         new ResourceLayoutElementDescription("buffer1", ResourceKind.StructuredBufferReadOnly, ShaderStages.Compute),
    //         new ResourceLayoutElementDescription("result", ResourceKind.StructuredBufferReadOnly, ShaderStages.Compute)));

    //     pipeline = ResourceFactory.CreateComputePipeline(new()
    //     {
    //         ComputeShader = shader,
    //         ResourceLayouts = new[] { resourceLayout },
    //         ThreadGroupSizeX = 1,
    //         ThreadGroupSizeY = 1,
    //         ThreadGroupSizeZ = 1,
    //     });
    // }

    // private static void CreateBuffers()
    // {
    //     var description = new BufferDescription(BufferSize, BufferUsage.StructuredBufferReadOnly, sizeof(float));
    //     inputBuffer0 = ResourceFactory.CreateBuffer(description);
    //     inputBuffer1 = ResourceFactory.CreateBuffer(description);
    //     outputBuffer = ResourceFactory.CreateBuffer(description with { Usage = BufferUsage.StructuredBufferReadWrite });
    //     stagingBuffer = ResourceFactory.CreateBuffer(description with { Usage = BufferUsage.Staging, StructureByteStride = 0 });

    //     var mapped = graphicsDevice.Map<float>(stagingBuffer, MapMode.Write);
    //     for (int i = 0; i < ElementCount; i++)
    //         mapped[i] = i;
    //     graphicsDevice.Unmap(stagingBuffer);
    // }

    // private static void DispatchCompute()
    // {
    //     using var commandList = ResourceFactory.CreateCommandList();
    //     using var resourceSet = ResourceFactory.CreateResourceSet(new(resourceLayout, inputBuffer0, inputBuffer1, outputBuffer));
    //     commandList.Begin();
    //     commandList.CopyBuffer(stagingBuffer, 0, inputBuffer0, 0, BufferSize);
    //     commandList.CopyBuffer(stagingBuffer, 0, inputBuffer1, 0, BufferSize);
    //     commandList.SetPipeline(pipeline);
    //     commandList.SetComputeResourceSet(0, resourceSet);
    //     commandList.Dispatch(ElementCount, 1, 1);
    //     commandList.CopyBuffer(outputBuffer, 0, stagingBuffer, 0, BufferSize);
    //     commandList.End();
    //     graphicsDevice.SubmitCommands(commandList);
    //     graphicsDevice.WaitForIdle();
    // }

    // private static void PrintComputeResults()
    // {
    //     var mapped = graphicsDevice.Map<float>(stagingBuffer, MapMode.Write);
    //     for (int i = 0; i < ElementCount; i++)
    //         Console.WriteLine(mapped[i]);
    //     graphicsDevice.Unmap(stagingBuffer);
    // }
}