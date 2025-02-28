using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='ISamplerState.xml' path='doc/member[@name="ISamplerState"]/*' />
[NativeTypeName("struct ISamplerState : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct ISamplerState
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(ISamplerState* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(ISamplerState* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(ISamplerState* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getNativeHandle(ISamplerState* pThis, [NativeTypeName("gfx::InteropHandle *")] InteropHandle* outNativeHandle);

    /// <include file='SamplerStateDesc.xml' path='doc/member[@name="SamplerStateDesc"]/*' />
    public partial struct SamplerStateDesc
    {
        /// <include file='SamplerStateDesc.xml' path='doc/member[@name="SamplerStateDesc.minFilter"]/*' />
        [NativeTypeName("gfx::TextureFilteringMode")]
        public TextureFilteringMode minFilter;

        /// <include file='SamplerStateDesc.xml' path='doc/member[@name="SamplerStateDesc.magFilter"]/*' />
        [NativeTypeName("gfx::TextureFilteringMode")]
        public TextureFilteringMode magFilter;

        /// <include file='SamplerStateDesc.xml' path='doc/member[@name="SamplerStateDesc.mipFilter"]/*' />
        [NativeTypeName("gfx::TextureFilteringMode")]
        public TextureFilteringMode mipFilter;

        /// <include file='SamplerStateDesc.xml' path='doc/member[@name="SamplerStateDesc.reductionOp"]/*' />
        [NativeTypeName("gfx::TextureReductionOp")]
        public TextureReductionOp reductionOp;

        /// <include file='SamplerStateDesc.xml' path='doc/member[@name="SamplerStateDesc.addressU"]/*' />
        [NativeTypeName("gfx::TextureAddressingMode")]
        public TextureAddressingMode addressU;

        /// <include file='SamplerStateDesc.xml' path='doc/member[@name="SamplerStateDesc.addressV"]/*' />
        [NativeTypeName("gfx::TextureAddressingMode")]
        public TextureAddressingMode addressV;

        /// <include file='SamplerStateDesc.xml' path='doc/member[@name="SamplerStateDesc.addressW"]/*' />
        [NativeTypeName("gfx::TextureAddressingMode")]
        public TextureAddressingMode addressW;

        /// <include file='SamplerStateDesc.xml' path='doc/member[@name="SamplerStateDesc.mipLODBias"]/*' />
        public float mipLODBias;

        /// <include file='SamplerStateDesc.xml' path='doc/member[@name="SamplerStateDesc.maxAnisotropy"]/*' />
        [NativeTypeName("uint32_t")]
        public uint maxAnisotropy;

        /// <include file='SamplerStateDesc.xml' path='doc/member[@name="SamplerStateDesc.comparisonFunc"]/*' />
        [NativeTypeName("gfx::ComparisonFunc")]
        public ComparisonFunc comparisonFunc;

        /// <include file='SamplerStateDesc.xml' path='doc/member[@name="SamplerStateDesc.borderColor"]/*' />
        [NativeTypeName("float[4]")]
        public _borderColor_e__FixedBuffer borderColor;

        /// <include file='SamplerStateDesc.xml' path='doc/member[@name="SamplerStateDesc.minLOD"]/*' />
        public float minLOD;

        /// <include file='SamplerStateDesc.xml' path='doc/member[@name="SamplerStateDesc.maxLOD"]/*' />
        public float maxLOD;

        /// <include file='_borderColor_e__FixedBuffer.xml' path='doc/member[@name="_borderColor_e__FixedBuffer"]/*' />
        [InlineArray(4)]
        public partial struct _borderColor_e__FixedBuffer
        {
            public float e0;
        }
    }

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((ISamplerState*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((ISamplerState*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((ISamplerState*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ISamplerState.xml' path='doc/member[@name="ISamplerState.getNativeHandle"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getNativeHandle([NativeTypeName("gfx::InteropHandle *")] InteropHandle* outNativeHandle)
    {
        return Marshal.GetDelegateForFunctionPointer<_getNativeHandle>(lpVtbl->getNativeHandle)((ISamplerState*)Unsafe.AsPointer(ref this), outNativeHandle);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr release;

        [NativeTypeName("Result (InteropHandle *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getNativeHandle;
    }
}
