namespace SlangNet.Bindings.Generated;

/// <include file='IndirectDrawArguments.xml' path='doc/member[@name="IndirectDrawArguments"]/*' />
public partial struct IndirectDrawArguments
{
    /// <include file='IndirectDrawArguments.xml' path='doc/member[@name="IndirectDrawArguments.VertexCountPerInstance"]/*' />
    [NativeTypeName("gfx::GfxCount")]
    public int VertexCountPerInstance;

    /// <include file='IndirectDrawArguments.xml' path='doc/member[@name="IndirectDrawArguments.InstanceCount"]/*' />
    [NativeTypeName("gfx::GfxCount")]
    public int InstanceCount;

    /// <include file='IndirectDrawArguments.xml' path='doc/member[@name="IndirectDrawArguments.StartVertexLocation"]/*' />
    [NativeTypeName("gfx::GfxIndex")]
    public int StartVertexLocation;

    /// <include file='IndirectDrawArguments.xml' path='doc/member[@name="IndirectDrawArguments.StartInstanceLocation"]/*' />
    [NativeTypeName("gfx::GfxIndex")]
    public int StartInstanceLocation;
}
