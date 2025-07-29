using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='ICompileResult.xml' path='doc/member[@name="ICompileResult"]/*' />
[Guid("5FA9380E-B62F-41E5-9F12-4BAD4D9EAAE4")]
[NativeTypeName("struct ICompileResult : ISlangCastable")]
[NativeInheritance("ISlangCastable")]
public unsafe partial struct ICompileResult
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(ICompileResult* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(ICompileResult* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(ICompileResult* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void* _castAs(ICompileResult* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* guid);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _getItemCount(ICompileResult* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getItemData(ICompileResult* pThis, [NativeTypeName("uint32_t")] uint index, [NativeTypeName("IBlob **")] ISlangBlob** outblob);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getMetadata(ICompileResult* pThis, IMetadata** outMetadata);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((ICompileResult*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((ICompileResult*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((ICompileResult*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangCastable.castAs" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void* castAs([NativeTypeName("const SlangUUID &")] SlangUUID* guid)
    {
        return Marshal.GetDelegateForFunctionPointer<_castAs>(lpVtbl->castAs)((ICompileResult*)Unsafe.AsPointer(ref this), guid);
    }

    /// <include file='ICompileResult.xml' path='doc/member[@name="ICompileResult.getItemCount"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint getItemCount()
    {
        return Marshal.GetDelegateForFunctionPointer<_getItemCount>(lpVtbl->getItemCount)((ICompileResult*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ICompileResult.xml' path='doc/member[@name="ICompileResult.getItemData"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getItemData([NativeTypeName("uint32_t")] uint index, [NativeTypeName("IBlob **")] ISlangBlob** outblob)
    {
        return Marshal.GetDelegateForFunctionPointer<_getItemData>(lpVtbl->getItemData)((ICompileResult*)Unsafe.AsPointer(ref this), index, outblob);
    }

    /// <include file='ICompileResult.xml' path='doc/member[@name="ICompileResult.getMetadata"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getMetadata(IMetadata** outMetadata)
    {
        return Marshal.GetDelegateForFunctionPointer<_getMetadata>(lpVtbl->getMetadata)((ICompileResult*)Unsafe.AsPointer(ref this), outMetadata);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr release;

        [NativeTypeName("void *(const SlangUUID &) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr castAs;

        [NativeTypeName("uint32_t () __attribute__((stdcall))")]
        public IntPtr getItemCount;

        [NativeTypeName("SlangResult (uint32_t, IBlob **) __attribute__((stdcall))")]
        public IntPtr getItemData;

        [NativeTypeName("SlangResult (IMetadata **) __attribute__((stdcall))")]
        public IntPtr getMetadata;
    }
}
