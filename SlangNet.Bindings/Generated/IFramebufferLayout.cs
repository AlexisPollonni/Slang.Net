using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='IFramebufferLayout.xml' path='doc/member[@name="IFramebufferLayout"]/*' />
[NativeTypeName("struct IFramebufferLayout : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct IFramebufferLayout
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(IFramebufferLayout* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IFramebufferLayout* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IFramebufferLayout* pThis);

    /// <include file='TargetLayout.xml' path='doc/member[@name="TargetLayout"]/*' />
    public partial struct TargetLayout
    {
        /// <include file='TargetLayout.xml' path='doc/member[@name="TargetLayout.format"]/*' />
        [NativeTypeName("gfx::Format")]
        public Format format;

        /// <include file='TargetLayout.xml' path='doc/member[@name="TargetLayout.sampleCount"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int sampleCount;
    }

    /// <include file='FramebufferLayoutDesc.xml' path='doc/member[@name="FramebufferLayoutDesc"]/*' />
    public unsafe partial struct FramebufferLayoutDesc
    {
        /// <include file='FramebufferLayoutDesc.xml' path='doc/member[@name="FramebufferLayoutDesc.renderTargetCount"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int renderTargetCount;

        /// <include file='FramebufferLayoutDesc.xml' path='doc/member[@name="FramebufferLayoutDesc.renderTargets"]/*' />
        [NativeTypeName("gfx::IFramebufferLayout::TargetLayout *")]
        public TargetLayout* renderTargets;

        /// <include file='FramebufferLayoutDesc.xml' path='doc/member[@name="FramebufferLayoutDesc.depthStencil"]/*' />
        [NativeTypeName("gfx::IFramebufferLayout::TargetLayout *")]
        public TargetLayout* depthStencil;
    }

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((IFramebufferLayout*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((IFramebufferLayout*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((IFramebufferLayout*)Unsafe.AsPointer(ref this));
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **)")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t ()")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t ()")]
        public IntPtr release;
    }
}
