using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='ITransientResourceHeapD3D12.xml' path='doc/member[@name="ITransientResourceHeapD3D12"]/*' />
[NativeTypeName("struct ITransientResourceHeapD3D12 : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct ITransientResourceHeapD3D12
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(ITransientResourceHeapD3D12* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(ITransientResourceHeapD3D12* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(ITransientResourceHeapD3D12* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _allocateTransientDescriptorTable(ITransientResourceHeapD3D12* pThis, [NativeTypeName("gfx::ITransientResourceHeapD3D12::DescriptorType")] DescriptorType type, [NativeTypeName("gfx::GfxCount")] int count, [NativeTypeName("gfx::Offset &")] nuint* outDescriptorOffset, void** outD3DDescriptorHeapHandle);

    /// <include file='DescriptorType.xml' path='doc/member[@name="DescriptorType"]/*' />
    public enum DescriptorType
    {
        /// <include file='DescriptorType.xml' path='doc/member[@name="DescriptorType.ResourceView"]/*' />
        ResourceView,

        /// <include file='DescriptorType.xml' path='doc/member[@name="DescriptorType.Sampler"]/*' />
        Sampler,
    }

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((ITransientResourceHeapD3D12*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((ITransientResourceHeapD3D12*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((ITransientResourceHeapD3D12*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ITransientResourceHeapD3D12.xml' path='doc/member[@name="ITransientResourceHeapD3D12.allocateTransientDescriptorTable"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int allocateTransientDescriptorTable([NativeTypeName("gfx::ITransientResourceHeapD3D12::DescriptorType")] DescriptorType type, [NativeTypeName("gfx::GfxCount")] int count, [NativeTypeName("gfx::Offset &")] nuint* outDescriptorOffset, void** outD3DDescriptorHeapHandle)
    {
        return Marshal.GetDelegateForFunctionPointer<_allocateTransientDescriptorTable>(lpVtbl->allocateTransientDescriptorTable)((ITransientResourceHeapD3D12*)Unsafe.AsPointer(ref this), type, count, outDescriptorOffset, outD3DDescriptorHeapHandle);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr release;

        [NativeTypeName("Result (DescriptorType, GfxCount, Offset &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr allocateTransientDescriptorTable;
    }
}
