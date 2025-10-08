using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='IShaderProgram.xml' path='doc/member[@name="IShaderProgram"]/*' />
[NativeTypeName("struct IShaderProgram : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct IShaderProgram
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(IShaderProgram* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IShaderProgram* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IShaderProgram* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("slang::TypeReflection *")]
    public delegate TypeReflection* _findTypeByName(IShaderProgram* pThis, [NativeTypeName("const char *")] sbyte* name);

    /// <include file='LinkingStyle.xml' path='doc/member[@name="LinkingStyle"]/*' />
    public enum LinkingStyle
    {
        /// <include file='LinkingStyle.xml' path='doc/member[@name="LinkingStyle.SingleProgram"]/*' />
        SingleProgram,

        /// <include file='LinkingStyle.xml' path='doc/member[@name="LinkingStyle.SeparateEntryPointCompilation"]/*' />
        SeparateEntryPointCompilation,
    }

    /// <include file='DownstreamLinkMode.xml' path='doc/member[@name="DownstreamLinkMode"]/*' />
    public enum DownstreamLinkMode
    {
        /// <include file='DownstreamLinkMode.xml' path='doc/member[@name="DownstreamLinkMode.None"]/*' />
        None,

        /// <include file='DownstreamLinkMode.xml' path='doc/member[@name="DownstreamLinkMode.Deferred"]/*' />
        Deferred,
    }

    /// <include file='ShaderProgramDesc.xml' path='doc/member[@name="ShaderProgramDesc"]/*' />
    public unsafe partial struct ShaderProgramDesc
    {
        /// <include file='ShaderProgramDesc.xml' path='doc/member[@name="ShaderProgramDesc.linkingStyle"]/*' />
        [NativeTypeName("gfx::IShaderProgram::LinkingStyle")]
        public LinkingStyle linkingStyle;

        /// <include file='ShaderProgramDesc.xml' path='doc/member[@name="ShaderProgramDesc.slangGlobalScope"]/*' />
        [NativeTypeName("slang::IComponentType *")]
        public IComponentType* slangGlobalScope;

        /// <include file='ShaderProgramDesc.xml' path='doc/member[@name="ShaderProgramDesc.entryPointCount"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int entryPointCount;

        /// <include file='ShaderProgramDesc.xml' path='doc/member[@name="ShaderProgramDesc.slangEntryPoints"]/*' />
        [NativeTypeName("slang::IComponentType **")]
        public IComponentType** slangEntryPoints;

        /// <include file='ShaderProgramDesc.xml' path='doc/member[@name="ShaderProgramDesc.downstreamLinkMode"]/*' />
        [NativeTypeName("gfx::IShaderProgram::DownstreamLinkMode")]
        public DownstreamLinkMode downstreamLinkMode;
    }

    /// <include file='CreateDesc2.xml' path='doc/member[@name="CreateDesc2"]/*' />
    public unsafe partial struct CreateDesc2
    {
        /// <include file='CreateDesc2.xml' path='doc/member[@name="CreateDesc2.sourceType"]/*' />
        [NativeTypeName("gfx::ShaderModuleSourceType")]
        public ShaderModuleSourceType sourceType;

        /// <include file='CreateDesc2.xml' path='doc/member[@name="CreateDesc2.sourceData"]/*' />
        public void* sourceData;

        /// <include file='CreateDesc2.xml' path='doc/member[@name="CreateDesc2.sourceDataSize"]/*' />
        [NativeTypeName("gfx::Size")]
        public nuint sourceDataSize;

        /// <include file='CreateDesc2.xml' path='doc/member[@name="CreateDesc2.entryPointCount"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int entryPointCount;

        /// <include file='CreateDesc2.xml' path='doc/member[@name="CreateDesc2.entryPointNames"]/*' />
        [NativeTypeName("const char **")]
        public sbyte** entryPointNames;
    }

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((IShaderProgram*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((IShaderProgram*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((IShaderProgram*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IShaderProgram.xml' path='doc/member[@name="IShaderProgram.findTypeByName"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("slang::TypeReflection *")]
    public TypeReflection* findTypeByName([NativeTypeName("const char *")] sbyte* name)
    {
        return Marshal.GetDelegateForFunctionPointer<_findTypeByName>(lpVtbl->findTypeByName)((IShaderProgram*)Unsafe.AsPointer(ref this), name);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr release;

        [NativeTypeName("slang::TypeReflection *(const char *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr findTypeByName;
    }
}
