using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(
    typeof(MarshalableMarshaller.Bidirectional<
        BufferResourceDescription,
        Unmanaged.IBufferResource.BufferResourceDesc
    >)
)]
public readonly record struct BufferResourceDescription(
    ResourceDescriptionBase Base,
    nuint SizeInBytes = 0,
    nuint ElementSize = 0,
    Unmanaged.Format Format = Unmanaged.Format.Unknown
)
    : IMarshalsToNative<Unmanaged.IBufferResource.BufferResourceDesc>,
        IMarshalsFromNative<BufferResourceDescription, Unmanaged.IBufferResource.BufferResourceDesc>
{
    Unmanaged.IBufferResource.BufferResourceDesc IMarshalsToNative<Unmanaged.IBufferResource.BufferResourceDesc>.AsNative(
        ref GrowingStackBuffer buffer
    )
    {
        var nativeBase = ((IMarshalsToNative<Unmanaged.IResource.DescBase>)Base).AsNative(
            ref buffer
        );

        return new()
        {
            Base = nativeBase,
            sizeInBytes = SizeInBytes,
            elementSize = ElementSize,
            format = Format,
        };
    }

    public static BufferResourceDescription CreateFromNative(
        Unmanaged.IBufferResource.BufferResourceDesc unmanaged
    )
    {
        var baseDesc = ResourceDescriptionBase.CreateFromNative(unmanaged.Base);

        return new(baseDesc, unmanaged.sizeInBytes, unmanaged.elementSize, unmanaged.format);
    }
}
