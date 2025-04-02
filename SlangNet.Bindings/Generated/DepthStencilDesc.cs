namespace SlangNet.Bindings.Generated;

/// <include file='DepthStencilDesc.xml' path='doc/member[@name="DepthStencilDesc"]/*' />
public partial struct DepthStencilDesc
{
    /// <include file='DepthStencilDesc.xml' path='doc/member[@name="DepthStencilDesc.depthTestEnable"]/*' />
    [NativeTypeName("bool")]
    public Boolean depthTestEnable;

    /// <include file='DepthStencilDesc.xml' path='doc/member[@name="DepthStencilDesc.depthWriteEnable"]/*' />
    [NativeTypeName("bool")]
    public Boolean depthWriteEnable;

    /// <include file='DepthStencilDesc.xml' path='doc/member[@name="DepthStencilDesc.depthFunc"]/*' />
    [NativeTypeName("gfx::ComparisonFunc")]
    public ComparisonFunc depthFunc;

    /// <include file='DepthStencilDesc.xml' path='doc/member[@name="DepthStencilDesc.stencilEnable"]/*' />
    [NativeTypeName("bool")]
    public Boolean stencilEnable;

    /// <include file='DepthStencilDesc.xml' path='doc/member[@name="DepthStencilDesc.stencilReadMask"]/*' />
    [NativeTypeName("uint32_t")]
    public uint stencilReadMask;

    /// <include file='DepthStencilDesc.xml' path='doc/member[@name="DepthStencilDesc.stencilWriteMask"]/*' />
    [NativeTypeName("uint32_t")]
    public uint stencilWriteMask;

    /// <include file='DepthStencilDesc.xml' path='doc/member[@name="DepthStencilDesc.frontFace"]/*' />
    [NativeTypeName("gfx::DepthStencilOpDesc")]
    public DepthStencilOpDesc frontFace;

    /// <include file='DepthStencilDesc.xml' path='doc/member[@name="DepthStencilDesc.backFace"]/*' />
    [NativeTypeName("gfx::DepthStencilOpDesc")]
    public DepthStencilOpDesc backFace;

    /// <include file='DepthStencilDesc.xml' path='doc/member[@name="DepthStencilDesc.stencilRef"]/*' />
    [NativeTypeName("uint32_t")]
    public uint stencilRef;
}
