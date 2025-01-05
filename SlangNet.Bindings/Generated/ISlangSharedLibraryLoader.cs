using System.Runtime.CompilerServices;

namespace SlangNet.Bindings.Generated;

/// <include file='ISlangSharedLibraryLoader.xml' path='doc/member[@name="ISlangSharedLibraryLoader"]/*' />
[NativeTypeName("struct ISlangSharedLibraryLoader : ISlangUnknown")]
public unsafe partial struct ISlangSharedLibraryLoader
{
    public void** lpVtbl;

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangSharedLibraryLoader*, SlangUUID*, void**, int>)(lpVtbl[0]))((ISlangSharedLibraryLoader*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangSharedLibraryLoader*, uint>)(lpVtbl[1]))((ISlangSharedLibraryLoader*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangSharedLibraryLoader*, uint>)(lpVtbl[2]))((ISlangSharedLibraryLoader*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISlangSharedLibraryLoader.xml' path='doc/member[@name="ISlangSharedLibraryLoader.loadSharedLibrary"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int loadSharedLibrary([NativeTypeName("const char *")] sbyte* path, ISlangSharedLibrary** sharedLibraryOut)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangSharedLibraryLoader*, sbyte*, ISlangSharedLibrary**, int>)(lpVtbl[3]))((ISlangSharedLibraryLoader*)Unsafe.AsPointer(ref this), path, sharedLibraryOut);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangSharedLibraryLoader*, SlangUUID*, void**, int> queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangSharedLibraryLoader*, uint> addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangSharedLibraryLoader*, uint> release;

        [NativeTypeName("SlangResult (const char *, ISlangSharedLibrary **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangSharedLibraryLoader*, sbyte*, ISlangSharedLibrary**, int> loadSharedLibrary;
    }
}
