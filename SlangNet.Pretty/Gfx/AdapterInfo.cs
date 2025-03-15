using System;
using System.Diagnostics.CodeAnalysis;
using SlangNet.Internal;

namespace SlangNet.Gfx;

public readonly record struct AdapterInfo(string Name, uint VendorId, uint DeviceId, AdapterLUID LUID)
    : IMarshalsFromNative<AdapterInfo, Unsafe.AdapterInfo>
{
    public unsafe static void CreateFromNative(Unsafe.AdapterInfo native, out AdapterInfo managed)
    {
        var namePtr = (sbyte*)&native.name;
        managed = new(
            InteropUtils.PtrToStringUTF8(namePtr) ?? "Error: Could not get device name",
            native.vendorID,
            native.deviceID,
            native.luid);
    }
}