using System;
using Nito.Disposables;
using SlangNet.Internal;

namespace SlangNet.Gfx.Desc;

public readonly record struct ShaderCacheDesc(string? Path, int MaxEntryCount = 0) : 
    IMarshalsToNative<IDevice.ShaderCacheDesc>, 
    IMarshalsFromNative<ShaderCacheDesc, IDevice.ShaderCacheDesc>
{
    public readonly int GetNativeAllocSize()
    {
        return Path.GetNativeAllocSize() + SysUnsafe.SizeOf<int>();
    }

    public unsafe void AsNative(MarshallingAllocBuffer buffer, out IDevice.ShaderCacheDesc native)
    {
        native = new IDevice.ShaderCacheDesc
        {
            shaderCachePath = Path.MarshalToNative(buffer),
            maxEntryCount = MaxEntryCount
        };
    }

    public static unsafe void CreateFromNative(IDevice.ShaderCacheDesc native, out ShaderCacheDesc desc)
    {
        desc = new ShaderCacheDesc(InteropUtils.PtrToStringUTF8(native.shaderCachePath), native.maxEntryCount);
    }
}


public record struct DeviceDesc(
    DeviceType DeviceType, 
    IDevice.InteropHandles ExistingDeviceHandles,
    AdapterLUID AdapterLUID,
    string[]? RequiredFeatures,
    SlangDesc Slang,
    ShaderCacheDesc ShaderCache,
    int NvApiExtnSlot = -1
    ) : IMarshalsToNative<IDevice.DeviceDesc>
{
    public readonly int GetNativeAllocSize()
    {
        return SysUnsafe.SizeOf<IDevice.DeviceDesc>()
            + RequiredFeatures.GetNativeAllocSize()
            + Slang.GetNativeAllocSize()
            + ShaderCache.GetNativeAllocSize();
    }

    public unsafe void AsNative(MarshallingAllocBuffer buffer, out IDevice.DeviceDesc native)
    {       
        Slang.AsNative(buffer, out var slangDesc);
        ShaderCache.AsNative(buffer, out var shaderCacheDesc);
        
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
            requiredFeatureCount = RequiredFeatures.CountIfNotNull(),
            requiredFeatures = RequiredFeatures.MarshalToNative(buffer),
            apiCommandDispatcher = null, // Not implemented yet
            nvapiExtnSlot = NvApiExtnSlot,
            shaderCache = shaderCacheDesc,
            slang = slangDesc,
            extendedDescCount = 0,
            extendedDescs = null
        };
    }
    
    public static DeviceDesc CreateFromNative(IDevice.DeviceDesc native)
    {
        // TODO: Implement this when needed
        throw new NotImplementedException();
    }
}
