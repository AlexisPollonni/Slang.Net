using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(
    typeof(MarshalableMarshaller.Bidirectional<FenceDescription, Unmanaged.IFence.FenceDesc>)
)]
public readonly record struct FenceDescription(ulong InitialValue = 0, bool IsShared = false)
    : IMarshalsToNative<Unmanaged.IFence.FenceDesc>,
        IMarshalsFromNative<FenceDescription, Unmanaged.IFence.FenceDesc>
{
    Unmanaged.IFence.FenceDesc IMarshalsToNative<Unmanaged.IFence.FenceDesc>.AsNative(
        ref GrowingStackBuffer buffer
    ) => new() { initialValue = InitialValue, isShared = IsShared ? (byte)1 : (byte)0 };

    public static FenceDescription CreateFromNative(Unmanaged.IFence.FenceDesc unmanaged) =>
        new(unmanaged.initialValue, unmanaged.isShared != 0);
}
