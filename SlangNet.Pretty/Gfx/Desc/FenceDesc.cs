using System;
using SlangNet.Internal;

namespace SlangNet.Gfx.Desc;

public record struct FenceDesc(ulong InitialValue = 0, bool IsShared = false) : IMarshalsToNative<IFence.FenceDesc>, IMarshalsFromNative<FenceDesc, IFence.FenceDesc>
{
    public static void CreateFromNative(IFence.FenceDesc native, out FenceDesc managed)
    {
        managed = new(native.initialValue, native.isShared != 0);
    }

    public void AsNative(ref MarshallingAllocBuffer buffer, out IFence.FenceDesc native)
    {
        native = new() { initialValue = InitialValue, isShared = IsShared ? (byte)1 : (byte)0 };
    }

    public readonly int GetNativeAllocSize() => SysUnsafe.SizeOf<IFence.FenceDesc>();
}
