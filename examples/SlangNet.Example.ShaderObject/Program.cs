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

var adapters = Gfx.GetAdapters(Unmanaged.DeviceType.Vulkan);
var devDesc = new DeviceDescription
{
    DeviceType = Unmanaged.DeviceType.Vulkan,
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
    AdapterLuid = adapters[0].Luid
};

Gfx.CreateDevice(devDesc, out var device).ThrowIfFailed();

device.CreateTransientResourceHeap(new(ConstantBufferSize: 4096), out var heap).ThrowIfFailed();

ShaderObjectExample.LoadShaderProgram(device, out var program, out var slangReflection).ThrowIfFailed();

device.CreateComputePipelineState(new(program), out var pipelineState).ThrowIfFailed();

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
                            initialData);

device.CreateBufferView(numbersBuffer,
    null,
    new()
    {
        Type = Unmanaged.IResourceView.ResourceViewType.UnorderedAccess,
        Format = Unmanaged.Format.Unknown
    }, out var bufferView).ThrowIfFailed();

device.CreateCommandQueue(new(Unmanaged.ICommandQueue.QueueType.Graphics), out var queue).ThrowIfFailed();

heap.CreateCommandBuffer(out var cmdBuffer).ThrowIfFailed();

cmdBuffer.EncodeComputeCommands(out var encoder);

encoder.BindPipeline(pipelineState, out var rootObject).ThrowIfFailed();

var addTransformerType = slangReflection.FindTypeByName("AddTransformer")!.Value;

device.CreateShaderObject(addTransformerType, Unmanaged.ShaderObjectContainerType.None, out var transformer).ThrowIfFailed();

const float c = 1.0f;

new ShaderCursor(transformer).GetPath("c").SetData(c);

rootObject.GetEntryPoint(0, out var entryPoint).ThrowIfFailed();
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
        device.GetSlangSession(out var slangSession).ThrowIfFailed();

        var module = slangSession.LoadModule("shader-object", out var diag);
        SharedLogger<IModule>.LogDiagnostics(diag);

        module.FindEntryPointByName("computeMain", out var computeEntryPoint).ThrowIfFailed();

        var componentTypes = new IComponentType[] { module, computeEntryPoint };

        slangSession.CreateCompositeComponentType(componentTypes, 2, out var composedProgram, out diag)
                                          .ThrowIfFailed();
        SharedLogger<IComponentType[]>.LogDiagnostics(diag);

        slangReflection = composedProgram.GetLayout(0, out diag).Value!;
        SharedLogger<ShaderReflection>.LogDiagnostics(diag);

        var programDesc = new ShaderProgramDescription(GlobalScope: composedProgram);

        device.CreateProgram(programDesc, out program, out diag).ThrowIfFailed();
        SharedLogger<IShaderProgram>.LogDiagnostics(diag);

        return SlangResult.Ok;
    }
}