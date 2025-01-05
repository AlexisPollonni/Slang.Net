using System.Runtime.CompilerServices;

namespace SlangNet.Bindings.Generated;

/// <include file='ISlangBlob.xml' path='doc/member[@name="ISlangBlob"]/*' />
[NativeTypeName("struct ISlangBlob : ISlangUnknown")]
public unsafe partial struct ISlangBlob
{
    public void** lpVtbl;

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<ISlangBlob*, SlangUUID*, void**, int>)(lpVtbl[0]))((ISlangBlob*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangBlob*, uint>)(lpVtbl[1]))((ISlangBlob*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangBlob*, uint>)(lpVtbl[2]))((ISlangBlob*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISlangBlob.xml' path='doc/member[@name="ISlangBlob.getBufferPointer"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("const void *")]
    public void* getBufferPointer()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangBlob*, void*>)(lpVtbl[3]))((ISlangBlob*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISlangBlob.xml' path='doc/member[@name="ISlangBlob.getBufferSize"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("size_t")]
    public nuint getBufferSize()
    {
        return ((delegate* unmanaged[Stdcall]<ISlangBlob*, nuint>)(lpVtbl[4]))((ISlangBlob*)Unsafe.AsPointer(ref this));
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangBlob*, SlangUUID*, void**, int> queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangBlob*, uint> addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangBlob*, uint> release;

        [NativeTypeName("const void *() __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangBlob*, void*> getBufferPointer;

        [NativeTypeName("size_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangBlob*, nuint> getBufferSize;
    }
}
