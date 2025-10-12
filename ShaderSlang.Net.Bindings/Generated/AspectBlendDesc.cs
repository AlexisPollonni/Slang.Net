namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='AspectBlendDesc.xml' path='doc/member[@name="AspectBlendDesc"]/*' />
public partial struct AspectBlendDesc
{
    /// <include file='AspectBlendDesc.xml' path='doc/member[@name="AspectBlendDesc.srcFactor"]/*' />
    [NativeTypeName("gfx::BlendFactor")]
    public BlendFactor srcFactor;

    /// <include file='AspectBlendDesc.xml' path='doc/member[@name="AspectBlendDesc.dstFactor"]/*' />
    [NativeTypeName("gfx::BlendFactor")]
    public BlendFactor dstFactor;

    /// <include file='AspectBlendDesc.xml' path='doc/member[@name="AspectBlendDesc.op"]/*' />
    [NativeTypeName("gfx::BlendOp")]
    public BlendOp op;
}
