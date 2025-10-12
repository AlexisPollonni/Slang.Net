using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='IFence.xml' path='doc/member[@name="IFence"]/*' />
[NativeTypeName("struct IFence : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct IFence
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(IFence* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IFence* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IFence* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getCurrentValue(IFence* pThis, [NativeTypeName("uint64_t *")] ulong* outValue);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _setCurrentValue(IFence* pThis, [NativeTypeName("uint64_t")] ulong value);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getSharedHandle(IFence* pThis, [NativeTypeName("gfx::InteropHandle *")] InteropHandle* outHandle);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getNativeHandle(IFence* pThis, [NativeTypeName("gfx::InteropHandle *")] InteropHandle* outNativeHandle);

    /// <include file='FenceDesc.xml' path='doc/member[@name="FenceDesc"]/*' />
    public partial struct FenceDesc
    {
        /// <include file='FenceDesc.xml' path='doc/member[@name="FenceDesc.initialValue"]/*' />
        [NativeTypeName("uint64_t")]
        public ulong initialValue;

        /// <include file='FenceDesc.xml' path='doc/member[@name="FenceDesc.isShared"]/*' />
        [NativeTypeName("bool")]
        public Boolean isShared;
    }

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((IFence*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((IFence*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((IFence*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IFence.xml' path='doc/member[@name="IFence.getCurrentValue"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getCurrentValue([NativeTypeName("uint64_t *")] ulong* outValue)
    {
        return Marshal.GetDelegateForFunctionPointer<_getCurrentValue>(lpVtbl->getCurrentValue)((IFence*)Unsafe.AsPointer(ref this), outValue);
    }

    /// <include file='IFence.xml' path='doc/member[@name="IFence.setCurrentValue"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int setCurrentValue([NativeTypeName("uint64_t")] ulong value)
    {
        return Marshal.GetDelegateForFunctionPointer<_setCurrentValue>(lpVtbl->setCurrentValue)((IFence*)Unsafe.AsPointer(ref this), value);
    }

    /// <include file='IFence.xml' path='doc/member[@name="IFence.getSharedHandle"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getSharedHandle([NativeTypeName("gfx::InteropHandle *")] InteropHandle* outHandle)
    {
        return Marshal.GetDelegateForFunctionPointer<_getSharedHandle>(lpVtbl->getSharedHandle)((IFence*)Unsafe.AsPointer(ref this), outHandle);
    }

    /// <include file='IFence.xml' path='doc/member[@name="IFence.getNativeHandle"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getNativeHandle([NativeTypeName("gfx::InteropHandle *")] InteropHandle* outNativeHandle)
    {
        return Marshal.GetDelegateForFunctionPointer<_getNativeHandle>(lpVtbl->getNativeHandle)((IFence*)Unsafe.AsPointer(ref this), outNativeHandle);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr release;

        [NativeTypeName("Result (uint64_t *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getCurrentValue;

        [NativeTypeName("Result (uint64_t) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr setCurrentValue;

        [NativeTypeName("Result (InteropHandle *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getSharedHandle;

        [NativeTypeName("Result (InteropHandle *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getNativeHandle;
    }
}
