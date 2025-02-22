using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='IQueryPool.xml' path='doc/member[@name="IQueryPool"]/*' />
[NativeTypeName("struct IQueryPool : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct IQueryPool
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(IQueryPool* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IQueryPool* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IQueryPool* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getResult(IQueryPool* pThis, [NativeTypeName("gfx::GfxIndex")] int queryIndex, [NativeTypeName("gfx::GfxCount")] int count, [NativeTypeName("uint64_t *")] nuint* data);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _reset(IQueryPool* pThis);

    /// <include file='QueryPoolDesc.xml' path='doc/member[@name="QueryPoolDesc"]/*' />
    public partial struct QueryPoolDesc
    {
        /// <include file='QueryPoolDesc.xml' path='doc/member[@name="QueryPoolDesc.type"]/*' />
        [NativeTypeName("gfx::QueryType")]
        public QueryType type;

        /// <include file='QueryPoolDesc.xml' path='doc/member[@name="QueryPoolDesc.count"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int count;
    }

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((IQueryPool*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((IQueryPool*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((IQueryPool*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IQueryPool.xml' path='doc/member[@name="IQueryPool.getResult"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getResult([NativeTypeName("gfx::GfxIndex")] int queryIndex, [NativeTypeName("gfx::GfxCount")] int count, [NativeTypeName("uint64_t *")] nuint* data)
    {
        return Marshal.GetDelegateForFunctionPointer<_getResult>(lpVtbl->getResult)((IQueryPool*)Unsafe.AsPointer(ref this), queryIndex, count, data);
    }

    /// <include file='IQueryPool.xml' path='doc/member[@name="IQueryPool.reset"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int reset()
    {
        return Marshal.GetDelegateForFunctionPointer<_reset>(lpVtbl->reset)((IQueryPool*)Unsafe.AsPointer(ref this));
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **)")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t ()")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t ()")]
        public IntPtr release;

        [NativeTypeName("Result (GfxIndex, GfxCount, uint64_t *)")]
        public IntPtr getResult;

        [NativeTypeName("Result ()")]
        public IntPtr reset;
    }
}
