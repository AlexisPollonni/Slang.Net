namespace SlangNet.Bindings.Generated;

/// <include file='DepthStencilOpDesc.xml' path='doc/member[@name="DepthStencilOpDesc"]/*' />
public partial struct DepthStencilOpDesc
{
    /// <include file='DepthStencilOpDesc.xml' path='doc/member[@name="DepthStencilOpDesc.stencilFailOp"]/*' />
    [NativeTypeName("gfx::StencilOp")]
    public StencilOp stencilFailOp;

    /// <include file='DepthStencilOpDesc.xml' path='doc/member[@name="DepthStencilOpDesc.stencilDepthFailOp"]/*' />
    [NativeTypeName("gfx::StencilOp")]
    public StencilOp stencilDepthFailOp;

    /// <include file='DepthStencilOpDesc.xml' path='doc/member[@name="DepthStencilOpDesc.stencilPassOp"]/*' />
    [NativeTypeName("gfx::StencilOp")]
    public StencilOp stencilPassOp;

    /// <include file='DepthStencilOpDesc.xml' path='doc/member[@name="DepthStencilOpDesc.stencilFunc"]/*' />
    [NativeTypeName("gfx::ComparisonFunc")]
    public ComparisonFunc stencilFunc;
}
