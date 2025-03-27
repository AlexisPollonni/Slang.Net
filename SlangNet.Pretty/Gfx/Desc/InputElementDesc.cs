using SlangNet.Internal;

namespace SlangNet.Gfx.Desc;

public readonly record struct InputElementDesc(
    string SemanticName,
    int SemanticIndex,
    Format Format,
    nuint Offset,
    int BufferSlotIndex) : IMarshalsToNative<Unsafe.InputElementDesc>
{
    public unsafe int GetNativeAllocSize() => sizeof(Unsafe.InputElementDesc);

    public unsafe void AsNative(ref MarshallingAllocBuffer buffer, out Unsafe.InputElementDesc native)
    {
        native = new()
        {
            semanticName = SemanticName.MarshalToNative(ref buffer),
            semanticIndex = SemanticIndex,
            format = Format,
            offset = Offset,
            bufferSlotIndex = BufferSlotIndex
        };
    }
}