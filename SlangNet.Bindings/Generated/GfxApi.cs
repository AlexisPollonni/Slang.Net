using System;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

public static unsafe partial class GfxApi
{
    [NativeTypeName("const GfxCount")]
    public const int kMaxRenderTargetCount = 8;

    public const int EnableNone = 0;
    public const int EnableRed = 0x01;
    public const int EnableGreen = 0x02;
    public const int EnableBlue = 0x04;
    public const int EnableAlpha = 0x08;
    public const int EnableAll = 0x0F;

    /// <include file='GfxApi.xml' path='doc/member[@name="GfxApi.gfxIsCompressedFormat"]/*' />
    [DllImport("gfx", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte gfxIsCompressedFormat([NativeTypeName("gfx::Format")] Format format);

    /// <include file='GfxApi.xml' path='doc/member[@name="GfxApi.gfxIsTypelessFormat"]/*' />
    [DllImport("gfx", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
    [return: NativeTypeName("bool")]
    public static extern byte gfxIsTypelessFormat([NativeTypeName("gfx::Format")] Format format);

    /// <include file='GfxApi.xml' path='doc/member[@name="GfxApi.gfxGetFormatInfo"]/*' />
    [DllImport("gfx", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int gfxGetFormatInfo([NativeTypeName("gfx::Format")] Format format, [NativeTypeName("gfx::FormatInfo *")] FormatInfo* outInfo);

    /// <include file='GfxApi.xml' path='doc/member[@name="GfxApi.gfxGetAdapters"]/*' />
    [DllImport("gfx", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int gfxGetAdapters([NativeTypeName("gfx::DeviceType")] DeviceType type, ISlangBlob** outAdaptersBlob);

    /// <include file='GfxApi.xml' path='doc/member[@name="GfxApi.gfxCreateDevice"]/*' />
    [DllImport("gfx", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int gfxCreateDevice([NativeTypeName("const IDevice::Desc *")] DeviceDesc* desc, IDevice** outDevice);

    /// <include file='GfxApi.xml' path='doc/member[@name="GfxApi.gfxReportLiveObjects"]/*' />
    [DllImport("gfx", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int gfxReportLiveObjects();

    /// <include file='GfxApi.xml' path='doc/member[@name="GfxApi.gfxSetDebugCallback"]/*' />
    [DllImport("gfx", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
    [return: NativeTypeName("SlangResult")]
    public static extern int gfxSetDebugCallback([NativeTypeName("gfx::IDebugCallback *")] IDebugCallback* callback);

    /// <include file='GfxApi.xml' path='doc/member[@name="GfxApi.gfxEnableDebugLayer"]/*' />
    [DllImport("gfx", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
    public static extern void gfxEnableDebugLayer();

    /// <include file='GfxApi.xml' path='doc/member[@name="GfxApi.gfxGetDeviceTypeName"]/*' />
    [DllImport("gfx", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* gfxGetDeviceTypeName([NativeTypeName("gfx::DeviceType")] DeviceType type);

    public static readonly Guid IID_ICommandEncoder = new Guid(0x77EA6383, 0xBE3D, 0x40AA, 0x8B, 0x45, 0xFD, 0xF0, 0xD7, 0x5B, 0xFA, 0x34);

    public static readonly Guid IID_IResourceCommandEncoder = new Guid(0xF99A00E9, 0xED50, 0x4088, 0x8A, 0x0E, 0x3B, 0x26, 0x75, 0x50, 0x31, 0xEA);

    public static readonly Guid IID_IRenderCommandEncoder = new Guid(0x7A8D56D0, 0x53E6, 0x4AD6, 0x85, 0xF7, 0xD1, 0x4D, 0xC1, 0x10, 0xFD, 0xCE);

    public static readonly Guid IID_IComputeCommandEncoder = new Guid(0x88AA9322, 0x82F7, 0x4FE6, 0xA6, 0x8A, 0x29, 0xC7, 0xFE, 0x79, 0x87, 0x37);

    public static readonly Guid IID_IRayTracingCommandEncoder = new Guid(0x9A672B87, 0x5035, 0x45E3, 0x96, 0x7C, 0x1F, 0x85, 0xCD, 0xB3, 0x63, 0x4F);
}
