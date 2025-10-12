using System.Runtime.InteropServices.Marshalling;
using ShaderSlang.Net.ComWrappers.Gfx.Interfaces;
using ShaderSlang.Net.ComWrappers.Tools;

namespace ShaderSlang.Net.ComWrappers.Gfx.Descriptions;

[NativeMarshalling(typeof(MarshalableMarshaller.Bidirectional<GraphicsPipelineStateDescription, Unmanaged.GraphicsPipelineStateDesc>))]
public readonly record struct GraphicsPipelineStateDescription(IShaderProgram Program,
                                                               IInputLayout InputLayout,
                                                               IFramebufferLayout FramebufferLayout,
                                                               Unmanaged.PrimitiveType PrimitiveType,
                                                               Unmanaged.DepthStencilDesc DepthStencil,
                                                               Unmanaged.RasterizerDesc Rasterizer,
                                                               BlendDescription Blend)
    : IMarshalsToNative<Unmanaged.GraphicsPipelineStateDesc>,
      IMarshalsFromNative<GraphicsPipelineStateDescription, Unmanaged.GraphicsPipelineStateDesc>,
      IFreeAfterMarshal<Unmanaged.GraphicsPipelineStateDesc>
{
    unsafe Unmanaged.GraphicsPipelineStateDesc IMarshalsToNative<Unmanaged.GraphicsPipelineStateDesc>.AsNative(ref GrowingStackBuffer buffer) =>
        new()
        {
            program = Program.InterfaceToPtr<IShaderProgram, Unmanaged.IShaderProgram>(),
            inputLayout = InputLayout.InterfaceToPtr<IInputLayout, Unmanaged.IInputLayout>(),
            framebufferLayout = FramebufferLayout.InterfaceToPtr<IFramebufferLayout, Unmanaged.IFramebufferLayout>(),
            primitiveType = PrimitiveType,
            depthStencil = DepthStencil,
            rasterizer = Rasterizer,
            blend = ((IMarshalsToNative<Unmanaged.BlendDesc>)Blend).AsNative(ref buffer)
        };

    public static unsafe GraphicsPipelineStateDescription CreateFromNative(Unmanaged.GraphicsPipelineStateDesc unmanaged) =>
        new(ComInterfaceMarshaller<IShaderProgram>.ConvertToManaged(unmanaged.program)!,
            ComInterfaceMarshaller<IInputLayout>.ConvertToManaged(unmanaged.inputLayout)!,
            ComInterfaceMarshaller<IFramebufferLayout>.ConvertToManaged(unmanaged.framebufferLayout)!,
            unmanaged.primitiveType,
            unmanaged.depthStencil,
            unmanaged.rasterizer,
            BlendDescription.CreateFromNative(unmanaged.blend));

    public unsafe void Free(Unmanaged.GraphicsPipelineStateDesc* unmanaged)
    {
        ComInterfaceMarshaller<IShaderProgram>.Free(unmanaged->program);
        ComInterfaceMarshaller<IInputLayout>.Free(unmanaged->inputLayout);
        ComInterfaceMarshaller<IFramebufferLayout>.Free(unmanaged->framebufferLayout);
    }
}