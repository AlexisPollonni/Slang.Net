// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Logging;
using SlangNet;
using SlangNet.Bindings.Generated;
using SlangNet.Gfx;
using SlangNet.Gfx.Desc;
using SlangNet.Gfx.Tools;
using ShaderReflection = SlangNet.ShaderReflection;

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

       logger.Log(level, "{Source}: {Message}", source, message);
   })
   .ThrowIfFailed();
#endif

var shaderIncludePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
var devDesc1 = new DeviceDesc
{
    DeviceType = DeviceType.Default,
    Slang = new()
    {
        TargetFlags = TargetFlags.GenerateSPIRVDirectly,
        OptimizationLevel = OptimizationLevel.None,
        DefaultMatrixLayoutMode = MatrixLayoutMode.RowMajor,
        TargetProfile = "glsl440",
        SearchPaths = [shaderIncludePath]
    },
    ShaderCache = new()
    {
        Path = "./ShaderCache",
    }
};

var device = Device.Create(devDesc1);

var heap = device.CreateTransientResourceHeap(new(ConstantBufferSize: 4096));

ShaderObjectExample.LoadShaderProgram(device, out var program, out var slangReflection).ThrowIfFailed();

var pipelineState = device.CreateComputePipelineState(new(program));

const int numberCount = 4;
float[] initialData = [0, 1, 2, 3];

var bufferDesc = new BufferResourceDesc
{
    Base = new()
    {
        AllowedStates = new(ResourceState.ShaderResource,
                            ResourceState.UnorderedAccess,
                            ResourceState.CopyDestination,
                            ResourceState.CopySource),
        DefaultState = ResourceState.UnorderedAccess,
        MemoryType = MemoryType.DeviceLocal,
    },
    Format = Format.Unknown,
    ElementSize = sizeof(float),
    SizeInBytes = numberCount * sizeof(float)
};

device.TryCreateBufferResource(bufferDesc, initialData.AsSpan(), out var numbersBuffer).ThrowIfFailed();

var bufferView = device.CreateBufferView(numbersBuffer,
                                         null,
                                         new()
                                         {
                                             Type = IResourceView.ResourceViewType.UnorderedAccess,
                                             Format = Format.Unknown
                                         });

var queue = device.CreateCommandQueue(new(ICommandQueue.QueueType.Graphics));

var cmdBuffer = heap.CreateCommandBuffer();

var encoder = cmdBuffer.EncodeComputeCommands();

var rootObject = encoder.BindPipeline(pipelineState);

var addTransformerType = slangReflection.FindTypeByName("AddTransformer")!.Value;

var transformer = device.CreateShaderObject(addTransformerType, ShaderObjectContainerType.None);

const float c = 1.0f;

new ShaderCursor(transformer).GetPath("c").SetData(c);

var entryPointCursor = new ShaderCursor(rootObject.GetEntryPoint(0));

entryPointCursor.GetPath("buffer").SetResource(bufferView);

entryPointCursor.GetPath("transformer").SetObject(transformer);

encoder.DispatchCompute(1, 1, 1);
encoder.EndEncoding();
cmdBuffer.Close();
queue.ExecuteCommandBuffer(cmdBuffer);
queue.WaitOnHost();

device.ReadBufferResource<float>(numbersBuffer, Range.All, out var data).ThrowIfFailed();

foreach (var item in data!.Memory.Span)
{
    Console.WriteLine(item);
}

static class ShaderObjectExample
{
    internal static SlangResult LoadShaderProgram(Device device,
                                                 out ShaderProgram program,
                                                 out ShaderReflection slangReflection)
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
}