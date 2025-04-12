using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Interfaces;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(typeof(MarshalableMarshaller.Bidirectional<DeviceDescription, Unmanaged.IDevice.DeviceDesc>))]
public readonly record struct DeviceDescription(
    Unmanaged.DeviceType DeviceType,
    Unmanaged.IDevice.InteropHandles ExistingDeviceHandles,
    Unmanaged.AdapterLUID AdapterLUID,
    string[]? RequiredFeatures,
    SlangDescription Slang,
    ShaderCacheDescription ShaderCache,
    IUnknown? ApiDispatcher = null,
    int NvApiExtnSlot = -1) : IMarshalsToNative<Unmanaged.IDevice.DeviceDesc>,
                              IMarshalsFromNative<DeviceDescription, Unmanaged.IDevice.DeviceDesc>,
                              IFreeAfterMarshal<Unmanaged.IDevice.DeviceDesc>
{
    unsafe Unmanaged.IDevice.DeviceDesc IMarshalsToNative<Unmanaged.IDevice.DeviceDesc>.AsNative(
        ref GrowingStackBuffer buffer)
    {
        var slangDesc = ((IMarshalsToNative<Unmanaged.IDevice.SlangDesc>)Slang).AsNative(ref buffer);
        var shaderCacheDesc = ((IMarshalsToNative<Unmanaged.IDevice.ShaderCacheDesc>)ShaderCache).AsNative(ref buffer);

        // AdapterLUID is a struct with a fixed buffer, so we can just pass it directly
        Unmanaged.AdapterLUID* adapterLuidPtr = null;
        // Check if the LUID is not empty (all zeros)
        var isNonZero = false;
        for (var i = 0; i < 16; i++)
        {
            if (AdapterLUID.luid.e0 == 0) continue;
            isNonZero = true;
            break;
        }

        var desc = new Unmanaged.IDevice.DeviceDesc
        {
            deviceType = DeviceType,
            existingDeviceHandles = ExistingDeviceHandles,
            adapterLUID = adapterLuidPtr,
            requiredFeatures = buffer.GetCollectionPtr(RequiredFeatures, out var featureCount),
            requiredFeatureCount = (int)featureCount,
            nvapiExtnSlot = NvApiExtnSlot,
            shaderCache = shaderCacheDesc,
            slang = slangDesc,
            extendedDescCount = 0,
            extendedDescs = null
        };
        
        if (isNonZero)
        {
            desc.adapterLUID = buffer.GetStructPtr(AdapterLUID);
        }

        if (ApiDispatcher is not null 
            && System.Runtime.InteropServices.ComWrappers.TryGetComInstance(ApiDispatcher, out var apiDispatcherPtr)) 
            desc.apiCommandDispatcher = (Unmanaged.ISlangUnknown*)apiDispatcherPtr;

        return desc;
    }

    public static unsafe DeviceDescription CreateFromNative(Unmanaged.IDevice.DeviceDesc unmanaged) =>
        new(unmanaged.deviceType,
            unmanaged.existingDeviceHandles,
            *unmanaged.adapterLUID,
            InteropUtils.PtrToStringArray(unmanaged.requiredFeatures, unmanaged.requiredFeatureCount),
            SlangDescription.CreateFromNative(unmanaged.slang),
            ShaderCacheDescription.CreateFromNative(unmanaged.shaderCache),
            ComInterfaceMarshaller<IUnknown>.ConvertToManaged(unmanaged.apiCommandDispatcher), //TODO: See if there isnt a better way to do this
            unmanaged.nvapiExtnSlot);

    public unsafe void Free(Unmanaged.IDevice.DeviceDesc* unmanaged)
    {
        ComInterfaceMarshaller<IUnknown>.Free(unmanaged->apiCommandDispatcher);
        Slang.Free(&unmanaged->slang);
    }
}