namespace SlangNet.Bindings.Generated;

/// <include file='VertexStreamDesc.xml' path='doc/member[@name="VertexStreamDesc"]/*' />
public partial struct VertexStreamDesc
{
    /// <include file='VertexStreamDesc.xml' path='doc/member[@name="VertexStreamDesc.stride"]/*' />
    [NativeTypeName("gfx::Size")]
    public nuint stride;

    /// <include file='VertexStreamDesc.xml' path='doc/member[@name="VertexStreamDesc.slotClass"]/*' />
    [NativeTypeName("gfx::InputSlotClass")]
    public InputSlotClass slotClass;

    /// <include file='VertexStreamDesc.xml' path='doc/member[@name="VertexStreamDesc.instanceDataStepRate"]/*' />
    [NativeTypeName("gfx::GfxCount")]
    public int instanceDataStepRate;
}
