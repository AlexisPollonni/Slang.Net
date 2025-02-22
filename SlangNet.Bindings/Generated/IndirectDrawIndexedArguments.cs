namespace SlangNet.Bindings.Generated;

/// <include file='IndirectDrawIndexedArguments.xml' path='doc/member[@name="IndirectDrawIndexedArguments"]/*' />
public partial struct IndirectDrawIndexedArguments
{
    /// <include file='IndirectDrawIndexedArguments.xml' path='doc/member[@name="IndirectDrawIndexedArguments.IndexCountPerInstance"]/*' />
    [NativeTypeName("gfx::GfxCount")]
    public int IndexCountPerInstance;

    /// <include file='IndirectDrawIndexedArguments.xml' path='doc/member[@name="IndirectDrawIndexedArguments.InstanceCount"]/*' />
    [NativeTypeName("gfx::GfxCount")]
    public int InstanceCount;

    /// <include file='IndirectDrawIndexedArguments.xml' path='doc/member[@name="IndirectDrawIndexedArguments.StartIndexLocation"]/*' />
    [NativeTypeName("gfx::GfxIndex")]
    public int StartIndexLocation;

    /// <include file='IndirectDrawIndexedArguments.xml' path='doc/member[@name="IndirectDrawIndexedArguments.BaseVertexLocation"]/*' />
    [NativeTypeName("gfx::GfxIndex")]
    public int BaseVertexLocation;

    /// <include file='IndirectDrawIndexedArguments.xml' path='doc/member[@name="IndirectDrawIndexedArguments.StartInstanceLocation"]/*' />
    [NativeTypeName("gfx::GfxIndex")]
    public int StartInstanceLocation;
}
