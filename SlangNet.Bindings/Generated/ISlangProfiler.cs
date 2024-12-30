using System.Runtime.CompilerServices;

namespace SlangNet.Bindings.Generated;

/// <include file='ISlangProfiler.xml' path='doc/member[@name="ISlangProfiler"]/*' />
[NativeTypeName("struct ISlangProfiler : ISlangUnknown")]
public unsafe partial struct ISlangProfiler
{
    public Vtbl* lpVtbl;

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return lpVtbl->queryInterface((ISlangProfiler*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return lpVtbl->addRef((ISlangProfiler*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return lpVtbl->release((ISlangProfiler*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISlangProfiler.xml' path='doc/member[@name="ISlangProfiler.getEntryCount"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("size_t")]
    public nuint getEntryCount()
    {
        return lpVtbl->getEntryCount((ISlangProfiler*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISlangProfiler.xml' path='doc/member[@name="ISlangProfiler.getEntryName"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("const char *")]
    public sbyte* getEntryName([NativeTypeName("uint32_t")] uint index)
    {
        return lpVtbl->getEntryName((ISlangProfiler*)Unsafe.AsPointer(ref this), index);
    }

    /// <include file='ISlangProfiler.xml' path='doc/member[@name="ISlangProfiler.getEntryTimeMS"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("long")]
    public int getEntryTimeMS([NativeTypeName("uint32_t")] uint index)
    {
        return lpVtbl->getEntryTimeMS((ISlangProfiler*)Unsafe.AsPointer(ref this), index);
    }

    /// <include file='ISlangProfiler.xml' path='doc/member[@name="ISlangProfiler.getEntryInvocationTimes"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint getEntryInvocationTimes([NativeTypeName("uint32_t")] uint index)
    {
        return lpVtbl->getEntryInvocationTimes((ISlangProfiler*)Unsafe.AsPointer(ref this), index);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangProfiler*, SlangUUID*, void**, int> queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangProfiler*, uint> addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangProfiler*, uint> release;

        [NativeTypeName("size_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangProfiler*, nuint> getEntryCount;

        [NativeTypeName("const char *(uint32_t) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangProfiler*, uint, sbyte*> getEntryName;

        [NativeTypeName("long (uint32_t) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangProfiler*, uint, int> getEntryTimeMS;

        [NativeTypeName("uint32_t (uint32_t) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangProfiler*, uint, uint> getEntryInvocationTimes;
    }
}
