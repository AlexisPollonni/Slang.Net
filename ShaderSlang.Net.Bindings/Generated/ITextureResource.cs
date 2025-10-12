using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='ITextureResource.xml' path='doc/member[@name="ITextureResource"]/*' />
[NativeTypeName("struct ITextureResource : gfx::IResource")]
[NativeInheritance("IResource")]
public unsafe partial struct ITextureResource
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(ITextureResource* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(ITextureResource* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(ITextureResource* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::IResource::Type")]
    public delegate ResourceType _getType(ITextureResource* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getNativeResourceHandle(ITextureResource* pThis, [NativeTypeName("gfx::InteropHandle *")] InteropHandle* outHandle);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getSharedHandle(ITextureResource* pThis, [NativeTypeName("gfx::InteropHandle *")] InteropHandle* outHandle);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _setDebugName(ITextureResource* pThis, [NativeTypeName("const char *")] sbyte* name);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("const char *")]
    public delegate sbyte* _getDebugName(ITextureResource* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::ITextureResource::Desc *")]
    public delegate TextureResourceDesc* _getDesc(ITextureResource* pThis);

    /// <include file='Offset3D.xml' path='doc/member[@name="Offset3D"]/*' />
    public partial struct Offset3D
    {
        /// <include file='Offset3D.xml' path='doc/member[@name="Offset3D.x"]/*' />
        [NativeTypeName("gfx::GfxIndex")]
        public int x;

        /// <include file='Offset3D.xml' path='doc/member[@name="Offset3D.y"]/*' />
        [NativeTypeName("gfx::GfxIndex")]
        public int y;

        /// <include file='Offset3D.xml' path='doc/member[@name="Offset3D.z"]/*' />
        [NativeTypeName("gfx::GfxIndex")]
        public int z;
    }

    /// <include file='SampleDesc.xml' path='doc/member[@name="SampleDesc"]/*' />
    public partial struct SampleDesc
    {
        /// <include file='SampleDesc.xml' path='doc/member[@name="SampleDesc.numSamples"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int numSamples;

        /// <include file='SampleDesc.xml' path='doc/member[@name="SampleDesc.quality"]/*' />
        public int quality;
    }

    /// <include file='Extents.xml' path='doc/member[@name="Extents"]/*' />
    public partial struct Extents
    {
        /// <include file='Extents.xml' path='doc/member[@name="Extents.width"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int width;

        /// <include file='Extents.xml' path='doc/member[@name="Extents.height"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int height;

        /// <include file='Extents.xml' path='doc/member[@name="Extents.depth"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int depth;
    }

    /// <include file='TextureResourceDesc.xml' path='doc/member[@name="TextureResourceDesc"]/*' />
    [NativeTypeName("struct Desc : gfx::IResource::DescBase")]
    [NativeInheritance("DescBase")]
    public unsafe partial struct TextureResourceDesc
    {
        public DescBase Base;

        /// <include file='TextureResourceDesc.xml' path='doc/member[@name="TextureResourceDesc.size"]/*' />
        [NativeTypeName("gfx::ITextureResource::Extents")]
        public Extents size;

        /// <include file='TextureResourceDesc.xml' path='doc/member[@name="TextureResourceDesc.arraySize"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int arraySize;

        /// <include file='TextureResourceDesc.xml' path='doc/member[@name="TextureResourceDesc.numMipLevels"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int numMipLevels;

        /// <include file='TextureResourceDesc.xml' path='doc/member[@name="TextureResourceDesc.format"]/*' />
        [NativeTypeName("gfx::Format")]
        public Format format;

        /// <include file='TextureResourceDesc.xml' path='doc/member[@name="TextureResourceDesc.sampleDesc"]/*' />
        [NativeTypeName("gfx::ITextureResource::SampleDesc")]
        public SampleDesc sampleDesc;

        /// <include file='TextureResourceDesc.xml' path='doc/member[@name="TextureResourceDesc.optimalClearValue"]/*' />
        [NativeTypeName("gfx::ClearValue *")]
        public ClearValue* optimalClearValue;
    }

    /// <include file='SubresourceData.xml' path='doc/member[@name="SubresourceData"]/*' />
    public unsafe partial struct SubresourceData
    {
        /// <include file='SubresourceData.xml' path='doc/member[@name="SubresourceData.data"]/*' />
        [NativeTypeName("const void *")]
        public void* data;

        /// <include file='SubresourceData.xml' path='doc/member[@name="SubresourceData.strideY"]/*' />
        [NativeTypeName("gfx::Size")]
        public nuint strideY;

        /// <include file='SubresourceData.xml' path='doc/member[@name="SubresourceData.strideZ"]/*' />
        [NativeTypeName("gfx::Size")]
        public nuint strideZ;
    }

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((ITextureResource*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((ITextureResource*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((ITextureResource*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="IResource.getType" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::IResource::Type")]
    public ResourceType getType()
    {
        return Marshal.GetDelegateForFunctionPointer<_getType>(lpVtbl->getType)((ITextureResource*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="IResource.getNativeResourceHandle" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getNativeResourceHandle([NativeTypeName("gfx::InteropHandle *")] InteropHandle* outHandle)
    {
        return Marshal.GetDelegateForFunctionPointer<_getNativeResourceHandle>(lpVtbl->getNativeResourceHandle)((ITextureResource*)Unsafe.AsPointer(ref this), outHandle);
    }

    /// <inheritdoc cref="IResource.getSharedHandle" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getSharedHandle([NativeTypeName("gfx::InteropHandle *")] InteropHandle* outHandle)
    {
        return Marshal.GetDelegateForFunctionPointer<_getSharedHandle>(lpVtbl->getSharedHandle)((ITextureResource*)Unsafe.AsPointer(ref this), outHandle);
    }

    /// <inheritdoc cref="IResource.setDebugName" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int setDebugName([NativeTypeName("const char *")] sbyte* name)
    {
        return Marshal.GetDelegateForFunctionPointer<_setDebugName>(lpVtbl->setDebugName)((ITextureResource*)Unsafe.AsPointer(ref this), name);
    }

    /// <inheritdoc cref="IResource.getDebugName" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("const char *")]
    public sbyte* getDebugName()
    {
        return Marshal.GetDelegateForFunctionPointer<_getDebugName>(lpVtbl->getDebugName)((ITextureResource*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ITextureResource.xml' path='doc/member[@name="ITextureResource.getDesc"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::ITextureResource::Desc *")]
    public TextureResourceDesc* getDesc()
    {
        return Marshal.GetDelegateForFunctionPointer<_getDesc>(lpVtbl->getDesc)((ITextureResource*)Unsafe.AsPointer(ref this));
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr release;

        [NativeTypeName("Type () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getType;

        [NativeTypeName("Result (InteropHandle *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getNativeResourceHandle;

        [NativeTypeName("Result (InteropHandle *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getSharedHandle;

        [NativeTypeName("Result (const char *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr setDebugName;

        [NativeTypeName("const char *() __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getDebugName;

        [NativeTypeName("Desc *() __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getDesc;
    }
}
