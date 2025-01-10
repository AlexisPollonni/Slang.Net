using System.Runtime.CompilerServices;

namespace SlangNet.Bindings.Generated;

/// <include file='IModule.xml' path='doc/member[@name="IModule"]/*' />
[NativeTypeName("struct IModule : slang::IComponentType")]
public unsafe partial struct IModule
{
    public void** lpVtbl;

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, SlangUUID*, void**, int>)(lpVtbl[0]))((IModule*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, uint>)(lpVtbl[1]))((IModule*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, uint>)(lpVtbl[2]))((IModule*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="IComponentType.getSession" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("slang::ISession *")]
    public ISession* getSession()
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, ISession*>)(lpVtbl[3]))((IModule*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="IComponentType.getLayout" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("slang::ProgramLayout *")]
    public ShaderReflection* getLayout([NativeTypeName("SlangInt")] long targetIndex = 0, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, long, ISlangBlob**, ShaderReflection*>)(lpVtbl[4]))((IModule*)Unsafe.AsPointer(ref this), targetIndex, outDiagnostics);
    }

    /// <inheritdoc cref="IComponentType.getSpecializationParamCount" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangInt")]
    public long getSpecializationParamCount()
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, long>)(lpVtbl[5]))((IModule*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="IComponentType.getEntryPointCode" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getEntryPointCode([NativeTypeName("SlangInt")] long entryPointIndex, [NativeTypeName("SlangInt")] long targetIndex, [NativeTypeName("IBlob **")] ISlangBlob** outCode, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, long, long, ISlangBlob**, ISlangBlob**, int>)(lpVtbl[6]))((IModule*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outCode, outDiagnostics);
    }

    /// <inheritdoc cref="IComponentType.getResultAsFileSystem" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getResultAsFileSystem([NativeTypeName("SlangInt")] long entryPointIndex, [NativeTypeName("SlangInt")] long targetIndex, ISlangMutableFileSystem** outFileSystem)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, long, long, ISlangMutableFileSystem**, int>)(lpVtbl[7]))((IModule*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outFileSystem);
    }

    /// <inheritdoc cref="IComponentType.getEntryPointHash" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void getEntryPointHash([NativeTypeName("SlangInt")] long entryPointIndex, [NativeTypeName("SlangInt")] long targetIndex, [NativeTypeName("IBlob **")] ISlangBlob** outHash)
    {
        ((delegate* unmanaged[Stdcall]<IModule*, long, long, ISlangBlob**, void>)(lpVtbl[8]))((IModule*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outHash);
    }

    /// <inheritdoc cref="IComponentType.specialize" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int specialize([NativeTypeName("const SpecializationArg *")] SpecializationArg* specializationArgs, [NativeTypeName("SlangInt")] long specializationArgCount, IComponentType** outSpecializedComponentType, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, SpecializationArg*, long, IComponentType**, ISlangBlob**, int>)(lpVtbl[9]))((IModule*)Unsafe.AsPointer(ref this), specializationArgs, specializationArgCount, outSpecializedComponentType, outDiagnostics);
    }

    /// <inheritdoc cref="IComponentType.link" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int link(IComponentType** outLinkedComponentType, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, IComponentType**, ISlangBlob**, int>)(lpVtbl[10]))((IModule*)Unsafe.AsPointer(ref this), outLinkedComponentType, outDiagnostics);
    }

    /// <inheritdoc cref="IComponentType.getEntryPointHostCallable" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getEntryPointHostCallable(int entryPointIndex, int targetIndex, ISlangSharedLibrary** outSharedLibrary, [NativeTypeName("slang::IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, int, int, ISlangSharedLibrary**, ISlangBlob**, int>)(lpVtbl[11]))((IModule*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outSharedLibrary, outDiagnostics);
    }

    /// <inheritdoc cref="IComponentType.renameEntryPoint" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int renameEntryPoint([NativeTypeName("const char *")] sbyte* newName, IComponentType** outEntryPoint)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, sbyte*, IComponentType**, int>)(lpVtbl[12]))((IModule*)Unsafe.AsPointer(ref this), newName, outEntryPoint);
    }

    /// <inheritdoc cref="IComponentType.linkWithOptions" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int linkWithOptions(IComponentType** outLinkedComponentType, [NativeTypeName("uint32_t")] uint compilerOptionEntryCount, [NativeTypeName("slang::CompilerOptionEntry *")] CompilerOptionEntry* compilerOptionEntries, ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, IComponentType**, uint, CompilerOptionEntry*, ISlangBlob**, int>)(lpVtbl[13]))((IModule*)Unsafe.AsPointer(ref this), outLinkedComponentType, compilerOptionEntryCount, compilerOptionEntries, outDiagnostics);
    }

    /// <inheritdoc cref="IComponentType.getTargetCode" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getTargetCode([NativeTypeName("SlangInt")] long targetIndex, [NativeTypeName("IBlob **")] ISlangBlob** outCode, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, long, ISlangBlob**, ISlangBlob**, int>)(lpVtbl[14]))((IModule*)Unsafe.AsPointer(ref this), targetIndex, outCode, outDiagnostics);
    }

    /// <inheritdoc cref="IComponentType.getTargetMetadata" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getTargetMetadata([NativeTypeName("SlangInt")] long targetIndex, IMetadata** outMetadata, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, long, IMetadata**, ISlangBlob**, int>)(lpVtbl[15]))((IModule*)Unsafe.AsPointer(ref this), targetIndex, outMetadata, outDiagnostics);
    }

    /// <inheritdoc cref="IComponentType.getEntryPointMetadata" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getEntryPointMetadata([NativeTypeName("SlangInt")] long entryPointIndex, [NativeTypeName("SlangInt")] long targetIndex, IMetadata** outMetadata, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, long, long, IMetadata**, ISlangBlob**, int>)(lpVtbl[16]))((IModule*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outMetadata, outDiagnostics);
    }

    /// <include file='IModule.xml' path='doc/member[@name="IModule.findEntryPointByName"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int findEntryPointByName([NativeTypeName("const char *")] sbyte* name, IEntryPoint** outEntryPoint)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, sbyte*, IEntryPoint**, int>)(lpVtbl[17]))((IModule*)Unsafe.AsPointer(ref this), name, outEntryPoint);
    }

    /// <include file='IModule.xml' path='doc/member[@name="IModule.getDefinedEntryPointCount"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangInt32")]
    public int getDefinedEntryPointCount()
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, int>)(lpVtbl[18]))((IModule*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IModule.xml' path='doc/member[@name="IModule.getDefinedEntryPoint"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getDefinedEntryPoint([NativeTypeName("SlangInt32")] int index, IEntryPoint** outEntryPoint)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, int, IEntryPoint**, int>)(lpVtbl[19]))((IModule*)Unsafe.AsPointer(ref this), index, outEntryPoint);
    }

    /// <include file='IModule.xml' path='doc/member[@name="IModule.serialize"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int serialize(ISlangBlob** outSerializedBlob)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, ISlangBlob**, int>)(lpVtbl[20]))((IModule*)Unsafe.AsPointer(ref this), outSerializedBlob);
    }

    /// <include file='IModule.xml' path='doc/member[@name="IModule.writeToFile"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int writeToFile([NativeTypeName("const char *")] sbyte* fileName)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, sbyte*, int>)(lpVtbl[21]))((IModule*)Unsafe.AsPointer(ref this), fileName);
    }

    /// <include file='IModule.xml' path='doc/member[@name="IModule.getName"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("const char *")]
    public sbyte* getName()
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, sbyte*>)(lpVtbl[22]))((IModule*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IModule.xml' path='doc/member[@name="IModule.getFilePath"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("const char *")]
    public sbyte* getFilePath()
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, sbyte*>)(lpVtbl[23]))((IModule*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IModule.xml' path='doc/member[@name="IModule.getUniqueIdentity"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("const char *")]
    public sbyte* getUniqueIdentity()
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, sbyte*>)(lpVtbl[24]))((IModule*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IModule.xml' path='doc/member[@name="IModule.findAndCheckEntryPoint"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int findAndCheckEntryPoint([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("SlangStage")] Stage stage, IEntryPoint** outEntryPoint, ISlangBlob** outDiagnostics)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, sbyte*, Stage, IEntryPoint**, ISlangBlob**, int>)(lpVtbl[25]))((IModule*)Unsafe.AsPointer(ref this), name, stage, outEntryPoint, outDiagnostics);
    }

    /// <include file='IModule.xml' path='doc/member[@name="IModule.getDependencyFileCount"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangInt32")]
    public int getDependencyFileCount()
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, int>)(lpVtbl[26]))((IModule*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IModule.xml' path='doc/member[@name="IModule.getDependencyFilePath"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("const char *")]
    public sbyte* getDependencyFilePath([NativeTypeName("SlangInt32")] int index)
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, int, sbyte*>)(lpVtbl[27]))((IModule*)Unsafe.AsPointer(ref this), index);
    }

    /// <include file='IModule.xml' path='doc/member[@name="IModule.getModuleReflection"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("slang::DeclReflection *")]
    public DeclReflection* getModuleReflection()
    {
        return ((delegate* unmanaged[Stdcall]<IModule*, DeclReflection*>)(lpVtbl[28]))((IModule*)Unsafe.AsPointer(ref this));
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, SlangUUID*, void**, int> queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, uint> addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, uint> release;

        [NativeTypeName("ISession *() __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, ISession*> getSession;

        [NativeTypeName("ProgramLayout *(SlangInt, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, long, ISlangBlob**, ShaderReflection*> getLayout;

        [NativeTypeName("SlangInt () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, long> getSpecializationParamCount;

        [NativeTypeName("SlangResult (SlangInt, SlangInt, IBlob **, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, long, long, ISlangBlob**, ISlangBlob**, int> getEntryPointCode;

        [NativeTypeName("SlangResult (SlangInt, SlangInt, ISlangMutableFileSystem **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, long, long, ISlangMutableFileSystem**, int> getResultAsFileSystem;

        [NativeTypeName("void (SlangInt, SlangInt, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, long, long, ISlangBlob**, void> getEntryPointHash;

        [NativeTypeName("SlangResult (const SpecializationArg *, SlangInt, IComponentType **, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, SpecializationArg*, long, IComponentType**, ISlangBlob**, int> specialize;

        [NativeTypeName("SlangResult (IComponentType **, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, IComponentType**, ISlangBlob**, int> link;

        [NativeTypeName("SlangResult (int, int, ISlangSharedLibrary **, slang::IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, int, int, ISlangSharedLibrary**, ISlangBlob**, int> getEntryPointHostCallable;

        [NativeTypeName("SlangResult (const char *, IComponentType **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, sbyte*, IComponentType**, int> renameEntryPoint;

        [NativeTypeName("SlangResult (IComponentType **, uint32_t, CompilerOptionEntry *, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, IComponentType**, uint, CompilerOptionEntry*, ISlangBlob**, int> linkWithOptions;

        [NativeTypeName("SlangResult (SlangInt, IBlob **, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, long, ISlangBlob**, ISlangBlob**, int> getTargetCode;

        [NativeTypeName("SlangResult (SlangInt, IMetadata **, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, long, IMetadata**, ISlangBlob**, int> getTargetMetadata;

        [NativeTypeName("SlangResult (SlangInt, SlangInt, IMetadata **, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, long, long, IMetadata**, ISlangBlob**, int> getEntryPointMetadata;

        [NativeTypeName("SlangResult (const char *, IEntryPoint **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, sbyte*, IEntryPoint**, int> findEntryPointByName;

        [NativeTypeName("SlangInt32 () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, int> getDefinedEntryPointCount;

        [NativeTypeName("SlangResult (SlangInt32, IEntryPoint **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, int, IEntryPoint**, int> getDefinedEntryPoint;

        [NativeTypeName("SlangResult (ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, ISlangBlob**, int> serialize;

        [NativeTypeName("SlangResult (const char *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, sbyte*, int> writeToFile;

        [NativeTypeName("const char *() __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, sbyte*> getName;

        [NativeTypeName("const char *() __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, sbyte*> getFilePath;

        [NativeTypeName("const char *() __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, sbyte*> getUniqueIdentity;

        [NativeTypeName("SlangResult (const char *, SlangStage, IEntryPoint **, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, sbyte*, Stage, IEntryPoint**, ISlangBlob**, int> findAndCheckEntryPoint;

        [NativeTypeName("SlangInt32 () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, int> getDependencyFileCount;

        [NativeTypeName("const char *(SlangInt32) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, int, sbyte*> getDependencyFilePath;

        [NativeTypeName("DeclReflection *() __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<IModule*, DeclReflection*> getModuleReflection;
    }
}
