using System;
using System.Buffers;
using Nito.Disposables;
using SlangNet.Gfx.Desc;
using SlangNet.Internal;
using SlangNet.Pretty.SourceGenerator;
using DeviceInfo = SlangNet.Gfx.Desc.DeviceInfo;

namespace SlangNet.Gfx;


[GenerateThrowingMethods]
public partial class Device : COMObject<IDevice>
{
    private unsafe Device(IDevice* pointer) : base(pointer)
    { }

    public static unsafe SlangResult TryCreate(in DeviceDesc desc, out Device? device)
    {
        return desc.MarshalToNative<DeviceDesc, IDevice.DeviceDesc, Device?>( out device, nDesc => 
        {
            IDevice* natDevice = null;
            var res = gfxCreateDevice(nDesc, &natDevice).ToSlangResult();
        
            var d = res ? new Device(natDevice) : null;
            return (res, d);
        });
    }

    [GenerateMarshallingCode<IDevice>(nameof(IDevice.getNativeDeviceHandles))]
    public partial SlangResult TryGetNativeDeviceHandles(out IDevice.InteropHandles handles);

    [GenerateMarshallingCode<IDevice>(nameof(IDevice.hasFeature))]
    public partial bool HasFeature(string feature);
    
    public unsafe SlangResult TryGetFeatures(out string[]? features)
    {
        int count = 0;
        var result = Pointer->getFeatures(null, 0, &count).ToSlangResult();
        if (!result || count == 0)
        {
            features = null;
            return result;
        }

        sbyte** featuresArrayPtr = stackalloc sbyte*[count];
        result = Pointer->getFeatures(featuresArrayPtr, (nuint)count, &count).ToSlangResult();

        if (!result)
        {
            features = null;
            return result;
        }

        var featuresArray = InteropUtils.PtrToStringArray(featuresArrayPtr, count);
        features = featuresArray;
        return result;
    }
    
    public unsafe SlangResult TryGetFormatSupportedResourceStates(Format format, out ResourceStateSet states)
    {
        var nativeStates = new ResourceStateSet();
        var result = Pointer->getFormatSupportedResourceStates(format, (ulong*)&nativeStates).ToSlangResult();
        states = nativeStates;
        return result;
    }

    [GenerateMarshallingCode<IDevice>(nameof(IDevice.getSlangSession))]
    public partial SlangResult TryGetSlangSession(out Session? session);
    

    // CREATE RESOURCES METHODS

    [GenerateMarshallingCode<IDevice>(nameof(IDevice.createTransientResourceHeap))]
    public partial SlangResult TryCreateTransientResourceHeap(in TransientResourceHeapDesc desc, out TransientResourceHeap? heap);

    /// <summary>
    /// Create a texture resource.
    ///
    /// If `initData` is non-null, then it must point to an array of
    /// `ITextureResource::SubresourceData` with one element for each
    /// subresource of the texture being created.
    ///
    /// The number of subresources in a texture is:
    ///
    ///     effectiveElementCount * mipLevelCount
    ///
    /// where the effective element count is computed as:
    ///
    ///     effectiveElementCount = (isArray ? arrayElementCount : 1) * (isCube ? 6 : 1);
    /// </summary>
    public unsafe SlangResult TryCreateTextureResource(in TextureResourceDesc desc,
                                                       ReadOnlySpan<TextureResource.SubresourceData> initData,
                                                       out TextureResource? texture)
    {
        var m = new MarshallingAllocBuffer(stackalloc byte[initData.Length * sizeof(ITextureResource.SubresourceData*) + desc.GetNativeAllocSize()]);

        var sbRrcSpan = m.AllocFor<ITextureResource.SubresourceData>(initData.Length);
        using var d = new CollectionDisposable();
        
        for (var i = 0; i < initData.Length; i++)
        {
            sbRrcSpan[i] = new()
            {
                data = initData[i].Data.Pin().DisposeWith(d).Pointer,
                strideY = initData[i].StrideY,
                strideZ = initData[i].StrideZ
            };
        }

        desc.AsNative(ref m, out var natDesc);
        
        fixed(ITextureResource.SubresourceData* pData = sbRrcSpan)
        {
            ITextureResource* nativeTexture = null;
            var res = Pointer->createTextureResource(&natDesc, pData, &nativeTexture).ToSlangResult();
            texture = res ? new TextureResource(nativeTexture) : null;
            return res;
        }
    }

    [GenerateMarshallingCode<IDevice>(nameof(IDevice.createTextureFromNativeHandle))]
    public partial SlangResult TryCreateTextureFromNativeHandle(InteropHandle handle,
                                                               in TextureResourceDesc srcDesc,
                                                               out TextureResource? texture);

