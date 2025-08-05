// See https://aka.ms/new-console-template for more information

using CommunityToolkit.HighPerformance;
using SlangNet;
using SlangNet.ComWrappers.Gfx;
using SlangNet.ComWrappers.Gfx.Descriptions;
using SlangNet.ComWrappers.Gfx.Interfaces;
using SlangNet.ComWrappers.Interfaces;
using SlangNet.ComWrappers.Reflection;
using SlangNet.Example.Shared;
using SlangNet.Gfx.Extensions;
using SlangNet.Gfx.Tools;
using Unmanaged = SlangNet.Bindings.Generated;

Debug.Layer();
Debug.EnableLogging();

var shaderIncludePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);

var devDesc = new DeviceDescription
{
    Slang = new()
    {
        TargetFlags = TargetFlags.GenerateSPIRVDirectly,
        OptimizationLevel = Unmanaged.OptimizationLevel.None,
        DefaultMatrixLayoutMode = Unmanaged.MatrixLayoutMode.RowMajor,
        TargetProfile = "glsl440",
        SearchPaths = [shaderIncludePath]
    },
    ShaderCache = new()
    {
        Path = "./ShaderCache"
    },
};

Gfx.CreateDevice(devDesc, out var device).ThrowIfFailed();

var heap = device.CreateTransientResourceHeapOrThrow(new(ConstantBufferSize: 4096));

ShaderObjectExample.LoadShaderProgram(device, out var program, out var slangReflection).ThrowIfFailed();

var pipelineState = device.CreateComputePipelineStateOrThrow(new(program));

ReadOnlySpan<float> initialData = [0, 1, 2, 3];

device.CreateBufferResource(out var numbersBuffer,
                            new()
                            {
                                AllowedStates = new(Unmanaged.ResourceState.ShaderResource,
                                                    Unmanaged.ResourceState.UnorderedAccess,
                                                    Unmanaged.ResourceState.CopyDestination,
                                                    Unmanaged.ResourceState.CopySource),
                                DefaultState = Unmanaged.ResourceState.UnorderedAccess,
                                MemoryType = Unmanaged.MemoryType.DeviceLocal,
                            },
                            initialData).ThrowIfFailed();

var bufferView = device.CreateBufferViewOrThrow(numbersBuffer,
    null,
    new()
    {
        Type = Unmanaged.IResourceView.ResourceViewType.UnorderedAccess,
        Format = Unmanaged.Format.Unknown
    });

var queue = device.CreateCommandQueueOrThrow(new(Unmanaged.ICommandQueue.QueueType.Graphics));

var cmdBuffer = heap.CreateCommandBufferOrThrow();

cmdBuffer.EncodeComputeCommands(out var encoder);

var rootObject = encoder.BindPipelineOrThrow(pipelineState);

var addTransformerType = slangReflection.FindTypeByName("AddTransformer")!.Value;

var transformer = device.CreateShaderObjectOrThrow(addTransformerType, Unmanaged.ShaderObjectContainerType.None);

const float c = 1.0f;

new ShaderCursor(transformer).GetPath("c").SetData(c);

var entryPoint = rootObject.GetEntryPointOrThrow(0);
var entryPointCursor = new ShaderCursor(entryPoint);

entryPointCursor.GetPath("buffer").SetResource(bufferView);
entryPointCursor.GetPath("transformer").SetObject(transformer);

encoder.DispatchCompute(1, 1, 1);
encoder.EndEncoding();
cmdBuffer.Close();
queue.ExecuteCommandBuffers(1, [cmdBuffer]);
queue.WaitOnHost();

device.ReadBufferResource(numbersBuffer, Range.All, out BlobMemory<float> data).ThrowIfFailed();

foreach (var item in data.AsReadOnlySpan().Enumerate())
{
    SharedLogger.LogInformation("Data[{Index}] = {Value}", item.Index, item.Value);
}

static class ShaderObjectExample
{
    internal static SlangResult LoadShaderProgram(IDevice device,
                                                 out IShaderProgram program,
                                                 out ShaderReflection slangReflection)
    {
        var slangSession = device.GetSlangSessionOrThrow();

        var module = slangSession.LoadModule("shader-object", out string? diag);
        SharedLogger<IModule>.LogDiagnostics(diag);

        var computeEntryPoint = module.FindEntryPointByNameOrThrow("computeMain");

        var componentTypes = new IComponentType[] { module, computeEntryPoint };

        var composedProgram = slangSession.CreateCompositeComponentTypeOrThrow(componentTypes, out diag);
        SharedLogger<IComponentType[]>.LogDiagnostics(diag);

        slangReflection = composedProgram.GetLayout(0, out diag).Value;
        SharedLogger<ShaderReflection>.LogDiagnostics(diag);

        var programDesc = new ShaderProgramDescription(GlobalScope: composedProgram);

        program = device.CreateProgramOrThrow(programDesc, out diag);
        SharedLogger<IShaderProgram>.LogDiagnostics(diag);

        return SlangResult.Ok;
    }
}