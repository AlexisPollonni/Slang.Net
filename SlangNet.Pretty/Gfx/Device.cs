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
            var nativeDescPtr = nDesc;

            IDevice* natDevice = null;
            var res = gfxCreateDevice(nativeDescPtr, &natDevice).ToSlangResult();
        
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
    
    // Additional methods will be implemented for the remaining IDevice interface methods
}

