using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='ICommandBuffer.xml' path='doc/member[@name="ICommandBuffer"]/*' />
[NativeTypeName("struct ICommandBuffer : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct ICommandBuffer
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(ICommandBuffer* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(ICommandBuffer* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(ICommandBuffer* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _encodeRenderCommands(ICommandBuffer* pThis, [NativeTypeName("gfx::IRenderPassLayout *")] IRenderPassLayout* renderPass, [NativeTypeName("gfx::IFramebuffer *")] IFramebuffer* framebuffer, IRenderCommandEncoder** outEncoder);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _encodeComputeCommands(ICommandBuffer* pThis, IComputeCommandEncoder** outEncoder);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _encodeResourceCommands(ICommandBuffer* pThis, IResourceCommandEncoder** outEncoder);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _encodeRayTracingCommands(ICommandBuffer* pThis, IRayTracingCommandEncoder** outEncoder);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _close(ICommandBuffer* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getNativeHandle(ICommandBuffer* pThis, [NativeTypeName("gfx::InteropHandle *")] InteropHandle* outHandle);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((ICommandBuffer*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((ICommandBuffer*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((ICommandBuffer*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ICommandBuffer.xml' path='doc/member[@name="ICommandBuffer.encodeRenderCommands"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void encodeRenderCommands([NativeTypeName("gfx::IRenderPassLayout *")] IRenderPassLayout* renderPass, [NativeTypeName("gfx::IFramebuffer *")] IFramebuffer* framebuffer, IRenderCommandEncoder** outEncoder)
    {
        Marshal.GetDelegateForFunctionPointer<_encodeRenderCommands>(lpVtbl->encodeRenderCommands)((ICommandBuffer*)Unsafe.AsPointer(ref this), renderPass, framebuffer, outEncoder);
    }

    /// <include file='ICommandBuffer.xml' path='doc/member[@name="ICommandBuffer.encodeComputeCommands"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void encodeComputeCommands(IComputeCommandEncoder** outEncoder)
    {
        Marshal.GetDelegateForFunctionPointer<_encodeComputeCommands>(lpVtbl->encodeComputeCommands)((ICommandBuffer*)Unsafe.AsPointer(ref this), outEncoder);
    }

    /// <include file='ICommandBuffer.xml' path='doc/member[@name="ICommandBuffer.encodeResourceCommands"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void encodeResourceCommands(IResourceCommandEncoder** outEncoder)
    {
        Marshal.GetDelegateForFunctionPointer<_encodeResourceCommands>(lpVtbl->encodeResourceCommands)((ICommandBuffer*)Unsafe.AsPointer(ref this), outEncoder);
    }

    /// <include file='ICommandBuffer.xml' path='doc/member[@name="ICommandBuffer.encodeRayTracingCommands"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void encodeRayTracingCommands(IRayTracingCommandEncoder** outEncoder)
    {
        Marshal.GetDelegateForFunctionPointer<_encodeRayTracingCommands>(lpVtbl->encodeRayTracingCommands)((ICommandBuffer*)Unsafe.AsPointer(ref this), outEncoder);
    }

    /// <include file='ICommandBuffer.xml' path='doc/member[@name="ICommandBuffer.close"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void close()
    {
        Marshal.GetDelegateForFunctionPointer<_close>(lpVtbl->close)((ICommandBuffer*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ICommandBuffer.xml' path='doc/member[@name="ICommandBuffer.getNativeHandle"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getNativeHandle([NativeTypeName("gfx::InteropHandle *")] InteropHandle* outHandle)
    {
        return Marshal.GetDelegateForFunctionPointer<_getNativeHandle>(lpVtbl->getNativeHandle)((ICommandBuffer*)Unsafe.AsPointer(ref this), outHandle);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((stdcall))")]
        public IntPtr release;

        [NativeTypeName("void (IRenderPassLayout *, IFramebuffer *, IRenderCommandEncoder **) __attribute__((stdcall))")]
        public IntPtr encodeRenderCommands;

        [NativeTypeName("void (IComputeCommandEncoder **) __attribute__((stdcall))")]
        public IntPtr encodeComputeCommands;

        [NativeTypeName("void (IResourceCommandEncoder **) __attribute__((stdcall))")]
        public IntPtr encodeResourceCommands;

        [NativeTypeName("void (IRayTracingCommandEncoder **) __attribute__((stdcall))")]
        public IntPtr encodeRayTracingCommands;

        [NativeTypeName("void () __attribute__((stdcall))")]
        public IntPtr close;

        [NativeTypeName("Result (InteropHandle *) __attribute__((stdcall))")]
        public IntPtr getNativeHandle;
    }
}
