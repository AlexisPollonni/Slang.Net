using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='ITransientResourceHeap.xml' path='doc/member[@name="ITransientResourceHeap"]/*' />
[NativeTypeName("struct ITransientResourceHeap : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct ITransientResourceHeap
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(ITransientResourceHeap* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(ITransientResourceHeap* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(ITransientResourceHeap* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _synchronizeAndReset(ITransientResourceHeap* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _finish(ITransientResourceHeap* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createCommandBuffer(ITransientResourceHeap* pThis, ICommandBuffer** outCommandBuffer);

    /// <include file='Flags.xml' path='doc/member[@name="Flags"]/*' />
    public partial struct Flags
    {

        /// <include file='Enum.xml' path='doc/member[@name="Enum"]/*' />
        [NativeTypeName("unsigned int")]
        public enum Enum : uint
        {
            /// <include file='Enum.xml' path='doc/member[@name="Enum.None"]/*' />
            None = 0,

            /// <include file='Enum.xml' path='doc/member[@name="Enum.AllowResizing"]/*' />
            AllowResizing = 0x1,
        }
    }

    /// <include file='TransientResourceHeapDesc.xml' path='doc/member[@name="TransientResourceHeapDesc"]/*' />
    public partial struct TransientResourceHeapDesc
    {
        /// <include file='TransientResourceHeapDesc.xml' path='doc/member[@name="TransientResourceHeapDesc.flags"]/*' />
        [NativeTypeName("gfx::ITransientResourceHeap::Flags::Enum")]
        public Enum flags;

        /// <include file='TransientResourceHeapDesc.xml' path='doc/member[@name="TransientResourceHeapDesc.constantBufferSize"]/*' />
        [NativeTypeName("gfx::Size")]
        public nuint constantBufferSize;

        /// <include file='TransientResourceHeapDesc.xml' path='doc/member[@name="TransientResourceHeapDesc.samplerDescriptorCount"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int samplerDescriptorCount;

        /// <include file='TransientResourceHeapDesc.xml' path='doc/member[@name="TransientResourceHeapDesc.uavDescriptorCount"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int uavDescriptorCount;

        /// <include file='TransientResourceHeapDesc.xml' path='doc/member[@name="TransientResourceHeapDesc.srvDescriptorCount"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int srvDescriptorCount;

        /// <include file='TransientResourceHeapDesc.xml' path='doc/member[@name="TransientResourceHeapDesc.constantBufferDescriptorCount"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int constantBufferDescriptorCount;

        /// <include file='TransientResourceHeapDesc.xml' path='doc/member[@name="TransientResourceHeapDesc.accelerationStructureDescriptorCount"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int accelerationStructureDescriptorCount;
    }

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((ITransientResourceHeap*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((ITransientResourceHeap*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((ITransientResourceHeap*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ITransientResourceHeap.xml' path='doc/member[@name="ITransientResourceHeap.synchronizeAndReset"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int synchronizeAndReset()
    {
        return Marshal.GetDelegateForFunctionPointer<_synchronizeAndReset>(lpVtbl->synchronizeAndReset)((ITransientResourceHeap*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ITransientResourceHeap.xml' path='doc/member[@name="ITransientResourceHeap.finish"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int finish()
    {
        return Marshal.GetDelegateForFunctionPointer<_finish>(lpVtbl->finish)((ITransientResourceHeap*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ITransientResourceHeap.xml' path='doc/member[@name="ITransientResourceHeap.createCommandBuffer"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createCommandBuffer(ICommandBuffer** outCommandBuffer)
    {
        return Marshal.GetDelegateForFunctionPointer<_createCommandBuffer>(lpVtbl->createCommandBuffer)((ITransientResourceHeap*)Unsafe.AsPointer(ref this), outCommandBuffer);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **)")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t ()")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t ()")]
        public IntPtr release;

        [NativeTypeName("Result ()")]
        public IntPtr synchronizeAndReset;

        [NativeTypeName("Result ()")]
        public IntPtr finish;

        [NativeTypeName("Result (ICommandBuffer **)")]
        public IntPtr createCommandBuffer;
    }
}
