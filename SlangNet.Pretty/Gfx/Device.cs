using System;
using System.Buffers;
using CommunityToolkit.HighPerformance;
using Nito.Disposables;
using SlangNet.Gfx.Desc;
using SlangNet.Internal;
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
    
    public unsafe SlangResult TryGetNativeDeviceHandles(out IDevice.InteropHandles handles)
    {
        fixed (IDevice.InteropHandles* pHandles = &handles)
        {
            return Pointer->getNativeDeviceHandles(pHandles).ToSlangResult();
        }
    }
    
    public unsafe bool HasFeature(string feature)
    {
        return feature.MarshalToNative(ptr => Pointer->hasFeature(ptr));
    }
    
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
    
    public unsafe SlangResult TryGetSlangSession(out Session? session)
    {
        ISession* nativeSession = null;
        var result = Pointer->getSlangSession(&nativeSession).ToSlangResult();
        session = result ? new Session(nativeSession) : null;
        return result;
    }
    

    // CREATE RESOURCES METHODS

    public unsafe SlangResult TryCreateTransientResourceHeap(in TransientResourceHeapDesc desc, out TransientResourceHeap? heap)
    {
        return desc.MarshalToNative<TransientResourceHeapDesc, ITransientResourceHeap.TransientResourceHeapDesc, TransientResourceHeap?>( out heap, descPtr => 
        {
            ITransientResourceHeap* nativeHeap = null;
            var result = Pointer->createTransientResourceHeap(descPtr, &nativeHeap).ToSlangResult();

            return (result, result ? new TransientResourceHeap(nativeHeap) : null);
        });
    }

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
    
    public unsafe SlangResult TryCreateTextureFromNativeHandle(InteropHandle handle,
                                                               in TextureResourceDesc srcDesc,
                                                               out TextureResource? texture)
    {
        return srcDesc.MarshalToNative<TextureResourceDesc, ITextureResource.TextureResourceDesc, TextureResource?>(out texture, ptr =>
        {
          ITextureResource* nativeTexture = null;
          var res = Pointer->createTextureFromNativeHandle(handle, ptr, &nativeTexture)
              .ToSlangResult();
          return (res, res ? new TextureResource(nativeTexture) : null);
        });
    }
    
    public unsafe SlangResult TryCreateTextureFromSharedHandle(InteropHandle handle,
                                                               TextureResourceDesc srcDesc,
                                                               nuint size,
                                                               out TextureResource? texture)
    {
        return srcDesc.MarshalToNative<TextureResourceDesc, ITextureResource.TextureResourceDesc, TextureResource?>(out texture, ptr =>
        {
            ITextureResource* nativeTexture = null;
            var res = Pointer->createTextureFromSharedHandle(handle, ptr, size, &nativeTexture)
                .ToSlangResult();
            return (res, res ? new TextureResource(nativeTexture) : null);
        });
    }
    
    
    public unsafe SlangResult TryCreateBufferResource(in BufferResourceDesc desc, IntPtr initData, out BufferResource? resource)
    {
        return desc.MarshalToNative<BufferResourceDesc, IBufferResource.BufferResourceDesc, BufferResource?>(out resource, descPtr => 
        {
            IBufferResource* nativeResource = null;
            var result = Pointer->createBufferResource(descPtr, (void*)initData, &nativeResource).ToSlangResult();
            return (result, result ? new BufferResource(nativeResource) : null);
        });
    }

    public unsafe SlangResult TryCreateBufferFromNativeHandle(InteropHandle handle, in BufferResourceDesc desc, out BufferResource? resource)
    {
        return desc.MarshalToNative<BufferResourceDesc, IBufferResource.BufferResourceDesc, BufferResource?>(out resource, descPtr => 
        {
            IBufferResource* nativeResource = null;
            var result = Pointer->createBufferFromNativeHandle(handle, descPtr, &nativeResource).ToSlangResult();
            return (result, result ? new BufferResource(nativeResource) : null);
        });
    }

    public unsafe SlangResult TryCreateBufferFromSharedHandle(InteropHandle handle, in BufferResourceDesc desc, out BufferResource? resource)
    {
        return desc.MarshalToNative<BufferResourceDesc, IBufferResource.BufferResourceDesc, BufferResource?>(out resource, descPtr => 
        {
            IBufferResource* nativeResource = null;
            var result = Pointer->createBufferFromSharedHandle(handle, descPtr, &nativeResource).ToSlangResult();
            return (result, result ? new BufferResource(nativeResource) : null);
        });
    }

    //TODO: Implement TryCreateSamplerState
    //TODO: Implement TryCreateTextureView

    public unsafe SlangResult TryCreateBufferView(BufferResource buffer, BufferResource? counterBuffer, in ResourceViewDesc desc, out ResourceView? view)
    {
        return desc.MarshalToNative<ResourceViewDesc, IResourceView.ResourceViewDesc, ResourceView?>(out view, descPtr => 
        {
            IResourceView* nativeView = null;
            var result = Pointer->createBufferView((IBufferResource*)buffer.Pointer, (IBufferResource*)counterBuffer.AsNullablePtr(), descPtr, &nativeView).ToSlangResult();
            return (result, result ? new ResourceView(nativeView) : null);
        });

    }

    //TODO: Implement TryCreateFrameBufferLayout
    //TODO: Implement TryCreateFrameBuffer
    //TODO: Implement TryCreateRenderPassLayout

    public unsafe SlangResult TryCreateSwapchain(SwapchainDesc desc, WindowHandle window, out Swapchain? swapchain)
    {
        return desc.MarshalToNative<SwapchainDesc, ISwapchain.SwapchainDesc, Swapchain?>(out swapchain, descPtr =>
        {
            ISwapchain* nativeSwapchain = null;
            var result = Pointer->createSwapchain(descPtr, window, &nativeSwapchain).ToSlangResult();
            return (result, result ? new Swapchain(nativeSwapchain) : null);
        });
    }

    //TODO: Implement TryCreateInputLayout

    public unsafe SlangResult TryCreateCommandQueue(in CommandQueueDesc desc, out CommandQueue? queue)
    {
        return desc.MarshalToNative<CommandQueueDesc, ICommandQueue.CommandQueueDesc, CommandQueue?>(out queue, descPtr => 
        {
            ICommandQueue* nativeQueue = null;
            var result = Pointer->createCommandQueue(descPtr, &nativeQueue).ToSlangResult();
            return (result, result ? new CommandQueue(nativeQueue) : null);
        });
    }

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

    public unsafe SlangResult TryCreateMutableRootShaderObject(ShaderProgram program, out ShaderObject? shaderObject)
    {
        IShaderObject* nativeShaderObject = null;
        var result = Pointer->createMutableRootShaderObject(program.Pointer, &nativeShaderObject).ToSlangResult();
        shaderObject = result ? new ShaderObject(nativeShaderObject) : null;
        return result;
    }

    //TODO: Implement TryCreateShaderTable

    public unsafe SlangResult TryCreateProgram(in ShaderProgramDesc desc, out ShaderProgram? program)
    {
        return desc.MarshalToNative<ShaderProgramDesc, IShaderProgram.ShaderProgramDesc, ShaderProgram?>(out program, descPtr => 
        {
            IShaderProgram* nativeProgram = null;
            var result = Pointer->createProgram(descPtr, &nativeProgram).ToSlangResult();
            return (result, result ? new ShaderProgram(nativeProgram) : null);
        });
    }

    //TODO: Implement TryCreateProgram2
    //public unsafe SlangResult TryCreateProgram2(in ShaderProgramDesc2 desc, out ShaderProgram? program);

    //TODO: Implement TryCreateGraphicsPipelineState

    public unsafe SlangResult TryCreateComputePipelineState(in ComputePipelineStateDesc desc, out PipelineState? pipeline)
    {
        return desc.MarshalToNative<ComputePipelineStateDesc, Unsafe.ComputePipelineStateDesc, PipelineState?>(out pipeline, descPtr => 
        {
            IPipelineState* nativePipeline = null;
            var result = Pointer->createComputePipelineState(descPtr, &nativePipeline).ToSlangResult();
            return (result, result ? new PipelineState(nativePipeline) : null);
        });
    }

    //TODO: Implement TryCreateRayTracingPipelineState


    // MANIPULATION METHODS

    //TODO: Implement ReadTextureResource
    public unsafe SlangResult TryReadTextureResource(TextureResource resource,
                                                     ResourceState state,
                                                     out MemoryManager<byte> data,
                                                     out nuint rowPitch,
                                                     out nuint pixelSize)
    {
        ISlangBlob* blobPtr = null;
        
        fixed (nuint* rowPitchPtr = &rowPitch)
            fixed (nuint* pixelSizePtr = &pixelSize)
        {
            var res = Pointer->readTextureResource(resource.Pointer, state, &blobPtr, rowPitchPtr, pixelSizePtr).ToSlangResult();

            data = new BlobMemoryManager(blobPtr);
            return res;
        }
    }

    public unsafe SlangResult TryReadBufferResource(BufferResource resource, Span<byte> data, nuint offset = 0)
    {
        ISlangBlob* blobPtr = null;

        var result = Pointer->readBufferResource((IBufferResource*)resource.Pointer, offset, (nuint)data.Length, &blobPtr).ToSlangResult();
        if (!result)
        {
            return result;
        }

        var blobSpan = new Span<byte>(blobPtr->getBufferPointer(), (int)blobPtr->getBufferSize());
        blobSpan.CopyTo(data);
        blobPtr->release();

        return result;
    }

    public Span<T> ReadBufferResource<T>(BufferResource resource, nuint offset, int size) where T : unmanaged
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(size % SysUnsafe.SizeOf<T>(), 0);

        var byteSize = (nuint)size * (nuint)SysUnsafe.SizeOf<T>();

        var data = new byte[byteSize];

        TryReadBufferResource(resource, data, offset).ThrowIfFailed();
        return data.AsSpan().Cast<byte, T>();
    }

    public Span<T> ReadBufferResource<T>(BufferResource resource) where T : unmanaged
    {
        var size = resource.GetDesc().SizeInBytes;
        return ReadBufferResource<T>(resource, 0, checked((int)size));
    }

    public unsafe DeviceInfo GetDeviceInfo()
    {
        var ptrInfo = Pointer->getDeviceInfo();
        DeviceInfo.CreateFromNative(*ptrInfo, out var info);
        return info;
    }

    public unsafe SlangResult TryCreateQueryPool(in QueryPoolDesc desc, out QueryPool? pool)
    {
        return desc.MarshalToNative<QueryPoolDesc, IQueryPool.QueryPoolDesc, QueryPool?>(out pool, descPtr => 
        {
            IQueryPool* nativePool = null;
            var result = Pointer->createQueryPool(descPtr, &nativePool).ToSlangResult();
            return (result, result ? new QueryPool(nativePool) : null);
        });
    }

    //TODO: Implement TryGetAccelerationStructurePrebuildInfo

    //TODO: Implement TryCreateAccelerationStructure

    public unsafe SlangResult TryCreateFence(in FenceDesc desc, out Fence? fence)
    {
        return desc.MarshalToNative<FenceDesc, IFence.FenceDesc, Fence?>(out fence, descPtr => 
        {
            IFence* nativeFence = null;
            var result = Pointer->createFence(descPtr, &nativeFence).ToSlangResult();
            return (result, result ? new Fence(nativeFence) : null);
        });
    }

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

    public unsafe SlangResult TryGetTextureRowAlignment(out nuint outAlignment)
    {
        fixed (nuint* pOutAlignment = &outAlignment)
        {
            return Pointer->getTextureRowAlignment(pOutAlignment).ToSlangResult();
        }
    }

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
