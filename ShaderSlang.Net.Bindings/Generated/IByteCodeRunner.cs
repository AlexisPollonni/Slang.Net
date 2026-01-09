using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='IByteCodeRunner.xml' path='doc/member[@name="IByteCodeRunner"]/*' />
[Guid("AFDAB195-361F-42CB-9513-9006261DD8CD")]
[NativeTypeName("struct IByteCodeRunner : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct IByteCodeRunner
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(IByteCodeRunner* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IByteCodeRunner* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IByteCodeRunner* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _loadModule(IByteCodeRunner* pThis, [NativeTypeName("slang::IBlob *")] ISlangBlob* moduleBlob);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _selectFunctionByIndex(IByteCodeRunner* pThis, [NativeTypeName("uint32_t")] uint functionIndex);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _findFunctionByName(IByteCodeRunner* pThis, [NativeTypeName("const char *")] sbyte* name);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _getFunctionInfo(IByteCodeRunner* pThis, [NativeTypeName("uint32_t")] uint index, [NativeTypeName("slang::ByteCodeFuncInfo *")] ByteCodeFuncInfo* outInfo);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void* _getCurrentWorkingSet(IByteCodeRunner* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _execute(IByteCodeRunner* pThis, void* argumentData, [NativeTypeName("size_t")] nuint argumentSize);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _getErrorString(IByteCodeRunner* pThis, [NativeTypeName("IBlob **")] ISlangBlob** outBlob);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void* _getReturnValue(IByteCodeRunner* pThis, [NativeTypeName("size_t *")] nuint* outValueSize);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _setExtInstHandlerUserData(IByteCodeRunner* pThis, void* userData);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _registerExtCall(IByteCodeRunner* pThis, [NativeTypeName("const char *")] sbyte* name, [NativeTypeName("slang::VMExtFunction")] IntPtr functionPtr);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _setPrintCallback(IByteCodeRunner* pThis, [NativeTypeName("slang::VMPrintFunc")] IntPtr callback, void* userData);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((IByteCodeRunner*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((IByteCodeRunner*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((IByteCodeRunner*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IByteCodeRunner.xml' path='doc/member[@name="IByteCodeRunner.loadModule"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int loadModule([NativeTypeName("slang::IBlob *")] ISlangBlob* moduleBlob)
    {
        return Marshal.GetDelegateForFunctionPointer<_loadModule>(lpVtbl->loadModule)((IByteCodeRunner*)Unsafe.AsPointer(ref this), moduleBlob);
    }

    /// <include file='IByteCodeRunner.xml' path='doc/member[@name="IByteCodeRunner.selectFunctionByIndex"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int selectFunctionByIndex([NativeTypeName("uint32_t")] uint functionIndex)
    {
        return Marshal.GetDelegateForFunctionPointer<_selectFunctionByIndex>(lpVtbl->selectFunctionByIndex)((IByteCodeRunner*)Unsafe.AsPointer(ref this), functionIndex);
    }

    /// <include file='IByteCodeRunner.xml' path='doc/member[@name="IByteCodeRunner.findFunctionByName"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int findFunctionByName([NativeTypeName("const char *")] sbyte* name)
    {
        return Marshal.GetDelegateForFunctionPointer<_findFunctionByName>(lpVtbl->findFunctionByName)((IByteCodeRunner*)Unsafe.AsPointer(ref this), name);
    }

    /// <include file='IByteCodeRunner.xml' path='doc/member[@name="IByteCodeRunner.getFunctionInfo"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int getFunctionInfo([NativeTypeName("uint32_t")] uint index, [NativeTypeName("slang::ByteCodeFuncInfo *")] ByteCodeFuncInfo* outInfo)
    {
        return Marshal.GetDelegateForFunctionPointer<_getFunctionInfo>(lpVtbl->getFunctionInfo)((IByteCodeRunner*)Unsafe.AsPointer(ref this), index, outInfo);
    }

    /// <include file='IByteCodeRunner.xml' path='doc/member[@name="IByteCodeRunner.getCurrentWorkingSet"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void* getCurrentWorkingSet()
    {
        return Marshal.GetDelegateForFunctionPointer<_getCurrentWorkingSet>(lpVtbl->getCurrentWorkingSet)((IByteCodeRunner*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IByteCodeRunner.xml' path='doc/member[@name="IByteCodeRunner.execute"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int execute(void* argumentData, [NativeTypeName("size_t")] nuint argumentSize)
    {
        return Marshal.GetDelegateForFunctionPointer<_execute>(lpVtbl->execute)((IByteCodeRunner*)Unsafe.AsPointer(ref this), argumentData, argumentSize);
    }

    /// <include file='IByteCodeRunner.xml' path='doc/member[@name="IByteCodeRunner.getErrorString"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void getErrorString([NativeTypeName("IBlob **")] ISlangBlob** outBlob)
    {
        Marshal.GetDelegateForFunctionPointer<_getErrorString>(lpVtbl->getErrorString)((IByteCodeRunner*)Unsafe.AsPointer(ref this), outBlob);
    }

    /// <include file='IByteCodeRunner.xml' path='doc/member[@name="IByteCodeRunner.getReturnValue"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void* getReturnValue([NativeTypeName("size_t *")] nuint* outValueSize)
    {
        return Marshal.GetDelegateForFunctionPointer<_getReturnValue>(lpVtbl->getReturnValue)((IByteCodeRunner*)Unsafe.AsPointer(ref this), outValueSize);
    }

    /// <include file='IByteCodeRunner.xml' path='doc/member[@name="IByteCodeRunner.setExtInstHandlerUserData"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void setExtInstHandlerUserData(void* userData)
    {
        Marshal.GetDelegateForFunctionPointer<_setExtInstHandlerUserData>(lpVtbl->setExtInstHandlerUserData)((IByteCodeRunner*)Unsafe.AsPointer(ref this), userData);
    }

    /// <include file='IByteCodeRunner.xml' path='doc/member[@name="IByteCodeRunner.registerExtCall"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int registerExtCall([NativeTypeName("const char *")] sbyte* name, [NativeTypeName("slang::VMExtFunction")] IntPtr functionPtr)
    {
        return Marshal.GetDelegateForFunctionPointer<_registerExtCall>(lpVtbl->registerExtCall)((IByteCodeRunner*)Unsafe.AsPointer(ref this), name, functionPtr);
    }

    /// <include file='IByteCodeRunner.xml' path='doc/member[@name="IByteCodeRunner.setPrintCallback"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int setPrintCallback([NativeTypeName("slang::VMPrintFunc")] IntPtr callback, void* userData)
    {
        return Marshal.GetDelegateForFunctionPointer<_setPrintCallback>(lpVtbl->setPrintCallback)((IByteCodeRunner*)Unsafe.AsPointer(ref this), callback, userData);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((stdcall))")]
        public IntPtr release;

        [NativeTypeName("SlangResult (IBlob *) __attribute__((stdcall))")]
        public IntPtr loadModule;

        [NativeTypeName("SlangResult (uint32_t) __attribute__((stdcall))")]
        public IntPtr selectFunctionByIndex;

        [NativeTypeName("int (const char *) __attribute__((stdcall))")]
        public IntPtr findFunctionByName;

        [NativeTypeName("SlangResult (uint32_t, ByteCodeFuncInfo *) __attribute__((stdcall))")]
        public IntPtr getFunctionInfo;

        [NativeTypeName("void *() __attribute__((stdcall))")]
        public IntPtr getCurrentWorkingSet;

        [NativeTypeName("SlangResult (void *, size_t) __attribute__((stdcall))")]
        public IntPtr execute;

        [NativeTypeName("void (IBlob **) __attribute__((stdcall))")]
        public IntPtr getErrorString;

        [NativeTypeName("void *(size_t *) __attribute__((stdcall))")]
        public IntPtr getReturnValue;

        [NativeTypeName("void (void *) __attribute__((stdcall))")]
        public IntPtr setExtInstHandlerUserData;

        [NativeTypeName("SlangResult (const char *, VMExtFunction) __attribute__((stdcall))")]
        public IntPtr registerExtCall;

        [NativeTypeName("SlangResult (VMPrintFunc, void *) __attribute__((stdcall))")]
        public IntPtr setPrintCallback;
    }
}
