using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='IShaderObject.xml' path='doc/member[@name="IShaderObject"]/*' />
[NativeTypeName("struct IShaderObject : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct IShaderObject
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(IShaderObject* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IShaderObject* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IShaderObject* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("slang::TypeLayoutReflection *")]
    public delegate TypeLayoutReflection* _getElementTypeLayout(IShaderObject* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::ShaderObjectContainerType")]
    public delegate ShaderObjectContainerType _getContainerType(IShaderObject* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::GfxCount")]
    public delegate int _getEntryPointCount(IShaderObject* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getEntryPoint(IShaderObject* pThis, [NativeTypeName("gfx::GfxIndex")] int index, IShaderObject** entryPoint);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _setData(IShaderObject* pThis, [NativeTypeName("const ShaderOffset &")] ShaderOffset* offset, [NativeTypeName("const void *")] void* data, [NativeTypeName("gfx::Size")] nuint size);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getObject(IShaderObject* pThis, [NativeTypeName("const ShaderOffset &")] ShaderOffset* offset, IShaderObject** @object);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _setObject(IShaderObject* pThis, [NativeTypeName("const ShaderOffset &")] ShaderOffset* offset, [NativeTypeName("gfx::IShaderObject *")] IShaderObject* @object);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _setResource(IShaderObject* pThis, [NativeTypeName("const ShaderOffset &")] ShaderOffset* offset, [NativeTypeName("gfx::IResourceView *")] IResourceView* resourceView);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _setSampler(IShaderObject* pThis, [NativeTypeName("const ShaderOffset &")] ShaderOffset* offset, [NativeTypeName("gfx::ISamplerState *")] ISamplerState* sampler);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _setCombinedTextureSampler(IShaderObject* pThis, [NativeTypeName("const ShaderOffset &")] ShaderOffset* offset, [NativeTypeName("gfx::IResourceView *")] IResourceView* textureView, [NativeTypeName("gfx::ISamplerState *")] ISamplerState* sampler);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _setSpecializationArgs(IShaderObject* pThis, [NativeTypeName("const ShaderOffset &")] ShaderOffset* offset, [NativeTypeName("const slang::SpecializationArg *")] SpecializationArg* args, [NativeTypeName("gfx::GfxCount")] int count);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getCurrentVersion(IShaderObject* pThis, [NativeTypeName("gfx::ITransientResourceHeap *")] ITransientResourceHeap* transientHeap, IShaderObject** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("const void *")]
    public delegate void* _getRawData(IShaderObject* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Size")]
    public delegate nuint _getSize(IShaderObject* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _setConstantBufferOverride(IShaderObject* pThis, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* constantBuffer);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((IShaderObject*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((IShaderObject*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((IShaderObject*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IShaderObject.xml' path='doc/member[@name="IShaderObject.getElementTypeLayout"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("slang::TypeLayoutReflection *")]
    public TypeLayoutReflection* getElementTypeLayout()
    {
        return Marshal.GetDelegateForFunctionPointer<_getElementTypeLayout>(lpVtbl->getElementTypeLayout)((IShaderObject*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IShaderObject.xml' path='doc/member[@name="IShaderObject.getContainerType"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::ShaderObjectContainerType")]
    public ShaderObjectContainerType getContainerType()
    {
        return Marshal.GetDelegateForFunctionPointer<_getContainerType>(lpVtbl->getContainerType)((IShaderObject*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IShaderObject.xml' path='doc/member[@name="IShaderObject.getEntryPointCount"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::GfxCount")]
    public int getEntryPointCount()
    {
        return Marshal.GetDelegateForFunctionPointer<_getEntryPointCount>(lpVtbl->getEntryPointCount)((IShaderObject*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IShaderObject.xml' path='doc/member[@name="IShaderObject.getEntryPoint"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getEntryPoint([NativeTypeName("gfx::GfxIndex")] int index, IShaderObject** entryPoint)
    {
        return Marshal.GetDelegateForFunctionPointer<_getEntryPoint>(lpVtbl->getEntryPoint)((IShaderObject*)Unsafe.AsPointer(ref this), index, entryPoint);
    }

    /// <include file='IShaderObject.xml' path='doc/member[@name="IShaderObject.setData"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int setData([NativeTypeName("const ShaderOffset &")] ShaderOffset* offset, [NativeTypeName("const void *")] void* data, [NativeTypeName("gfx::Size")] nuint size)
    {
        return Marshal.GetDelegateForFunctionPointer<_setData>(lpVtbl->setData)((IShaderObject*)Unsafe.AsPointer(ref this), offset, data, size);
    }

    /// <include file='IShaderObject.xml' path='doc/member[@name="IShaderObject.getObject"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getObject([NativeTypeName("const ShaderOffset &")] ShaderOffset* offset, IShaderObject** @object)
    {
        return Marshal.GetDelegateForFunctionPointer<_getObject>(lpVtbl->getObject)((IShaderObject*)Unsafe.AsPointer(ref this), offset, @object);
    }

    /// <include file='IShaderObject.xml' path='doc/member[@name="IShaderObject.setObject"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int setObject([NativeTypeName("const ShaderOffset &")] ShaderOffset* offset, [NativeTypeName("gfx::IShaderObject *")] IShaderObject* @object)
    {
        return Marshal.GetDelegateForFunctionPointer<_setObject>(lpVtbl->setObject)((IShaderObject*)Unsafe.AsPointer(ref this), offset, @object);
    }

    /// <include file='IShaderObject.xml' path='doc/member[@name="IShaderObject.setResource"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int setResource([NativeTypeName("const ShaderOffset &")] ShaderOffset* offset, [NativeTypeName("gfx::IResourceView *")] IResourceView* resourceView)
    {
        return Marshal.GetDelegateForFunctionPointer<_setResource>(lpVtbl->setResource)((IShaderObject*)Unsafe.AsPointer(ref this), offset, resourceView);
    }

    /// <include file='IShaderObject.xml' path='doc/member[@name="IShaderObject.setSampler"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int setSampler([NativeTypeName("const ShaderOffset &")] ShaderOffset* offset, [NativeTypeName("gfx::ISamplerState *")] ISamplerState* sampler)
    {
        return Marshal.GetDelegateForFunctionPointer<_setSampler>(lpVtbl->setSampler)((IShaderObject*)Unsafe.AsPointer(ref this), offset, sampler);
    }

    /// <include file='IShaderObject.xml' path='doc/member[@name="IShaderObject.setCombinedTextureSampler"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int setCombinedTextureSampler([NativeTypeName("const ShaderOffset &")] ShaderOffset* offset, [NativeTypeName("gfx::IResourceView *")] IResourceView* textureView, [NativeTypeName("gfx::ISamplerState *")] ISamplerState* sampler)
    {
        return Marshal.GetDelegateForFunctionPointer<_setCombinedTextureSampler>(lpVtbl->setCombinedTextureSampler)((IShaderObject*)Unsafe.AsPointer(ref this), offset, textureView, sampler);
    }

    /// <include file='IShaderObject.xml' path='doc/member[@name="IShaderObject.setSpecializationArgs"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int setSpecializationArgs([NativeTypeName("const ShaderOffset &")] ShaderOffset* offset, [NativeTypeName("const slang::SpecializationArg *")] SpecializationArg* args, [NativeTypeName("gfx::GfxCount")] int count)
    {
        return Marshal.GetDelegateForFunctionPointer<_setSpecializationArgs>(lpVtbl->setSpecializationArgs)((IShaderObject*)Unsafe.AsPointer(ref this), offset, args, count);
    }

    /// <include file='IShaderObject.xml' path='doc/member[@name="IShaderObject.getCurrentVersion"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getCurrentVersion([NativeTypeName("gfx::ITransientResourceHeap *")] ITransientResourceHeap* transientHeap, IShaderObject** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_getCurrentVersion>(lpVtbl->getCurrentVersion)((IShaderObject*)Unsafe.AsPointer(ref this), transientHeap, outObject);
    }

    /// <include file='IShaderObject.xml' path='doc/member[@name="IShaderObject.getRawData"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("const void *")]
    public void* getRawData()
    {
        return Marshal.GetDelegateForFunctionPointer<_getRawData>(lpVtbl->getRawData)((IShaderObject*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IShaderObject.xml' path='doc/member[@name="IShaderObject.getSize"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Size")]
    public nuint getSize()
    {
        return Marshal.GetDelegateForFunctionPointer<_getSize>(lpVtbl->getSize)((IShaderObject*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IShaderObject.xml' path='doc/member[@name="IShaderObject.setConstantBufferOverride"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int setConstantBufferOverride([NativeTypeName("gfx::IBufferResource *")] IBufferResource* constantBuffer)
    {
        return Marshal.GetDelegateForFunctionPointer<_setConstantBufferOverride>(lpVtbl->setConstantBufferOverride)((IShaderObject*)Unsafe.AsPointer(ref this), constantBuffer);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((stdcall))")]
        public IntPtr release;

        [NativeTypeName("slang::TypeLayoutReflection *() __attribute__((stdcall))")]
        public IntPtr getElementTypeLayout;

        [NativeTypeName("ShaderObjectContainerType () __attribute__((stdcall))")]
        public IntPtr getContainerType;

        [NativeTypeName("GfxCount () __attribute__((stdcall))")]
        public IntPtr getEntryPointCount;

        [NativeTypeName("Result (GfxIndex, IShaderObject **) __attribute__((stdcall))")]
        public IntPtr getEntryPoint;

        [NativeTypeName("Result (const ShaderOffset &, const void *, Size) __attribute__((stdcall))")]
        public IntPtr setData;

        [NativeTypeName("Result (const ShaderOffset &, IShaderObject **) __attribute__((stdcall))")]
        public IntPtr getObject;

        [NativeTypeName("Result (const ShaderOffset &, IShaderObject *) __attribute__((stdcall))")]
        public IntPtr setObject;

        [NativeTypeName("Result (const ShaderOffset &, IResourceView *) __attribute__((stdcall))")]
        public IntPtr setResource;

        [NativeTypeName("Result (const ShaderOffset &, ISamplerState *) __attribute__((stdcall))")]
        public IntPtr setSampler;

        [NativeTypeName("Result (const ShaderOffset &, IResourceView *, ISamplerState *) __attribute__((stdcall))")]
        public IntPtr setCombinedTextureSampler;

        [NativeTypeName("Result (const ShaderOffset &, const slang::SpecializationArg *, GfxCount) __attribute__((stdcall))")]
        public IntPtr setSpecializationArgs;

        [NativeTypeName("Result (ITransientResourceHeap *, IShaderObject **) __attribute__((stdcall))")]
        public IntPtr getCurrentVersion;

        [NativeTypeName("const void *() __attribute__((stdcall))")]
        public IntPtr getRawData;

        [NativeTypeName("Size () __attribute__((stdcall))")]
        public IntPtr getSize;

        [NativeTypeName("Result (IBufferResource *) __attribute__((stdcall))")]
        public IntPtr setConstantBufferOverride;
    }
}
