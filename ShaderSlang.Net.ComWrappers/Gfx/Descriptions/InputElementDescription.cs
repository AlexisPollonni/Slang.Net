using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(
    typeof(BidirectionalMarshaller<InputElementDescription, Unmanaged.InputElementDesc>)
)]
public readonly record struct InputElementDescription(
    string SemanticName,
    int SemanticIndex,
    Unmanaged.Format Format,
    nuint Offset,
    int BufferSlotIndex
)
    : IMarshalsToNative<Unmanaged.InputElementDesc>,
        IMarshalsFromNative<InputElementDescription, Unmanaged.InputElementDesc>
{
    unsafe Unmanaged.InputElementDesc IMarshalsToNative<Unmanaged.InputElementDesc>.AsNative(
        ref GrowingStackBuffer buffer
    ) =>
        new()
        {
            semanticName = buffer.GetStringPtr(SemanticName),
            semanticIndex = SemanticIndex,
            format = Format,
            offset = Offset,
            bufferSlotIndex = BufferSlotIndex,
        };

    public static unsafe InputElementDescription CreateFromNative(
        Unmanaged.InputElementDesc unmanaged
    ) =>
        new(
            InteropUtils.PtrToStringUtf8(unmanaged.semanticName) ?? "",
            unmanaged.semanticIndex,
            unmanaged.format,
            unmanaged.offset,
            unmanaged.bufferSlotIndex
        );
}
