using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='ISwapchain.xml' path='doc/member[@name="ISwapchain"]/*' />
[NativeTypeName("struct ISwapchain : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct ISwapchain
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(ISwapchain* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(ISwapchain* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(ISwapchain* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("const Desc &")]
    public delegate SwapchainDesc* _getDesc(ISwapchain* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getImage(ISwapchain* pThis, [NativeTypeName("gfx::GfxIndex")] int index, ITextureResource** outResource);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _present(ISwapchain* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _acquireNextImage(ISwapchain* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _resize(ISwapchain* pThis, [NativeTypeName("gfx::GfxCount")] int width, [NativeTypeName("gfx::GfxCount")] int height);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("bool")]
    public delegate byte _isOccluded(ISwapchain* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _setFullScreenMode(ISwapchain* pThis, [NativeTypeName("bool")] byte mode);

    /// <include file='SwapchainDesc.xml' path='doc/member[@name="SwapchainDesc"]/*' />
    public unsafe partial struct SwapchainDesc
    {
        /// <include file='SwapchainDesc.xml' path='doc/member[@name="SwapchainDesc.format"]/*' />
        [NativeTypeName("gfx::Format")]
        public Format format;

        /// <include file='SwapchainDesc.xml' path='doc/member[@name="SwapchainDesc.width"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int width;

        /// <include file='SwapchainDesc.xml' path='doc/member[@name="SwapchainDesc.height"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int height;

        /// <include file='SwapchainDesc.xml' path='doc/member[@name="SwapchainDesc.imageCount"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int imageCount;

        /// <include file='SwapchainDesc.xml' path='doc/member[@name="SwapchainDesc.queue"]/*' />
        [NativeTypeName("gfx::ICommandQueue *")]
        public ICommandQueue* queue;

        /// <include file='SwapchainDesc.xml' path='doc/member[@name="SwapchainDesc.enableVSync"]/*' />
        [NativeTypeName("bool")]
        public byte enableVSync;
    }

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((ISwapchain*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((ISwapchain*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((ISwapchain*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISwapchain.xml' path='doc/member[@name="ISwapchain.getDesc"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("const Desc &")]
    public SwapchainDesc* getDesc()
    {
        return Marshal.GetDelegateForFunctionPointer<_getDesc>(lpVtbl->getDesc)((ISwapchain*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISwapchain.xml' path='doc/member[@name="ISwapchain.getImage"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getImage([NativeTypeName("gfx::GfxIndex")] int index, ITextureResource** outResource)
    {
        return Marshal.GetDelegateForFunctionPointer<_getImage>(lpVtbl->getImage)((ISwapchain*)Unsafe.AsPointer(ref this), index, outResource);
    }

    /// <include file='ISwapchain.xml' path='doc/member[@name="ISwapchain.present"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int present()
    {
        return Marshal.GetDelegateForFunctionPointer<_present>(lpVtbl->present)((ISwapchain*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISwapchain.xml' path='doc/member[@name="ISwapchain.acquireNextImage"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int acquireNextImage()
    {
        return Marshal.GetDelegateForFunctionPointer<_acquireNextImage>(lpVtbl->acquireNextImage)((ISwapchain*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISwapchain.xml' path='doc/member[@name="ISwapchain.resize"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int resize([NativeTypeName("gfx::GfxCount")] int width, [NativeTypeName("gfx::GfxCount")] int height)
    {
        return Marshal.GetDelegateForFunctionPointer<_resize>(lpVtbl->resize)((ISwapchain*)Unsafe.AsPointer(ref this), width, height);
    }

    /// <include file='ISwapchain.xml' path='doc/member[@name="ISwapchain.isOccluded"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool isOccluded()
    {
        return Marshal.GetDelegateForFunctionPointer<_isOccluded>(lpVtbl->isOccluded)((ISwapchain*)Unsafe.AsPointer(ref this)) != 0;
    }

    /// <include file='ISwapchain.xml' path='doc/member[@name="ISwapchain.setFullScreenMode"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int setFullScreenMode([NativeTypeName("bool")] byte mode)
    {
        return Marshal.GetDelegateForFunctionPointer<_setFullScreenMode>(lpVtbl->setFullScreenMode)((ISwapchain*)Unsafe.AsPointer(ref this), mode);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr release;

        [NativeTypeName("const Desc &() __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getDesc;

        [NativeTypeName("Result (GfxIndex, ITextureResource **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getImage;

        [NativeTypeName("Result () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr present;

        [NativeTypeName("int () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr acquireNextImage;

        [NativeTypeName("Result (GfxCount, GfxCount) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr resize;

        [NativeTypeName("bool () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr isOccluded;

        [NativeTypeName("Result (bool) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr setFullScreenMode;
    }
}
