using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.Slang;

/// <include file='ISlangClonable.xml' path='doc/member[@name="ISlangClonable"]/*' />
[Guid("1EC36168-E9F4-430D-BB17-048A8046B31F")]
[NativeTypeName("struct ISlangClonable : ISlangCastable")]
[NativeInheritance("ISlangCastable")]
public unsafe partial struct ISlangClonable
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(ISlangClonable* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(ISlangClonable* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(ISlangClonable* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void* _castAs(ISlangClonable* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* guid);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate void* _clone(ISlangClonable* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* guid);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((ISlangClonable*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((ISlangClonable*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((ISlangClonable*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangCastable.castAs" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void* castAs([NativeTypeName("const SlangUUID &")] SlangUUID* guid)
    {
        return Marshal.GetDelegateForFunctionPointer<_castAs>(lpVtbl->castAs)((ISlangClonable*)Unsafe.AsPointer(ref this), guid);
    }

    /// <include file='ISlangClonable.xml' path='doc/member[@name="ISlangClonable.clone"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void* clone([NativeTypeName("const SlangUUID &")] SlangUUID* guid)
    {
        return Marshal.GetDelegateForFunctionPointer<_clone>(lpVtbl->clone)((ISlangClonable*)Unsafe.AsPointer(ref this), guid);
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

        [NativeTypeName("void *(const SlangUUID &)")]
        public IntPtr clone;
    }
}
