using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(
    typeof(MarshalableMarshaller.Bidirectional<
        TransientResourceHeapDescription,
        Unmanaged.ITransientResourceHeap.TransientResourceHeapDesc
    >)
)]
public readonly record struct TransientResourceHeapDescription(
    Unmanaged.ITransientResourceHeap.Flags.TransientResourceHeapFlagsEnum Flags =
        Unmanaged.ITransientResourceHeap.Flags.TransientResourceHeapFlagsEnum.None,
    nuint ConstantBufferSize = 0,
    int SamplerDescriptorCount = 0,
    int UavDescriptorCount = 0,
    int SrvDescriptorCount = 0,
    int ConstantBufferDescriptorCount = 0,
    int AccelerationStructureDescriptorCount = 0
)
    : IMarshalsToNative<Unmanaged.ITransientResourceHeap.TransientResourceHeapDesc>,
        IMarshalsFromNative<
            TransientResourceHeapDescription,
            Unmanaged.ITransientResourceHeap.TransientResourceHeapDesc
        >
{
    Unmanaged.ITransientResourceHeap.TransientResourceHeapDesc IMarshalsToNative<Unmanaged.ITransientResourceHeap.TransientResourceHeapDesc>.AsNative(
        ref GrowingStackBuffer buffer
    ) =>
        new()
        {
            flags = Flags,
            constantBufferSize = ConstantBufferSize,
            samplerDescriptorCount = SamplerDescriptorCount,
            uavDescriptorCount = UavDescriptorCount,
            srvDescriptorCount = SrvDescriptorCount,
            constantBufferDescriptorCount = ConstantBufferDescriptorCount,
            accelerationStructureDescriptorCount = AccelerationStructureDescriptorCount,
        };

    public static TransientResourceHeapDescription CreateFromNative(
        Unmanaged.ITransientResourceHeap.TransientResourceHeapDesc unmanaged
    ) =>
        new(
            unmanaged.flags,
            unmanaged.constantBufferSize,
            unmanaged.samplerDescriptorCount,
            unmanaged.uavDescriptorCount,
            unmanaged.srvDescriptorCount,
            unmanaged.constantBufferDescriptorCount,
            unmanaged.accelerationStructureDescriptorCount
        );
}
