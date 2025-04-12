using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Gfx.Descriptions;
using SlangNet.ComWrappers.Gfx.Interfaces;
using SlangNet.ComWrappers.Interfaces;
using SlangNet.ComWrappers.Tools;
using DeviceType = SlangNet.Bindings.Generated.DeviceType;
using Format = SlangNet.Bindings.Generated.Format;
using FormatInfo = SlangNet.Bindings.Generated.FormatInfo;

namespace SlangNet.ComWrappers.Gfx;

public static partial class Gfx
{
    [LibraryImport("gfx", EntryPoint = "gfxIsCompressedFormat")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool IsCompressedFormat(Format format);

    [LibraryImport("gfx", EntryPoint = "gfxIsTypelessFormat")]
    [return: MarshalAs(UnmanagedType.I1)]
    public static partial bool IsTypelessFormat(Format format);

    [LibraryImport("gfx", EntryPoint = "gfxGetFormatInfo")]
    public static partial SlangResult GetFormatInfo(Format format, out FormatInfo outInfo);

    [LibraryImport("gfx", EntryPoint = "gfxGetAdapters")]
    public static partial SlangResult GetAdapters(DeviceType type, out IBlob outAdaptersBlob);

    [LibraryImport("gfx", EntryPoint = "gfxCreateDevice")]
    public static partial SlangResult CreateDevice(in DeviceDescription desc, out IDevice outDevice);

    [LibraryImport("gfx", EntryPoint = "gfxReportLiveObjects")]
    public static partial SlangResult ReportLiveObjects();
    
    [LibraryImport("gfx", EntryPoint = "gfxSetDebugCallback")]
    public static partial SlangResult SetDebugCallback(in Unmanaged.IDebugCallback callback);
    
    [LibraryImport("gfx", EntryPoint = "gfxEnableDebugLayer")]
    public static partial void EnableDebugLayer();

    [LibraryImport("gfx", EntryPoint = "gfxGetDeviceTypeName")]
    [return: MarshalUsing(typeof(UnownedUTF8StringMarshaller))]
    public static partial string? GetDeviceTypeName(DeviceType type);

} 