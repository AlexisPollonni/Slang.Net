using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='IInputLayout.xml' path='doc/member[@name="IInputLayout"]/*' />
[NativeTypeName("struct IInputLayout : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct IInputLayout
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(IInputLayout* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IInputLayout* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IInputLayout* pThis);

    /// <include file='InputLayoutDesc.xml' path='doc/member[@name="InputLayoutDesc"]/*' />
    public unsafe partial struct InputLayoutDesc
    {
        /// <include file='InputLayoutDesc.xml' path='doc/member[@name="InputLayoutDesc.inputElements"]/*' />
        [NativeTypeName("const InputElementDesc *")]
        public InputElementDesc* inputElements;

        /// <include file='InputLayoutDesc.xml' path='doc/member[@name="InputLayoutDesc.inputElementCount"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int inputElementCount;

        /// <include file='InputLayoutDesc.xml' path='doc/member[@name="InputLayoutDesc.vertexStreams"]/*' />
        [NativeTypeName("const VertexStreamDesc *")]
        public VertexStreamDesc* vertexStreams;

        /// <include file='InputLayoutDesc.xml' path='doc/member[@name="InputLayoutDesc.vertexStreamCount"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int vertexStreamCount;
    }

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((IInputLayout*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((IInputLayout*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((IInputLayout*)Unsafe.AsPointer(ref this));
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
