using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='IMetadata.xml' path='doc/member[@name="IMetadata"]/*' />
[Guid("8044A8A3-DDC0-4B7F-AF8E-026E905D7332")]
[NativeTypeName("struct IMetadata : ISlangCastable")]
[NativeInheritance("ISlangCastable")]
public unsafe partial struct IMetadata
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(IMetadata* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IMetadata* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IMetadata* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void* _castAs(IMetadata* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* guid);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _isParameterLocationUsed(IMetadata* pThis, [NativeTypeName("SlangParameterCategory")] ParameterCategory category, [NativeTypeName("SlangUInt")] nuint spaceIndex, [NativeTypeName("SlangUInt")] nuint registerIndex, [NativeTypeName("bool &")] Boolean* outUsed);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("const char *")]
    public delegate sbyte* _getDebugBuildIdentifier(IMetadata* pThis);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((IMetadata*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((IMetadata*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((IMetadata*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangCastable.castAs" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void* castAs([NativeTypeName("const SlangUUID &")] SlangUUID* guid)
    {
        return Marshal.GetDelegateForFunctionPointer<_castAs>(lpVtbl->castAs)((IMetadata*)Unsafe.AsPointer(ref this), guid);
    }

    /// <include file='IMetadata.xml' path='doc/member[@name="IMetadata.isParameterLocationUsed"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int isParameterLocationUsed([NativeTypeName("SlangParameterCategory")] ParameterCategory category, [NativeTypeName("SlangUInt")] nuint spaceIndex, [NativeTypeName("SlangUInt")] nuint registerIndex, [NativeTypeName("bool &")] Boolean* outUsed)
    {
        return Marshal.GetDelegateForFunctionPointer<_isParameterLocationUsed>(lpVtbl->isParameterLocationUsed)((IMetadata*)Unsafe.AsPointer(ref this), category, spaceIndex, registerIndex, outUsed);
    }

    /// <include file='IMetadata.xml' path='doc/member[@name="IMetadata.getDebugBuildIdentifier"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("const char *")]
    public sbyte* getDebugBuildIdentifier()
    {
        return Marshal.GetDelegateForFunctionPointer<_getDebugBuildIdentifier>(lpVtbl->getDebugBuildIdentifier)((IMetadata*)Unsafe.AsPointer(ref this));
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr release;

        [NativeTypeName("void *(const SlangUUID &) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr castAs;

        [NativeTypeName("SlangResult (SlangParameterCategory, SlangUInt, SlangUInt, bool &)")]
        public IntPtr isParameterLocationUsed;

        [NativeTypeName("const char *() __attribute__((stdcall))")]
        public IntPtr getDebugBuildIdentifier;
    }
}