    [GenerateMarshallingCode<IDevice>(nameof(IDevice.createTextureFromSharedHandle))]
    public partial SlangResult TryCreateTextureFromSharedHandle(InteropHandle handle,
                                                                TextureResourceDesc srcDesc,
                                                                nuint size,
                                                                out TextureResource? texture);
    
    
    public unsafe SlangResult TryCreateBufferResource(in BufferResourceDesc desc, IntPtr initData, out BufferResource? resource)
    {
        return desc.MarshalToNative<BufferResourceDesc, IBufferResource.BufferResourceDesc, BufferResource?>(out resource, descPtr => 
        {
            IBufferResource* nativeResource = null;
            var result = Pointer->createBufferResource(descPtr, (void*)initData, &nativeResource).ToSlangResult();
            return (result, result ? new BufferResource(nativeResource) : null);
        });
    }

    [GenerateMarshallingCode<IDevice>(nameof(IDevice.createBufferFromNativeHandle))]
    public partial SlangResult TryCreateBufferFromNativeHandle(InteropHandle handle,
                                                              in BufferResourceDesc desc,
                                                              out BufferResource? resource);

    [GenerateMarshallingCode<IDevice>(nameof(IDevice.createBufferFromSharedHandle))]
    public partial SlangResult TryCreateBufferFromSharedHandle(InteropHandle handle,
                                                              in BufferResourceDesc desc,
                                                              out BufferResource? resource);

    //TODO: Implement TryCreateSamplerState
    //TODO: Implement TryCreateTextureView

    [GenerateMarshallingCode<IDevice>(nameof(IDevice.createBufferView))]
    public partial SlangResult TryCreateBufferView(BufferResource buffer,
                                                  BufferResource? counterBuffer,
                                                  in ResourceViewDesc desc,
                                                  out ResourceView? view);

    [GenerateMarshallingCode<IDevice>(nameof(IDevice.createFramebufferLayout))]
    public partial SlangResult TryCreateFrameBufferLayout(in FramebufferLayout.FramebufferLayoutDesc desc, out FramebufferLayout? framebufferLayout);

    [GenerateMarshallingCode<IDevice>(nameof(IDevice.createFramebuffer))]
    public partial SlangResult TryCreateFrameBuffer(in Framebuffer.FramebufferDesc desc, out Framebuffer? framebuffer);

    [GenerateMarshallingCode<IDevice>(nameof(IDevice.createRenderPassLayout))]
    public partial SlangResult TryCreateRenderPassLayout(in RenderPassLayout.RenderPassLayoutDesc desc, out RenderPassLayout? layout);


    [GenerateMarshallingCode<IDevice>(nameof(IDevice.createSwapchain))]
    public partial SlangResult TryCreateSwapchain(in SwapchainDesc desc, WindowHandle window, out Swapchain? swapchain);

    [GenerateMarshallingCode<IDevice>(nameof(IDevice.createInputLayout))]
    public partial SlangResult TryCreateInputLayout(in InputLayout.InputLayoutDesc desc, out InputLayout? layout);

    [GenerateMarshallingCode<IDevice>(nameof(IDevice.createCommandQueue))]
    public partial SlangResult TryCreateCommandQueue(in CommandQueueDesc desc, out CommandQueue? queue);

    public unsafe SlangResult TryCreateShaderObject(TypeReflection type, ShaderObjectContainerType container, out ShaderObject? shaderObject)
    {
        IShaderObject* nativeShaderObject = null;
        var result = Pointer->createShaderObject(type.Pointer, container, &nativeShaderObject).ToSlangResult();
        shaderObject = result ? new ShaderObject(nativeShaderObject) : null;
        return result;
    }

    public unsafe SlangResult TryCreateMutableShaderObject(TypeReflection type, ShaderObjectContainerType container, out ShaderObject? shaderObject)
    {
        IShaderObject* nativeShaderObject = null;
        var result = Pointer->createMutableShaderObject(type.Pointer, container, &nativeShaderObject).ToSlangResult();
        shaderObject = result ? new ShaderObject(nativeShaderObject) : null;
        return result;
    }

    public unsafe SlangResult TryCreateShaderObjectFromTypeLayout(TypeLayoutReflection typeLayout, out ShaderObject? shaderObject)
    {
        IShaderObject* nativeShaderObject = null;
        var result = Pointer->createShaderObjectFromTypeLayout(typeLayout.Pointer, &nativeShaderObject).ToSlangResult();
        shaderObject = result ? new ShaderObject(nativeShaderObject) : null;
        return result;
    }

    public unsafe SlangResult TryCreateMutableShaderObjectFromTypeLayout(TypeLayoutReflection typeLayout, out ShaderObject? shaderObject)
    {
        IShaderObject* nativeShaderObject = null;
        var result = Pointer->createMutableShaderObjectFromTypeLayout(typeLayout.Pointer, &nativeShaderObject).ToSlangResult();
        shaderObject = result ? new ShaderObject(nativeShaderObject) : null;
        return result;
    }

