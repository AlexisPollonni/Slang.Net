using SlangNet.Bindings.Generated;
using SlangNet.ComWrappers;
using SlangNet.ComWrappers.Interfaces;
using SlangNet.ComWrappers.Tools.Extensions;
using Veldrid;
using static SlangNet.Example.Shared.SharedLogger<SlangNet.Example.HelloWorld.HelloWorld>;
using IComponentType = SlangNet.ComWrappers.Interfaces.IComponentType;

namespace SlangNet.Example.HelloWorld;

class HelloWorld
{
    private const int ElementCount = 16;
    private const int BufferSize = sizeof(float) * ElementCount;

    private static GraphicsDevice graphicsDevice;
    private static Shader shader;
    private static ResourceLayout resourceLayout;
    private static Pipeline pipeline;
    private static DeviceBuffer inputBuffer0, inputBuffer1, outputBuffer, stagingBuffer;

    private static ResourceFactory ResourceFactory => graphicsDevice.ResourceFactory;

    private static void Main(string[] args)
    {
        try
        {
            graphicsDevice = GraphicsDevice.CreateVulkan(new()
            {
                Debug = false,
                HasMainSwapchain = false
            });

            LoadModuleAndCreatePipeline();
            CreateBuffers();
            DispatchCompute();
            PrintComputeResults();
        }
        finally
        {
            inputBuffer0?.Dispose();
            inputBuffer1?.Dispose();
            outputBuffer?.Dispose();
            shader?.Dispose();
            resourceLayout?.Dispose();
            pipeline?.Dispose();
            graphicsDevice?.Dispose();
        }
    }

    private static void LoadModuleAndCreatePipeline()
    {
        // First a global session is necessary
        var globalSession = Slang.CreateGlobalSession();

        // Next a session to generate SPIRV code is created
        globalSession.CreateSession(new([
            new(CompileTarget.Spirv, globalSession.FindProfile("glsl440"))
        ]), out var session);

        // Once the session has been obtained, we can start loading code into it.
        Environment.CurrentDirectory = Path.GetDirectoryName(typeof(HelloWorld).Assembly.Location)!;
        var module = session.LoadModule("hello-world", out _);

        LogInformation("Slang API Version : {Version}", globalSession.GetBuildTagString());;
        LogInformation("Module filepath: {Path}", module?.GetFilePath());

        for (var i = 0; i < module!.GetDefinedEntryPointCount(); i++)
        {
            var e = module.GetDefinedEntryPointOrThrow(i);

            var func = e.GetFunctionReflection();

            LogDebug("Entry point {Index}: {EntryPointName}", i, func?.Name);
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
        var composedProgram = session.CreateCompositeComponentTypeOrThrow(componentTypes, componentTypes.Length, out _);

        // Now we can call `composedProgram->getEntryPointCode()` to retrieve the
        // compiled SPIRV code that we will use to create a vulkan compute pipeline.
        // This will trigger the final Slang compilation and spirv code generation.
        var spirvCode = composedProgram.GetEntryPointCodeOrThrow(0, 0, out _);

        CreatePipelineFromSpirv(spirvCode.AsReadOnlySpan());
    }

    private static void CreatePipelineFromSpirv(ReadOnlySpan<byte> spirvCode)
    {
        shader = ResourceFactory.CreateShader(new()
        {
            Debug = true,
            EntryPoint = "main",
            Stage = ShaderStages.Compute,
            ShaderBytes = spirvCode.ToArray()
        });

        resourceLayout = ResourceFactory.CreateResourceLayout(
            new(new ResourceLayoutElementDescription("buffer0", ResourceKind.StructuredBufferReadOnly, ShaderStages.Compute),
                new ResourceLayoutElementDescription("buffer1", ResourceKind.StructuredBufferReadOnly, ShaderStages.Compute),
                new ResourceLayoutElementDescription("result",
                                                     ResourceKind.StructuredBufferReadOnly,
                                                     ShaderStages.Compute)));

        pipeline = ResourceFactory.CreateComputePipeline(new()
        {
            ComputeShader = shader,
            ResourceLayouts = [resourceLayout],
            ThreadGroupSizeX = 1,
            ThreadGroupSizeY = 1,
            ThreadGroupSizeZ = 1,
        });
    }

    private static void CreateBuffers()
    {
        var description = new BufferDescription(BufferSize, BufferUsage.StructuredBufferReadOnly, sizeof(float));
        inputBuffer0 = ResourceFactory.CreateBuffer(description);
        inputBuffer1 = ResourceFactory.CreateBuffer(description);
        outputBuffer = ResourceFactory.CreateBuffer(description with { Usage = BufferUsage.StructuredBufferReadWrite });
        stagingBuffer
            = ResourceFactory.CreateBuffer(description with { Usage = BufferUsage.Staging, StructureByteStride = 0 });

        var mapped = graphicsDevice.Map<float>(stagingBuffer, MapMode.Write);
        for (var i = 0; i < ElementCount; i++) mapped[i] = i;
        graphicsDevice.Unmap(stagingBuffer);
    }

    private static void DispatchCompute()
    {
        using var commandList = ResourceFactory.CreateCommandList();
        using var resourceSet
            = ResourceFactory.CreateResourceSet(new(resourceLayout, inputBuffer0, inputBuffer1, outputBuffer));
        commandList.Begin();
        commandList.CopyBuffer(stagingBuffer, 0, inputBuffer0, 0, BufferSize);
        commandList.CopyBuffer(stagingBuffer, 0, inputBuffer1, 0, BufferSize);
        commandList.SetPipeline(pipeline);
        commandList.SetComputeResourceSet(0, resourceSet);
        commandList.Dispatch(ElementCount, 1, 1);
        commandList.CopyBuffer(outputBuffer, 0, stagingBuffer, 0, BufferSize);
        commandList.End();
        graphicsDevice.SubmitCommands(commandList);
        graphicsDevice.WaitForIdle();
    }

    private static void PrintComputeResults()
    {
        var mapped = graphicsDevice.Map<float>(stagingBuffer, MapMode.Write);
        for (var i = 0; i < ElementCount; i++) LogInformation("[{Index}] = {Value}", i, mapped[i]);
        graphicsDevice.Unmap(stagingBuffer);
    }
}