using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='ICommandEncoder.xml' path='doc/member[@name="ICommandEncoder"]/*' />
[Guid("77EA6383-BE3D-40AA-8B45-FDF0D75BFA34")]
[NativeTypeName("struct ICommandEncoder : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct ICommandEncoder
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(ICommandEncoder* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(ICommandEncoder* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(ICommandEncoder* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _endEncoding(ICommandEncoder* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _writeTimestamp(ICommandEncoder* pThis, [NativeTypeName("gfx::IQueryPool *")] IQueryPool* queryPool, [NativeTypeName("gfx::GfxIndex")] int queryIndex);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((ICommandEncoder*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((ICommandEncoder*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((ICommandEncoder*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ICommandEncoder.xml' path='doc/member[@name="ICommandEncoder.endEncoding"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void endEncoding()
    {
        Marshal.GetDelegateForFunctionPointer<_endEncoding>(lpVtbl->endEncoding)((ICommandEncoder*)Unsafe.AsPointer(ref this));
    }

    /// <include file='ICommandEncoder.xml' path='doc/member[@name="ICommandEncoder.writeTimestamp"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void writeTimestamp([NativeTypeName("gfx::IQueryPool *")] IQueryPool* queryPool, [NativeTypeName("gfx::GfxIndex")] int queryIndex)
    {
        Marshal.GetDelegateForFunctionPointer<_writeTimestamp>(lpVtbl->writeTimestamp)((ICommandEncoder*)Unsafe.AsPointer(ref this), queryPool, queryIndex);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((stdcall))")]
        public IntPtr release;

        [NativeTypeName("void () __attribute__((stdcall))")]
        public IntPtr endEncoding;

        [NativeTypeName("void (IQueryPool *, GfxIndex) __attribute__((stdcall))")]
        public IntPtr writeTimestamp;
    }
}
