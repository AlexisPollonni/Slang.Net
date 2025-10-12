namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='ClearValue.xml' path='doc/member[@name="ClearValue"]/*' />
public partial struct ClearValue
{
    /// <include file='ClearValue.xml' path='doc/member[@name="ClearValue.color"]/*' />
    [NativeTypeName("gfx::ColorClearValue")]
    public ColorClearValue color;

    /// <include file='ClearValue.xml' path='doc/member[@name="ClearValue.depthStencil"]/*' />
    [NativeTypeName("gfx::DepthStencilClearValue")]
    public DepthStencilClearValue depthStencil;
}
