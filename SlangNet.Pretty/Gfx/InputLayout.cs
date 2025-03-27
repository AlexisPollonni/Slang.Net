using System.Collections.Generic;
using System.Linq;
using SlangNet.Internal;
using InputElementDesc = SlangNet.Gfx.Desc.InputElementDesc;

namespace SlangNet.Gfx;

public sealed class InputLayout : COMObject<IInputLayout>
{
    internal unsafe InputLayout(IInputLayout* pointer) : base(pointer) { }
    
    public readonly record struct InputLayoutDesc(IReadOnlyCollection<InputElementDesc> InputElements,
                                                  IReadOnlyList<VertexStreamDesc> VertexStreams)
        : IMarshalsToNative<IInputLayout.InputLayoutDesc>
    {
        public unsafe int GetNativeAllocSize() =>
            sizeof(IInputLayout.InputLayoutDesc)
            + InputElements.Sum(input => input.GetNativeAllocSize()) 
            + VertexStreams.Count * sizeof(VertexStreamDesc);

        public unsafe void AsNative(ref MarshallingAllocBuffer buffer, out IInputLayout.InputLayoutDesc native)
        {
            var vertexStreamsPtr = buffer.AllocForPtr<VertexStreamDesc>(VertexStreams.Count);
            for (var i = 0; i < VertexStreams.Count; i++)
                vertexStreamsPtr[i] = VertexStreams[i];

            native = new()
            {
                inputElements = InputElements.MarshalToNative<InputElementDesc, Unsafe.InputElementDesc>(ref buffer),
                inputElementCount = InputElements.Count,
                vertexStreams = vertexStreamsPtr,
                vertexStreamCount = VertexStreams.Count
            };
        }
    }
}