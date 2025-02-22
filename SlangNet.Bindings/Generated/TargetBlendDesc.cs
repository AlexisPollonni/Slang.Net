namespace SlangNet.Bindings.Generated;

/// <include file='TargetBlendDesc.xml' path='doc/member[@name="TargetBlendDesc"]/*' />
public partial struct TargetBlendDesc
{
    /// <include file='TargetBlendDesc.xml' path='doc/member[@name="TargetBlendDesc.color"]/*' />
    [NativeTypeName("gfx::AspectBlendDesc")]
    public AspectBlendDesc color;

    /// <include file='TargetBlendDesc.xml' path='doc/member[@name="TargetBlendDesc.alpha"]/*' />
    [NativeTypeName("gfx::AspectBlendDesc")]
    public AspectBlendDesc alpha;

    /// <include file='TargetBlendDesc.xml' path='doc/member[@name="TargetBlendDesc.enableBlend"]/*' />
    [NativeTypeName("bool")]
    public byte enableBlend;

    /// <include file='TargetBlendDesc.xml' path='doc/member[@name="TargetBlendDesc.logicOp"]/*' />
    [NativeTypeName("gfx::LogicOp")]
    public LogicOp logicOp;

    /// <include file='TargetBlendDesc.xml' path='doc/member[@name="TargetBlendDesc.writeMask"]/*' />
    [NativeTypeName("gfx::RenderTargetWriteMaskT")]
    public byte writeMask;
}
