using System.Runtime.CompilerServices;

namespace SlangNet.Bindings.Generated;

/// <include file='ITypeConformance.xml' path='doc/member[@name="ITypeConformance"]/*' />
[NativeTypeName("struct ITypeConformance : slang::IComponentType")]
public unsafe partial struct ITypeConformance
{
    public void** lpVtbl;

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, SlangUUID*, void**, int>)(lpVtbl[0]))((ITypeConformance*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, uint>)(lpVtbl[1]))((ITypeConformance*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, uint>)(lpVtbl[2]))((ITypeConformance*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="IComponentType.getSession" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("slang::ISession *")]
    public ISession* getSession()
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, ISession*>)(lpVtbl[3]))((ITypeConformance*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="IComponentType.getLayout" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("slang::ProgramLayout *")]
    public ShaderReflection* getLayout([NativeTypeName("SlangInt")] long targetIndex = 0, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, long, ISlangBlob**, ShaderReflection*>)(lpVtbl[4]))((ITypeConformance*)Unsafe.AsPointer(ref this), targetIndex, outDiagnostics);
    }

    /// <inheritdoc cref="IComponentType.getSpecializationParamCount" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangInt")]
    public long getSpecializationParamCount()
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, long>)(lpVtbl[5]))((ITypeConformance*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="IComponentType.getEntryPointCode" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getEntryPointCode([NativeTypeName("SlangInt")] long entryPointIndex, [NativeTypeName("SlangInt")] long targetIndex, [NativeTypeName("IBlob **")] ISlangBlob** outCode, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, long, long, ISlangBlob**, ISlangBlob**, int>)(lpVtbl[6]))((ITypeConformance*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outCode, outDiagnostics);
    }

    /// <inheritdoc cref="IComponentType.getResultAsFileSystem" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getResultAsFileSystem([NativeTypeName("SlangInt")] long entryPointIndex, [NativeTypeName("SlangInt")] long targetIndex, ISlangMutableFileSystem** outFileSystem)
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, long, long, ISlangMutableFileSystem**, int>)(lpVtbl[7]))((ITypeConformance*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outFileSystem);
    }

    /// <inheritdoc cref="IComponentType.getEntryPointHash" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void getEntryPointHash([NativeTypeName("SlangInt")] long entryPointIndex, [NativeTypeName("SlangInt")] long targetIndex, [NativeTypeName("IBlob **")] ISlangBlob** outHash)
    {
        ((delegate* unmanaged[Stdcall]<ITypeConformance*, long, long, ISlangBlob**, void>)(lpVtbl[8]))((ITypeConformance*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outHash);
    }

    /// <inheritdoc cref="IComponentType.specialize" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int specialize([NativeTypeName("const SpecializationArg *")] SpecializationArg* specializationArgs, [NativeTypeName("SlangInt")] long specializationArgCount, IComponentType** outSpecializedComponentType, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, SpecializationArg*, long, IComponentType**, ISlangBlob**, int>)(lpVtbl[9]))((ITypeConformance*)Unsafe.AsPointer(ref this), specializationArgs, specializationArgCount, outSpecializedComponentType, outDiagnostics);
    }

    /// <inheritdoc cref="IComponentType.link" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int link(IComponentType** outLinkedComponentType, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, IComponentType**, ISlangBlob**, int>)(lpVtbl[10]))((ITypeConformance*)Unsafe.AsPointer(ref this), outLinkedComponentType, outDiagnostics);
    }

    /// <inheritdoc cref="IComponentType.getEntryPointHostCallable" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getEntryPointHostCallable(int entryPointIndex, int targetIndex, ISlangSharedLibrary** outSharedLibrary, [NativeTypeName("slang::IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, int, int, ISlangSharedLibrary**, ISlangBlob**, int>)(lpVtbl[11]))((ITypeConformance*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outSharedLibrary, outDiagnostics);
    }

    /// <inheritdoc cref="IComponentType.renameEntryPoint" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int renameEntryPoint([NativeTypeName("const char *")] sbyte* newName, IComponentType** outEntryPoint)
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, sbyte*, IComponentType**, int>)(lpVtbl[12]))((ITypeConformance*)Unsafe.AsPointer(ref this), newName, outEntryPoint);
    }

    /// <inheritdoc cref="IComponentType.linkWithOptions" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int linkWithOptions(IComponentType** outLinkedComponentType, [NativeTypeName("uint32_t")] uint compilerOptionEntryCount, [NativeTypeName("slang::CompilerOptionEntry *")] CompilerOptionEntry* compilerOptionEntries, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, IComponentType**, uint, CompilerOptionEntry*, ISlangBlob**, int>)(lpVtbl[13]))((ITypeConformance*)Unsafe.AsPointer(ref this), outLinkedComponentType, compilerOptionEntryCount, compilerOptionEntries, outDiagnostics);
    }

    /// <inheritdoc cref="IComponentType.getTargetCode" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getTargetCode([NativeTypeName("SlangInt")] long targetIndex, [NativeTypeName("IBlob **")] ISlangBlob** outCode, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, long, ISlangBlob**, ISlangBlob**, int>)(lpVtbl[14]))((ITypeConformance*)Unsafe.AsPointer(ref this), targetIndex, outCode, outDiagnostics);
    }

    /// <inheritdoc cref="IComponentType.getTargetMetadata" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getTargetMetadata([NativeTypeName("SlangInt")] long targetIndex, IMetadata** outMetadata, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, long, IMetadata**, ISlangBlob**, int>)(lpVtbl[15]))((ITypeConformance*)Unsafe.AsPointer(ref this), targetIndex, outMetadata, outDiagnostics);
    }

    /// <inheritdoc cref="IComponentType.getEntryPointMetadata" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getEntryPointMetadata([NativeTypeName("SlangInt")] long entryPointIndex, [NativeTypeName("SlangInt")] long targetIndex, IMetadata** outMetadata, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<ITypeConformance*, long, long, IMetadata**, ISlangBlob**, int>)(lpVtbl[16]))((ITypeConformance*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outMetadata, outDiagnostics);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ITypeConformance*, SlangUUID*, void**, int> queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ITypeConformance*, uint> addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ITypeConformance*, uint> release;

        [NativeTypeName("ISession *() __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ITypeConformance*, ISession*> getSession;

        [NativeTypeName("ProgramLayout *(SlangInt, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ITypeConformance*, long, ISlangBlob**, ShaderReflection*> getLayout;

        [NativeTypeName("SlangInt () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ITypeConformance*, long> getSpecializationParamCount;

        [NativeTypeName("SlangResult (SlangInt, SlangInt, IBlob **, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ITypeConformance*, long, long, ISlangBlob**, ISlangBlob**, int> getEntryPointCode;

        [NativeTypeName("SlangResult (SlangInt, SlangInt, ISlangMutableFileSystem **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ITypeConformance*, long, long, ISlangMutableFileSystem**, int> getResultAsFileSystem;

        [NativeTypeName("void (SlangInt, SlangInt, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ITypeConformance*, long, long, ISlangBlob**, void> getEntryPointHash;

        [NativeTypeName("SlangResult (const SpecializationArg *, SlangInt, IComponentType **, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ITypeConformance*, SpecializationArg*, long, IComponentType**, ISlangBlob**, int> specialize;

        [NativeTypeName("SlangResult (IComponentType **, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ITypeConformance*, IComponentType**, ISlangBlob**, int> link;

        [NativeTypeName("SlangResult (int, int, ISlangSharedLibrary **, slang::IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ITypeConformance*, int, int, ISlangSharedLibrary**, ISlangBlob**, int> getEntryPointHostCallable;

        [NativeTypeName("SlangResult (const char *, IComponentType **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ITypeConformance*, sbyte*, IComponentType**, int> renameEntryPoint;

        [NativeTypeName("SlangResult (IComponentType **, uint32_t, CompilerOptionEntry *, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ITypeConformance*, IComponentType**, uint, CompilerOptionEntry*, ISlangBlob**, int> linkWithOptions;

        [NativeTypeName("SlangResult (SlangInt, IBlob **, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ITypeConformance*, long, ISlangBlob**, ISlangBlob**, int> getTargetCode;

        [NativeTypeName("SlangResult (SlangInt, IMetadata **, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ITypeConformance*, long, IMetadata**, ISlangBlob**, int> getTargetMetadata;

        [NativeTypeName("SlangResult (SlangInt, SlangInt, IMetadata **, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ITypeConformance*, long, long, IMetadata**, ISlangBlob**, int> getEntryPointMetadata;
    }
}
