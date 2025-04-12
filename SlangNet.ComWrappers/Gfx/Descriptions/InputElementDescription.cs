using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(typeof(MarshalableMarshaller.Bidirectional<InputElementDescription, Unmanaged.InputElementDesc>))]
public readonly record struct InputElementDescription(
    string SemanticName,
    int SemanticIndex,
    Unmanaged.Format Format,
    nuint Offset,
    int BufferSlotIndex) : IMarshalsToNative<Unmanaged.InputElementDesc>,
                           IMarshalsFromNative<InputElementDescription, Unmanaged.InputElementDesc>
{
    unsafe Unmanaged.InputElementDesc IMarshalsToNative<Unmanaged.InputElementDesc>.AsNative(ref GrowingStackBuffer buffer) =>
        new()
        {
            semanticName = buffer.GetStringPtr(SemanticName),
            semanticIndex = SemanticIndex,
            format = Format,
            offset = Offset,
            bufferSlotIndex = BufferSlotIndex
        };

    public static unsafe InputElementDescription CreateFromNative(Unmanaged.InputElementDesc unmanaged) =>
        new(InteropUtils.PtrToStringUtf8(unmanaged.semanticName) ?? "",
            unmanaged.semanticIndex,
            unmanaged.format,
            unmanaged.offset,
            unmanaged.bufferSlotIndex);
}