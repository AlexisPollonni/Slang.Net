using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='IComponentType2.xml' path='doc/member[@name="IComponentType2"]/*' />
[Guid("9C2A4B3D-7F68-4E91-A52C-8B193E457A9F")]
[NativeTypeName("struct IComponentType2 : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct IComponentType2
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(IComponentType2* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IComponentType2* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IComponentType2* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getTargetCompileResult(IComponentType2* pThis, [NativeTypeName("SlangInt")] nint targetIndex, ICompileResult** outCompileResult, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getEntryPointCompileResult(IComponentType2* pThis, [NativeTypeName("SlangInt")] nint entryPointIndex, [NativeTypeName("SlangInt")] nint targetIndex, ICompileResult** outCompileResult, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((IComponentType2*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((IComponentType2*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((IComponentType2*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IComponentType2.xml' path='doc/member[@name="IComponentType2.getTargetCompileResult"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getTargetCompileResult([NativeTypeName("SlangInt")] nint targetIndex, ICompileResult** outCompileResult, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return Marshal.GetDelegateForFunctionPointer<_getTargetCompileResult>(lpVtbl->getTargetCompileResult)((IComponentType2*)Unsafe.AsPointer(ref this), targetIndex, outCompileResult, outDiagnostics);
    }

    /// <include file='IComponentType2.xml' path='doc/member[@name="IComponentType2.getEntryPointCompileResult"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getEntryPointCompileResult([NativeTypeName("SlangInt")] nint entryPointIndex, [NativeTypeName("SlangInt")] nint targetIndex, ICompileResult** outCompileResult, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return Marshal.GetDelegateForFunctionPointer<_getEntryPointCompileResult>(lpVtbl->getEntryPointCompileResult)((IComponentType2*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outCompileResult, outDiagnostics);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr release;

        [NativeTypeName("SlangResult (SlangInt, ICompileResult **, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getTargetCompileResult;

        [NativeTypeName("SlangResult (SlangInt, SlangInt, ICompileResult **, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getEntryPointCompileResult;
    }
}
