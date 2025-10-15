using CommunityToolkit.HighPerformance;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Gfx.Descriptions;

public readonly record struct AdapterInfo(string Name, uint VendorId, uint DeviceId, Guid Luid)
    : IMarshalsFromNative<AdapterInfo, Unmanaged.AdapterInfo>
{
    public static unsafe AdapterInfo CreateFromNative(Unmanaged.AdapterInfo unmanaged)
    {
        var namePtr = (sbyte*)&unmanaged.name;
        return new(
            InteropUtils.PtrToStringUtf8(namePtr) ?? "Error: Could not get device name",
            unmanaged.vendorID,
            unmanaged.deviceID,
            new(unmanaged.luid.AsReadOnlySpan().AsBytes())
        );
    }
}
