using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='ISlangSharedLibrary.xml' path='doc/member[@name="ISlangSharedLibrary"]/*' />
[Guid("70DBC7C4-DC3B-4A07-AE7E-752AF6A81555")]
[NativeTypeName("struct ISlangSharedLibrary : ISlangCastable")]
[NativeInheritance("ISlangCastable")]
public unsafe partial struct ISlangSharedLibrary
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(ISlangSharedLibrary* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(ISlangSharedLibrary* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(ISlangSharedLibrary* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void* _castAs(ISlangSharedLibrary* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* guid);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void* _findSymbolAddressByName(ISlangSharedLibrary* pThis, [NativeTypeName("const char *")] sbyte* name);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((ISlangSharedLibrary*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((ISlangSharedLibrary*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((ISlangSharedLibrary*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangCastable.castAs" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void* castAs([NativeTypeName("const SlangUUID &")] SlangUUID* guid)
    {
        return Marshal.GetDelegateForFunctionPointer<_castAs>(lpVtbl->castAs)((ISlangSharedLibrary*)Unsafe.AsPointer(ref this), guid);
    }

    /// <include file='ISlangSharedLibrary.xml' path='doc/member[@name="ISlangSharedLibrary.findSymbolAddressByName"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void* findSymbolAddressByName([NativeTypeName("const char *")] sbyte* name)
    {
        return Marshal.GetDelegateForFunctionPointer<_findSymbolAddressByName>(lpVtbl->findSymbolAddressByName)((ISlangSharedLibrary*)Unsafe.AsPointer(ref this), name);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **)")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t ()")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t ()")]
        public IntPtr release;

        [NativeTypeName("void *(const SlangUUID &)")]
        public IntPtr castAs;

        [NativeTypeName("void *(const char *)")]
        public IntPtr findSymbolAddressByName;
    }
}
