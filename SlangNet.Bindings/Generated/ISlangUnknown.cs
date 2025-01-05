using System.Runtime.CompilerServices;

namespace SlangNet.Bindings.Generated;

/// <include file='ISlangUnknown.xml' path='doc/member[@name="ISlangUnknown"]/*' />
public unsafe partial struct ISlangUnknown
{
    public void** lpVtbl;

    /// <include file='ISlangUnknown.xml' path='doc/member[@name="ISlangUnknown.queryInterface"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangUnknown*, SlangUUID*, void**, int>)(lpVtbl[0]))((ISlangUnknown*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <include file='ISlangUnknown.xml' path='doc/member[@name="ISlangUnknown.addRef"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangUnknown*, uint>)(lpVtbl[1]))((ISlangUnknown*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISlangUnknown.xml' path='doc/member[@name="ISlangUnknown.release"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangUnknown*, uint>)(lpVtbl[2]))((ISlangUnknown*)Unsafe.AsPointer(ref this));
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangUnknown*, SlangUUID*, void**, int> queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangUnknown*, uint> addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangUnknown*, uint> release;
    }
}
