using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.Slang;

/// <include file='ISlangCastable.xml' path='doc/member[@name="ISlangCastable"]/*' />
[NativeTypeName("struct ISlangCastable : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct ISlangCastable
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(ISlangCastable* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(ISlangCastable* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(ISlangCastable* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void* _castAs(ISlangCastable* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* guid);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((ISlangCastable*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((ISlangCastable*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((ISlangCastable*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISlangCastable.xml' path='doc/member[@name="ISlangCastable.castAs"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void* castAs([NativeTypeName("const SlangUUID &")] SlangUUID* guid)
    {
        return Marshal.GetDelegateForFunctionPointer<_castAs>(lpVtbl->castAs)((ISlangCastable*)Unsafe.AsPointer(ref this), guid);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **)")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t ()")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t ()")]
        public IntPtr release;

        [NativeTypeName("void *(const SlangUUID &)")]
        public IntPtr castAs;
    }
}
