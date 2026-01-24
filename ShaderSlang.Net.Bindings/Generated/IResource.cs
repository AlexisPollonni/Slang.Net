using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='IResource.xml' path='doc/member[@name="IResource"]/*' />
[NativeTypeName("struct IResource : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct IResource
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(
        IResource* pThis,
        [NativeTypeName("const SlangUUID &")] SlangUUID* uuid,
        void** outObject
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IResource* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IResource* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::IResource::Type")]
    public delegate ResourceType _getType(IResource* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getNativeResourceHandle(
        IResource* pThis,
        [NativeTypeName("gfx::InteropHandle *")] InteropHandle* outHandle
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getSharedHandle(
        IResource* pThis,
        [NativeTypeName("gfx::InteropHandle *")] InteropHandle* outHandle
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _setDebugName(
        IResource* pThis,
        [NativeTypeName("const char *")] sbyte* name
    );

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("const char *")]
    public delegate sbyte* _getDebugName(IResource* pThis);

    /// <include file='ResourceType.xml' path='doc/member[@name="ResourceType"]/*' />
    public enum ResourceType
    {
        /// <include file='ResourceType.xml' path='doc/member[@name="ResourceType.Unknown"]/*' />
        Unknown,

        /// <include file='ResourceType.xml' path='doc/member[@name="ResourceType.Buffer"]/*' />
        Buffer,

        /// <include file='ResourceType.xml' path='doc/member[@name="ResourceType.Texture1D"]/*' />
        Texture1D,

        /// <include file='ResourceType.xml' path='doc/member[@name="ResourceType.Texture2D"]/*' />
        Texture2D,

        /// <include file='ResourceType.xml' path='doc/member[@name="ResourceType.Texture3D"]/*' />
        Texture3D,

        /// <include file='ResourceType.xml' path='doc/member[@name="ResourceType.TextureCube"]/*' />
        TextureCube,

        /// <include file='ResourceType.xml' path='doc/member[@name="ResourceType._Count"]/*' />
        _Count,
    }

    /// <include file='DescBase.xml' path='doc/member[@name="DescBase"]/*' />
    public partial struct DescBase
    {
        /// <include file='DescBase.xml' path='doc/member[@name="DescBase.type"]/*' />
        [NativeTypeName("gfx::IResource::Type")]
        public ResourceType type;

        /// <include file='DescBase.xml' path='doc/member[@name="DescBase.defaultState"]/*' />
        [NativeTypeName("gfx::ResourceState")]
        public ResourceState defaultState;

        /// <include file='DescBase.xml' path='doc/member[@name="DescBase.allowedStates"]/*' />
        [NativeTypeName("gfx::ResourceStateSet")]
        public ulong allowedStates;

        /// <include file='DescBase.xml' path='doc/member[@name="DescBase.memoryType"]/*' />
        [NativeTypeName("gfx::MemoryType")]
        public MemoryType memoryType;

        /// <include file='DescBase.xml' path='doc/member[@name="DescBase.existingHandle"]/*' />
        [NativeTypeName("gfx::InteropHandle")]
        public InteropHandle existingHandle;

        /// <include file='DescBase.xml' path='doc/member[@name="DescBase.isShared"]/*' />
        [NativeTypeName("bool")]
        public Boolean isShared;
    }

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface(
        [NativeTypeName("const SlangUUID &")] SlangUUID* uuid,
        void** outObject
    )
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)(
            (IResource*)Unsafe.AsPointer(ref this),
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
            (IResource*)Unsafe.AsPointer(ref this)
        );
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)(
            (IResource*)Unsafe.AsPointer(ref this)
        );
    }

    /// <include file='IResource.xml' path='doc/member[@name="IResource.getType"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::IResource::Type")]
    public ResourceType getType()
    {
        return Marshal.GetDelegateForFunctionPointer<_getType>(lpVtbl->getType)(
            (IResource*)Unsafe.AsPointer(ref this)
        );
    }

    /// <include file='IResource.xml' path='doc/member[@name="IResource.getNativeResourceHandle"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getNativeResourceHandle(
        [NativeTypeName("gfx::InteropHandle *")] InteropHandle* outHandle
    )
    {
        return Marshal.GetDelegateForFunctionPointer<_getNativeResourceHandle>(
            lpVtbl->getNativeResourceHandle
        )((IResource*)Unsafe.AsPointer(ref this), outHandle);
    }

    /// <include file='IResource.xml' path='doc/member[@name="IResource.getSharedHandle"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getSharedHandle([NativeTypeName("gfx::InteropHandle *")] InteropHandle* outHandle)
    {
        return Marshal.GetDelegateForFunctionPointer<_getSharedHandle>(lpVtbl->getSharedHandle)(
            (IResource*)Unsafe.AsPointer(ref this),
            outHandle
        );
    }

    /// <include file='IResource.xml' path='doc/member[@name="IResource.setDebugName"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int setDebugName([NativeTypeName("const char *")] sbyte* name)
    {
        return Marshal.GetDelegateForFunctionPointer<_setDebugName>(lpVtbl->setDebugName)(
            (IResource*)Unsafe.AsPointer(ref this),
            name
        );
    }

    /// <include file='IResource.xml' path='doc/member[@name="IResource.getDebugName"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("const char *")]
    public sbyte* getDebugName()
    {
        return Marshal.GetDelegateForFunctionPointer<_getDebugName>(lpVtbl->getDebugName)(
            (IResource*)Unsafe.AsPointer(ref this)
        );
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

        [NativeTypeName("Type () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getType;

        [NativeTypeName(
            "Result (InteropHandle *) __attribute__((nothrow)) __attribute__((stdcall))"
        )]
        public IntPtr getNativeResourceHandle;

        [NativeTypeName(
            "Result (InteropHandle *) __attribute__((nothrow)) __attribute__((stdcall))"
        )]
        public IntPtr getSharedHandle;

        [NativeTypeName("Result (const char *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr setDebugName;

        [NativeTypeName("const char *() __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getDebugName;
    }
}
