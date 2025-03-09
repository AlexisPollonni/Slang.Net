using System;
using Nito.Disposables;
using SlangNet.Internal;

namespace SlangNet.Gfx.Desc;

public record struct DeviceDesc(
    DeviceType DeviceType, 
    IDevice.InteropHandles ExistingDeviceHandles,
    AdapterLUID AdapterLUID,
    string[] RequiredFeatures,
    SlangDesc Slang,
    string ShaderCachePath,
    int MaxShaderEntryCount = 0,
    int NvApiExtnSlot = -1
    ) : IMarshalable<DeviceDesc, IDevice.DeviceDesc>    
{
    public unsafe IDisposable AsNative(out IDevice.DeviceDesc native)
    {
        var disposables = new CollectionDisposable();
        
        var featuresUtf8 = new Utf8StringArray(RequiredFeatures).DisposeWith(disposables);
        
        Slang.AsNative(out var slangDesc).DisposeWith(disposables);
        
        var shaderCachePathUtf8 = new Utf8String(ShaderCachePath).DisposeWith(disposables);
        
        var shaderCacheDesc = new IDevice.ShaderCacheDesc
        {
            shaderCachePath = shaderCachePathUtf8,
            maxEntryCount = MaxShaderEntryCount
        };
        
        // AdapterLUID is a struct with a fixed buffer, so we can just pass it directly
        AdapterLUID* adapterLuidPtr = null;
        // Check if the LUID is not empty (all zeros)
        bool isNonZero = false;
        for (int i = 0; i < 16; i++)
        {
            if (AdapterLUID.luid.e0 != 0)
            {
                isNonZero = true;
                break;
            }
        }
        
        if (isNonZero)
        {
            // Create a copy of the LUID on the stack
            var luid = AdapterLUID;
            adapterLuidPtr = &luid;
        }
        
        native = new IDevice.DeviceDesc
        {
            deviceType = DeviceType,
            existingDeviceHandles = ExistingDeviceHandles,
            adapterLUID = adapterLuidPtr,
            requiredFeatureCount = featuresUtf8.Count,
            requiredFeatures = featuresUtf8.Memory,
            apiCommandDispatcher = null, // Not implemented yet
            nvapiExtnSlot = NvApiExtnSlot,
            shaderCache = shaderCacheDesc,
            slang = slangDesc,
            extendedDescCount = 0,
            extendedDescs = null
        };
        
        return disposables;
    }
    
    public static DeviceDesc CreateFromNative(IDevice.DeviceDesc native)
    {
        // TODO: Implement this when needed
        throw new NotImplementedException();
    }
}
