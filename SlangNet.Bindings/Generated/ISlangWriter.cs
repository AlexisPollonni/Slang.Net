using System.Runtime.CompilerServices;

namespace SlangNet.Bindings.Generated;

/// <include file='ISlangWriter.xml' path='doc/member[@name="ISlangWriter"]/*' />
[NativeTypeName("struct ISlangWriter : ISlangUnknown")]
public unsafe partial struct ISlangWriter
{
    public Vtbl* lpVtbl;

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return lpVtbl->queryInterface((ISlangWriter*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return lpVtbl->addRef((ISlangWriter*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return lpVtbl->release((ISlangWriter*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISlangWriter.xml' path='doc/member[@name="ISlangWriter.beginAppendBuffer"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("char *")]
    public sbyte* beginAppendBuffer([NativeTypeName("size_t")] nuint maxNumChars)
    {
        return lpVtbl->beginAppendBuffer((ISlangWriter*)Unsafe.AsPointer(ref this), maxNumChars);
    }

    /// <include file='ISlangWriter.xml' path='doc/member[@name="ISlangWriter.endAppendBuffer"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int endAppendBuffer([NativeTypeName("char *")] sbyte* buffer, [NativeTypeName("size_t")] nuint numChars)
    {
        return lpVtbl->endAppendBuffer((ISlangWriter*)Unsafe.AsPointer(ref this), buffer, numChars);
    }

    /// <include file='ISlangWriter.xml' path='doc/member[@name="ISlangWriter.write"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int write([NativeTypeName("const char *")] sbyte* chars, [NativeTypeName("size_t")] nuint numChars)
    {
        return lpVtbl->write((ISlangWriter*)Unsafe.AsPointer(ref this), chars, numChars);
    }

    /// <include file='ISlangWriter.xml' path='doc/member[@name="ISlangWriter.flush"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void flush()
    {
        lpVtbl->flush((ISlangWriter*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISlangWriter.xml' path='doc/member[@name="ISlangWriter.isConsole"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangBool")]
    public bool isConsole()
    {
        return lpVtbl->isConsole((ISlangWriter*)Unsafe.AsPointer(ref this)) != 0;
    }

    /// <include file='ISlangWriter.xml' path='doc/member[@name="ISlangWriter.setMode"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int setMode(SlangWriterMode mode)
    {
        return lpVtbl->setMode((ISlangWriter*)Unsafe.AsPointer(ref this), mode);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangWriter*, SlangUUID*, void**, int> queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangWriter*, uint> addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangWriter*, uint> release;

        [NativeTypeName("char *(size_t) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangWriter*, nuint, sbyte*> beginAppendBuffer;

        [NativeTypeName("SlangResult (char *, size_t) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangWriter*, sbyte*, nuint, int> endAppendBuffer;

        [NativeTypeName("SlangResult (const char *, size_t) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangWriter*, sbyte*, nuint, int> write;

        [NativeTypeName("void () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangWriter*, void> flush;

        [NativeTypeName("SlangBool () __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangWriter*, byte> isConsole;

        [NativeTypeName("SlangResult (SlangWriterMode) __attribute__((nothrow)) __attribute__((stdcall))")]
        public delegate* unmanaged[Stdcall]<ISlangWriter*, SlangWriterMode, int> setMode;
    }
}
