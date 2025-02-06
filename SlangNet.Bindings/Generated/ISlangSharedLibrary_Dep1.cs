using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='ISlangSharedLibrary_Dep1.xml' path='doc/member[@name="ISlangSharedLibrary_Dep1"]/*' />
[Guid("9C9D5BC5-EB61-496F-80D7-D147C4A23730")]
[NativeTypeName("struct ISlangSharedLibrary_Dep1 : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct ISlangSharedLibrary_Dep1
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(ISlangSharedLibrary_Dep1* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(ISlangSharedLibrary_Dep1* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(ISlangSharedLibrary_Dep1* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void* _findSymbolAddressByName(ISlangSharedLibrary_Dep1* pThis, [NativeTypeName("const char *")] sbyte* name);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((ISlangSharedLibrary_Dep1*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((ISlangSharedLibrary_Dep1*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((ISlangSharedLibrary_Dep1*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISlangSharedLibrary_Dep1.xml' path='doc/member[@name="ISlangSharedLibrary_Dep1.findSymbolAddressByName"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void* findSymbolAddressByName([NativeTypeName("const char *")] sbyte* name)
    {
        return Marshal.GetDelegateForFunctionPointer<_findSymbolAddressByName>(lpVtbl->findSymbolAddressByName)((ISlangSharedLibrary_Dep1*)Unsafe.AsPointer(ref this), name);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **)")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t ()")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t ()")]
        public IntPtr release;

        [NativeTypeName("void *(const char *)")]
        public IntPtr findSymbolAddressByName;
    }
}
