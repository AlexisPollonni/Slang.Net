using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='ICommandQueue.xml' path='doc/member[@name="ICommandQueue"]/*' />
[NativeTypeName("struct ICommandQueue : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct ICommandQueue
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(ICommandQueue* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(ICommandQueue* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(ICommandQueue* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("const Desc &")]
    public delegate CommandQueueDesc* _getDesc(ICommandQueue* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _executeCommandBuffers(ICommandQueue* pThis, [NativeTypeName("gfx::GfxCount")] int count, [NativeTypeName("ICommandBuffer *const *")] ICommandBuffer** commandBuffers, [NativeTypeName("gfx::IFence *")] IFence* fenceToSignal, [NativeTypeName("uint64_t")] ulong newFenceValue);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getNativeHandle(ICommandQueue* pThis, [NativeTypeName("gfx::InteropHandle *")] InteropHandle* outHandle);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _waitOnHost(ICommandQueue* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _waitForFenceValuesOnDevice(ICommandQueue* pThis, [NativeTypeName("gfx::GfxCount")] int fenceCount, IFence** fences, [NativeTypeName("uint64_t *")] ulong* waitValues);

    /// <include file='QueueType.xml' path='doc/member[@name="QueueType"]/*' />
    public enum QueueType
    {
        /// <include file='QueueType.xml' path='doc/member[@name="QueueType.Graphics"]/*' />
        Graphics,
    }

    /// <include file='CommandQueueDesc.xml' path='doc/member[@name="CommandQueueDesc"]/*' />
    public partial struct CommandQueueDesc
    {
        /// <include file='CommandQueueDesc.xml' path='doc/member[@name="CommandQueueDesc.type"]/*' />
        [NativeTypeName("gfx::ICommandQueue::QueueType")]
        public QueueType type;
    }

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((ICommandQueue*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((ICommandQueue*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((ICommandQueue*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ICommandQueue.xml' path='doc/member[@name="ICommandQueue.getDesc"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("const Desc &")]
    public CommandQueueDesc* getDesc()
    {
        return Marshal.GetDelegateForFunctionPointer<_getDesc>(lpVtbl->getDesc)((ICommandQueue*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ICommandQueue.xml' path='doc/member[@name="ICommandQueue.executeCommandBuffers"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void executeCommandBuffers([NativeTypeName("gfx::GfxCount")] int count, [NativeTypeName("ICommandBuffer *const *")] ICommandBuffer** commandBuffers, [NativeTypeName("gfx::IFence *")] IFence* fenceToSignal, [NativeTypeName("uint64_t")] ulong newFenceValue)
    {
        Marshal.GetDelegateForFunctionPointer<_executeCommandBuffers>(lpVtbl->executeCommandBuffers)((ICommandQueue*)Unsafe.AsPointer(ref this), count, commandBuffers, fenceToSignal, newFenceValue);
    }

    /// <include file='ICommandQueue.xml' path='doc/member[@name="ICommandQueue.getNativeHandle"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getNativeHandle([NativeTypeName("gfx::InteropHandle *")] InteropHandle* outHandle)
    {
        return Marshal.GetDelegateForFunctionPointer<_getNativeHandle>(lpVtbl->getNativeHandle)((ICommandQueue*)Unsafe.AsPointer(ref this), outHandle);
    }

    /// <include file='ICommandQueue.xml' path='doc/member[@name="ICommandQueue.waitOnHost"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void waitOnHost()
    {
        Marshal.GetDelegateForFunctionPointer<_waitOnHost>(lpVtbl->waitOnHost)((ICommandQueue*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ICommandQueue.xml' path='doc/member[@name="ICommandQueue.waitForFenceValuesOnDevice"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int waitForFenceValuesOnDevice([NativeTypeName("gfx::GfxCount")] int fenceCount, IFence** fences, [NativeTypeName("uint64_t *")] ulong* waitValues)
    {
        return Marshal.GetDelegateForFunctionPointer<_waitForFenceValuesOnDevice>(lpVtbl->waitForFenceValuesOnDevice)((ICommandQueue*)Unsafe.AsPointer(ref this), fenceCount, fences, waitValues);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((stdcall))")]
        public IntPtr release;

        [NativeTypeName("const Desc &() __attribute__((stdcall))")]
        public IntPtr getDesc;

        [NativeTypeName("void (GfxCount, ICommandBuffer *const *, IFence *, uint64_t) __attribute__((stdcall))")]
        public IntPtr executeCommandBuffers;

        [NativeTypeName("Result (InteropHandle *) __attribute__((stdcall))")]
        public IntPtr getNativeHandle;

        [NativeTypeName("void () __attribute__((stdcall))")]
        public IntPtr waitOnHost;

        [NativeTypeName("Result (GfxCount, IFence **, uint64_t *) __attribute__((stdcall))")]
        public IntPtr waitForFenceValuesOnDevice;
    }
}
