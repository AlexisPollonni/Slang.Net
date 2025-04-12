using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(typeof(MarshalableMarshaller.Bidirectional<InputLayoutDescription, Unmanaged.IInputLayout.InputLayoutDesc>))]
public readonly record struct InputLayoutDescription(IReadOnlyCollection<InputElementDescription> InputElements,
                                                     IReadOnlyList<Unmanaged.VertexStreamDesc> VertexStreams)
    : IMarshalsToNative<Unmanaged.IInputLayout.InputLayoutDesc>,
      IMarshalsFromNative<InputLayoutDescription, Unmanaged.IInputLayout.InputLayoutDesc>
{
    unsafe Unmanaged.IInputLayout.InputLayoutDesc IMarshalsToNative<Unmanaged.IInputLayout.InputLayoutDesc>.AsNative(ref GrowingStackBuffer buffer)
    {
        return new()
        {
            inputElements = buffer.GetCollectionPtr<InputElementDescription, Unmanaged.InputElementDesc>(InputElements, out var inElementsCount),
            inputElementCount = (int)inElementsCount,
            vertexStreams = buffer.GetCollectionPtr(VertexStreams, out var vertexStreamsCount),
            vertexStreamCount = (int)vertexStreamsCount
        };
    }

    public static unsafe InputLayoutDescription CreateFromNative(Unmanaged.IInputLayout.InputLayoutDesc unmanaged) =>
        new(InteropUtils.PtrToManagedMarshal<InputElementDescription, Unmanaged.InputElementDesc>(unmanaged.inputElements, unmanaged.inputElementCount) ?? [],
            new ReadOnlySpan<Unmanaged.VertexStreamDesc>(unmanaged.vertexStreams, unmanaged.vertexStreamCount).ToArray());
}