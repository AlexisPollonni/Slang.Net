using System.Runtime.CompilerServices;

namespace SlangNet.Bindings.Generated;

/// <include file='ISlangSharedLibrary.xml' path='doc/member[@name="ISlangSharedLibrary"]/*' />
[NativeTypeName("struct ISlangSharedLibrary : ISlangCastable")]
public unsafe partial struct ISlangSharedLibrary
{
    public Vtbl* lpVtbl;

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return lpVtbl->queryInterface((ISlangSharedLibrary*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return lpVtbl->addRef((ISlangSharedLibrary*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return lpVtbl->release((ISlangSharedLibrary*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangCastable.castAs" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void* castAs([NativeTypeName("const SlangUUID &")] SlangUUID* guid)
    {
        return lpVtbl->castAs((ISlangSharedLibrary*)Unsafe.AsPointer(ref this), guid);
    }

    /// <include file='ISlangSharedLibrary.xml' path='doc/member[@name="ISlangSharedLibrary.findSymbolAddressByName"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void* findSymbolAddressByName([NativeTypeName("const char *")] sbyte* name)
    {
        return lpVtbl->findSymbolAddressByName((ISlangSharedLibrary*)Unsafe.AsPointer(ref this), name);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangSharedLibrary*, SlangUUID*, void**, int> queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangSharedLibrary*, uint> addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangSharedLibrary*, uint> release;

        [NativeTypeName("void *(const SlangUUID &) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangSharedLibrary*, SlangUUID*, void*> castAs;

        [NativeTypeName("void *(const char *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangSharedLibrary*, sbyte*, void*> findSymbolAddressByName;
    }
}
