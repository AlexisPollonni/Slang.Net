namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='GraphicsPipelineStateDesc.xml' path='doc/member[@name="GraphicsPipelineStateDesc"]/*' />
public unsafe partial struct GraphicsPipelineStateDesc
{
    /// <include file='GraphicsPipelineStateDesc.xml' path='doc/member[@name="GraphicsPipelineStateDesc.program"]/*' />
    [NativeTypeName("gfx::IShaderProgram *")]
    public IShaderProgram* program;

    /// <include file='GraphicsPipelineStateDesc.xml' path='doc/member[@name="GraphicsPipelineStateDesc.inputLayout"]/*' />
    [NativeTypeName("gfx::IInputLayout *")]
    public IInputLayout* inputLayout;

    /// <include file='GraphicsPipelineStateDesc.xml' path='doc/member[@name="GraphicsPipelineStateDesc.framebufferLayout"]/*' />
    [NativeTypeName("gfx::IFramebufferLayout *")]
    public IFramebufferLayout* framebufferLayout;

    /// <include file='GraphicsPipelineStateDesc.xml' path='doc/member[@name="GraphicsPipelineStateDesc.primitiveType"]/*' />
    [NativeTypeName("gfx::PrimitiveType")]
    public PrimitiveType primitiveType;

    /// <include file='GraphicsPipelineStateDesc.xml' path='doc/member[@name="GraphicsPipelineStateDesc.depthStencil"]/*' />
    [NativeTypeName("gfx::DepthStencilDesc")]
    public DepthStencilDesc depthStencil;

    /// <include file='GraphicsPipelineStateDesc.xml' path='doc/member[@name="GraphicsPipelineStateDesc.rasterizer"]/*' />
    [NativeTypeName("gfx::RasterizerDesc")]
    public RasterizerDesc rasterizer;

    /// <include file='GraphicsPipelineStateDesc.xml' path='doc/member[@name="GraphicsPipelineStateDesc.blend"]/*' />
    [NativeTypeName("gfx::BlendDesc")]
    public BlendDesc blend;
}
