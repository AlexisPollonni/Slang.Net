using SlangNet.Internal;

namespace SlangNet.Gfx;

[GenerateThrowingMethods]
public partial class Device : COMObject<IDevice>
{
    internal unsafe Device(IDevice* pointer) : base(pointer)
    { }

    public static unsafe SlangResult TryCreate(in DeviceDesc desc, out Device device)
    {
        //SlangApi.gfxCreateDevice();
        device = new Device(null);
        return SlangResult.NotImplemented;
    }
}

public record struct DeviceDesc(
    DeviceType DeviceType, 
    IDevice.InteropHandles ExistingDeviceHandles,
    AdapterLUID AdapterLUID,
    string[] RequiredFeatures,
    SlangDesc Slang,
    string ShaderCachePath,
    int MaxShaderEntryCount = 0,
    int NvApiExtnSlot = -1
    )
{
    
}

public record struct SlangDesc(
    GlobalSession GlobalSession,
    MatrixLayoutMode DefaultMatrixLayoutMode,
    string[] SearchPaths,
    PreprocessorMacroDesc[]? PreprocessorMacros,
    string TargetProfile,
    FloatingPointMode FloatingPointMode,
    OptimizationLevel OptimizationLevel,
    TargetFlags TargetFlags,
    LineDirectiveMode LineDirectiveMode
    )
{
    
}

public readonly record struct PreprocessorMacroDesc(string Name, string Value);