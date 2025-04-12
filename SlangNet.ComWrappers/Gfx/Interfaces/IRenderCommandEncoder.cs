using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.ComWrappers.Tools;

namespace SlangNet.ComWrappers.Gfx.Interfaces;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Custom,
                       StringMarshallingCustomType = typeof(UnownedUTF8StringMarshaller))]
[Guid("7A8D56D0-53E6-4AD6-85F7-D14DC110FDCE")]
public partial interface IRenderCommandEncoder : IResourceCommandEncoder
{
    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult BindPipeline(IPipelineState state, out IShaderObject rootShaderObject);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult BindPipelineWithRootObject(IPipelineState state, IShaderObject rootObject);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult SetViewports(int count, [MarshalUsing(CountElementName = "count")] Span<Unmanaged.Viewport> viewports);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetScissorRects(int count, [MarshalUsing(CountElementName = "count")] Span<Unmanaged.ScissorRect> scissors);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetPrimitiveTopology(Unmanaged.PrimitiveTopology topology);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetVertexBuffer(int startSlot,
                         int slotCount,
                         [MarshalUsing(CountElementName = "slotCount")] Span<IBufferResource> buffers,
                         [MarshalUsing(CountElementName = "slotCount")] Span<nuint> offsets);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetIndexBuffer(IBufferResource buffer, Unmanaged.Format indexFormat, nuint offset = 0);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult Draw(int vertexCount, int startVertex = 0);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult DrawIndexed(int indexCount, int startIndex = 0, int baseVertex = 0);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult DrawIndirect(int maxDrawCount,
                             IBufferResource argBuffer,
                             nuint argOffset,
                             IBufferResource? countBuffer = null,
                             nuint countOffset = 0);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult DrawIndexedIndirect(int maxDrawCount,
                                    IBufferResource argBuffer,
                                    nuint argOffset,
                                    IBufferResource? countBuffer = null,
                                    nuint countOffset = 0);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    void SetStencilReference(uint referenceValue);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult SetSamplePositions(int samplesPerPixel,
                                   int pixelCount,
                                   [MarshalUsing(CountElementName = "pixelCount")] //TODO: this is probably incorrect
                                   Span<Unmanaged.SamplePosition> samplePositions);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult DrawInstanced(int vertexCount, int instanceCount, int startVertex, int startInstanceLocation);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult DrawIndexedInstanced(int indexCount,
                                     int instanceCount,
                                     int startIndexLocation,
                                     int baseVertexLocation,
                                     int startInstanceLocation);

    [PreserveSig, UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall)])]
    SlangResult DrawMeshTasks(int x, int y, int z);
}