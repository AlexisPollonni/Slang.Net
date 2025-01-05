using System.Runtime.CompilerServices;

namespace SlangNet.Bindings.Generated;

/// <include file='ISlangCastable.xml' path='doc/member[@name="ISlangCastable"]/*' />
[NativeTypeName("struct ISlangCastable : ISlangUnknown")]
public unsafe partial struct ISlangCastable
{
    public void** lpVtbl;

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangCastable*, SlangUUID*, void**, int>)(lpVtbl[0]))((ISlangCastable*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangCastable*, uint>)(lpVtbl[1]))((ISlangCastable*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangCastable*, uint>)(lpVtbl[2]))((ISlangCastable*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISlangCastable.xml' path='doc/member[@name="ISlangCastable.castAs"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void* castAs([NativeTypeName("const SlangUUID &")] SlangUUID* guid)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangCastable*, SlangUUID*, void*>)(lpVtbl[3]))((ISlangCastable*)Unsafe.AsPointer(ref this), guid);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangCastable*, SlangUUID*, void**, int> queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangCastable*, uint> addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangCastable*, uint> release;

        [NativeTypeName("void *(const SlangUUID &) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangCastable*, SlangUUID*, void*> castAs;
    }
}
