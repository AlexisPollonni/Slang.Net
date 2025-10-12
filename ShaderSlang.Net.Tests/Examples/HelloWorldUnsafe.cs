using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using ShaderSlang.Net.Bindings.Generated;
using ShaderSlang.Net.Tests.Common.Tools;
using Veldrid;
using Xunit;
using static ShaderSlang.Net.Bindings.Generated.SlangApi;

namespace ShaderSlang.Net.Tests.Examples;

public sealed unsafe class HelloWorldUnsafeTests(
    ITestOutputHelper testOutputHelper,
    DefaultTestFixture fixture
) : TestBase<HelloWorldUnsafeTests>(testOutputHelper, fixture)
{
    private const int ElementCount = 16;
    private const int BufferSize = sizeof(float) * ElementCount;

    private GraphicsDevice? _graphicsDevice;
    private Shader? _shader;
    private ResourceLayout? _resourceLayout;
    private Pipeline? _pipeline;
    private DeviceBuffer? _inputBuffer0;
    private DeviceBuffer? _inputBuffer1;
    private DeviceBuffer? _outputBuffer;
    private DeviceBuffer? _stagingBuffer;

    [Fact]
    public void HelloWorldUnsafe()
    {
        Assert.SkipWhen(
            !GraphicsDevice.IsBackendSupported(GraphicsBackend.Vulkan),
            "Vulkan is not supported on this device"
        );
        try
        {
            _graphicsDevice = GraphicsDevice.CreateVulkan(
                new() { Debug = false, HasMainSwapchain = false }
            );

            LoadModuleAndCreatePipeline();
            CreateBuffers();
            DispatchCompute();
            PrintComputeResults();
        }
        finally
        {
            _inputBuffer0?.Dispose();
            _inputBuffer1?.Dispose();
            _outputBuffer?.Dispose();
            _shader?.Dispose();
            _resourceLayout?.Dispose();
            _pipeline?.Dispose();
            _graphicsDevice?.Dispose();
        }
    }

    private ResourceFactory ResourceFactory => _graphicsDevice.ResourceFactory;

    private void ThrowOnFail(int error)
    {
        if (error != SLANG_OK)
            throw new Exception($"Slang error: {error}");
    }

    private void DiagnoseIfNeeded(ISlangBlob* diagnosticBlob)
    {
        if (diagnosticBlob == null)
            return;
        Logger.LogError(
            "Slang diagnostics: {Diagnostics}",
            Marshal.PtrToStringUTF8(new(diagnosticBlob->getBufferPointer()))
        );
    }

    private void LoadModuleAndCreatePipeline()
    {
        IGlobalSession* globalSession = null;
        ISession* session = null;
        IModule* module = null;
        ISlangBlob* diagnosticsBlob = null;
        IEntryPoint* entryPoint = null;
        IComponentType* composedProgram = null;
        ISlangBlob* spirvCode = null;

        try
        {
            // First a global session is necessary
            ThrowOnFail(slang_createGlobalSession(SLANG_API_VERSION, &globalSession));

            // Next a session to generate SPIRV code is created
            ProfileID profile;
            fixed (byte* profileName = "glsl440"u8)
                profile = globalSession->findProfile((sbyte*)profileName);
            TargetDesc targetDesc = new()
            {
                structureSize = (nuint)sizeof(TargetDesc),
                format = CompileTarget.Spirv,
                profile = profile,
                flags = SLANG_TARGET_FLAG_GENERATE_SPIRV_DIRECTLY,
            };
            SessionDesc sessionDesc = new()
            {
                structureSize = (nuint)sizeof(SessionDesc),
                defaultMatrixLayoutMode = MatrixLayoutMode.RowMajor,
                targetCount = 1,
                targets = &targetDesc,
            };
            globalSession->createSession(&sessionDesc, &session);

            // Once the session has been obtained, we can start loading code into it.
            Environment.CurrentDirectory = Path.Combine(
                SharedHelpers.RunningExePath,
                "Examples",
                "Assets"
            );
            fixed (byte* moduleName = "hello-world"u8)
                module = session->loadModule((sbyte*)moduleName, &diagnosticsBlob);
            DiagnoseIfNeeded(diagnosticsBlob);
            if (module == null)
                throw new("Module was not loaded");

            // Now that the module is loaded we can look up those entry points by name.
            fixed (byte* entryPointName = "computeMain"u8)
                ThrowOnFail(module->findEntryPointByName((sbyte*)entryPointName, &entryPoint));

            // A single Slang module could contain many different entry points (e.g.,
            // four vertex entry points, three fragment entry points, and two compute
            // shaders), and before we try to generate output code for our target API
            // we need to identify which entry points we plan to use together.
            var componentTypes = stackalloc IComponentType*[2];
            componentTypes[0] = (IComponentType*)module;
            componentTypes[1] = (IComponentType*)entryPoint;

            // Actually creating the composite component type is a single operation
            // on the Slang session, but the operation could potentially fail if
            // something about the composite was invalid (e.g., you are trying to
            // combine multiple copies of the same module), so we need to deal
            // with the possibility of diagnostic output.
            if (diagnosticsBlob != null)
                diagnosticsBlob->release();
            var result = session->createCompositeComponentType(
                componentTypes,
                2,
                &composedProgram,
                &diagnosticsBlob
            );
            DiagnoseIfNeeded(diagnosticsBlob);
            ThrowOnFail(result);

            // Now we can call `composedProgram->getEntryPointCode()` to retrieve the
            // compiled SPIRV code that we will use to create a vulkan compute pipeline.
            // This will trigger the final Slang compilation and spirv code generation.
            result = composedProgram->getEntryPointCode(0, 0, &spirvCode, &diagnosticsBlob);
            DiagnoseIfNeeded(diagnosticsBlob);
            ThrowOnFail(result);

            CreatePipelineFromSpirv(spirvCode);
        }
        finally
        {
            if (spirvCode != null)
                spirvCode->release();
            if (composedProgram != null)
                composedProgram->release();
            if (entryPoint != null)
                entryPoint->release();
            if (diagnosticsBlob != null)
                diagnosticsBlob->release();
            if (module != null)
                module->release();
            if (session != null)
                session->release();
            if (globalSession != null)
                globalSession->release();
        }
    }

    private void CreatePipelineFromSpirv(ISlangBlob* spirvCode)
    {
        ReadOnlySpan<byte> spirvSpan = new(
            spirvCode->getBufferPointer(),
            checked((int)spirvCode->getBufferSize())
        );
        _shader = ResourceFactory.CreateShader(
            new()
            {
                Debug = true,
                EntryPoint = "main",
                Stage = ShaderStages.Compute,
                ShaderBytes = spirvSpan.ToArray(),
            }
        );

        _resourceLayout = ResourceFactory.CreateResourceLayout(
            new(
                new ResourceLayoutElementDescription(
                    "buffer0",
                    ResourceKind.StructuredBufferReadOnly,
                    ShaderStages.Compute
                ),
                new ResourceLayoutElementDescription(
                    "buffer1",
                    ResourceKind.StructuredBufferReadOnly,
                    ShaderStages.Compute
                ),
                new ResourceLayoutElementDescription(
                    "result",
                    ResourceKind.StructuredBufferReadOnly,
                    ShaderStages.Compute
                )
            )
        );

        _pipeline = ResourceFactory.CreateComputePipeline(
            new()
            {
                ComputeShader = _shader,
                ResourceLayouts = [_resourceLayout],
                ThreadGroupSizeX = 1,
                ThreadGroupSizeY = 1,
                ThreadGroupSizeZ = 1,
            }
        );
    }

    private void CreateBuffers()
    {
        var description = new BufferDescription(
            BufferSize,
            BufferUsage.StructuredBufferReadOnly,
            sizeof(float)
        );
        _inputBuffer0 = ResourceFactory.CreateBuffer(description);
        _inputBuffer1 = ResourceFactory.CreateBuffer(description);
        _outputBuffer = ResourceFactory.CreateBuffer(
            description with
            {
                Usage = BufferUsage.StructuredBufferReadWrite,
            }
        );
        _stagingBuffer = ResourceFactory.CreateBuffer(
            description with
            {
                Usage = BufferUsage.Staging,
                StructureByteStride = 0,
            }
        );

        var mapped = _graphicsDevice.Map<float>(_stagingBuffer, MapMode.Write);
        for (int i = 0; i < ElementCount; i++)
            mapped[i] = i;
        _graphicsDevice.Unmap(_stagingBuffer);
    }

    private void DispatchCompute()
    {
        using var commandList = ResourceFactory.CreateCommandList();
        using var resourceSet = ResourceFactory.CreateResourceSet(
            new(_resourceLayout, _inputBuffer0, _inputBuffer1, _outputBuffer)
        );
        commandList.Begin();
        commandList.CopyBuffer(_stagingBuffer, 0, _inputBuffer0, 0, BufferSize);
        commandList.CopyBuffer(_stagingBuffer, 0, _inputBuffer1, 0, BufferSize);
        commandList.SetPipeline(_pipeline);
        commandList.SetComputeResourceSet(0, resourceSet);
        commandList.Dispatch(ElementCount, 1, 1);
        commandList.CopyBuffer(_outputBuffer, 0, _stagingBuffer, 0, BufferSize);
        commandList.End();
        _graphicsDevice.SubmitCommands(commandList);
        _graphicsDevice.WaitForIdle();
    }

    private void PrintComputeResults()
    {
        var mapped = _graphicsDevice.Map<float>(_stagingBuffer, MapMode.Write);
        for (int i = 0; i < ElementCount; i++)
            Logger.LogInformation("[{Index}] = {Value}", i, mapped[i]);
        _graphicsDevice.Unmap(_stagingBuffer);
    }
}
