using System.Runtime.CompilerServices;

namespace SlangNet.Bindings.Generated;

/// <include file='IModulePrecompileService_Experimental.xml' path='doc/member[@name="IModulePrecompileService_Experimental"]/*' />
[NativeTypeName("struct IModulePrecompileService_Experimental : ISlangUnknown")]
public unsafe partial struct IModulePrecompileService_Experimental
{
    public Vtbl* lpVtbl;

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return lpVtbl->queryInterface((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return lpVtbl->addRef((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return lpVtbl->release((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IModulePrecompileService_Experimental.xml' path='doc/member[@name="IModulePrecompileService_Experimental.precompileForTarget"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int precompileForTarget(SlangCompileTarget target, ISlangBlob** outDiagnostics)
    {
        return lpVtbl->precompileForTarget((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this), target, outDiagnostics);
    }

    /// <include file='IModulePrecompileService_Experimental.xml' path='doc/member[@name="IModulePrecompileService_Experimental.getPrecompiledTargetCode"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getPrecompiledTargetCode(SlangCompileTarget target, [NativeTypeName("IBlob **")] ISlangBlob** outCode, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return lpVtbl->getPrecompiledTargetCode((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this), target, outCode, outDiagnostics);
    }

    /// <include file='IModulePrecompileService_Experimental.xml' path='doc/member[@name="IModulePrecompileService_Experimental.getModuleDependencyCount"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangInt")]
    public long getModuleDependencyCount()
    {
        return lpVtbl->getModuleDependencyCount((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IModulePrecompileService_Experimental.xml' path='doc/member[@name="IModulePrecompileService_Experimental.getModuleDependency"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getModuleDependency([NativeTypeName("SlangInt")] long dependencyIndex, IModule** outModule, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return lpVtbl->getModuleDependency((IModulePrecompileService_Experimental*)Unsafe.AsPointer(ref this), dependencyIndex, outModule, outDiagnostics);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModulePrecompileService_Experimental*, SlangUUID*, void**, int> queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModulePrecompileService_Experimental*, uint> addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModulePrecompileService_Experimental*, uint> release;

        [NativeTypeName("SlangResult (SlangCompileTarget, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModulePrecompileService_Experimental*, SlangCompileTarget, ISlangBlob**, int> precompileForTarget;

        [NativeTypeName("SlangResult (SlangCompileTarget, IBlob **, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModulePrecompileService_Experimental*, SlangCompileTarget, ISlangBlob**, ISlangBlob**, int> getPrecompiledTargetCode;

        [NativeTypeName("SlangInt () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModulePrecompileService_Experimental*, long> getModuleDependencyCount;

        [NativeTypeName("SlangResult (SlangInt, IModule **, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModulePrecompileService_Experimental*, long, IModule**, ISlangBlob**, int> getModuleDependency;
    }
}
