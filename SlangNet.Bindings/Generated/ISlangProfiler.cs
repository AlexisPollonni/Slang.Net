using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.Slang;

/// <include file='ISlangProfiler.xml' path='doc/member[@name="ISlangProfiler"]/*' />
[NativeTypeName("struct ISlangProfiler : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct ISlangProfiler
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(ISlangProfiler* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(ISlangProfiler* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(ISlangProfiler* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("size_t")]
    public delegate nuint _getEntryCount(ISlangProfiler* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("const char *")]
    public delegate sbyte* _getEntryName(ISlangProfiler* pThis, [NativeTypeName("uint32_t")] uint index);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("long")]
    public delegate nint _getEntryTimeMS(ISlangProfiler* pThis, [NativeTypeName("uint32_t")] uint index);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _getEntryInvocationTimes(ISlangProfiler* pThis, [NativeTypeName("uint32_t")] uint index);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((ISlangProfiler*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((ISlangProfiler*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((ISlangProfiler*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISlangProfiler.xml' path='doc/member[@name="ISlangProfiler.getEntryCount"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("size_t")]
    public nuint getEntryCount()
    {
        return Marshal.GetDelegateForFunctionPointer<_getEntryCount>(lpVtbl->getEntryCount)((ISlangProfiler*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISlangProfiler.xml' path='doc/member[@name="ISlangProfiler.getEntryName"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("const char *")]
    public sbyte* getEntryName([NativeTypeName("uint32_t")] uint index)
    {
        return Marshal.GetDelegateForFunctionPointer<_getEntryName>(lpVtbl->getEntryName)((ISlangProfiler*)Unsafe.AsPointer(ref this), index);
    }

    /// <include file='ISlangProfiler.xml' path='doc/member[@name="ISlangProfiler.getEntryTimeMS"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("long")]
    public nint getEntryTimeMS([NativeTypeName("uint32_t")] uint index)
    {
        return Marshal.GetDelegateForFunctionPointer<_getEntryTimeMS>(lpVtbl->getEntryTimeMS)((ISlangProfiler*)Unsafe.AsPointer(ref this), index);
    }

    /// <include file='ISlangProfiler.xml' path='doc/member[@name="ISlangProfiler.getEntryInvocationTimes"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint getEntryInvocationTimes([NativeTypeName("uint32_t")] uint index)
    {
        return Marshal.GetDelegateForFunctionPointer<_getEntryInvocationTimes>(lpVtbl->getEntryInvocationTimes)((ISlangProfiler*)Unsafe.AsPointer(ref this), index);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **)")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t ()")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t ()")]
        public IntPtr release;

        [NativeTypeName("size_t ()")]
        public IntPtr getEntryCount;

        [NativeTypeName("const char *(uint32_t)")]
        public IntPtr getEntryName;

        [NativeTypeName("long (uint32_t)")]
        public IntPtr getEntryTimeMS;

        [NativeTypeName("uint32_t (uint32_t)")]
        public IntPtr getEntryInvocationTimes;
    }
}
