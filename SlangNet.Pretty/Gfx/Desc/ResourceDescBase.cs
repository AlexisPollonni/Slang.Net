using System;
using Nito.Disposables;
using SlangNet.Internal;

namespace SlangNet.Gfx.Desc;

public record struct ResourceDescBase(
    IResource.Type Type = IResource.Type.Unknown,
    ResourceState DefaultState = ResourceState.Undefined,
    ResourceStateSet AllowedStates = default,
    MemoryType MemoryType = MemoryType.DeviceLocal,
    InteropHandle ExistingHandle = default,
    bool IsShared = false
) : IMarshalsToNative<IResource.DescBase>, IMarshalsFromNative<ResourceDescBase, IResource.DescBase>
{
    public IDisposable AsNative(out IResource.DescBase native)
    {
        native = new IResource.DescBase
        {
            type = Type,
            defaultState = DefaultState,
            allowedStates = AllowedStates,
            memoryType = MemoryType,
            existingHandle = ExistingHandle,
            isShared = IsShared ? (byte)1 : (byte)0
        };
        
        return NoopDisposable.Instance;
    }

    public static void CreateFromNative(IResource.DescBase native, out ResourceDescBase managed)
    {
        managed = new ResourceDescBase(
            native.type,
            native.defaultState,
            native.allowedStates,
            native.memoryType,
            native.existingHandle,
            native.isShared == 1);
    }
}
