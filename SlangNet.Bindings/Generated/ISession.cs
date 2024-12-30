using System.Runtime.CompilerServices;
using static SlangNet.LayoutRules;

namespace SlangNet.Bindings.Generated;

/// <include file='ISession.xml' path='doc/member[@name="ISession"]/*' />
[NativeTypeName("struct ISession : ISlangUnknown")]
public unsafe partial struct ISession
{
    public Vtbl* lpVtbl;

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return lpVtbl->queryInterface((ISession*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return lpVtbl->addRef((ISession*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return lpVtbl->release((ISession*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISession.xml' path='doc/member[@name="ISession.getGlobalSession"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("slang::IGlobalSession *")]
    public IGlobalSession* getGlobalSession()
    {
        return lpVtbl->getGlobalSession((ISession*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISession.xml' path='doc/member[@name="ISession.loadModule"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("slang::IModule *")]
    public IModule* loadModule([NativeTypeName("const char *")] sbyte* moduleName, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return lpVtbl->loadModule((ISession*)Unsafe.AsPointer(ref this), moduleName, outDiagnostics);
    }

    /// <include file='ISession.xml' path='doc/member[@name="ISession.loadModuleFromSource"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("slang::IModule *")]
    public IModule* loadModuleFromSource([NativeTypeName("const char *")] sbyte* moduleName, [NativeTypeName("const char *")] sbyte* path, [NativeTypeName("slang::IBlob *")] ISlangBlob* source, [NativeTypeName("slang::IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return lpVtbl->loadModuleFromSource((ISession*)Unsafe.AsPointer(ref this), moduleName, path, source, outDiagnostics);
    }

    /// <include file='ISession.xml' path='doc/member[@name="ISession.createCompositeComponentType"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int createCompositeComponentType([NativeTypeName("IComponentType *const *")] IComponentType** componentTypes, [NativeTypeName("SlangInt")] long componentTypeCount, IComponentType** outCompositeComponentType, ISlangBlob** outDiagnostics = null)
    {
        return lpVtbl->createCompositeComponentType((ISession*)Unsafe.AsPointer(ref this), componentTypes, componentTypeCount, outCompositeComponentType, outDiagnostics);
    }

    /// <include file='ISession.xml' path='doc/member[@name="ISession.specializeType"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("slang::TypeReflection *")]
    public TypeReflection* specializeType([NativeTypeName("slang::TypeReflection *")] TypeReflection* type, [NativeTypeName("const SpecializationArg *")] SpecializationArg* specializationArgs, [NativeTypeName("SlangInt")] long specializationArgCount, ISlangBlob** outDiagnostics = null)
    {
        return lpVtbl->specializeType((ISession*)Unsafe.AsPointer(ref this), type, specializationArgs, specializationArgCount, outDiagnostics);
    }

    /// <include file='ISession.xml' path='doc/member[@name="ISession.getTypeLayout"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("slang::TypeLayoutReflection *")]
    public TypeLayoutReflection* getTypeLayout([NativeTypeName("slang::TypeReflection *")] TypeReflection* type, [NativeTypeName("SlangInt")] long targetIndex = 0, [NativeTypeName("slang::LayoutRules")] LayoutRules rules = Default, ISlangBlob** outDiagnostics = null)
    {
        return lpVtbl->getTypeLayout((ISession*)Unsafe.AsPointer(ref this), type, targetIndex, rules, outDiagnostics);
    }

    /// <include file='ISession.xml' path='doc/member[@name="ISession.getContainerType"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("slang::TypeReflection *")]
    public TypeReflection* getContainerType([NativeTypeName("slang::TypeReflection *")] TypeReflection* elementType, [NativeTypeName("slang::ContainerType")] ContainerType containerType, ISlangBlob** outDiagnostics = null)
    {
        return lpVtbl->getContainerType((ISession*)Unsafe.AsPointer(ref this), elementType, containerType, outDiagnostics);
    }

    /// <include file='ISession.xml' path='doc/member[@name="ISession.getDynamicType"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("slang::TypeReflection *")]
    public TypeReflection* getDynamicType()
    {
        return lpVtbl->getDynamicType((ISession*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISession.xml' path='doc/member[@name="ISession.getTypeRTTIMangledName"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getTypeRTTIMangledName([NativeTypeName("slang::TypeReflection *")] TypeReflection* type, ISlangBlob** outNameBlob)
    {
        return lpVtbl->getTypeRTTIMangledName((ISession*)Unsafe.AsPointer(ref this), type, outNameBlob);
    }

    /// <include file='ISession.xml' path='doc/member[@name="ISession.getTypeConformanceWitnessMangledName"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getTypeConformanceWitnessMangledName([NativeTypeName("slang::TypeReflection *")] TypeReflection* type, [NativeTypeName("slang::TypeReflection *")] TypeReflection* interfaceType, ISlangBlob** outNameBlob)
    {
        return lpVtbl->getTypeConformanceWitnessMangledName((ISession*)Unsafe.AsPointer(ref this), type, interfaceType, outNameBlob);
    }

    /// <include file='ISession.xml' path='doc/member[@name="ISession.getTypeConformanceWitnessSequentialID"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getTypeConformanceWitnessSequentialID([NativeTypeName("slang::TypeReflection *")] TypeReflection* type, [NativeTypeName("slang::TypeReflection *")] TypeReflection* interfaceType, [NativeTypeName("uint32_t *")] uint* outId)
    {
        return lpVtbl->getTypeConformanceWitnessSequentialID((ISession*)Unsafe.AsPointer(ref this), type, interfaceType, outId);
    }

    /// <include file='ISession.xml' path='doc/member[@name="ISession.createTypeConformanceComponentType"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int createTypeConformanceComponentType([NativeTypeName("slang::TypeReflection *")] TypeReflection* type, [NativeTypeName("slang::TypeReflection *")] TypeReflection* interfaceType, ITypeConformance** outConformance, [NativeTypeName("SlangInt")] long conformanceIdOverride, ISlangBlob** outDiagnostics)
    {
        return lpVtbl->createTypeConformanceComponentType((ISession*)Unsafe.AsPointer(ref this), type, interfaceType, outConformance, conformanceIdOverride, outDiagnostics);
    }

    /// <include file='ISession.xml' path='doc/member[@name="ISession.loadModuleFromIRBlob"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("slang::IModule *")]
    public IModule* loadModuleFromIRBlob([NativeTypeName("const char *")] sbyte* moduleName, [NativeTypeName("const char *")] sbyte* path, [NativeTypeName("slang::IBlob *")] ISlangBlob* source, [NativeTypeName("slang::IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return lpVtbl->loadModuleFromIRBlob((ISession*)Unsafe.AsPointer(ref this), moduleName, path, source, outDiagnostics);
    }

    /// <include file='ISession.xml' path='doc/member[@name="ISession.getLoadedModuleCount"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangInt")]
    public long getLoadedModuleCount()
    {
        return lpVtbl->getLoadedModuleCount((ISession*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISession.xml' path='doc/member[@name="ISession.getLoadedModule"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("slang::IModule *")]
    public IModule* getLoadedModule([NativeTypeName("SlangInt")] long index)
    {
        return lpVtbl->getLoadedModule((ISession*)Unsafe.AsPointer(ref this), index);
    }

    /// <include file='ISession.xml' path='doc/member[@name="ISession.isBinaryModuleUpToDate"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool isBinaryModuleUpToDate([NativeTypeName("const char *")] sbyte* modulePath, [NativeTypeName("slang::IBlob *")] ISlangBlob* binaryModuleBlob)
    {
        return lpVtbl->isBinaryModuleUpToDate((ISession*)Unsafe.AsPointer(ref this), modulePath, binaryModuleBlob) != 0;
    }

    /// <include file='ISession.xml' path='doc/member[@name="ISession.loadModuleFromSourceString"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("slang::IModule *")]
    public IModule* loadModuleFromSourceString([NativeTypeName("const char *")] sbyte* moduleName, [NativeTypeName("const char *")] sbyte* path, [NativeTypeName("const char *")] sbyte* @string, [NativeTypeName("slang::IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return lpVtbl->loadModuleFromSourceString((ISession*)Unsafe.AsPointer(ref this), moduleName, path, @string, outDiagnostics);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISession*, SlangUUID*, void**, int> queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISession*, uint> addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISession*, uint> release;

        [NativeTypeName("IGlobalSession *() __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISession*, IGlobalSession*> getGlobalSession;

        [NativeTypeName("IModule *(const char *, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISession*, sbyte*, ISlangBlob**, IModule*> loadModule;

        [NativeTypeName("IModule *(const char *, const char *, slang::IBlob *, slang::IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISession*, sbyte*, sbyte*, ISlangBlob*, ISlangBlob**, IModule*> loadModuleFromSource;

        [NativeTypeName("SlangResult (IComponentType *const *, SlangInt, IComponentType **, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISession*, IComponentType**, long, IComponentType**, ISlangBlob**, int> createCompositeComponentType;

        [NativeTypeName("TypeReflection *(TypeReflection *, const SpecializationArg *, SlangInt, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISession*, TypeReflection*, SpecializationArg*, long, ISlangBlob**, TypeReflection*> specializeType;

        [NativeTypeName("TypeLayoutReflection *(TypeReflection *, SlangInt, LayoutRules, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISession*, TypeReflection*, long, LayoutRules, ISlangBlob**, TypeLayoutReflection*> getTypeLayout;

        [NativeTypeName("TypeReflection *(TypeReflection *, ContainerType, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISession*, TypeReflection*, ContainerType, ISlangBlob**, TypeReflection*> getContainerType;

        [NativeTypeName("TypeReflection *() __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISession*, TypeReflection*> getDynamicType;

        [NativeTypeName("SlangResult (TypeReflection *, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISession*, TypeReflection*, ISlangBlob**, int> getTypeRTTIMangledName;

        [NativeTypeName("SlangResult (TypeReflection *, TypeReflection *, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISession*, TypeReflection*, TypeReflection*, ISlangBlob**, int> getTypeConformanceWitnessMangledName;

        [NativeTypeName("SlangResult (slang::TypeReflection *, slang::TypeReflection *, uint32_t *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISession*, TypeReflection*, TypeReflection*, uint*, int> getTypeConformanceWitnessSequentialID;

        [NativeTypeName("SlangResult (slang::TypeReflection *, slang::TypeReflection *, ITypeConformance **, SlangInt, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISession*, TypeReflection*, TypeReflection*, ITypeConformance**, long, ISlangBlob**, int> createTypeConformanceComponentType;

        [NativeTypeName("IModule *(const char *, const char *, slang::IBlob *, slang::IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISession*, sbyte*, sbyte*, ISlangBlob*, ISlangBlob**, IModule*> loadModuleFromIRBlob;

        [NativeTypeName("SlangInt () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISession*, long> getLoadedModuleCount;

        [NativeTypeName("IModule *(SlangInt) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISession*, long, IModule*> getLoadedModule;

        [NativeTypeName("bool (const char *, slang::IBlob *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISession*, sbyte*, ISlangBlob*, byte> isBinaryModuleUpToDate;

        [NativeTypeName("IModule *(const char *, const char *, const char *, slang::IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISession*, sbyte*, sbyte*, sbyte*, ISlangBlob**, IModule*> loadModuleFromSourceString;
    }
}
