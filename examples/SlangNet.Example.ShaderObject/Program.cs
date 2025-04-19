// See https://aka.ms/new-console-template for more information

using CommunityToolkit.HighPerformance;
using Microsoft.Extensions.Logging;
using SlangNet;
using SlangNet.ComWrappers.Gfx;
using SlangNet.ComWrappers.Gfx.Descriptions;
using SlangNet.ComWrappers.Gfx.Interfaces;
using SlangNet.ComWrappers.Interfaces;
using SlangNet.ComWrappers.Reflection;
using SlangNet.ComWrappers.Tools.Extensions;
using SlangNet.Gfx.Tools;
using Unmanaged = SlangNet.Bindings.Generated;

var factory = LoggerFactory.Create(builder => builder.AddConsole());
var logger = factory.CreateLogger("Gfx");
#if DEBUG
Gfx.EnableDebugLayer();

Gfx.SetDebugCallback((type, source, message) =>
   {
       var level = type switch
       {
           Unmanaged.DebugMessageType.Info => LogLevel.Information,
           Unmanaged.DebugMessageType.Warning => LogLevel.Warning,
           Unmanaged.DebugMessageType.Error => LogLevel.Error,
           _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
       };

       logger.Log(level, "{Source}: {Message}", source, message);
   })
   .ThrowIfFailed();
#endif

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

const int numberCount = 4;
ReadOnlySpan<float> initialData = [0, 1, 2, 3];

var bufferDesc = new BufferResourceDescription
{
    Base = new()
    {
        AllowedStates = new(Unmanaged.ResourceState.ShaderResource,
                            Unmanaged.ResourceState.UnorderedAccess,
                            Unmanaged.ResourceState.CopyDestination,
                            Unmanaged.ResourceState.CopySource),
        DefaultState = Unmanaged.ResourceState.UnorderedAccess,
        MemoryType = Unmanaged.MemoryType.DeviceLocal,
    },
    Format = Unmanaged.Format.Unknown,
    ElementSize = sizeof(float),
    SizeInBytes = numberCount * sizeof(float)
};
    
device.CreateBufferResource(bufferDesc, in initialData.AsBytes().DangerousGetReference(), out var numbersBuffer).ThrowIfFailed();

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

device.ReadBufferResource(numbersBuffer, 0, (nuint)initialData.AsBytes().Length, out var dataBlob).ThrowIfFailed();

foreach (var item in dataBlob.AsReadOnlySpan().Cast<byte, float>())
{
    Console.WriteLine(item);
}

static class ShaderObjectExample
{
    internal static SlangResult LoadShaderProgram(IDevice device,
                                                 out IShaderProgram program,
                                                 out ShaderReflection slangReflection)
    {
        device.GetSlangSession(out var slangSession).ThrowIfFailed();

        var module = slangSession.LoadModule("shader-object", out var diag);

        module.FindEntryPointByName("computeMain", out var computeEntryPoint).ThrowIfFailed();

        var componentTypes = new IComponentType[] { module, computeEntryPoint };

        slangSession.CreateCompositeComponentType(componentTypes, 2, out var composedProgram, out diag)
                                          .ThrowIfFailed();

        slangReflection = composedProgram.GetLayout(0, out diag).Value!;

        var programDesc = new ShaderProgramDescription(GlobalScope: composedProgram);

        device.CreateProgram(programDesc, out program, out diag).ThrowIfFailed();

        return SlangResult.Ok;
    }
}