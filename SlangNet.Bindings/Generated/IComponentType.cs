using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='IComponentType.xml' path='doc/member[@name="IComponentType"]/*' />
[NativeTypeName("struct IComponentType : ISlangUnknown")]
public unsafe partial struct IComponentType
{
    public void** lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(IComponentType* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IComponentType* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IComponentType* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("slang::ISession *")]
    public delegate ISession* _getSession(IComponentType* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("slang::ProgramLayout *")]
    public delegate ShaderReflection* _getLayout(IComponentType* pThis, [NativeTypeName("SlangInt")] long targetIndex = 0, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangInt")]
    public delegate long _getSpecializationParamCount(IComponentType* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getEntryPointCode(IComponentType* pThis, [NativeTypeName("SlangInt")] long entryPointIndex, [NativeTypeName("SlangInt")] long targetIndex, [NativeTypeName("IBlob **")] ISlangBlob** outCode, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getResultAsFileSystem(IComponentType* pThis, [NativeTypeName("SlangInt")] long entryPointIndex, [NativeTypeName("SlangInt")] long targetIndex, ISlangMutableFileSystem** outFileSystem);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _getEntryPointHash(IComponentType* pThis, [NativeTypeName("SlangInt")] long entryPointIndex, [NativeTypeName("SlangInt")] long targetIndex, [NativeTypeName("IBlob **")] ISlangBlob** outHash);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _specialize(IComponentType* pThis, [NativeTypeName("const SpecializationArg *")] SpecializationArg* specializationArgs, [NativeTypeName("SlangInt")] long specializationArgCount, IComponentType** outSpecializedComponentType, ISlangBlob** outDiagnostics = null);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _link(IComponentType* pThis, IComponentType** outLinkedComponentType, ISlangBlob** outDiagnostics = null);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getEntryPointHostCallable(IComponentType* pThis, int entryPointIndex, int targetIndex, ISlangSharedLibrary** outSharedLibrary, [NativeTypeName("slang::IBlob **")] ISlangBlob** outDiagnostics = null);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _renameEntryPoint(IComponentType* pThis, [NativeTypeName("const char *")] sbyte* newName, IComponentType** outEntryPoint);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _linkWithOptions(IComponentType* pThis, IComponentType** outLinkedComponentType, [NativeTypeName("uint32_t")] uint compilerOptionEntryCount, [NativeTypeName("slang::CompilerOptionEntry *")] CompilerOptionEntry* compilerOptionEntries, ISlangBlob** outDiagnostics = null);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getTargetCode(IComponentType* pThis, [NativeTypeName("SlangInt")] long targetIndex, [NativeTypeName("IBlob **")] ISlangBlob** outCode, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getTargetMetadata(IComponentType* pThis, [NativeTypeName("SlangInt")] long targetIndex, IMetadata** outMetadata, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getEntryPointMetadata(IComponentType* pThis, [NativeTypeName("SlangInt")] long entryPointIndex, [NativeTypeName("SlangInt")] long targetIndex, IMetadata** outMetadata, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>((IntPtr)(lpVtbl[0]))((IComponentType*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>((IntPtr)(lpVtbl[1]))((IComponentType*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>((IntPtr)(lpVtbl[2]))((IComponentType*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IComponentType.xml' path='doc/member[@name="IComponentType.getSession"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("slang::ISession *")]
    public ISession* getSession()
    {
        return Marshal.GetDelegateForFunctionPointer<_getSession>((IntPtr)(lpVtbl[3]))((IComponentType*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IComponentType.xml' path='doc/member[@name="IComponentType.getLayout"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("slang::ProgramLayout *")]
    public ShaderReflection* getLayout([NativeTypeName("SlangInt")] long targetIndex = 0, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return Marshal.GetDelegateForFunctionPointer<_getLayout>((IntPtr)(lpVtbl[4]))((IComponentType*)Unsafe.AsPointer(ref this), targetIndex, outDiagnostics);
    }

    /// <include file='IComponentType.xml' path='doc/member[@name="IComponentType.getSpecializationParamCount"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangInt")]
    public long getSpecializationParamCount()
    {
        return Marshal.GetDelegateForFunctionPointer<_getSpecializationParamCount>((IntPtr)(lpVtbl[5]))((IComponentType*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IComponentType.xml' path='doc/member[@name="IComponentType.getEntryPointCode"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getEntryPointCode([NativeTypeName("SlangInt")] long entryPointIndex, [NativeTypeName("SlangInt")] long targetIndex, [NativeTypeName("IBlob **")] ISlangBlob** outCode, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return Marshal.GetDelegateForFunctionPointer<_getEntryPointCode>((IntPtr)(lpVtbl[6]))((IComponentType*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outCode, outDiagnostics);
    }

    /// <include file='IComponentType.xml' path='doc/member[@name="IComponentType.getResultAsFileSystem"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getResultAsFileSystem([NativeTypeName("SlangInt")] long entryPointIndex, [NativeTypeName("SlangInt")] long targetIndex, ISlangMutableFileSystem** outFileSystem)
    {
        return Marshal.GetDelegateForFunctionPointer<_getResultAsFileSystem>((IntPtr)(lpVtbl[7]))((IComponentType*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outFileSystem);
    }

    /// <include file='IComponentType.xml' path='doc/member[@name="IComponentType.getEntryPointHash"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void getEntryPointHash([NativeTypeName("SlangInt")] long entryPointIndex, [NativeTypeName("SlangInt")] long targetIndex, [NativeTypeName("IBlob **")] ISlangBlob** outHash)
    {
        Marshal.GetDelegateForFunctionPointer<_getEntryPointHash>((IntPtr)(lpVtbl[8]))((IComponentType*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outHash);
    }

    /// <include file='IComponentType.xml' path='doc/member[@name="IComponentType.specialize"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int specialize([NativeTypeName("const SpecializationArg *")] SpecializationArg* specializationArgs, [NativeTypeName("SlangInt")] long specializationArgCount, IComponentType** outSpecializedComponentType, ISlangBlob** outDiagnostics = null)
    {
        return Marshal.GetDelegateForFunctionPointer<_specialize>((IntPtr)(lpVtbl[9]))((IComponentType*)Unsafe.AsPointer(ref this), specializationArgs, specializationArgCount, outSpecializedComponentType, outDiagnostics);
    }

    /// <include file='IComponentType.xml' path='doc/member[@name="IComponentType.link"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int link(IComponentType** outLinkedComponentType, ISlangBlob** outDiagnostics = null)
    {
        return Marshal.GetDelegateForFunctionPointer<_link>((IntPtr)(lpVtbl[10]))((IComponentType*)Unsafe.AsPointer(ref this), outLinkedComponentType, outDiagnostics);
    }

    /// <include file='IComponentType.xml' path='doc/member[@name="IComponentType.getEntryPointHostCallable"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getEntryPointHostCallable(int entryPointIndex, int targetIndex, ISlangSharedLibrary** outSharedLibrary, [NativeTypeName("slang::IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return Marshal.GetDelegateForFunctionPointer<_getEntryPointHostCallable>((IntPtr)(lpVtbl[11]))((IComponentType*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outSharedLibrary, outDiagnostics);
    }

    /// <include file='IComponentType.xml' path='doc/member[@name="IComponentType.renameEntryPoint"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int renameEntryPoint([NativeTypeName("const char *")] sbyte* newName, IComponentType** outEntryPoint)
    {
        return Marshal.GetDelegateForFunctionPointer<_renameEntryPoint>((IntPtr)(lpVtbl[12]))((IComponentType*)Unsafe.AsPointer(ref this), newName, outEntryPoint);
    }

    /// <include file='IComponentType.xml' path='doc/member[@name="IComponentType.linkWithOptions"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int linkWithOptions(IComponentType** outLinkedComponentType, [NativeTypeName("uint32_t")] uint compilerOptionEntryCount, [NativeTypeName("slang::CompilerOptionEntry *")] CompilerOptionEntry* compilerOptionEntries, ISlangBlob** outDiagnostics = null)
    {
        return Marshal.GetDelegateForFunctionPointer<_linkWithOptions>((IntPtr)(lpVtbl[13]))((IComponentType*)Unsafe.AsPointer(ref this), outLinkedComponentType, compilerOptionEntryCount, compilerOptionEntries, outDiagnostics);
    }

    /// <include file='IComponentType.xml' path='doc/member[@name="IComponentType.getTargetCode"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getTargetCode([NativeTypeName("SlangInt")] long targetIndex, [NativeTypeName("IBlob **")] ISlangBlob** outCode, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return Marshal.GetDelegateForFunctionPointer<_getTargetCode>((IntPtr)(lpVtbl[14]))((IComponentType*)Unsafe.AsPointer(ref this), targetIndex, outCode, outDiagnostics);
    }

    /// <include file='IComponentType.xml' path='doc/member[@name="IComponentType.getTargetMetadata"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getTargetMetadata([NativeTypeName("SlangInt")] long targetIndex, IMetadata** outMetadata, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return Marshal.GetDelegateForFunctionPointer<_getTargetMetadata>((IntPtr)(lpVtbl[15]))((IComponentType*)Unsafe.AsPointer(ref this), targetIndex, outMetadata, outDiagnostics);
    }

    /// <include file='IComponentType.xml' path='doc/member[@name="IComponentType.getEntryPointMetadata"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getEntryPointMetadata([NativeTypeName("SlangInt")] long entryPointIndex, [NativeTypeName("SlangInt")] long targetIndex, IMetadata** outMetadata, [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null)
    {
        return Marshal.GetDelegateForFunctionPointer<_getEntryPointMetadata>((IntPtr)(lpVtbl[16]))((IComponentType*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outMetadata, outDiagnostics);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr release;

        [NativeTypeName("ISession *() __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getSession;

        [NativeTypeName("ProgramLayout *(SlangInt, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getLayout;

        [NativeTypeName("SlangInt () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getSpecializationParamCount;

        [NativeTypeName("SlangResult (SlangInt, SlangInt, IBlob **, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getEntryPointCode;

        [NativeTypeName("SlangResult (SlangInt, SlangInt, ISlangMutableFileSystem **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getResultAsFileSystem;

        [NativeTypeName("void (SlangInt, SlangInt, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getEntryPointHash;

        [NativeTypeName("SlangResult (const SpecializationArg *, SlangInt, IComponentType **, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr specialize;

        [NativeTypeName("SlangResult (IComponentType **, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr link;

        [NativeTypeName("SlangResult (int, int, ISlangSharedLibrary **, slang::IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getEntryPointHostCallable;

        [NativeTypeName("SlangResult (const char *, IComponentType **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr renameEntryPoint;

        [NativeTypeName("SlangResult (IComponentType **, uint32_t, CompilerOptionEntry *, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr linkWithOptions;

        [NativeTypeName("SlangResult (SlangInt, IBlob **, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getTargetCode;

        [NativeTypeName("SlangResult (SlangInt, IMetadata **, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getTargetMetadata;

        [NativeTypeName("SlangResult (SlangInt, SlangInt, IMetadata **, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getEntryPointMetadata;
    }
}
