using System.Runtime.CompilerServices;

namespace SlangNet.Bindings.Generated;

/// <include file='ISlangSharedLibrary_Dep1.xml' path='doc/member[@name="ISlangSharedLibrary_Dep1"]/*' />
[NativeTypeName("struct ISlangSharedLibrary_Dep1 : ISlangUnknown")]
public unsafe partial struct ISlangSharedLibrary_Dep1
{
    public void** lpVtbl;

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangSharedLibrary_Dep1*, SlangUUID*, void**, int>)(lpVtbl[0]))((ISlangSharedLibrary_Dep1*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangSharedLibrary_Dep1*, uint>)(lpVtbl[1]))((ISlangSharedLibrary_Dep1*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangSharedLibrary_Dep1*, uint>)(lpVtbl[2]))((ISlangSharedLibrary_Dep1*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISlangSharedLibrary_Dep1.xml' path='doc/member[@name="ISlangSharedLibrary_Dep1.findSymbolAddressByName"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void* findSymbolAddressByName([NativeTypeName("const char *")] sbyte* name)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangSharedLibrary_Dep1*, sbyte*, void*>)(lpVtbl[3]))((ISlangSharedLibrary_Dep1*)Unsafe.AsPointer(ref this), name);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangSharedLibrary_Dep1*, SlangUUID*, void**, int> queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangSharedLibrary_Dep1*, uint> addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangSharedLibrary_Dep1*, uint> release;

        [NativeTypeName("void *(const char *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangSharedLibrary_Dep1*, sbyte*, void*> findSymbolAddressByName;
    }
}
