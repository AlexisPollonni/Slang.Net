using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.Slang;

/// <include file='ISlangBlob.xml' path='doc/member[@name="ISlangBlob"]/*' />
[Guid("8BA5FB08-5195-40E2-AC58-0D989C3A0102")]
[NativeTypeName("struct ISlangBlob : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct ISlangBlob
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(ISlangBlob* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(ISlangBlob* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(ISlangBlob* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("const void *")]
    public delegate void* _getBufferPointer(ISlangBlob* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("size_t")]
    public delegate nuint _getBufferSize(ISlangBlob* pThis);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((ISlangBlob*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((ISlangBlob*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((ISlangBlob*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISlangBlob.xml' path='doc/member[@name="ISlangBlob.getBufferPointer"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("const void *")]
    public void* getBufferPointer()
    {
        return Marshal.GetDelegateForFunctionPointer<_getBufferPointer>(lpVtbl->getBufferPointer)((ISlangBlob*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISlangBlob.xml' path='doc/member[@name="ISlangBlob.getBufferSize"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("size_t")]
    public nuint getBufferSize()
    {
        return Marshal.GetDelegateForFunctionPointer<_getBufferSize>(lpVtbl->getBufferSize)((ISlangBlob*)Unsafe.AsPointer(ref this));
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **)")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t ()")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t ()")]
        public IntPtr release;

        [NativeTypeName("const void *()")]
        public IntPtr getBufferPointer;

        [NativeTypeName("size_t ()")]
        public IntPtr getBufferSize;
    }
}
