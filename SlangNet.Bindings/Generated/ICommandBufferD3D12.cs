using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='ICommandBufferD3D12.xml' path='doc/member[@name="ICommandBufferD3D12"]/*' />
[NativeTypeName("struct ICommandBufferD3D12 : gfx::ICommandBuffer")]
[NativeInheritance("ICommandBuffer")]
public unsafe partial struct ICommandBufferD3D12
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(ICommandBufferD3D12* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(ICommandBufferD3D12* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(ICommandBufferD3D12* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _encodeRenderCommands(ICommandBufferD3D12* pThis, [NativeTypeName("gfx::IRenderPassLayout *")] IRenderPassLayout* renderPass, [NativeTypeName("gfx::IFramebuffer *")] IFramebuffer* framebuffer, IRenderCommandEncoder** outEncoder);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _encodeComputeCommands(ICommandBufferD3D12* pThis, IComputeCommandEncoder** outEncoder);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _encodeResourceCommands(ICommandBufferD3D12* pThis, IResourceCommandEncoder** outEncoder);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _encodeRayTracingCommands(ICommandBufferD3D12* pThis, IRayTracingCommandEncoder** outEncoder);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _close(ICommandBufferD3D12* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getNativeHandle(ICommandBufferD3D12* pThis, [NativeTypeName("gfx::InteropHandle *")] InteropHandle* outHandle);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _invalidateDescriptorHeapBinding(ICommandBufferD3D12* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _ensureInternalDescriptorHeapsBound(ICommandBufferD3D12* pThis);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((ICommandBufferD3D12*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((ICommandBufferD3D12*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((ICommandBufferD3D12*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ICommandBuffer.encodeRenderCommands" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void encodeRenderCommands([NativeTypeName("gfx::IRenderPassLayout *")] IRenderPassLayout* renderPass, [NativeTypeName("gfx::IFramebuffer *")] IFramebuffer* framebuffer, IRenderCommandEncoder** outEncoder)
    {
        Marshal.GetDelegateForFunctionPointer<_encodeRenderCommands>(lpVtbl->encodeRenderCommands)((ICommandBufferD3D12*)Unsafe.AsPointer(ref this), renderPass, framebuffer, outEncoder);
    }

    /// <inheritdoc cref="ICommandBuffer.encodeComputeCommands" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void encodeComputeCommands(IComputeCommandEncoder** outEncoder)
    {
        Marshal.GetDelegateForFunctionPointer<_encodeComputeCommands>(lpVtbl->encodeComputeCommands)((ICommandBufferD3D12*)Unsafe.AsPointer(ref this), outEncoder);
    }

    /// <inheritdoc cref="ICommandBuffer.encodeResourceCommands" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void encodeResourceCommands(IResourceCommandEncoder** outEncoder)
    {
        Marshal.GetDelegateForFunctionPointer<_encodeResourceCommands>(lpVtbl->encodeResourceCommands)((ICommandBufferD3D12*)Unsafe.AsPointer(ref this), outEncoder);
    }

    /// <inheritdoc cref="ICommandBuffer.encodeRayTracingCommands" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void encodeRayTracingCommands(IRayTracingCommandEncoder** outEncoder)
    {
        Marshal.GetDelegateForFunctionPointer<_encodeRayTracingCommands>(lpVtbl->encodeRayTracingCommands)((ICommandBufferD3D12*)Unsafe.AsPointer(ref this), outEncoder);
    }

    /// <inheritdoc cref="ICommandBuffer.close" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void close()
    {
        Marshal.GetDelegateForFunctionPointer<_close>(lpVtbl->close)((ICommandBufferD3D12*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ICommandBuffer.getNativeHandle" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getNativeHandle([NativeTypeName("gfx::InteropHandle *")] InteropHandle* outHandle)
    {
        return Marshal.GetDelegateForFunctionPointer<_getNativeHandle>(lpVtbl->getNativeHandle)((ICommandBufferD3D12*)Unsafe.AsPointer(ref this), outHandle);
    }

    /// <include file='ICommandBufferD3D12.xml' path='doc/member[@name="ICommandBufferD3D12.invalidateDescriptorHeapBinding"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void invalidateDescriptorHeapBinding()
    {
        Marshal.GetDelegateForFunctionPointer<_invalidateDescriptorHeapBinding>(lpVtbl->invalidateDescriptorHeapBinding)((ICommandBufferD3D12*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ICommandBufferD3D12.xml' path='doc/member[@name="ICommandBufferD3D12.ensureInternalDescriptorHeapsBound"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ensureInternalDescriptorHeapsBound()
    {
        Marshal.GetDelegateForFunctionPointer<_ensureInternalDescriptorHeapsBound>(lpVtbl->ensureInternalDescriptorHeapsBound)((ICommandBufferD3D12*)Unsafe.AsPointer(ref this));
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr release;

        [NativeTypeName("void (IRenderPassLayout *, IFramebuffer *, IRenderCommandEncoder **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr encodeRenderCommands;

        [NativeTypeName("void (IComputeCommandEncoder **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr encodeComputeCommands;

        [NativeTypeName("void (IResourceCommandEncoder **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr encodeResourceCommands;

        [NativeTypeName("void (IRayTracingCommandEncoder **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr encodeRayTracingCommands;

        [NativeTypeName("void () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr close;

        [NativeTypeName("Result (InteropHandle *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getNativeHandle;

        [NativeTypeName("void () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr invalidateDescriptorHeapBinding;

        [NativeTypeName("void () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr ensureInternalDescriptorHeapsBound;
    }
}
