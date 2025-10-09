using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='ISlangWriter.xml' path='doc/member[@name="ISlangWriter"]/*' />
[Guid("EC457F0E-9ADD-4E6B-851C-D7FA716D15FD")]
[NativeTypeName("struct ISlangWriter : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct ISlangWriter
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(ISlangWriter* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(ISlangWriter* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(ISlangWriter* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("char *")]
    public delegate sbyte* _beginAppendBuffer(ISlangWriter* pThis, [NativeTypeName("size_t")] nuint maxNumChars);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _endAppendBuffer(ISlangWriter* pThis, [NativeTypeName("char *")] sbyte* buffer, [NativeTypeName("size_t")] nuint numChars);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _write(ISlangWriter* pThis, [NativeTypeName("const char *")] sbyte* chars, [NativeTypeName("size_t")] nuint numChars);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _flush(ISlangWriter* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangBool")]
    public delegate Boolean _isConsole(ISlangWriter* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _setMode(ISlangWriter* pThis, [NativeTypeName("SlangWriterMode")] WriterMode mode);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((ISlangWriter*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((ISlangWriter*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((ISlangWriter*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISlangWriter.xml' path='doc/member[@name="ISlangWriter.beginAppendBuffer"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("char *")]
    public sbyte* beginAppendBuffer([NativeTypeName("size_t")] nuint maxNumChars)
    {
        return Marshal.GetDelegateForFunctionPointer<_beginAppendBuffer>(lpVtbl->beginAppendBuffer)((ISlangWriter*)Unsafe.AsPointer(ref this), maxNumChars);
    }

    /// <include file='ISlangWriter.xml' path='doc/member[@name="ISlangWriter.endAppendBuffer"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int endAppendBuffer([NativeTypeName("char *")] sbyte* buffer, [NativeTypeName("size_t")] nuint numChars)
    {
        return Marshal.GetDelegateForFunctionPointer<_endAppendBuffer>(lpVtbl->endAppendBuffer)((ISlangWriter*)Unsafe.AsPointer(ref this), buffer, numChars);
    }

    /// <include file='ISlangWriter.xml' path='doc/member[@name="ISlangWriter.write"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int write([NativeTypeName("const char *")] sbyte* chars, [NativeTypeName("size_t")] nuint numChars)
    {
        return Marshal.GetDelegateForFunctionPointer<_write>(lpVtbl->write)((ISlangWriter*)Unsafe.AsPointer(ref this), chars, numChars);
    }

    /// <include file='ISlangWriter.xml' path='doc/member[@name="ISlangWriter.flush"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void flush()
    {
        Marshal.GetDelegateForFunctionPointer<_flush>(lpVtbl->flush)((ISlangWriter*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISlangWriter.xml' path='doc/member[@name="ISlangWriter.isConsole"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangBool")]
    public Boolean isConsole()
    {
        return Marshal.GetDelegateForFunctionPointer<_isConsole>(lpVtbl->isConsole)((ISlangWriter*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISlangWriter.xml' path='doc/member[@name="ISlangWriter.setMode"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int setMode([NativeTypeName("SlangWriterMode")] WriterMode mode)
    {
        return Marshal.GetDelegateForFunctionPointer<_setMode>(lpVtbl->setMode)((ISlangWriter*)Unsafe.AsPointer(ref this), mode);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr release;

        [NativeTypeName("char *(size_t) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr beginAppendBuffer;

        [NativeTypeName("SlangResult (char *, size_t) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr endAppendBuffer;

        [NativeTypeName("SlangResult (const char *, size_t) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr write;

        [NativeTypeName("void () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr flush;

        [NativeTypeName("SlangBool () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr isConsole;

        [NativeTypeName("SlangResult (SlangWriterMode) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr setMode;
    }
}
