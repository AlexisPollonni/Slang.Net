using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Gfx.Interfaces;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(
    typeof(BidirectionalMarshaller<
        ComputePipelineStateDescription,
        Unmanaged.ComputePipelineStateDesc
    >)
)]
public readonly record struct ComputePipelineStateDescription(
    IShaderProgram? Program,
    nint D3D12RootSignatureOverride = 0
)
    : IMarshalsToNative<Unmanaged.ComputePipelineStateDesc>,
        IMarshalsFromNative<ComputePipelineStateDescription, Unmanaged.ComputePipelineStateDesc>,
        IFreeAfterMarshal<Unmanaged.ComputePipelineStateDesc>
{
    unsafe Unmanaged.ComputePipelineStateDesc IMarshalsToNative<Unmanaged.ComputePipelineStateDesc>.AsNative(
        ref GrowingStackBuffer buffer
    ) =>
        new()
        {
            program = (Unmanaged.IShaderProgram*)
                ComInterfaceMarshaller<IShaderProgram>.ConvertToUnmanaged(Program),
            d3d12RootSignatureOverride = (void*)D3D12RootSignatureOverride,
        };

    public static unsafe ComputePipelineStateDescription CreateFromNative(
        Unmanaged.ComputePipelineStateDesc unmanaged
    ) =>
        new(
            ComInterfaceMarshaller<IShaderProgram>.ConvertToManaged(unmanaged.program),
            (nint)unmanaged.d3d12RootSignatureOverride
        );

    public static unsafe void Free(scoped ref readonly Unmanaged.ComputePipelineStateDesc unmanaged) =>
        ComInterfaceMarshaller<IShaderProgram>.Free(unmanaged.program);
}