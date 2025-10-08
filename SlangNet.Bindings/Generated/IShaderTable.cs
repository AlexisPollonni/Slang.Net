using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='IShaderTable.xml' path='doc/member[@name="IShaderTable"]/*' />
[NativeTypeName("struct IShaderTable : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct IShaderTable
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(IShaderTable* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IShaderTable* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IShaderTable* pThis);

    /// <include file='ShaderRecordOverwrite.xml' path='doc/member[@name="ShaderRecordOverwrite"]/*' />
    public partial struct ShaderRecordOverwrite
    {
        /// <include file='ShaderRecordOverwrite.xml' path='doc/member[@name="ShaderRecordOverwrite.offset"]/*' />
        [NativeTypeName("gfx::Offset")]
        public nuint offset;

        /// <include file='ShaderRecordOverwrite.xml' path='doc/member[@name="ShaderRecordOverwrite.size"]/*' />
        [NativeTypeName("gfx::Size")]
        public nuint size;

        /// <include file='ShaderRecordOverwrite.xml' path='doc/member[@name="ShaderRecordOverwrite.data"]/*' />
        [NativeTypeName("uint8_t[8]")]
        public _data_e__FixedBuffer data;

        /// <include file='_data_e__FixedBuffer.xml' path='doc/member[@name="_data_e__FixedBuffer"]/*' />
        [InlineArray(8)]
        public partial struct _data_e__FixedBuffer
        {
            public byte e0;
        }
    }

    /// <include file='ShaderTableDesc.xml' path='doc/member[@name="ShaderTableDesc"]/*' />
    public unsafe partial struct ShaderTableDesc
    {
        /// <include file='ShaderTableDesc.xml' path='doc/member[@name="ShaderTableDesc.rayGenShaderCount"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int rayGenShaderCount;

        /// <include file='ShaderTableDesc.xml' path='doc/member[@name="ShaderTableDesc.rayGenShaderEntryPointNames"]/*' />
        [NativeTypeName("const char **")]
        public sbyte** rayGenShaderEntryPointNames;

        /// <include file='ShaderTableDesc.xml' path='doc/member[@name="ShaderTableDesc.rayGenShaderRecordOverwrites"]/*' />
        [NativeTypeName("const ShaderRecordOverwrite *")]
        public ShaderRecordOverwrite* rayGenShaderRecordOverwrites;

        /// <include file='ShaderTableDesc.xml' path='doc/member[@name="ShaderTableDesc.missShaderCount"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int missShaderCount;

        /// <include file='ShaderTableDesc.xml' path='doc/member[@name="ShaderTableDesc.missShaderEntryPointNames"]/*' />
        [NativeTypeName("const char **")]
        public sbyte** missShaderEntryPointNames;

        /// <include file='ShaderTableDesc.xml' path='doc/member[@name="ShaderTableDesc.missShaderRecordOverwrites"]/*' />
        [NativeTypeName("const ShaderRecordOverwrite *")]
        public ShaderRecordOverwrite* missShaderRecordOverwrites;

        /// <include file='ShaderTableDesc.xml' path='doc/member[@name="ShaderTableDesc.hitGroupCount"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int hitGroupCount;

        /// <include file='ShaderTableDesc.xml' path='doc/member[@name="ShaderTableDesc.hitGroupNames"]/*' />
        [NativeTypeName("const char **")]
        public sbyte** hitGroupNames;

        /// <include file='ShaderTableDesc.xml' path='doc/member[@name="ShaderTableDesc.hitGroupRecordOverwrites"]/*' />
        [NativeTypeName("const ShaderRecordOverwrite *")]
        public ShaderRecordOverwrite* hitGroupRecordOverwrites;

        /// <include file='ShaderTableDesc.xml' path='doc/member[@name="ShaderTableDesc.callableShaderCount"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int callableShaderCount;

        /// <include file='ShaderTableDesc.xml' path='doc/member[@name="ShaderTableDesc.callableShaderEntryPointNames"]/*' />
        [NativeTypeName("const char **")]
        public sbyte** callableShaderEntryPointNames;

        /// <include file='ShaderTableDesc.xml' path='doc/member[@name="ShaderTableDesc.callableShaderRecordOverwrites"]/*' />
        [NativeTypeName("const ShaderRecordOverwrite *")]
        public ShaderRecordOverwrite* callableShaderRecordOverwrites;

        /// <include file='ShaderTableDesc.xml' path='doc/member[@name="ShaderTableDesc.program"]/*' />
        [NativeTypeName("gfx::IShaderProgram *")]
        public IShaderProgram* program;
    }

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((IShaderTable*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((IShaderTable*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((IShaderTable*)Unsafe.AsPointer(ref this));
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr release;
    }
}
