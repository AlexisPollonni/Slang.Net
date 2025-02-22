using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='IPipelineCreationAPIDispatcher.xml' path='doc/member[@name="IPipelineCreationAPIDispatcher"]/*' />
[NativeTypeName("struct IPipelineCreationAPIDispatcher : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct IPipelineCreationAPIDispatcher
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(IPipelineCreationAPIDispatcher* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IPipelineCreationAPIDispatcher* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IPipelineCreationAPIDispatcher* pThis);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createComputePipelineState(IPipelineCreationAPIDispatcher* pThis, [NativeTypeName("gfx::IDevice *")] IDevice* device, [NativeTypeName("slang::IComponentType *")] IComponentType* program, void* pipelineDesc, void** outPipelineState);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createGraphicsPipelineState(IPipelineCreationAPIDispatcher* pThis, [NativeTypeName("gfx::IDevice *")] IDevice* device, [NativeTypeName("slang::IComponentType *")] IComponentType* program, void* pipelineDesc, void** outPipelineState);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createMeshPipelineState(IPipelineCreationAPIDispatcher* pThis, [NativeTypeName("gfx::IDevice *")] IDevice* device, [NativeTypeName("slang::IComponentType *")] IComponentType* program, void* pipelineDesc, void** outPipelineState);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _beforeCreateRayTracingState(IPipelineCreationAPIDispatcher* pThis, [NativeTypeName("gfx::IDevice *")] IDevice* device, [NativeTypeName("slang::IComponentType *")] IComponentType* program);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _afterCreateRayTracingState(IPipelineCreationAPIDispatcher* pThis, [NativeTypeName("gfx::IDevice *")] IDevice* device, [NativeTypeName("slang::IComponentType *")] IComponentType* program);

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((IPipelineCreationAPIDispatcher*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((IPipelineCreationAPIDispatcher*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((IPipelineCreationAPIDispatcher*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IPipelineCreationAPIDispatcher.xml' path='doc/member[@name="IPipelineCreationAPIDispatcher.createComputePipelineState"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createComputePipelineState([NativeTypeName("gfx::IDevice *")] IDevice* device, [NativeTypeName("slang::IComponentType *")] IComponentType* program, void* pipelineDesc, void** outPipelineState)
    {
        return Marshal.GetDelegateForFunctionPointer<_createComputePipelineState>(lpVtbl->createComputePipelineState)((IPipelineCreationAPIDispatcher*)Unsafe.AsPointer(ref this), device, program, pipelineDesc, outPipelineState);
    }

    /// <include file='IPipelineCreationAPIDispatcher.xml' path='doc/member[@name="IPipelineCreationAPIDispatcher.createGraphicsPipelineState"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createGraphicsPipelineState([NativeTypeName("gfx::IDevice *")] IDevice* device, [NativeTypeName("slang::IComponentType *")] IComponentType* program, void* pipelineDesc, void** outPipelineState)
    {
        return Marshal.GetDelegateForFunctionPointer<_createGraphicsPipelineState>(lpVtbl->createGraphicsPipelineState)((IPipelineCreationAPIDispatcher*)Unsafe.AsPointer(ref this), device, program, pipelineDesc, outPipelineState);
    }

    /// <include file='IPipelineCreationAPIDispatcher.xml' path='doc/member[@name="IPipelineCreationAPIDispatcher.createMeshPipelineState"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createMeshPipelineState([NativeTypeName("gfx::IDevice *")] IDevice* device, [NativeTypeName("slang::IComponentType *")] IComponentType* program, void* pipelineDesc, void** outPipelineState)
    {
        return Marshal.GetDelegateForFunctionPointer<_createMeshPipelineState>(lpVtbl->createMeshPipelineState)((IPipelineCreationAPIDispatcher*)Unsafe.AsPointer(ref this), device, program, pipelineDesc, outPipelineState);
    }

    /// <include file='IPipelineCreationAPIDispatcher.xml' path='doc/member[@name="IPipelineCreationAPIDispatcher.beforeCreateRayTracingState"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int beforeCreateRayTracingState([NativeTypeName("gfx::IDevice *")] IDevice* device, [NativeTypeName("slang::IComponentType *")] IComponentType* program)
    {
        return Marshal.GetDelegateForFunctionPointer<_beforeCreateRayTracingState>(lpVtbl->beforeCreateRayTracingState)((IPipelineCreationAPIDispatcher*)Unsafe.AsPointer(ref this), device, program);
    }

    /// <include file='IPipelineCreationAPIDispatcher.xml' path='doc/member[@name="IPipelineCreationAPIDispatcher.afterCreateRayTracingState"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int afterCreateRayTracingState([NativeTypeName("gfx::IDevice *")] IDevice* device, [NativeTypeName("slang::IComponentType *")] IComponentType* program)
    {
        return Marshal.GetDelegateForFunctionPointer<_afterCreateRayTracingState>(lpVtbl->afterCreateRayTracingState)((IPipelineCreationAPIDispatcher*)Unsafe.AsPointer(ref this), device, program);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **)")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t ()")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t ()")]
        public IntPtr release;

        [NativeTypeName("Result (IDevice *, slang::IComponentType *, void *, void **)")]
        public IntPtr createComputePipelineState;

        [NativeTypeName("Result (IDevice *, slang::IComponentType *, void *, void **)")]
        public IntPtr createGraphicsPipelineState;

        [NativeTypeName("Result (IDevice *, slang::IComponentType *, void *, void **)")]
        public IntPtr createMeshPipelineState;

        [NativeTypeName("Result (IDevice *, slang::IComponentType *)")]
        public IntPtr beforeCreateRayTracingState;

        [NativeTypeName("Result (IDevice *, slang::IComponentType *)")]
        public IntPtr afterCreateRayTracingState;
    }
}
