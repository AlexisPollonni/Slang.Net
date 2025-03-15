using System;
using Nito.Disposables;
using SlangNet.Internal;

namespace SlangNet.Gfx.Desc;

public record struct TransientResourceHeapDesc(
    ITransientResourceHeap.Flags.TransientResourceHeapFlagsEnum Flags = ITransientResourceHeap.Flags.TransientResourceHeapFlagsEnum.None,
    nuint ConstantBufferSize = 0,
    int SamplerDescriptorCount = 0,
    int UavDescriptorCount = 0,
    int SrvDescriptorCount = 0,
    int ConstantBufferDescriptorCount = 0,
    int AccelerationStructureDescriptorCount = 0
) : IMarshalsToNative<ITransientResourceHeap.TransientResourceHeapDesc>, IMarshalsFromNative<TransientResourceHeapDesc, ITransientResourceHeap.TransientResourceHeapDesc>
{
    public readonly int GetNativeAllocSize()
    {
        return SysUnsafe.SizeOf<ITransientResourceHeap.TransientResourceHeapDesc>();
    }
    
    
    public unsafe void AsNative(ref MarshallingAllocBuffer buffer, out ITransientResourceHeap.TransientResourceHeapDesc native)
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
    }
    
    public static unsafe void CreateFromNative(ITransientResourceHeap.TransientResourceHeapDesc native, out TransientResourceHeapDesc desc)
    {
        desc = new TransientResourceHeapDesc(
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