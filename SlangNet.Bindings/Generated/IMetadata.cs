using System.Runtime.CompilerServices;

namespace SlangNet.Bindings.Generated;

/// <include file='IMetadata.xml' path='doc/member[@name="IMetadata"]/*' />
[NativeTypeName("struct IMetadata : ISlangCastable")]
public unsafe partial struct IMetadata
{
    public void** lpVtbl;

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<IMetadata*, SlangUUID*, void**, int>)(lpVtbl[0]))((IMetadata*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<IMetadata*, uint>)(lpVtbl[1]))((IMetadata*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<IMetadata*, uint>)(lpVtbl[2]))((IMetadata*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangCastable.castAs" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void* castAs([NativeTypeName("const SlangUUID &")] SlangUUID* guid)
    {
        return ((delegate* unmanaged[Stdcall]<IMetadata*, SlangUUID*, void*>)(lpVtbl[3]))((IMetadata*)Unsafe.AsPointer(ref this), guid);
    }

    /// <include file='IMetadata.xml' path='doc/member[@name="IMetadata.isParameterLocationUsed"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int isParameterLocationUsed([NativeTypeName("SlangParameterCategory")] ParameterCategory category, [NativeTypeName("SlangUInt")] ulong spaceIndex, [NativeTypeName("SlangUInt")] ulong registerIndex, [NativeTypeName("bool &")] bool* outUsed)
    {
        return ((delegate* unmanaged[Thiscall]<IMetadata*, ParameterCategory, ulong, ulong, bool*, int>)(lpVtbl[4]))((IMetadata*)Unsafe.AsPointer(ref this), category, spaceIndex, registerIndex, outUsed);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IMetadata*, SlangUUID*, void**, int> queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IMetadata*, uint> addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IMetadata*, uint> release;

        [NativeTypeName("void *(const SlangUUID &) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IMetadata*, SlangUUID*, void*> castAs;

        [NativeTypeName("SlangResult (SlangParameterCategory, SlangUInt, SlangUInt, bool &)")]
        public delegate* unmanaged[Thiscall]<IMetadata*, ParameterCategory, ulong, ulong, bool*, int> isParameterLocationUsed;
    }
}
