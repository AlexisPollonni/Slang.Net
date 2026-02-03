using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(
    typeof(BidirectionalMarshaller<
        ShaderCacheDescription,
        Unmanaged.IDevice.ShaderCacheDesc
    >)
)]
public readonly record struct ShaderCacheDescription(string? Path, int MaxEntryCount = 0)
    : IMarshalsToNative<Unmanaged.IDevice.ShaderCacheDesc>,
        IMarshalsFromNative<ShaderCacheDescription, Unmanaged.IDevice.ShaderCacheDesc>
{
    unsafe Unmanaged.IDevice.ShaderCacheDesc IMarshalsToNative<Unmanaged.IDevice.ShaderCacheDesc>.AsNative(
        ref GrowingStackBuffer buffer
    ) => new() { shaderCachePath = buffer.GetStringPtr(Path), maxEntryCount = MaxEntryCount };

    public static unsafe ShaderCacheDescription CreateFromNative(
        Unmanaged.IDevice.ShaderCacheDesc unmanaged
    ) => new(InteropUtils.PtrToStringUtf8(unmanaged.shaderCachePath), unmanaged.maxEntryCount);
}
