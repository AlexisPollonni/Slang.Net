using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='IFramebuffer.xml' path='doc/member[@name="IFramebuffer"]/*' />
[NativeTypeName("struct IFramebuffer : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct IFramebuffer
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(
        IFramebuffer* pThis,
        [NativeTypeName("const SlangUUID &")] SlangUUID* uuid,
        void** outObject
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IFramebuffer* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IFramebuffer* pThis);

    /// <include file='FramebufferDesc.xml' path='doc/member[@name="FramebufferDesc"]/*' />
    public unsafe partial struct FramebufferDesc
    {
        /// <include file='FramebufferDesc.xml' path='doc/member[@name="FramebufferDesc.renderTargetCount"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int renderTargetCount;

        /// <include file='FramebufferDesc.xml' path='doc/member[@name="FramebufferDesc.renderTargetViews"]/*' />
        [NativeTypeName("IResourceView *const *")]
        public IResourceView** renderTargetViews;

        /// <include file='FramebufferDesc.xml' path='doc/member[@name="FramebufferDesc.depthStencilView"]/*' />
        [NativeTypeName("gfx::IResourceView *")]
        public IResourceView* depthStencilView;

        /// <include file='FramebufferDesc.xml' path='doc/member[@name="FramebufferDesc.layout"]/*' />
        [NativeTypeName("gfx::IFramebufferLayout *")]
        public IFramebufferLayout* layout;
    }

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface(
        [NativeTypeName("const SlangUUID &")] SlangUUID* uuid,
        void** outObject
    )
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)(
            (IFramebuffer*)Unsafe.AsPointer(ref this),
            uuid,
            outObject
        );
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)(
            (IFramebuffer*)Unsafe.AsPointer(ref this)
        );
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)(
            (IFramebuffer*)Unsafe.AsPointer(ref this)
        );
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((stdcall))")]
        public IntPtr release;
    }
}
