using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(
    typeof(BidirectionalMarshaller<
        ResourceDescriptionBase,
        Unmanaged.IResource.DescBase
    >)
)]
public readonly record struct ResourceDescriptionBase(
    Unmanaged.IResource.ResourceType Type = Unmanaged.IResource.ResourceType.Unknown,
    Unmanaged.ResourceState DefaultState = Unmanaged.ResourceState.Undefined,
    ResourceStateSet AllowedStates = default,
    Unmanaged.MemoryType MemoryType = Unmanaged.MemoryType.DeviceLocal,
    Unmanaged.InteropHandle ExistingHandle = default,
    bool IsShared = false
)
    : IMarshalsToNative<Unmanaged.IResource.DescBase>,
        IMarshalsFromNative<ResourceDescriptionBase, Unmanaged.IResource.DescBase>
{
    Unmanaged.IResource.DescBase IMarshalsToNative<Unmanaged.IResource.DescBase>.AsNative(
        ref GrowingStackBuffer buffer
    ) =>
        new()
        {
            type = Type,
            defaultState = DefaultState,
            allowedStates = AllowedStates,
            memoryType = MemoryType,
            existingHandle = ExistingHandle,
            isShared = IsShared ? (byte)1 : (byte)0,
        };

    public static ResourceDescriptionBase CreateFromNative(
        Unmanaged.IResource.DescBase unmanaged
    ) =>
        new(
            unmanaged.type,
            unmanaged.defaultState,
            unmanaged.allowedStates,
            unmanaged.memoryType,
            unmanaged.existingHandle,
            unmanaged.isShared == 1
        );
}
