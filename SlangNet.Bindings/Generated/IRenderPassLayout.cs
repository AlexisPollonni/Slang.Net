using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='IRenderPassLayout.xml' path='doc/member[@name="IRenderPassLayout"]/*' />
[NativeTypeName("struct IRenderPassLayout : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct IRenderPassLayout
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(IRenderPassLayout* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IRenderPassLayout* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IRenderPassLayout* pThis);

    /// <include file='TargetLoadOp.xml' path='doc/member[@name="TargetLoadOp"]/*' />
    public enum TargetLoadOp
    {
        /// <include file='TargetLoadOp.xml' path='doc/member[@name="TargetLoadOp.Load"]/*' />
        Load,

        /// <include file='TargetLoadOp.xml' path='doc/member[@name="TargetLoadOp.Clear"]/*' />
        Clear,

        /// <include file='TargetLoadOp.xml' path='doc/member[@name="TargetLoadOp.DontCare"]/*' />
        DontCare,
    }

    /// <include file='TargetStoreOp.xml' path='doc/member[@name="TargetStoreOp"]/*' />
    public enum TargetStoreOp
    {
        /// <include file='TargetStoreOp.xml' path='doc/member[@name="TargetStoreOp.Store"]/*' />
        Store,

        /// <include file='TargetStoreOp.xml' path='doc/member[@name="TargetStoreOp.DontCare"]/*' />
        DontCare,
    }

    /// <include file='TargetAccessDesc.xml' path='doc/member[@name="TargetAccessDesc"]/*' />
    public partial struct TargetAccessDesc
    {
        /// <include file='TargetAccessDesc.xml' path='doc/member[@name="TargetAccessDesc.loadOp"]/*' />
        [NativeTypeName("gfx::IRenderPassLayout::TargetLoadOp")]
        public TargetLoadOp loadOp;

        /// <include file='TargetAccessDesc.xml' path='doc/member[@name="TargetAccessDesc.stencilLoadOp"]/*' />
        [NativeTypeName("gfx::IRenderPassLayout::TargetLoadOp")]
        public TargetLoadOp stencilLoadOp;

        /// <include file='TargetAccessDesc.xml' path='doc/member[@name="TargetAccessDesc.storeOp"]/*' />
        [NativeTypeName("gfx::IRenderPassLayout::TargetStoreOp")]
        public TargetStoreOp storeOp;

        /// <include file='TargetAccessDesc.xml' path='doc/member[@name="TargetAccessDesc.stencilStoreOp"]/*' />
        [NativeTypeName("gfx::IRenderPassLayout::TargetStoreOp")]
        public TargetStoreOp stencilStoreOp;

        /// <include file='TargetAccessDesc.xml' path='doc/member[@name="TargetAccessDesc.initialState"]/*' />
        [NativeTypeName("gfx::ResourceState")]
        public ResourceState initialState;

        /// <include file='TargetAccessDesc.xml' path='doc/member[@name="TargetAccessDesc.finalState"]/*' />
        [NativeTypeName("gfx::ResourceState")]
        public ResourceState finalState;
    }

    /// <include file='RenderPassLayoutDesc.xml' path='doc/member[@name="RenderPassLayoutDesc"]/*' />
    public unsafe partial struct RenderPassLayoutDesc
    {
        /// <include file='RenderPassLayoutDesc.xml' path='doc/member[@name="RenderPassLayoutDesc.framebufferLayout"]/*' />
        [NativeTypeName("gfx::IFramebufferLayout *")]
        public IFramebufferLayout* framebufferLayout;

        /// <include file='RenderPassLayoutDesc.xml' path='doc/member[@name="RenderPassLayoutDesc.renderTargetCount"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int renderTargetCount;

        /// <include file='RenderPassLayoutDesc.xml' path='doc/member[@name="RenderPassLayoutDesc.renderTargetAccess"]/*' />
        [NativeTypeName("gfx::IRenderPassLayout::TargetAccessDesc *")]
        public TargetAccessDesc* renderTargetAccess;

        /// <include file='RenderPassLayoutDesc.xml' path='doc/member[@name="RenderPassLayoutDesc.depthStencilAccess"]/*' />
        [NativeTypeName("gfx::IRenderPassLayout::TargetAccessDesc *")]
        public TargetAccessDesc* depthStencilAccess;
    }

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((IRenderPassLayout*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((IRenderPassLayout*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((IRenderPassLayout*)Unsafe.AsPointer(ref this));
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr release;
    }
}