    [GenerateMarshallingCode<IDevice>(nameof(IDevice.createMutableRootShaderObject))]
    public partial SlangResult TryCreateMutableRootShaderObject(ShaderProgram program, out ShaderObject? shaderObject);

    //TODO: Implement TryCreateShaderTable

    [GenerateMarshallingCode<IDevice>(nameof(IDevice.createProgram))]
    public partial SlangResult TryCreateProgram(in ShaderProgramDesc desc, out ShaderProgram? program);

    //TODO: Implement TryCreateProgram2
    //public unsafe SlangResult TryCreateProgram2(in ShaderProgramDesc2 desc, out ShaderProgram? program);

    //TODO: Implement TryCreateGraphicsPipelineState


    [GenerateMarshallingCode<IDevice>(nameof(IDevice.createComputePipelineState))]
    public partial SlangResult TryCreateComputePipelineState(in ComputePipelineStateDesc desc, out PipelineState? pipeline);

    //TODO: Implement TryCreateRayTracingPipelineState


    // MANIPULATION METHODS
    
    public unsafe SlangResult TryReadTextureResource(TextureResource resource,
                                                     ResourceState state,
                                                     out IMemoryOwner<byte> data,
                                                     out nuint rowPitch,
                                                     out nuint pixelSize)
    {
        ISlangBlob* blobPtr = null;
        
        fixed (nuint* rowPitchPtr = &rowPitch)
            fixed (nuint* pixelSizePtr = &pixelSize)
        {
            var res = Pointer->readTextureResource(resource.Pointer, state, &blobPtr, rowPitchPtr, pixelSizePtr).ToSlangResult();

            data = new BlobMemoryManager<byte>(blobPtr);
            return res;
        }
    }

    //TODO: rename when throwing source gen supports generic methods
    public unsafe SlangResult ReadBufferResource<T>(BufferResource resource, Range range, out IMemoryOwner<T>? data) 
        where T : unmanaged
    {
        var byteSize = resource.GetDesc().SizeInBytes;
        ArgumentOutOfRangeException.ThrowIfNotEqual(byteSize % (nuint)sizeof(T), (nuint)0);
        var pair = range.GetOffsetAndLength((int)(byteSize / (nuint)sizeof(T)));
        
        ISlangBlob* blobPtr = null;
        var result = Pointer->readBufferResource(resource.Pointer, (nuint)pair.Offset * (nuint)sizeof(T), (nuint)pair.Length * (nuint)sizeof(T), &blobPtr).ToSlangResult();
        data = result ? new BlobMemoryManager<T>(blobPtr) : null;
        return result;
    }

    public unsafe DeviceInfo GetDeviceInfo()
    {
        var ptrInfo = Pointer->getDeviceInfo();
        DeviceInfo.CreateFromNative(*ptrInfo, out var info);
        return info;
    }

    [GenerateMarshallingCode<IDevice>(nameof(IDevice.createQueryPool))]
    public partial SlangResult TryCreateQueryPool(in QueryPoolDesc desc, out QueryPool? pool);

    //TODO: Implement TryGetAccelerationStructurePrebuildInfo

    //TODO: Implement TryCreateAccelerationStructure

    [GenerateMarshallingCode<IDevice>(nameof(IDevice.createFence))]
    public partial SlangResult TryCreateFence(in FenceDesc desc, out Fence? fence);

    public unsafe SlangResult TryWaitForFences(ReadOnlySpan<Fence> fences, ReadOnlySpan<ulong> values, bool waitForAll, ulong timeout)
    {
        var fencePtrs = stackalloc IFence*[fences.Length];
        for (int i = 0; i < fences.Length; i++)
        {
            fencePtrs[i] = fences[i].Pointer;
        }

        fixed (ulong* pValues = values)
        {
            return Pointer->waitForFences(fences.Length, fencePtrs, pValues, (byte)(waitForAll ? 1 : 0), timeout).ToSlangResult();
        }
    }
    
    //TODO: Implement TryGetTextureAllocationInfo

    [GenerateMarshallingCode<IDevice>(nameof(IDevice.getTextureRowAlignment))]
    public partial SlangResult TryGetTextureRowAlignment(out nuint outAlignment);

    //TODO: Implement TryCreateShaderObject2

    //TODO: Implement TryCreateMutableShaderObject2


    // Additional methods will be implemented for the remaining IDevice interface methods
}


public static class DeviceExtensions
{
    public static unsafe SlangResult TryCreateBufferResource<T>(this Device device, in BufferResourceDesc desc, ReadOnlySpan<T> initData, out BufferResource? resource) where T : unmanaged
    {
        if ((nuint)(initData.Length * sizeof(T)) > desc.SizeInBytes)
        {
            resource = null;
            return SlangResult.InsufficientBuffer;
        }

        fixed (T* pData = initData)
        {
            return device.TryCreateBufferResource(desc, (nint)pData, out resource);
        }
    }
}
