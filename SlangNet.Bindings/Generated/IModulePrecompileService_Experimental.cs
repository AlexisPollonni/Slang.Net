using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='IModulePrecompileService_Experimental.xml' path='doc/member[@name="IModulePrecompileService_Experimental"]/*' />
[NativeTypeName("struct IModulePrecompileService_Experimental : ISlangUnknown")]
public unsafe partial struct IModulePrecompileService_Experimental
{
    public void** lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(IModulePrecompileService_Experimental* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IModulePrecompileService_Experimental* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IModulePrecompileService_Experimental* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _precompileForTarget(IModulePrecompileService_Experimental* pThis, [NativeTypeName("SlangCompileTarget")] CompileTarget target, ISlangBlob** outDiagnostics);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getPrecompiledTargetCode(IModulePrecompileService_Experimental* pThis, [NativeTypeName("SlangCompileTarget")] CompileTarget target, [NativeTypeName("IBlob **")] ISlangBlob** outCode, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangInt")]
    public delegate long _getModuleDependencyCount(IModulePrecompileService_Experimental* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getModuleDependency(IModulePrecompileService_Experimental* pThis, [NativeTypeName("SlangInt")] long dependencyIndex, IModule** outModule, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>((IntPtr)(lpVtbl[0]))((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>((IntPtr)(lpVtbl[1]))((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>((IntPtr)(lpVtbl[2]))((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IModulePrecompileService_Experimental.xml' path='doc/member[@name="IModulePrecompileService_Experimental.precompileForTarget"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int precompileForTarget([NativeTypeName("SlangCompileTarget")] CompileTarget target, ISlangBlob** outDiagnostics)
    {
        return Marshal.GetDelegateForFunctionPointer<_precompileForTarget>((IntPtr)(lpVtbl[3]))((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this), target, outDiagnostics);
    }

    /// <include file='IModulePrecompileService_Experimental.xml' path='doc/member[@name="IModulePrecompileService_Experimental.getPrecompiledTargetCode"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getPrecompiledTargetCode([NativeTypeName("SlangCompileTarget")] CompileTarget target, [NativeTypeName("IBlob **")] ISlangBlob** outCode, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return Marshal.GetDelegateForFunctionPointer<_getPrecompiledTargetCode>((IntPtr)(lpVtbl[4]))((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this), target, outCode, outDiagnostics);
    }

    /// <include file='IModulePrecompileService_Experimental.xml' path='doc/member[@name="IModulePrecompileService_Experimental.getModuleDependencyCount"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangInt")]
    public long getModuleDependencyCount()
    {
        return Marshal.GetDelegateForFunctionPointer<_getModuleDependencyCount>((IntPtr)(lpVtbl[5]))((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IModulePrecompileService_Experimental.xml' path='doc/member[@name="IModulePrecompileService_Experimental.getModuleDependency"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getModuleDependency([NativeTypeName("SlangInt")] long dependencyIndex, IModule** outModule, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return Marshal.GetDelegateForFunctionPointer<_getModuleDependency>((IntPtr)(lpVtbl[6]))((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this), dependencyIndex, outModule, outDiagnostics);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr release;

        [NativeTypeName("SlangResult (SlangCompileTarget, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr precompileForTarget;

        [NativeTypeName("SlangResult (SlangCompileTarget, IBlob **, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getPrecompiledTargetCode;

        [NativeTypeName("SlangInt () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getModuleDependencyCount;

        [NativeTypeName("SlangResult (SlangInt, IModule **, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getModuleDependency;
    }
}
