using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='IResourceView.xml' path='doc/member[@name="IResourceView"]/*' />
[NativeTypeName("struct IResourceView : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct IResourceView
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(
        IResourceView* pThis,
        [NativeTypeName("const SlangUUID &")] SlangUUID* uuid,
        void** outObject
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IResourceView* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IResourceView* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::IResourceView::Desc *")]
    public delegate ResourceViewDesc* _getViewDesc(IResourceView* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getNativeHandle(
        IResourceView* pThis,
        [NativeTypeName("gfx::InteropHandle *")] InteropHandle* outNativeHandle
    );

    /// <include file='ResourceViewType.xml' path='doc/member[@name="ResourceViewType"]/*' />
    public enum ResourceViewType
    {
        /// <include file='ResourceViewType.xml' path='doc/member[@name="ResourceViewType.Unknown"]/*' />
        Unknown,

        /// <include file='ResourceViewType.xml' path='doc/member[@name="ResourceViewType.RenderTarget"]/*' />
        RenderTarget,

        /// <include file='ResourceViewType.xml' path='doc/member[@name="ResourceViewType.DepthStencil"]/*' />
        DepthStencil,

        /// <include file='ResourceViewType.xml' path='doc/member[@name="ResourceViewType.ShaderResource"]/*' />
        ShaderResource,

        /// <include file='ResourceViewType.xml' path='doc/member[@name="ResourceViewType.UnorderedAccess"]/*' />
        UnorderedAccess,

        /// <include file='ResourceViewType.xml' path='doc/member[@name="ResourceViewType.AccelerationStructure"]/*' />
        AccelerationStructure,

        /// <include file='ResourceViewType.xml' path='doc/member[@name="ResourceViewType.CountOf_"]/*' />
        CountOf_,
    }

    /// <include file='RenderTargetDesc.xml' path='doc/member[@name="RenderTargetDesc"]/*' />
    public partial struct RenderTargetDesc
    {
        /// <include file='RenderTargetDesc.xml' path='doc/member[@name="RenderTargetDesc.shape"]/*' />
        [NativeTypeName("gfx::IResource::Type")]
        public ResourceType shape;
    }

    /// <include file='ResourceViewDesc.xml' path='doc/member[@name="ResourceViewDesc"]/*' />
    public partial struct ResourceViewDesc
    {
        /// <include file='ResourceViewDesc.xml' path='doc/member[@name="ResourceViewDesc.type"]/*' />
        [NativeTypeName("gfx::IResourceView::Type")]
        public ResourceViewType type;

        /// <include file='ResourceViewDesc.xml' path='doc/member[@name="ResourceViewDesc.format"]/*' />
        [NativeTypeName("gfx::Format")]
        public Format format;

        /// <include file='ResourceViewDesc.xml' path='doc/member[@name="ResourceViewDesc.renderTarget"]/*' />
        [NativeTypeName("gfx::IResourceView::RenderTargetDesc")]
        public RenderTargetDesc renderTarget;

        /// <include file='ResourceViewDesc.xml' path='doc/member[@name="ResourceViewDesc.subresourceRange"]/*' />
        [NativeTypeName("gfx::SubresourceRange")]
        public SubresourceRange subresourceRange;

        /// <include file='ResourceViewDesc.xml' path='doc/member[@name="ResourceViewDesc.bufferRange"]/*' />
        [NativeTypeName("gfx::BufferRange")]
        public BufferRange bufferRange;
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
            (IResourceView*)Unsafe.AsPointer(ref this),
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
            (IResourceView*)Unsafe.AsPointer(ref this)
        );
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)(
            (IResourceView*)Unsafe.AsPointer(ref this)
        );
    }

    /// <include file='IResourceView.xml' path='doc/member[@name="IResourceView.getViewDesc"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::IResourceView::Desc *")]
    public ResourceViewDesc* getViewDesc()
    {
        return Marshal.GetDelegateForFunctionPointer<_getViewDesc>(lpVtbl->getViewDesc)(
            (IResourceView*)Unsafe.AsPointer(ref this)
        );
    }

    /// <include file='IResourceView.xml' path='doc/member[@name="IResourceView.getNativeHandle"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getNativeHandle(
        [NativeTypeName("gfx::InteropHandle *")] InteropHandle* outNativeHandle
    )
    {
        return Marshal.GetDelegateForFunctionPointer<_getNativeHandle>(lpVtbl->getNativeHandle)(
            (IResourceView*)Unsafe.AsPointer(ref this),
            outNativeHandle
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

        [NativeTypeName("Desc *() __attribute__((stdcall))")]
        public IntPtr getViewDesc;

        [NativeTypeName("Result (InteropHandle *) __attribute__((stdcall))")]
        public IntPtr getNativeHandle;
    }
}
