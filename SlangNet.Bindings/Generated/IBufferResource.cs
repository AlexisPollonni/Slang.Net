using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='IBufferResource.xml' path='doc/member[@name="IBufferResource"]/*' />
[NativeTypeName("struct IBufferResource : gfx::IResource")]
[NativeInheritance("IResource")]
public unsafe partial struct IBufferResource
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(IBufferResource* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IBufferResource* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IBufferResource* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::IResource::Type")]
    public delegate Type _getType(IBufferResource* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getNativeResourceHandle(IBufferResource* pThis, [NativeTypeName("gfx::InteropHandle *")] InteropHandle* outHandle);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getSharedHandle(IBufferResource* pThis, [NativeTypeName("gfx::InteropHandle *")] InteropHandle* outHandle);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _setDebugName(IBufferResource* pThis, [NativeTypeName("const char *")] sbyte* name);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("const char *")]
    public delegate sbyte* _getDebugName(IBufferResource* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::IBufferResource::Desc *")]
    public delegate BufferResourceDesc* _getDesc(IBufferResource* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::DeviceAddress")]
    public delegate nuint _getDeviceAddress(IBufferResource* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _map(IBufferResource* pThis, [NativeTypeName("gfx::MemoryRange *")] MemoryRange* rangeToRead, void** outPointer);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _unmap(IBufferResource* pThis, [NativeTypeName("gfx::MemoryRange *")] MemoryRange* writtenRange);

    /// <include file='BufferResourceDesc.xml' path='doc/member[@name="BufferResourceDesc"]/*' />
    [NativeTypeName("struct Desc : gfx::IResource::DescBase")]
    [NativeInheritance("DescBase")]
    public partial struct BufferResourceDesc
    {
        public DescBase Base;

        /// <include file='BufferResourceDesc.xml' path='doc/member[@name="BufferResourceDesc.sizeInBytes"]/*' />
        [NativeTypeName("gfx::Size")]
        public nuint sizeInBytes;

        /// <include file='BufferResourceDesc.xml' path='doc/member[@name="BufferResourceDesc.elementSize"]/*' />
        [NativeTypeName("gfx::Size")]
        public nuint elementSize;

        /// <include file='BufferResourceDesc.xml' path='doc/member[@name="BufferResourceDesc.format"]/*' />
        [NativeTypeName("gfx::Format")]
        public Format format;
    }

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((IBufferResource*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((IBufferResource*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((IBufferResource*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="IResource.getType" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::IResource::Type")]
    public Type getType()
    {
        return Marshal.GetDelegateForFunctionPointer<_getType>(lpVtbl->getType)((IBufferResource*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="IResource.getNativeResourceHandle" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getNativeResourceHandle([NativeTypeName("gfx::InteropHandle *")] InteropHandle* outHandle)
    {
        return Marshal.GetDelegateForFunctionPointer<_getNativeResourceHandle>(lpVtbl->getNativeResourceHandle)((IBufferResource*)Unsafe.AsPointer(ref this), outHandle);
    }

    /// <inheritdoc cref="IResource.getSharedHandle" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getSharedHandle([NativeTypeName("gfx::InteropHandle *")] InteropHandle* outHandle)
    {
        return Marshal.GetDelegateForFunctionPointer<_getSharedHandle>(lpVtbl->getSharedHandle)((IBufferResource*)Unsafe.AsPointer(ref this), outHandle);
    }

    /// <inheritdoc cref="IResource.setDebugName" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int setDebugName([NativeTypeName("const char *")] sbyte* name)
    {
        return Marshal.GetDelegateForFunctionPointer<_setDebugName>(lpVtbl->setDebugName)((IBufferResource*)Unsafe.AsPointer(ref this), name);
    }

    /// <inheritdoc cref="IResource.getDebugName" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("const char *")]
    public sbyte* getDebugName()
    {
        return Marshal.GetDelegateForFunctionPointer<_getDebugName>(lpVtbl->getDebugName)((IBufferResource*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IBufferResource.xml' path='doc/member[@name="IBufferResource.getDesc"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::IBufferResource::Desc *")]
    public BufferResourceDesc* getDesc()
    {
        return Marshal.GetDelegateForFunctionPointer<_getDesc>(lpVtbl->getDesc)((IBufferResource*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IBufferResource.xml' path='doc/member[@name="IBufferResource.getDeviceAddress"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::DeviceAddress")]
    public nuint getDeviceAddress()
    {
        return Marshal.GetDelegateForFunctionPointer<_getDeviceAddress>(lpVtbl->getDeviceAddress)((IBufferResource*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IBufferResource.xml' path='doc/member[@name="IBufferResource.map"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int map([NativeTypeName("gfx::MemoryRange *")] MemoryRange* rangeToRead, void** outPointer)
    {
        return Marshal.GetDelegateForFunctionPointer<_map>(lpVtbl->map)((IBufferResource*)Unsafe.AsPointer(ref this), rangeToRead, outPointer);
    }

    /// <include file='IBufferResource.xml' path='doc/member[@name="IBufferResource.unmap"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int unmap([NativeTypeName("gfx::MemoryRange *")] MemoryRange* writtenRange)
    {
        return Marshal.GetDelegateForFunctionPointer<_unmap>(lpVtbl->unmap)((IBufferResource*)Unsafe.AsPointer(ref this), writtenRange);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **)")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t ()")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t ()")]
        public IntPtr release;

        [NativeTypeName("Type ()")]
        public IntPtr getType;

        [NativeTypeName("Result (InteropHandle *)")]
        public IntPtr getNativeResourceHandle;

        [NativeTypeName("Result (InteropHandle *)")]
        public IntPtr getSharedHandle;

        [NativeTypeName("Result (const char *)")]
        public IntPtr setDebugName;

        [NativeTypeName("const char *()")]
        public IntPtr getDebugName;

        [NativeTypeName("Desc *()")]
        public IntPtr getDesc;

        [NativeTypeName("DeviceAddress ()")]
        public IntPtr getDeviceAddress;

        [NativeTypeName("Result (MemoryRange *, void **)")]
        public IntPtr map;

        [NativeTypeName("Result (MemoryRange *)")]
        public IntPtr unmap;
    }
}
