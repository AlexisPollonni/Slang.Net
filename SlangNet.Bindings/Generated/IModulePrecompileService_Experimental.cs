using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated.Slang;

/// <include file='IModulePrecompileService_Experimental.xml' path='doc/member[@name="IModulePrecompileService_Experimental"]/*' />
[Guid("8E12E8E3-5FCD-433E-AFCB-13A088BC5EE5")]
[NativeTypeName("struct IModulePrecompileService_Experimental : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct IModulePrecompileService_Experimental
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(IModulePrecompileService_Experimental* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IModulePrecompileService_Experimental* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IModulePrecompileService_Experimental* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _precompileForTarget(IModulePrecompileService_Experimental* pThis, [NativeTypeName("SlangCompileTarget")] CompileTarget target, ISlangBlob** outDiagnostics);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getPrecompiledTargetCode(IModulePrecompileService_Experimental* pThis, [NativeTypeName("SlangCompileTarget")] CompileTarget target, [NativeTypeName("IBlob **")] ISlangBlob** outCode, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangInt")]
    public delegate nint _getModuleDependencyCount(IModulePrecompileService_Experimental* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getModuleDependency(IModulePrecompileService_Experimental* pThis, [NativeTypeName("SlangInt")] nint dependencyIndex, IModule** outModule, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IModulePrecompileService_Experimental.xml' path='doc/member[@name="IModulePrecompileService_Experimental.precompileForTarget"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int precompileForTarget([NativeTypeName("SlangCompileTarget")] CompileTarget target, ISlangBlob** outDiagnostics)
    {
        return Marshal.GetDelegateForFunctionPointer<_precompileForTarget>(lpVtbl->precompileForTarget)((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this), target, outDiagnostics);
    }

    /// <include file='IModulePrecompileService_Experimental.xml' path='doc/member[@name="IModulePrecompileService_Experimental.getPrecompiledTargetCode"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getPrecompiledTargetCode([NativeTypeName("SlangCompileTarget")] CompileTarget target, [NativeTypeName("IBlob **")] ISlangBlob** outCode, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return Marshal.GetDelegateForFunctionPointer<_getPrecompiledTargetCode>(lpVtbl->getPrecompiledTargetCode)((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this), target, outCode, outDiagnostics);
    }

    /// <include file='IModulePrecompileService_Experimental.xml' path='doc/member[@name="IModulePrecompileService_Experimental.getModuleDependencyCount"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangInt")]
    public nint getModuleDependencyCount()
    {
        return Marshal.GetDelegateForFunctionPointer<_getModuleDependencyCount>(lpVtbl->getModuleDependencyCount)((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IModulePrecompileService_Experimental.xml' path='doc/member[@name="IModulePrecompileService_Experimental.getModuleDependency"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getModuleDependency([NativeTypeName("SlangInt")] nint dependencyIndex, IModule** outModule, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return Marshal.GetDelegateForFunctionPointer<_getModuleDependency>(lpVtbl->getModuleDependency)((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this), dependencyIndex, outModule, outDiagnostics);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **)")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t ()")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t ()")]
        public IntPtr release;

        [NativeTypeName("SlangResult (SlangCompileTarget, ISlangBlob **)")]
        public IntPtr precompileForTarget;

        [NativeTypeName("SlangResult (SlangCompileTarget, IBlob **, IBlob **)")]
        public IntPtr getPrecompiledTargetCode;

        [NativeTypeName("SlangInt ()")]
        public IntPtr getModuleDependencyCount;

        [NativeTypeName("SlangResult (SlangInt, IModule **, IBlob **)")]
        public IntPtr getModuleDependency;
    }
}
