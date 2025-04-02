using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='IDevice.xml' path='doc/member[@name="IDevice"]/*' />
[NativeTypeName("struct IDevice : ISlangUnknown")]
[NativeInheritance("ISlangUnknown")]
public unsafe partial struct IDevice
{
    public Vtbl* lpVtbl;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _queryInterface(IDevice* pThis, [NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _addRef(IDevice* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("uint32_t")]
    public delegate uint _release(IDevice* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getNativeDeviceHandles(IDevice* pThis, [NativeTypeName("gfx::IDevice::InteropHandles *")] InteropHandles* outHandles);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("bool")]
    public delegate Boolean _hasFeature(IDevice* pThis, [NativeTypeName("const char *")] sbyte* feature);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getFeatures(IDevice* pThis, [NativeTypeName("const char **")] sbyte** outFeatures, [NativeTypeName("gfx::Size")] nuint bufferSize, [NativeTypeName("gfx::GfxCount *")] int* outFeatureCount);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getFormatSupportedResourceStates(IDevice* pThis, [NativeTypeName("gfx::Format")] Format format, [NativeTypeName("gfx::ResourceStateSet *")] ulong* outStates);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getSlangSession(IDevice* pThis, [NativeTypeName("slang::ISession **")] ISession** outSlangSession);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createTransientResourceHeap(IDevice* pThis, [NativeTypeName("const ITransientResourceHeap::Desc &")] TransientResourceHeapDesc* desc, ITransientResourceHeap** outHeap);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createTextureResource(IDevice* pThis, [NativeTypeName("const ITextureResource::Desc &")] TextureResourceDesc* desc, [NativeTypeName("const ITextureResource::SubresourceData *")] SubresourceData* initData, ITextureResource** outResource);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createTextureFromNativeHandle(IDevice* pThis, [NativeTypeName("gfx::InteropHandle")] InteropHandle handle, [NativeTypeName("const ITextureResource::Desc &")] TextureResourceDesc* srcDesc, ITextureResource** outResource);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createTextureFromSharedHandle(IDevice* pThis, [NativeTypeName("gfx::InteropHandle")] InteropHandle handle, [NativeTypeName("const ITextureResource::Desc &")] TextureResourceDesc* srcDesc, [NativeTypeName("const Size")] nuint size, ITextureResource** outResource);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createBufferResource(IDevice* pThis, [NativeTypeName("const IBufferResource::Desc &")] BufferResourceDesc* desc, [NativeTypeName("const void *")] void* initData, IBufferResource** outResource);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createBufferFromNativeHandle(IDevice* pThis, [NativeTypeName("gfx::InteropHandle")] InteropHandle handle, [NativeTypeName("const IBufferResource::Desc &")] BufferResourceDesc* srcDesc, IBufferResource** outResource);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createBufferFromSharedHandle(IDevice* pThis, [NativeTypeName("gfx::InteropHandle")] InteropHandle handle, [NativeTypeName("const IBufferResource::Desc &")] BufferResourceDesc* srcDesc, IBufferResource** outResource);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createSamplerState(IDevice* pThis, [NativeTypeName("const ISamplerState::Desc &")] SamplerStateDesc* desc, ISamplerState** outSampler);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createTextureView(IDevice* pThis, [NativeTypeName("gfx::ITextureResource *")] ITextureResource* texture, [NativeTypeName("const IResourceView::Desc &")] ResourceViewDesc* desc, IResourceView** outView);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createBufferView(IDevice* pThis, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* buffer, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* counterBuffer, [NativeTypeName("const IResourceView::Desc &")] ResourceViewDesc* desc, IResourceView** outView);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createFramebufferLayout(IDevice* pThis, [NativeTypeName("const IFramebufferLayout::Desc &")] FramebufferLayoutDesc* desc, IFramebufferLayout** outFrameBuffer);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createFramebuffer(IDevice* pThis, [NativeTypeName("const IFramebuffer::Desc &")] FramebufferDesc* desc, IFramebuffer** outFrameBuffer);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createRenderPassLayout(IDevice* pThis, [NativeTypeName("const IRenderPassLayout::Desc &")] RenderPassLayoutDesc* desc, IRenderPassLayout** outRenderPassLayout);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createSwapchain(IDevice* pThis, [NativeTypeName("const ISwapchain::Desc &")] SwapchainDesc* desc, [NativeTypeName("gfx::WindowHandle")] WindowHandle window, ISwapchain** outSwapchain);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createInputLayout(IDevice* pThis, [NativeTypeName("const IInputLayout::Desc &")] InputLayoutDesc* desc, IInputLayout** outLayout);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createCommandQueue(IDevice* pThis, [NativeTypeName("const ICommandQueue::Desc &")] CommandQueueDesc* desc, ICommandQueue** outQueue);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createShaderObject(IDevice* pThis, [NativeTypeName("slang::TypeReflection *")] TypeReflection* type, [NativeTypeName("gfx::ShaderObjectContainerType")] ShaderObjectContainerType container, IShaderObject** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createMutableShaderObject(IDevice* pThis, [NativeTypeName("slang::TypeReflection *")] TypeReflection* type, [NativeTypeName("gfx::ShaderObjectContainerType")] ShaderObjectContainerType container, IShaderObject** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createShaderObjectFromTypeLayout(IDevice* pThis, [NativeTypeName("slang::TypeLayoutReflection *")] TypeLayoutReflection* typeLayout, IShaderObject** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createMutableShaderObjectFromTypeLayout(IDevice* pThis, [NativeTypeName("slang::TypeLayoutReflection *")] TypeLayoutReflection* typeLayout, IShaderObject** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createMutableRootShaderObject(IDevice* pThis, [NativeTypeName("gfx::IShaderProgram *")] IShaderProgram* program, IShaderObject** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createShaderTable(IDevice* pThis, [NativeTypeName("const IShaderTable::Desc &")] ShaderTableDesc* desc, IShaderTable** outTable);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createProgram(IDevice* pThis, [NativeTypeName("const IShaderProgram::Desc &")] ShaderProgramDesc* desc, IShaderProgram** outProgram, ISlangBlob** outDiagnosticBlob = null);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createProgram2(IDevice* pThis, [NativeTypeName("const IShaderProgram::CreateDesc2 &")] CreateDesc2* createDesc, IShaderProgram** outProgram, ISlangBlob** outDiagnosticBlob = null);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createGraphicsPipelineState(IDevice* pThis, [NativeTypeName("const GraphicsPipelineStateDesc &")] GraphicsPipelineStateDesc* desc, IPipelineState** outState);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createComputePipelineState(IDevice* pThis, [NativeTypeName("const ComputePipelineStateDesc &")] ComputePipelineStateDesc* desc, IPipelineState** outState);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createRayTracingPipelineState(IDevice* pThis, [NativeTypeName("const RayTracingPipelineStateDesc &")] RayTracingPipelineStateDesc* desc, IPipelineState** outState);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _readTextureResource(IDevice* pThis, [NativeTypeName("gfx::ITextureResource *")] ITextureResource* resource, [NativeTypeName("gfx::ResourceState")] ResourceState state, ISlangBlob** outBlob, [NativeTypeName("gfx::Size *")] nuint* outRowPitch, [NativeTypeName("gfx::Size *")] nuint* outPixelSize);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("SlangResult")]
    public delegate int _readBufferResource(IDevice* pThis, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* buffer, [NativeTypeName("gfx::Offset")] nuint offset, [NativeTypeName("gfx::Size")] nuint size, ISlangBlob** outBlob);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("const DeviceInfo &")]
    public delegate DeviceInfo* _getDeviceInfo(IDevice* pThis);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createQueryPool(IDevice* pThis, [NativeTypeName("const IQueryPool::Desc &")] QueryPoolDesc* desc, IQueryPool** outPool);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getAccelerationStructurePrebuildInfo(IDevice* pThis, [NativeTypeName("const IAccelerationStructure::BuildInputs &")] BuildInputs* buildInputs, [NativeTypeName("gfx::IAccelerationStructure::PrebuildInfo *")] PrebuildInfo* outPrebuildInfo);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createAccelerationStructure(IDevice* pThis, [NativeTypeName("const IAccelerationStructure::CreateDesc &")] CreateDesc* desc, IAccelerationStructure** outView);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createFence(IDevice* pThis, [NativeTypeName("const IFence::Desc &")] FenceDesc* desc, IFence** outFence);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _waitForFences(IDevice* pThis, [NativeTypeName("gfx::GfxCount")] int fenceCount, IFence** fences, [NativeTypeName("uint64_t *")] ulong* values, [NativeTypeName("bool")] Boolean waitForAll, [NativeTypeName("uint64_t")] ulong timeout);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getTextureAllocationInfo(IDevice* pThis, [NativeTypeName("const ITextureResource::Desc &")] TextureResourceDesc* desc, [NativeTypeName("gfx::Size *")] nuint* outSize, [NativeTypeName("gfx::Size *")] nuint* outAlignment);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _getTextureRowAlignment(IDevice* pThis, [NativeTypeName("gfx::Size *")] nuint* outAlignment);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createShaderObject2(IDevice* pThis, [NativeTypeName("slang::ISession *")] ISession* slangSession, [NativeTypeName("slang::TypeReflection *")] TypeReflection* type, [NativeTypeName("gfx::ShaderObjectContainerType")] ShaderObjectContainerType container, IShaderObject** outObject);

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    [return: NativeTypeName("gfx::Result")]
    public delegate int _createMutableShaderObject2(IDevice* pThis, [NativeTypeName("slang::ISession *")] ISession* slangSession, [NativeTypeName("slang::TypeReflection *")] TypeReflection* type, [NativeTypeName("gfx::ShaderObjectContainerType")] ShaderObjectContainerType container, IShaderObject** outObject);

    /// <include file='SlangDesc.xml' path='doc/member[@name="SlangDesc"]/*' />
    public unsafe partial struct SlangDesc
    {
        /// <include file='SlangDesc.xml' path='doc/member[@name="SlangDesc.slangGlobalSession"]/*' />
        [NativeTypeName("slang::IGlobalSession *")]
        public IGlobalSession* slangGlobalSession;

        /// <include file='SlangDesc.xml' path='doc/member[@name="SlangDesc.defaultMatrixLayoutMode"]/*' />
        [NativeTypeName("SlangMatrixLayoutMode")]
        public MatrixLayoutMode defaultMatrixLayoutMode;

        /// <include file='SlangDesc.xml' path='doc/member[@name="SlangDesc.searchPaths"]/*' />
        [NativeTypeName("const char *const *")]
        public sbyte** searchPaths;

        /// <include file='SlangDesc.xml' path='doc/member[@name="SlangDesc.searchPathCount"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int searchPathCount;

        /// <include file='SlangDesc.xml' path='doc/member[@name="SlangDesc.preprocessorMacros"]/*' />
        [NativeTypeName("const slang::PreprocessorMacroDesc *")]
        public PreprocessorMacroDesc* preprocessorMacros;

        /// <include file='SlangDesc.xml' path='doc/member[@name="SlangDesc.preprocessorMacroCount"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int preprocessorMacroCount;

        /// <include file='SlangDesc.xml' path='doc/member[@name="SlangDesc.targetProfile"]/*' />
        [NativeTypeName("const char *")]
        public sbyte* targetProfile;

        /// <include file='SlangDesc.xml' path='doc/member[@name="SlangDesc.floatingPointMode"]/*' />
        [NativeTypeName("SlangFloatingPointMode")]
        public FloatingPointMode floatingPointMode;

        /// <include file='SlangDesc.xml' path='doc/member[@name="SlangDesc.optimizationLevel"]/*' />
        [NativeTypeName("SlangOptimizationLevel")]
        public OptimizationLevel optimizationLevel;

        /// <include file='SlangDesc.xml' path='doc/member[@name="SlangDesc.targetFlags"]/*' />
        [NativeTypeName("SlangTargetFlags")]
        public uint targetFlags;

        /// <include file='SlangDesc.xml' path='doc/member[@name="SlangDesc.lineDirectiveMode"]/*' />
        [NativeTypeName("SlangLineDirectiveMode")]
        public LineDirectiveMode lineDirectiveMode;
    }

    /// <include file='ShaderCacheDesc.xml' path='doc/member[@name="ShaderCacheDesc"]/*' />
    public unsafe partial struct ShaderCacheDesc
    {
        /// <include file='ShaderCacheDesc.xml' path='doc/member[@name="ShaderCacheDesc.shaderCachePath"]/*' />
        [NativeTypeName("const char *")]
        public sbyte* shaderCachePath;

        /// <include file='ShaderCacheDesc.xml' path='doc/member[@name="ShaderCacheDesc.maxEntryCount"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int maxEntryCount;
    }

    /// <include file='InteropHandles.xml' path='doc/member[@name="InteropHandles"]/*' />
    public partial struct InteropHandles
    {
        /// <include file='InteropHandles.xml' path='doc/member[@name="InteropHandles.handles"]/*' />
        [NativeTypeName("InteropHandle[3]")]
        public _handles_e__FixedBuffer handles;

        /// <include file='_handles_e__FixedBuffer.xml' path='doc/member[@name="_handles_e__FixedBuffer"]/*' />
        [InlineArray(3)]
        public partial struct _handles_e__FixedBuffer
        {
            public InteropHandle e0;
        }
    }

    /// <include file='DeviceDesc.xml' path='doc/member[@name="DeviceDesc"]/*' />
    public unsafe partial struct DeviceDesc
    {
        /// <include file='DeviceDesc.xml' path='doc/member[@name="DeviceDesc.deviceType"]/*' />
        [NativeTypeName("gfx::DeviceType")]
        public DeviceType deviceType;

        /// <include file='DeviceDesc.xml' path='doc/member[@name="DeviceDesc.existingDeviceHandles"]/*' />
        [NativeTypeName("gfx::IDevice::InteropHandles")]
        public InteropHandles existingDeviceHandles;

        /// <include file='DeviceDesc.xml' path='doc/member[@name="DeviceDesc.adapterLUID"]/*' />
        [NativeTypeName("const AdapterLUID *")]
        public AdapterLUID* adapterLUID;

        /// <include file='DeviceDesc.xml' path='doc/member[@name="DeviceDesc.requiredFeatureCount"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int requiredFeatureCount;

        /// <include file='DeviceDesc.xml' path='doc/member[@name="DeviceDesc.requiredFeatures"]/*' />
        [NativeTypeName("const char **")]
        public sbyte** requiredFeatures;

        /// <include file='DeviceDesc.xml' path='doc/member[@name="DeviceDesc.apiCommandDispatcher"]/*' />
        public ISlangUnknown* apiCommandDispatcher;

        /// <include file='DeviceDesc.xml' path='doc/member[@name="DeviceDesc.nvapiExtnSlot"]/*' />
        [NativeTypeName("gfx::GfxIndex")]
        public int nvapiExtnSlot;

        /// <include file='DeviceDesc.xml' path='doc/member[@name="DeviceDesc.shaderCache"]/*' />
        [NativeTypeName("gfx::IDevice::ShaderCacheDesc")]
        public ShaderCacheDesc shaderCache;

        /// <include file='DeviceDesc.xml' path='doc/member[@name="DeviceDesc.slang"]/*' />
        [NativeTypeName("gfx::IDevice::SlangDesc")]
        public SlangDesc slang;

        /// <include file='DeviceDesc.xml' path='doc/member[@name="DeviceDesc.extendedDescCount"]/*' />
        [NativeTypeName("gfx::GfxCount")]
        public int extendedDescCount;

        /// <include file='DeviceDesc.xml' path='doc/member[@name="DeviceDesc.extendedDescs"]/*' />
        public void** extendedDescs;
    }

    /// <inheritdoc cref="ISlangUnknown.queryInterface" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int queryInterface([NativeTypeName("const SlangUUID &")] SlangUUID* uuid, void** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_queryInterface>(lpVtbl->queryInterface)((IDevice*)Unsafe.AsPointer(ref this), uuid, outObject);
    }

    /// <inheritdoc cref="ISlangUnknown.addRef" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint addRef()
    {
        return Marshal.GetDelegateForFunctionPointer<_addRef>(lpVtbl->addRef)((IDevice*)Unsafe.AsPointer(ref this));
    }

    /// <inheritdoc cref="ISlangUnknown.release" />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("uint32_t")]
    public uint release()
    {
        return Marshal.GetDelegateForFunctionPointer<_release>(lpVtbl->release)((IDevice*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.getNativeDeviceHandles"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getNativeDeviceHandles([NativeTypeName("gfx::IDevice::InteropHandles *")] InteropHandles* outHandles)
    {
        return Marshal.GetDelegateForFunctionPointer<_getNativeDeviceHandles>(lpVtbl->getNativeDeviceHandles)((IDevice*)Unsafe.AsPointer(ref this), outHandles);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.hasFeature"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("bool")]
    public Boolean hasFeature([NativeTypeName("const char *")] sbyte* feature)
    {
        return Marshal.GetDelegateForFunctionPointer<_hasFeature>(lpVtbl->hasFeature)((IDevice*)Unsafe.AsPointer(ref this), feature);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.getFeatures"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getFeatures([NativeTypeName("const char **")] sbyte** outFeatures, [NativeTypeName("gfx::Size")] nuint bufferSize, [NativeTypeName("gfx::GfxCount *")] int* outFeatureCount)
    {
        return Marshal.GetDelegateForFunctionPointer<_getFeatures>(lpVtbl->getFeatures)((IDevice*)Unsafe.AsPointer(ref this), outFeatures, bufferSize, outFeatureCount);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.getFormatSupportedResourceStates"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getFormatSupportedResourceStates([NativeTypeName("gfx::Format")] Format format, [NativeTypeName("gfx::ResourceStateSet *")] ulong* outStates)
    {
        return Marshal.GetDelegateForFunctionPointer<_getFormatSupportedResourceStates>(lpVtbl->getFormatSupportedResourceStates)((IDevice*)Unsafe.AsPointer(ref this), format, outStates);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.getSlangSession"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getSlangSession([NativeTypeName("slang::ISession **")] ISession** outSlangSession)
    {
        return Marshal.GetDelegateForFunctionPointer<_getSlangSession>(lpVtbl->getSlangSession)((IDevice*)Unsafe.AsPointer(ref this), outSlangSession);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createTransientResourceHeap"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createTransientResourceHeap([NativeTypeName("const ITransientResourceHeap::Desc &")] TransientResourceHeapDesc* desc, ITransientResourceHeap** outHeap)
    {
        return Marshal.GetDelegateForFunctionPointer<_createTransientResourceHeap>(lpVtbl->createTransientResourceHeap)((IDevice*)Unsafe.AsPointer(ref this), desc, outHeap);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createTextureResource"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createTextureResource([NativeTypeName("const ITextureResource::Desc &")] TextureResourceDesc* desc, [NativeTypeName("const ITextureResource::SubresourceData *")] SubresourceData* initData, ITextureResource** outResource)
    {
        return Marshal.GetDelegateForFunctionPointer<_createTextureResource>(lpVtbl->createTextureResource)((IDevice*)Unsafe.AsPointer(ref this), desc, initData, outResource);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createTextureFromNativeHandle"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createTextureFromNativeHandle([NativeTypeName("gfx::InteropHandle")] InteropHandle handle, [NativeTypeName("const ITextureResource::Desc &")] TextureResourceDesc* srcDesc, ITextureResource** outResource)
    {
        return Marshal.GetDelegateForFunctionPointer<_createTextureFromNativeHandle>(lpVtbl->createTextureFromNativeHandle)((IDevice*)Unsafe.AsPointer(ref this), handle, srcDesc, outResource);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createTextureFromSharedHandle"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createTextureFromSharedHandle([NativeTypeName("gfx::InteropHandle")] InteropHandle handle, [NativeTypeName("const ITextureResource::Desc &")] TextureResourceDesc* srcDesc, [NativeTypeName("const Size")] nuint size, ITextureResource** outResource)
    {
        return Marshal.GetDelegateForFunctionPointer<_createTextureFromSharedHandle>(lpVtbl->createTextureFromSharedHandle)((IDevice*)Unsafe.AsPointer(ref this), handle, srcDesc, size, outResource);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createBufferResource"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createBufferResource([NativeTypeName("const IBufferResource::Desc &")] BufferResourceDesc* desc, [NativeTypeName("const void *")] void* initData, IBufferResource** outResource)
    {
        return Marshal.GetDelegateForFunctionPointer<_createBufferResource>(lpVtbl->createBufferResource)((IDevice*)Unsafe.AsPointer(ref this), desc, initData, outResource);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createBufferFromNativeHandle"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createBufferFromNativeHandle([NativeTypeName("gfx::InteropHandle")] InteropHandle handle, [NativeTypeName("const IBufferResource::Desc &")] BufferResourceDesc* srcDesc, IBufferResource** outResource)
    {
        return Marshal.GetDelegateForFunctionPointer<_createBufferFromNativeHandle>(lpVtbl->createBufferFromNativeHandle)((IDevice*)Unsafe.AsPointer(ref this), handle, srcDesc, outResource);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createBufferFromSharedHandle"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createBufferFromSharedHandle([NativeTypeName("gfx::InteropHandle")] InteropHandle handle, [NativeTypeName("const IBufferResource::Desc &")] BufferResourceDesc* srcDesc, IBufferResource** outResource)
    {
        return Marshal.GetDelegateForFunctionPointer<_createBufferFromSharedHandle>(lpVtbl->createBufferFromSharedHandle)((IDevice*)Unsafe.AsPointer(ref this), handle, srcDesc, outResource);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createSamplerState"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createSamplerState([NativeTypeName("const ISamplerState::Desc &")] SamplerStateDesc* desc, ISamplerState** outSampler)
    {
        return Marshal.GetDelegateForFunctionPointer<_createSamplerState>(lpVtbl->createSamplerState)((IDevice*)Unsafe.AsPointer(ref this), desc, outSampler);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createTextureView"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createTextureView([NativeTypeName("gfx::ITextureResource *")] ITextureResource* texture, [NativeTypeName("const IResourceView::Desc &")] ResourceViewDesc* desc, IResourceView** outView)
    {
        return Marshal.GetDelegateForFunctionPointer<_createTextureView>(lpVtbl->createTextureView)((IDevice*)Unsafe.AsPointer(ref this), texture, desc, outView);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createBufferView"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createBufferView([NativeTypeName("gfx::IBufferResource *")] IBufferResource* buffer, [NativeTypeName("gfx::IBufferResource *")] IBufferResource* counterBuffer, [NativeTypeName("const IResourceView::Desc &")] ResourceViewDesc* desc, IResourceView** outView)
    {
        return Marshal.GetDelegateForFunctionPointer<_createBufferView>(lpVtbl->createBufferView)((IDevice*)Unsafe.AsPointer(ref this), buffer, counterBuffer, desc, outView);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createFramebufferLayout"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createFramebufferLayout([NativeTypeName("const IFramebufferLayout::Desc &")] FramebufferLayoutDesc* desc, IFramebufferLayout** outFrameBuffer)
    {
        return Marshal.GetDelegateForFunctionPointer<_createFramebufferLayout>(lpVtbl->createFramebufferLayout)((IDevice*)Unsafe.AsPointer(ref this), desc, outFrameBuffer);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createFramebuffer"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createFramebuffer([NativeTypeName("const IFramebuffer::Desc &")] FramebufferDesc* desc, IFramebuffer** outFrameBuffer)
    {
        return Marshal.GetDelegateForFunctionPointer<_createFramebuffer>(lpVtbl->createFramebuffer)((IDevice*)Unsafe.AsPointer(ref this), desc, outFrameBuffer);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createRenderPassLayout"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createRenderPassLayout([NativeTypeName("const IRenderPassLayout::Desc &")] RenderPassLayoutDesc* desc, IRenderPassLayout** outRenderPassLayout)
    {
        return Marshal.GetDelegateForFunctionPointer<_createRenderPassLayout>(lpVtbl->createRenderPassLayout)((IDevice*)Unsafe.AsPointer(ref this), desc, outRenderPassLayout);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createSwapchain"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createSwapchain([NativeTypeName("const ISwapchain::Desc &")] SwapchainDesc* desc, [NativeTypeName("gfx::WindowHandle")] WindowHandle window, ISwapchain** outSwapchain)
    {
        return Marshal.GetDelegateForFunctionPointer<_createSwapchain>(lpVtbl->createSwapchain)((IDevice*)Unsafe.AsPointer(ref this), desc, window, outSwapchain);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createInputLayout"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createInputLayout([NativeTypeName("const IInputLayout::Desc &")] InputLayoutDesc* desc, IInputLayout** outLayout)
    {
        return Marshal.GetDelegateForFunctionPointer<_createInputLayout>(lpVtbl->createInputLayout)((IDevice*)Unsafe.AsPointer(ref this), desc, outLayout);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createCommandQueue"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createCommandQueue([NativeTypeName("const ICommandQueue::Desc &")] CommandQueueDesc* desc, ICommandQueue** outQueue)
    {
        return Marshal.GetDelegateForFunctionPointer<_createCommandQueue>(lpVtbl->createCommandQueue)((IDevice*)Unsafe.AsPointer(ref this), desc, outQueue);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createShaderObject"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createShaderObject([NativeTypeName("slang::TypeReflection *")] TypeReflection* type, [NativeTypeName("gfx::ShaderObjectContainerType")] ShaderObjectContainerType container, IShaderObject** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_createShaderObject>(lpVtbl->createShaderObject)((IDevice*)Unsafe.AsPointer(ref this), type, container, outObject);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createMutableShaderObject"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createMutableShaderObject([NativeTypeName("slang::TypeReflection *")] TypeReflection* type, [NativeTypeName("gfx::ShaderObjectContainerType")] ShaderObjectContainerType container, IShaderObject** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_createMutableShaderObject>(lpVtbl->createMutableShaderObject)((IDevice*)Unsafe.AsPointer(ref this), type, container, outObject);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createShaderObjectFromTypeLayout"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createShaderObjectFromTypeLayout([NativeTypeName("slang::TypeLayoutReflection *")] TypeLayoutReflection* typeLayout, IShaderObject** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_createShaderObjectFromTypeLayout>(lpVtbl->createShaderObjectFromTypeLayout)((IDevice*)Unsafe.AsPointer(ref this), typeLayout, outObject);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createMutableShaderObjectFromTypeLayout"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createMutableShaderObjectFromTypeLayout([NativeTypeName("slang::TypeLayoutReflection *")] TypeLayoutReflection* typeLayout, IShaderObject** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_createMutableShaderObjectFromTypeLayout>(lpVtbl->createMutableShaderObjectFromTypeLayout)((IDevice*)Unsafe.AsPointer(ref this), typeLayout, outObject);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createMutableRootShaderObject"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createMutableRootShaderObject([NativeTypeName("gfx::IShaderProgram *")] IShaderProgram* program, IShaderObject** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_createMutableRootShaderObject>(lpVtbl->createMutableRootShaderObject)((IDevice*)Unsafe.AsPointer(ref this), program, outObject);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createShaderTable"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createShaderTable([NativeTypeName("const IShaderTable::Desc &")] ShaderTableDesc* desc, IShaderTable** outTable)
    {
        return Marshal.GetDelegateForFunctionPointer<_createShaderTable>(lpVtbl->createShaderTable)((IDevice*)Unsafe.AsPointer(ref this), desc, outTable);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createProgram"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createProgram([NativeTypeName("const IShaderProgram::Desc &")] ShaderProgramDesc* desc, IShaderProgram** outProgram, ISlangBlob** outDiagnosticBlob = null)
    {
        return Marshal.GetDelegateForFunctionPointer<_createProgram>(lpVtbl->createProgram)((IDevice*)Unsafe.AsPointer(ref this), desc, outProgram, outDiagnosticBlob);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createProgram2"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createProgram2([NativeTypeName("const IShaderProgram::CreateDesc2 &")] CreateDesc2* createDesc, IShaderProgram** outProgram, ISlangBlob** outDiagnosticBlob = null)
    {
        return Marshal.GetDelegateForFunctionPointer<_createProgram2>(lpVtbl->createProgram2)((IDevice*)Unsafe.AsPointer(ref this), createDesc, outProgram, outDiagnosticBlob);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createGraphicsPipelineState"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createGraphicsPipelineState([NativeTypeName("const GraphicsPipelineStateDesc &")] GraphicsPipelineStateDesc* desc, IPipelineState** outState)
    {
        return Marshal.GetDelegateForFunctionPointer<_createGraphicsPipelineState>(lpVtbl->createGraphicsPipelineState)((IDevice*)Unsafe.AsPointer(ref this), desc, outState);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createComputePipelineState"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createComputePipelineState([NativeTypeName("const ComputePipelineStateDesc &")] ComputePipelineStateDesc* desc, IPipelineState** outState)
    {
        return Marshal.GetDelegateForFunctionPointer<_createComputePipelineState>(lpVtbl->createComputePipelineState)((IDevice*)Unsafe.AsPointer(ref this), desc, outState);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createRayTracingPipelineState"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createRayTracingPipelineState([NativeTypeName("const RayTracingPipelineStateDesc &")] RayTracingPipelineStateDesc* desc, IPipelineState** outState)
    {
        return Marshal.GetDelegateForFunctionPointer<_createRayTracingPipelineState>(lpVtbl->createRayTracingPipelineState)((IDevice*)Unsafe.AsPointer(ref this), desc, outState);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.readTextureResource"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int readTextureResource([NativeTypeName("gfx::ITextureResource *")] ITextureResource* resource, [NativeTypeName("gfx::ResourceState")] ResourceState state, ISlangBlob** outBlob, [NativeTypeName("gfx::Size *")] nuint* outRowPitch, [NativeTypeName("gfx::Size *")] nuint* outPixelSize)
    {
        return Marshal.GetDelegateForFunctionPointer<_readTextureResource>(lpVtbl->readTextureResource)((IDevice*)Unsafe.AsPointer(ref this), resource, state, outBlob, outRowPitch, outPixelSize);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.readBufferResource"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("SlangResult")]
    public int readBufferResource([NativeTypeName("gfx::IBufferResource *")] IBufferResource* buffer, [NativeTypeName("gfx::Offset")] nuint offset, [NativeTypeName("gfx::Size")] nuint size, ISlangBlob** outBlob)
    {
        return Marshal.GetDelegateForFunctionPointer<_readBufferResource>(lpVtbl->readBufferResource)((IDevice*)Unsafe.AsPointer(ref this), buffer, offset, size, outBlob);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.getDeviceInfo"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("const DeviceInfo &")]
    public DeviceInfo* getDeviceInfo()
    {
        return Marshal.GetDelegateForFunctionPointer<_getDeviceInfo>(lpVtbl->getDeviceInfo)((IDevice*)Unsafe.AsPointer(ref this));
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createQueryPool"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createQueryPool([NativeTypeName("const IQueryPool::Desc &")] QueryPoolDesc* desc, IQueryPool** outPool)
    {
        return Marshal.GetDelegateForFunctionPointer<_createQueryPool>(lpVtbl->createQueryPool)((IDevice*)Unsafe.AsPointer(ref this), desc, outPool);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.getAccelerationStructurePrebuildInfo"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getAccelerationStructurePrebuildInfo([NativeTypeName("const IAccelerationStructure::BuildInputs &")] BuildInputs* buildInputs, [NativeTypeName("gfx::IAccelerationStructure::PrebuildInfo *")] PrebuildInfo* outPrebuildInfo)
    {
        return Marshal.GetDelegateForFunctionPointer<_getAccelerationStructurePrebuildInfo>(lpVtbl->getAccelerationStructurePrebuildInfo)((IDevice*)Unsafe.AsPointer(ref this), buildInputs, outPrebuildInfo);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createAccelerationStructure"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createAccelerationStructure([NativeTypeName("const IAccelerationStructure::CreateDesc &")] CreateDesc* desc, IAccelerationStructure** outView)
    {
        return Marshal.GetDelegateForFunctionPointer<_createAccelerationStructure>(lpVtbl->createAccelerationStructure)((IDevice*)Unsafe.AsPointer(ref this), desc, outView);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createFence"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createFence([NativeTypeName("const IFence::Desc &")] FenceDesc* desc, IFence** outFence)
    {
        return Marshal.GetDelegateForFunctionPointer<_createFence>(lpVtbl->createFence)((IDevice*)Unsafe.AsPointer(ref this), desc, outFence);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.waitForFences"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int waitForFences([NativeTypeName("gfx::GfxCount")] int fenceCount, IFence** fences, [NativeTypeName("uint64_t *")] ulong* values, [NativeTypeName("bool")] Boolean waitForAll, [NativeTypeName("uint64_t")] ulong timeout)
    {
        return Marshal.GetDelegateForFunctionPointer<_waitForFences>(lpVtbl->waitForFences)((IDevice*)Unsafe.AsPointer(ref this), fenceCount, fences, values, waitForAll, timeout);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.getTextureAllocationInfo"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getTextureAllocationInfo([NativeTypeName("const ITextureResource::Desc &")] TextureResourceDesc* desc, [NativeTypeName("gfx::Size *")] nuint* outSize, [NativeTypeName("gfx::Size *")] nuint* outAlignment)
    {
        return Marshal.GetDelegateForFunctionPointer<_getTextureAllocationInfo>(lpVtbl->getTextureAllocationInfo)((IDevice*)Unsafe.AsPointer(ref this), desc, outSize, outAlignment);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.getTextureRowAlignment"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int getTextureRowAlignment([NativeTypeName("gfx::Size *")] nuint* outAlignment)
    {
        return Marshal.GetDelegateForFunctionPointer<_getTextureRowAlignment>(lpVtbl->getTextureRowAlignment)((IDevice*)Unsafe.AsPointer(ref this), outAlignment);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createShaderObject2"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createShaderObject2([NativeTypeName("slang::ISession *")] ISession* slangSession, [NativeTypeName("slang::TypeReflection *")] TypeReflection* type, [NativeTypeName("gfx::ShaderObjectContainerType")] ShaderObjectContainerType container, IShaderObject** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_createShaderObject2>(lpVtbl->createShaderObject2)((IDevice*)Unsafe.AsPointer(ref this), slangSession, type, container, outObject);
    }

    /// <include file='IDevice.xml' path='doc/member[@name="IDevice.createMutableShaderObject2"]/*' />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NativeTypeName("gfx::Result")]
    public int createMutableShaderObject2([NativeTypeName("slang::ISession *")] ISession* slangSession, [NativeTypeName("slang::TypeReflection *")] TypeReflection* type, [NativeTypeName("gfx::ShaderObjectContainerType")] ShaderObjectContainerType container, IShaderObject** outObject)
    {
        return Marshal.GetDelegateForFunctionPointer<_createMutableShaderObject2>(lpVtbl->createMutableShaderObject2)((IDevice*)Unsafe.AsPointer(ref this), slangSession, type, container, outObject);
    }

    public partial struct Vtbl
    {
        [NativeTypeName("SlangResult (const SlangUUID &, void **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr queryInterface;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr addRef;

        [NativeTypeName("uint32_t () __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr release;

        [NativeTypeName("Result (InteropHandles *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getNativeDeviceHandles;

        [NativeTypeName("bool (const char *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr hasFeature;

        [NativeTypeName("Result (const char **, Size, GfxCount *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getFeatures;

        [NativeTypeName("Result (Format, ResourceStateSet *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getFormatSupportedResourceStates;

        [NativeTypeName("Result (slang::ISession **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getSlangSession;

        [NativeTypeName("Result (const ITransientResourceHeap::Desc &, ITransientResourceHeap **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createTransientResourceHeap;

        [NativeTypeName("Result (const ITextureResource::Desc &, const ITextureResource::SubresourceData *, ITextureResource **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createTextureResource;

        [NativeTypeName("Result (InteropHandle, const ITextureResource::Desc &, ITextureResource **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createTextureFromNativeHandle;

        [NativeTypeName("Result (InteropHandle, const ITextureResource::Desc &, const Size, ITextureResource **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createTextureFromSharedHandle;

        [NativeTypeName("Result (const IBufferResource::Desc &, const void *, IBufferResource **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createBufferResource;

        [NativeTypeName("Result (InteropHandle, const IBufferResource::Desc &, IBufferResource **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createBufferFromNativeHandle;

        [NativeTypeName("Result (InteropHandle, const IBufferResource::Desc &, IBufferResource **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createBufferFromSharedHandle;

        [NativeTypeName("Result (const ISamplerState::Desc &, ISamplerState **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createSamplerState;

        [NativeTypeName("Result (ITextureResource *, const IResourceView::Desc &, IResourceView **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createTextureView;

        [NativeTypeName("Result (IBufferResource *, IBufferResource *, const IResourceView::Desc &, IResourceView **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createBufferView;

        [NativeTypeName("Result (const IFramebufferLayout::Desc &, IFramebufferLayout **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createFramebufferLayout;

        [NativeTypeName("Result (const IFramebuffer::Desc &, IFramebuffer **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createFramebuffer;

        [NativeTypeName("Result (const IRenderPassLayout::Desc &, IRenderPassLayout **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createRenderPassLayout;

        [NativeTypeName("Result (const ISwapchain::Desc &, WindowHandle, ISwapchain **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createSwapchain;

        [NativeTypeName("Result (const IInputLayout::Desc &, IInputLayout **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createInputLayout;

        [NativeTypeName("Result (const ICommandQueue::Desc &, ICommandQueue **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createCommandQueue;

        [NativeTypeName("Result (slang::TypeReflection *, ShaderObjectContainerType, IShaderObject **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createShaderObject;

        [NativeTypeName("Result (slang::TypeReflection *, ShaderObjectContainerType, IShaderObject **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createMutableShaderObject;

        [NativeTypeName("Result (slang::TypeLayoutReflection *, IShaderObject **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createShaderObjectFromTypeLayout;

        [NativeTypeName("Result (slang::TypeLayoutReflection *, IShaderObject **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createMutableShaderObjectFromTypeLayout;

        [NativeTypeName("Result (IShaderProgram *, IShaderObject **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createMutableRootShaderObject;

        [NativeTypeName("Result (const IShaderTable::Desc &, IShaderTable **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createShaderTable;

        [NativeTypeName("Result (const IShaderProgram::Desc &, IShaderProgram **, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createProgram;

        [NativeTypeName("Result (const IShaderProgram::CreateDesc2 &, IShaderProgram **, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createProgram2;

        [NativeTypeName("Result (const GraphicsPipelineStateDesc &, IPipelineState **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createGraphicsPipelineState;

        [NativeTypeName("Result (const ComputePipelineStateDesc &, IPipelineState **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createComputePipelineState;

        [NativeTypeName("Result (const RayTracingPipelineStateDesc &, IPipelineState **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createRayTracingPipelineState;

        [NativeTypeName("SlangResult (ITextureResource *, ResourceState, ISlangBlob **, Size *, Size *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr readTextureResource;

        [NativeTypeName("SlangResult (IBufferResource *, Offset, Size, ISlangBlob **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr readBufferResource;

        [NativeTypeName("const DeviceInfo &() const __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getDeviceInfo;

        [NativeTypeName("Result (const IQueryPool::Desc &, IQueryPool **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createQueryPool;

        [NativeTypeName("Result (const IAccelerationStructure::BuildInputs &, IAccelerationStructure::PrebuildInfo *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getAccelerationStructurePrebuildInfo;

        [NativeTypeName("Result (const IAccelerationStructure::CreateDesc &, IAccelerationStructure **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createAccelerationStructure;

        [NativeTypeName("Result (const IFence::Desc &, IFence **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createFence;

        [NativeTypeName("Result (GfxCount, IFence **, uint64_t *, bool, uint64_t) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr waitForFences;

        [NativeTypeName("Result (const ITextureResource::Desc &, Size *, Size *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getTextureAllocationInfo;

        [NativeTypeName("Result (Size *) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr getTextureRowAlignment;

        [NativeTypeName("Result (slang::ISession *, slang::TypeReflection *, ShaderObjectContainerType, IShaderObject **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createShaderObject2;

        [NativeTypeName("Result (slang::ISession *, slang::TypeReflection *, ShaderObjectContainerType, IShaderObject **) __attribute__((nothrow)) __attribute__((stdcall))")]
        public IntPtr createMutableShaderObject2;
    }
}
