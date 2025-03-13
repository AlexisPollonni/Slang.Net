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
        var nativeDesc = desc.MarshalToNative<DeviceDesc, IDevice.DeviceDesc>();

        var nativeDescPtr = (IDevice.DeviceDesc*)SysUnsafe.AsPointer(ref nativeDesc.DangerousGetValueOrNullReference());
        
        IDevice* natDevice = null;
        var res = gfxCreateDevice(nativeDescPtr, &natDevice).ToSlangResult();
        
            device = res ? new(natDevice) : null;
            return res;
        
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
        using var featureUtf8 = new Utf8String(feature);
        return Pointer->hasFeature(featureUtf8);
    }
    
    public unsafe SlangResult TryGetFeatures(out string[] features)
    {
        int count = 0;
        var result = Pointer->getFeatures(null, 0, &count).ToSlangResult();
        if (!result)
        {
            features = Array.Empty<string>();
            return result;
        }
        
        var featuresArray = new sbyte*[count];
        fixed (sbyte** pFeatures = featuresArray)
        {
            result = Pointer->getFeatures(pFeatures, (nuint)featuresArray.Length, &count).ToSlangResult();
            if (!result)
            {
                features = Array.Empty<string>();
                return result;
            }
            
            features = new string[count];
            for (int i = 0; i < count; i++)
            {
                features[i] = InteropUtils.PtrToStringUTF8(featuresArray[i])!;
            }
            
            return result;
        }
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
    
    public unsafe SlangResult TryCreateTransientResourceHeap(in TransientResourceHeapDesc desc, out TransientResourceHeap? heap)
    {
        var disposable = desc.AsNative(out var nativeDesc);
        using (disposable)
        {
            ITransientResourceHeap* nativeHeap = null;
            var result = Pointer->createTransientResourceHeap(&nativeDesc, &nativeHeap).ToSlangResult();
            heap = result ? new TransientResourceHeap(nativeHeap) : null;
            return result;
        }
    }
    
    public unsafe SlangResult TryCreateBufferResource(in BufferResourceDesc desc, IntPtr initData, out BufferResource? resource)
    {
        var disposable = desc.AsNative(out var nativeDesc);
        using (disposable)
        {
            IBufferResource* nativeResource = null;
            var result = Pointer->createBufferResource(&nativeDesc, (void*)initData, &nativeResource).ToSlangResult();
            resource = result ? new BufferResource(nativeResource) : null;
            return result;
        }
    }
    
    // Additional methods will be implemented for the remaining IDevice interface methods
}

