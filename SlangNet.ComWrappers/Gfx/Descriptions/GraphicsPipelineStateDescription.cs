using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(typeof(MarshalableMarshaller.Bidirectional<GraphicsPipelineStateDescription, Unmanaged.GraphicsPipelineStateDesc>))]
public readonly record struct GraphicsPipelineStateDescription
    : IMarshalsToNative<Unmanaged.GraphicsPipelineStateDesc>,
      IMarshalsFromNative<GraphicsPipelineStateDescription, Unmanaged.GraphicsPipelineStateDesc>
{
    Unmanaged.GraphicsPipelineStateDesc IMarshalsToNative<Unmanaged.GraphicsPipelineStateDesc>.AsNative(ref GrowingStackBuffer buffer) =>
        throw new NotImplementedException();

    public static GraphicsPipelineStateDescription CreateFromNative(Unmanaged.GraphicsPipelineStateDesc unmanaged) =>
        throw new NotImplementedException();
}