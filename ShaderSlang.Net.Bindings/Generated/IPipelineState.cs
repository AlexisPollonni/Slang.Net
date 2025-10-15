using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='IPipelineState.xml' path='doc/member[@name="IPipelineState"]/*' />
[NativeTypeName("struct IPipelineState : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct IPipelineState
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(
        IPipelineState* pThis,
        [NativeTypeName("const SlangUUID &")] SlangUUID* uuid,
        void** outObject
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IPipelineState* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IPipelineState* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getNativeHandle(
        IPipelineState* pThis,
        [NativeTypeName("gfx::InteropHandle *")] InteropHandle* outHandle
    );

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface(
        [NativeTypeName("const SlangUUID &")] SlangUUID* uuid,
        void** outObject
    )
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)(
            (IPipelineState*)Unsafe.AsPointer(ref this),
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
            (IPipelineState*)Unsafe.AsPointer(ref this)
        );
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)(
            (IPipelineState*)Unsafe.AsPointer(ref this)
        );
    }

    /// <include file='IPipelineState.xml' path='doc/member[@name="IPipelineState.getNativeHandle"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getNativeHandle([NativeTypeName("gfx::InteropHandle *")] InteropHandle* outHandle)
    {
        return Marshal.GetDelegateForFunctionPointer<_getNativeHandle>(lpVtbl->getNativeHandle)(
            (IPipelineState*)Unsafe.AsPointer(ref this),
            outHandle
        );
    }

    public partial struct Vtbl
    {
        [NativeTypeName(
            "SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))"
        )]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr release;

        [NativeTypeName(
            "Result (InteropHandle *) __attribute__((nothrow)) __attribute__((stdcall))"
        )]
        public IntPtr getNativeHandle;
    }
}
