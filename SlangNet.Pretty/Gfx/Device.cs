using System;
using System.Linq;
using System.Runtime.CompilerServices;
using CommunityToolkit.HighPerformance;
using SlangNet.Gfx.Desc;
using SlangNet.Internal;

namespace SlangNet.Gfx;


[GenerateThrowingMethods]
public partial class Device : COMObject<IDevice>
{
    internal unsafe Device(IDevice* pointer) : base(pointer)
    { }



    public static unsafe SlangResult TryCreate(in DeviceDesc desc, out Device? device)
    {
        var res = desc.MarshalToNative<DeviceDesc, IDevice.DeviceDesc, Device?>(nDesc => 
        {
            IDevice* natDevice = null;
            var res = gfxCreateDevice(nDesc, &natDevice).ToSlangResult();
        
            var d = res ? new Device(natDevice) : null;
            return (res, d);
        });

        device = res.Item2;
        return res.Item1;
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
        var res = desc.MarshalToNative<TransientResourceHeapDesc, ITransientResourceHeap.TransientResourceHeapDesc, TransientResourceHeap?>(descPtr => 
        {
            ITransientResourceHeap* nativeHeap = null;
            var result = Pointer->createTransientResourceHeap(descPtr, &nativeHeap).ToSlangResult();

            return (result, result ? new TransientResourceHeap(nativeHeap) : null);
        });

        heap = res.Item2;
        return res.Item1;
    }
    
    public unsafe SlangResult TryCreateBufferResource(in BufferResourceDesc desc, IntPtr initData, out BufferResource? resource)
    {
        var res = desc.MarshalToNative<BufferResourceDesc, IBufferResource.BufferResourceDesc, BufferResource?>(descPtr => 
        {
            IBufferResource* nativeResource = null;
            var result = Pointer->createBufferResource(descPtr, (void*)initData, &nativeResource).ToSlangResult();
            return (result, result ? new BufferResource(nativeResource) : null);
        });

        resource = res.Item2;
        return res.Item1;
    }

    // public unsafe SlangResult TryCreateBufferView(in BufferViewDesc desc, out BufferView? view)
    // {
    //     IBufferView* nativeView = null;
    //     var result = Pointer->createBufferView(desc, &nativeView).ToSlangResult();
    //     view = result ? new BufferView(nativeView) : null;
    //     return result;
    // }

    public unsafe SlangResult TryCreateProgram(in ShaderProgramDesc desc, out ShaderProgram? program)
    {
        var res = desc.MarshalToNative<ShaderProgramDesc, IShaderProgram.ShaderProgramDesc, ShaderProgram?>(descPtr => 
        {
            IShaderProgram* nativeProgram = null;
            var result = Pointer->createProgram(descPtr, &nativeProgram).ToSlangResult();
            return (result, result ? new ShaderProgram(nativeProgram) : null);
        });

        program = res.Item2;
        return res.Item1;
    }

    // public unsafe SlangResult TryCreateComputePipelineState(in ComputePipelineStateDesc desc, out ComputePipelineState? pipeline)
    // {
    //     IComputePipelineState* nativePipeline = null;
    //     var result = Pointer->createComputePipelineState(desc, &nativePipeline).ToSlangResult();
    //     pipeline = result ? new ComputePipelineState(nativePipeline) : null;
    //     return result;
    // }

    // public unsafe SlangResult TryCreateCommandQueue(in CommandQueueDesc desc, out CommandQueue? queue)
    // {
    //     ICommandQueue* nativeQueue = null;
    //     var result = Pointer->createCommandQueue(desc, &nativeQueue).ToSlangResult();
    //     queue = result ? new CommandQueue(nativeQueue) : null;
    //     return result;
    // }

    public unsafe SlangResult TryCreateShaderObject(TypeReflection type, ShaderObjectContainerType container, out ShaderObject? shaderObject)
    {
        IShaderObject* nativeShaderObject = null;
        var result = Pointer->createShaderObject(type.Pointer, container, &nativeShaderObject).ToSlangResult();
        shaderObject = result ? new ShaderObject(nativeShaderObject) : null;
        return result;
    }
    

    // MANIPULATION METHODS

    // public unsafe SlangResult TryReadBufferResource(BufferResource resource, nuint offset, nuint size, byte* data)
    // {
    //     ISlangBlob* blobPtr = null;

    //     var result = Pointer->readBufferResource(resource.Pointer, offset, size, &blobPtr).ToSlangResult();
    //     if (!result)
    //     {
    //         return result;
    //     }

    //     blobPtr->

    //     return result;
    // }

    // Additional methods will be implemented for the remaining IDevice interface methods
}

