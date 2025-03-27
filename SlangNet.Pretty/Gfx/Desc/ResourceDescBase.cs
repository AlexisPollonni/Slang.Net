using SlangNet.Internal;

namespace SlangNet.Gfx.Desc;

public readonly record struct ResourceDescBase(
    IResource.ResourceType Type = IResource.ResourceType.Unknown,
    ResourceState DefaultState = ResourceState.Undefined,
    ResourceStateSet AllowedStates = default,
    MemoryType MemoryType = MemoryType.DeviceLocal,
    InteropHandle ExistingHandle = default,
    bool IsShared = false
) : IMarshalsToNative<IResource.DescBase>, IMarshalsFromNative<ResourceDescBase, IResource.DescBase>
{
    public int GetNativeAllocSize()
    {
        return SysUnsafe.SizeOf<IResource.DescBase>();
    }

    public void AsNative(ref MarshallingAllocBuffer buffer, out IResource.DescBase native)
    {
        native = new()
        {
            type = Type,
            defaultState = DefaultState,
            allowedStates = AllowedStates,
            memoryType = MemoryType,
            existingHandle = ExistingHandle,
            isShared = IsShared ? (byte)1 : (byte)0
        };
    }

    public static void CreateFromNative(IResource.DescBase native, out ResourceDescBase managed)
    {
        managed = new(
            native.type,
            native.defaultState,
            native.allowedStates,
            native.memoryType,
            native.existingHandle,
            native.isShared == 1);
    }
}
