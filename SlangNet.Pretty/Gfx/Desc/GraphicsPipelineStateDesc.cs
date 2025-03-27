using SlangNet.Internal;

namespace SlangNet.Gfx.Desc;

public readonly record struct GraphicsPipelineStateDesc()
    : IMarshalsToNative<Unsafe.GraphicsPipelineStateDesc>
{
    public int GetNativeAllocSize() =>
        throw new System.NotImplementedException();

    public void AsNative(ref MarshallingAllocBuffer buffer, out Unsafe.GraphicsPipelineStateDesc native)
    {
        throw new System.NotImplementedException();
    }
}