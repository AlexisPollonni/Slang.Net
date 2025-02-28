using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='IShaderCache.xml' path='doc/member[@name="IShaderCache"]/*' />
[NativeTypeName("struct IShaderCache : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct IShaderCache
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(IShaderCache* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IShaderCache* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IShaderCache* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _clearShaderCache(IShaderCache* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getShaderCacheStats(IShaderCache* pThis, [NativeTypeName("gfx::ShaderCacheStats *")] ShaderCacheStats* outStats);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _resetShaderCacheStats(IShaderCache* pThis);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((IShaderCache*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((IShaderCache*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((IShaderCache*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IShaderCache.xml' path='doc/member[@name="IShaderCache.clearShaderCache"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int clearShaderCache()
    {
        return Marshal.GetDelegateForFunctionPointer<_clearShaderCache>(lpVtbl->clearShaderCache)((IShaderCache*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IShaderCache.xml' path='doc/member[@name="IShaderCache.getShaderCacheStats"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getShaderCacheStats([NativeTypeName("gfx::ShaderCacheStats *")] ShaderCacheStats* outStats)
    {
        return Marshal.GetDelegateForFunctionPointer<_getShaderCacheStats>(lpVtbl->getShaderCacheStats)((IShaderCache*)Unsafe.AsPointer(ref this), outStats);
    }

    /// <include file='IShaderCache.xml' path='doc/member[@name="IShaderCache.resetShaderCacheStats"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int resetShaderCacheStats()
    {
        return Marshal.GetDelegateForFunctionPointer<_resetShaderCacheStats>(lpVtbl->resetShaderCacheStats)((IShaderCache*)Unsafe.AsPointer(ref this));
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr release;

        [NativeTypeName("Result () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr clearShaderCache;

        [NativeTypeName("Result (ShaderCacheStats *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getShaderCacheStats;

        [NativeTypeName("Result () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr resetShaderCacheStats;
    }
}
