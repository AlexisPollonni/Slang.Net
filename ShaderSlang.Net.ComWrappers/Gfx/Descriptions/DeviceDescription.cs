using System.Runtime.InteropServices.Marshalling;
using CommunityToolkit.HighPerformance;
using ShaderSlang.Net.ComWrappers.Interfaces;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(
    typeof(BidirectionalMarshaller<DeviceDescription, Unmanaged.IDevice.DeviceDesc>)
)]
public readonly record struct DeviceDescription(
    Unmanaged.DeviceType DeviceType,
    Unmanaged.IDevice.InteropHandles ExistingDeviceHandles,
    Guid AdapterLuid,
    string[]? RequiredFeatures,
    SlangDescription Slang,
    ShaderCacheDescription ShaderCache,
    IUnknown? ApiDispatcher = null,
    int NvApiExtnSlot = -1
)
    : IMarshalsToNative<Unmanaged.IDevice.DeviceDesc>,
        IMarshalsFromNative<DeviceDescription, Unmanaged.IDevice.DeviceDesc>,
        IFreeAfterMarshal<Unmanaged.IDevice.DeviceDesc>
{
    public DeviceDescription()
        : this(Unmanaged.DeviceType.Default, new(), Guid.Empty, null, new(), new()) { }

    unsafe Unmanaged.IDevice.DeviceDesc IMarshalsToNative<Unmanaged.IDevice.DeviceDesc>.AsNative(
        ref GrowingStackBuffer buffer
    )
    {
        var slangDesc = ((IMarshalsToNative<Unmanaged.IDevice.SlangDesc>)Slang).AsNative(
            ref buffer
        );
        var shaderCacheDesc = (
            (IMarshalsToNative<Unmanaged.IDevice.ShaderCacheDesc>)ShaderCache
        ).AsNative(ref buffer);

        var desc = new Unmanaged.IDevice.DeviceDesc
        {
            deviceType = DeviceType,
            existingDeviceHandles = ExistingDeviceHandles,
            requiredFeatures = buffer.GetCollectionPtr(RequiredFeatures, out var featureCount),
            requiredFeatureCount = (int)featureCount,
            nvapiExtnSlot = NvApiExtnSlot,
            shaderCache = shaderCacheDesc,
            slang = slangDesc,
            extendedDescCount = 0,
            extendedDescs = null,
        };

        // Check if the LUID is not empty (all zeros)
        if (AdapterLuid != Guid.Empty)
        {
            Unmanaged.AdapterLUID adapterLuid = default;
            AdapterLuid.TryWriteBytes(adapterLuid.AsSpan().AsBytes());
            desc.adapterLUID = buffer.GetStructPtr(in adapterLuid);
        }

        if (
            ApiDispatcher is not null
            && System.Runtime.InteropServices.ComWrappers.TryGetComInstance(
                ApiDispatcher,
                out var apiDispatcherPtr
            )
        )
            desc.apiCommandDispatcher = (Unmanaged.ISlangUnknown*)apiDispatcherPtr;

        return desc;
    }

    public static unsafe DeviceDescription CreateFromNative(
        Unmanaged.IDevice.DeviceDesc unmanaged
    ) =>
        new(
            unmanaged.deviceType,
            unmanaged.existingDeviceHandles,
            new(unmanaged.adapterLUID->AsReadOnlySpan().AsBytes()),
            InteropUtils.PtrToStringArray(
                unmanaged.requiredFeatures,
                unmanaged.requiredFeatureCount
            ),
            SlangDescription.CreateFromNative(unmanaged.slang),
            ShaderCacheDescription.CreateFromNative(unmanaged.shaderCache),
            ComInterfaceMarshaller<IUnknown>.ConvertToManaged(unmanaged.apiCommandDispatcher), //TODO: See if there isnt a better way to do this
            unmanaged.nvapiExtnSlot
        );

    public static unsafe void Free(scoped ref readonly Unmanaged.IDevice.DeviceDesc unmanaged)
    {
        ComInterfaceMarshaller<IUnknown>.Free(unmanaged.apiCommandDispatcher);
        SlangDescription.Free(in unmanaged.slang);
    }
}
