using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='ISlangBlob.xml' path='doc/member[@name="ISlangBlob"]/*' />
[NativeTypeName("struct ISlangBlob : ISlangUnknown")]
public unsafe partial struct ISlangBlob
{
    public void** lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(ISlangBlob* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(ISlangBlob* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(ISlangBlob* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("const void *")]
    public delegate void* _getBufferPointer(ISlangBlob* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("size_t")]
    public delegate nuint _getBufferSize(ISlangBlob* pThis);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>((IntPtr)(lpVtbl[0]))((ISlangBlob*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>((IntPtr)(lpVtbl[1]))((ISlangBlob*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>((IntPtr)(lpVtbl[2]))((ISlangBlob*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISlangBlob.xml' path='doc/member[@name="ISlangBlob.getBufferPointer"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("const void *")]
    public void* getBufferPointer()
    {
        return Marshal.GetDelegateForFunctionPointer<_getBufferPointer>((IntPtr)(lpVtbl[3]))((ISlangBlob*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISlangBlob.xml' path='doc/member[@name="ISlangBlob.getBufferSize"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("size_t")]
    public nuint getBufferSize()
    {
        return Marshal.GetDelegateForFunctionPointer<_getBufferSize>((IntPtr)(lpVtbl[4]))((ISlangBlob*)Unsafe.AsPointer(ref this));
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr release;

        [NativeTypeName("const void *() __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getBufferPointer;

        [NativeTypeName("size_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getBufferSize;
    }
}
