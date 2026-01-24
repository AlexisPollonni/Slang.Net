using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='IEntryPoint.xml' path='doc/member[@name="IEntryPoint"]/*' />
[Guid("8F241361-F5BD-4CA0-A3AC-02F7FA2402B8")]
[NativeTypeName("struct IEntryPoint : slang::IComponentType")]
[NativeInheritance("IComponentType")]
public unsafe partial struct IEntryPoint
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(
        IEntryPoint* pThis,
        [NativeTypeName("const SlangUUID &")] SlangUUID* uuid,
        void** outObject
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IEntryPoint* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IEntryPoint* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("slang::ISession *")]
    public delegate ISession* _getSession(IEntryPoint* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("slang::ProgramLayout *")]
    public delegate ShaderReflection* _getLayout(
        IEntryPoint* pThis,
        [NativeTypeName("SlangInt")] nint targetIndex = 0,
        [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangInt")]
    public delegate nint _getSpecializationParamCount(IEntryPoint* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getEntryPointCode(
        IEntryPoint* pThis,
        [NativeTypeName("SlangInt")] nint entryPointIndex,
        [NativeTypeName("SlangInt")] nint targetIndex,
        [NativeTypeName("IBlob **")] ISlangBlob** outCode,
        [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getResultAsFileSystem(
        IEntryPoint* pThis,
        [NativeTypeName("SlangInt")] nint entryPointIndex,
        [NativeTypeName("SlangInt")] nint targetIndex,
        ISlangMutableFileSystem** outFileSystem
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _getEntryPointHash(
        IEntryPoint* pThis,
        [NativeTypeName("SlangInt")] nint entryPointIndex,
        [NativeTypeName("SlangInt")] nint targetIndex,
        [NativeTypeName("IBlob **")] ISlangBlob** outHash
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _specialize(
        IEntryPoint* pThis,
        [NativeTypeName("const SpecializationArg *")] SpecializationArg* specializationArgs,
        [NativeTypeName("SlangInt")] nint specializationArgCount,
        IComponentType** outSpecializedComponentType,
        ISlangBlob** outDiagnostics = null
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _link(
        IEntryPoint* pThis,
        IComponentType** outLinkedComponentType,
        ISlangBlob** outDiagnostics = null
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getEntryPointHostCallable(
        IEntryPoint* pThis,
        int entryPointIndex,
        int targetIndex,
        ISlangSharedLibrary** outSharedLibrary,
        [NativeTypeName("slang::IBlob **")] ISlangBlob** outDiagnostics = null
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _renameEntryPoint(
        IEntryPoint* pThis,
        [NativeTypeName("const char *")] sbyte* newName,
        IComponentType** outEntryPoint
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _linkWithOptions(
        IEntryPoint* pThis,
        IComponentType** outLinkedComponentType,
        [NativeTypeName("uint32_t")] uint compilerOptionEntryCount,
        [NativeTypeName("slang::CompilerOptionEntry *")] CompilerOptionEntry* compilerOptionEntries,
        ISlangBlob** outDiagnostics = null
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getTargetCode(
        IEntryPoint* pThis,
        [NativeTypeName("SlangInt")] nint targetIndex,
        [NativeTypeName("IBlob **")] ISlangBlob** outCode,
        [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getTargetMetadata(
        IEntryPoint* pThis,
        [NativeTypeName("SlangInt")] nint targetIndex,
        IMetadata** outMetadata,
        [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getEntryPointMetadata(
        IEntryPoint* pThis,
        [NativeTypeName("SlangInt")] nint entryPointIndex,
        [NativeTypeName("SlangInt")] nint targetIndex,
        IMetadata** outMetadata,
        [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("slang::FunctionReflection *")]
    public delegate FunctionReflection* _getFunctionReflection(IEntryPoint* pThis);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface(
        [NativeTypeName("const SlangUUID &")] SlangUUID* uuid,
        void** outObject
    )
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)(
            (IEntryPoint*)Unsafe.AsPointer(ref this),
            uuid,
            outObject
        );
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)(
            (IEntryPoint*)Unsafe.AsPointer(ref this)
        );
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)(
            (IEntryPoint*)Unsafe.AsPointer(ref this)
        );
    }

    /// <inheritdoc cref="IComponentType.getSession" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("slang::ISession *")]
    public ISession* getSession()
    {
        return Marshal.GetDelegateForFunctionPointer<_getSession>(lpVtbl->getSession)(
            (IEntryPoint*)Unsafe.AsPointer(ref this)
        );
    }

    /// <inheritdoc cref="IComponentType.getLayout" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("slang::ProgramLayout *")]
    public ShaderReflection* getLayout(
        [NativeTypeName("SlangInt")] nint targetIndex = 0,
        [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null
    )
    {
        return Marshal.GetDelegateForFunctionPointer<_getLayout>(lpVtbl->getLayout)(
            (IEntryPoint*)Unsafe.AsPointer(ref this),
            targetIndex,
            outDiagnostics
        );
    }

    /// <inheritdoc cref="IComponentType.getSpecializationParamCount" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangInt")]
    public nint getSpecializationParamCount()
    {
        return Marshal.GetDelegateForFunctionPointer<_getSpecializationParamCount>(
            lpVtbl->getSpecializationParamCount
        )((IEntryPoint*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="IComponentType.getEntryPointCode" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getEntryPointCode(
        [NativeTypeName("SlangInt")] nint entryPointIndex,
        [NativeTypeName("SlangInt")] nint targetIndex,
        [NativeTypeName("IBlob **")] ISlangBlob** outCode,
        [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null
    )
    {
        return Marshal.GetDelegateForFunctionPointer<_getEntryPointCode>(lpVtbl->getEntryPointCode)(
            (IEntryPoint*)Unsafe.AsPointer(ref this),
            entryPointIndex,
            targetIndex,
            outCode,
            outDiagnostics
        );
    }

    /// <inheritdoc cref="IComponentType.getResultAsFileSystem" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getResultAsFileSystem(
        [NativeTypeName("SlangInt")] nint entryPointIndex,
        [NativeTypeName("SlangInt")] nint targetIndex,
        ISlangMutableFileSystem** outFileSystem
    )
    {
        return Marshal.GetDelegateForFunctionPointer<_getResultAsFileSystem>(
            lpVtbl->getResultAsFileSystem
        )((IEntryPoint*)Unsafe.AsPointer(ref this), entryPointIndex, targetIndex, outFileSystem);
    }

    /// <inheritdoc cref="IComponentType.getEntryPointHash" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void getEntryPointHash(
        [NativeTypeName("SlangInt")] nint entryPointIndex,
        [NativeTypeName("SlangInt")] nint targetIndex,
        [NativeTypeName("IBlob **")] ISlangBlob** outHash
    )
    {
        Marshal.GetDelegateForFunctionPointer<_getEntryPointHash>(lpVtbl->getEntryPointHash)(
            (IEntryPoint*)Unsafe.AsPointer(ref this),
            entryPointIndex,
            targetIndex,
            outHash
        );
    }

    /// <inheritdoc cref="IComponentType.specialize" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int specialize(
        [NativeTypeName("const SpecializationArg *")] SpecializationArg* specializationArgs,
        [NativeTypeName("SlangInt")] nint specializationArgCount,
        IComponentType** outSpecializedComponentType,
        ISlangBlob** outDiagnostics = null
    )
    {
        return Marshal.GetDelegateForFunctionPointer<_specialize>(lpVtbl->specialize)(
            (IEntryPoint*)Unsafe.AsPointer(ref this),
            specializationArgs,
            specializationArgCount,
            outSpecializedComponentType,
            outDiagnostics
        );
    }

    /// <inheritdoc cref="IComponentType.link" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int link(IComponentType** outLinkedComponentType, ISlangBlob** outDiagnostics = null)
    {
        return Marshal.GetDelegateForFunctionPointer<_link>(lpVtbl->link)(
            (IEntryPoint*)Unsafe.AsPointer(ref this),
            outLinkedComponentType,
            outDiagnostics
        );
    }

    /// <inheritdoc cref="IComponentType.getEntryPointHostCallable" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getEntryPointHostCallable(
        int entryPointIndex,
        int targetIndex,
        ISlangSharedLibrary** outSharedLibrary,
        [NativeTypeName("slang::IBlob **")] ISlangBlob** outDiagnostics = null
    )
    {
        return Marshal.GetDelegateForFunctionPointer<_getEntryPointHostCallable>(
            lpVtbl->getEntryPointHostCallable
        )(
            (IEntryPoint*)Unsafe.AsPointer(ref this),
            entryPointIndex,
            targetIndex,
            outSharedLibrary,
            outDiagnostics
        );
    }

    /// <inheritdoc cref="IComponentType.renameEntryPoint" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int renameEntryPoint(
        [NativeTypeName("const char *")] sbyte* newName,
        IComponentType** outEntryPoint
    )
    {
        return Marshal.GetDelegateForFunctionPointer<_renameEntryPoint>(lpVtbl->renameEntryPoint)(
            (IEntryPoint*)Unsafe.AsPointer(ref this),
            newName,
            outEntryPoint
        );
    }

    /// <inheritdoc cref="IComponentType.linkWithOptions" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int linkWithOptions(
        IComponentType** outLinkedComponentType,
        [NativeTypeName("uint32_t")] uint compilerOptionEntryCount,
        [NativeTypeName("slang::CompilerOptionEntry *")] CompilerOptionEntry* compilerOptionEntries,
        ISlangBlob** outDiagnostics = null
    )
    {
        return Marshal.GetDelegateForFunctionPointer<_linkWithOptions>(lpVtbl->linkWithOptions)(
            (IEntryPoint*)Unsafe.AsPointer(ref this),
            outLinkedComponentType,
            compilerOptionEntryCount,
            compilerOptionEntries,
            outDiagnostics
        );
    }

    /// <inheritdoc cref="IComponentType.getTargetCode" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getTargetCode(
        [NativeTypeName("SlangInt")] nint targetIndex,
        [NativeTypeName("IBlob **")] ISlangBlob** outCode,
        [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null
    )
    {
        return Marshal.GetDelegateForFunctionPointer<_getTargetCode>(lpVtbl->getTargetCode)(
            (IEntryPoint*)Unsafe.AsPointer(ref this),
            targetIndex,
            outCode,
            outDiagnostics
        );
    }

    /// <inheritdoc cref="IComponentType.getTargetMetadata" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getTargetMetadata(
        [NativeTypeName("SlangInt")] nint targetIndex,
        IMetadata** outMetadata,
        [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null
    )
    {
        return Marshal.GetDelegateForFunctionPointer<_getTargetMetadata>(lpVtbl->getTargetMetadata)(
            (IEntryPoint*)Unsafe.AsPointer(ref this),
            targetIndex,
            outMetadata,
            outDiagnostics
        );
    }

    /// <inheritdoc cref="IComponentType.getEntryPointMetadata" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getEntryPointMetadata(
        [NativeTypeName("SlangInt")] nint entryPointIndex,
        [NativeTypeName("SlangInt")] nint targetIndex,
        IMetadata** outMetadata,
        [NativeTypeName("IBlob **")] ISlangBlob** outDiagnostics = null
    )
    {
        return Marshal.GetDelegateForFunctionPointer<_getEntryPointMetadata>(
            lpVtbl->getEntryPointMetadata
        )(
            (IEntryPoint*)Unsafe.AsPointer(ref this),
            entryPointIndex,
            targetIndex,
            outMetadata,
            outDiagnostics
        );
    }

    /// <include file='IEntryPoint.xml' path='doc/member[@name="IEntryPoint.getFunctionReflection"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("slang::FunctionReflection *")]
    public FunctionReflection* getFunctionReflection()
    {
        return Marshal.GetDelegateForFunctionPointer<_getFunctionReflection>(
            lpVtbl->getFunctionReflection
        )((IEntryPoint*)Unsafe.AsPointer(ref this));
    }

    public partial struct Vtbl
    {
        [NativeTypeName(
            "SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))"
        )]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr release;

        [NativeTypeName("ISession *() __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getSession;

        [NativeTypeName(
            "ProgramLayout *(SlangInt, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))"
        )]
        public IntPtr getLayout;

        [NativeTypeName("SlangInt () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getSpecializationParamCount;

        [NativeTypeName(
            "SlangResult (SlangInt, SlangInt, IBlob **, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))"
        )]
        public IntPtr getEntryPointCode;

        [NativeTypeName(
            "SlangResult (SlangInt, SlangInt, ISlangMutableFileSystem **) __attribute__((nothrow)) __attribute__((stdcall))"
        )]
        public IntPtr getResultAsFileSystem;

        [NativeTypeName(
            "void (SlangInt, SlangInt, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))"
        )]
        public IntPtr getEntryPointHash;

        [NativeTypeName(
            "SlangResult (const SpecializationArg *, SlangInt, IComponentType **, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))"
        )]
        public IntPtr specialize;

        [NativeTypeName(
            "SlangResult (IComponentType **, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))"
        )]
        public IntPtr link;

        [NativeTypeName(
            "SlangResult (int, int, ISlangSharedLibrary **, slang::IBlob **) __attribute__((nothrow)) __attribute__((stdcall))"
        )]
        public IntPtr getEntryPointHostCallable;

        [NativeTypeName(
            "SlangResult (const char *, IComponentType **) __attribute__((nothrow)) __attribute__((stdcall))"
        )]
        public IntPtr renameEntryPoint;

        [NativeTypeName(
            "SlangResult (IComponentType **, uint32_t, CompilerOptionEntry *, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))"
        )]
        public IntPtr linkWithOptions;

        [NativeTypeName(
            "SlangResult (SlangInt, IBlob **, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))"
        )]
        public IntPtr getTargetCode;

        [NativeTypeName(
            "SlangResult (SlangInt, IMetadata **, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))"
        )]
        public IntPtr getTargetMetadata;

        [NativeTypeName(
            "SlangResult (SlangInt, SlangInt, IMetadata **, IBlob **) __attribute__((nothrow)) __attribute__((stdcall))"
        )]
        public IntPtr getEntryPointMetadata;

        [NativeTypeName("FunctionReflection *() __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getFunctionReflection;
    }
}
