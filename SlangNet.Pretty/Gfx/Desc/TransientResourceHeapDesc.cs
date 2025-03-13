using System;
using Nito.Disposables;

namespace SlangNet.Gfx.Desc;

public record struct TransientResourceHeapDesc(
    ITransientResourceHeap.Flags.TransientResourceHeapFlagsEnum Flags = ITransientResourceHeap.Flags.TransientResourceHeapFlagsEnum.None,
    nuint ConstantBufferSize = 0,
    int SamplerDescriptorCount = 0,
    int UavDescriptorCount = 0,
    int SrvDescriptorCount = 0,
    int ConstantBufferDescriptorCount = 0,
    int AccelerationStructureDescriptorCount = 0
)
{
    public IDisposable AsNative(out ITransientResourceHeap.TransientResourceHeapDesc native)
    {
        native = new ITransientResourceHeap.TransientResourceHeapDesc
        {
            flags = Flags,
            constantBufferSize = ConstantBufferSize,
            samplerDescriptorCount = SamplerDescriptorCount,
            uavDescriptorCount = UavDescriptorCount,
            srvDescriptorCount = SrvDescriptorCount,
            constantBufferDescriptorCount = ConstantBufferDescriptorCount,
            accelerationStructureDescriptorCount = AccelerationStructureDescriptorCount
        };
        
        return NoopDisposable.Instance;
    }
    
    public static TransientResourceHeapDesc CreateFromNative(ITransientResourceHeap.TransientResourceHeapDesc native)
    {
        return new TransientResourceHeapDesc(
            native.flags,
            native.constantBufferSize,
            native.samplerDescriptorCount,
            native.uavDescriptorCount,
            native.srvDescriptorCount,
            native.constantBufferDescriptorCount,
            native.accelerationStructureDescriptorCount
        );
    }
}