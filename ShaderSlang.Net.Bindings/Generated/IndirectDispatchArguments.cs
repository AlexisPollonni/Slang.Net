namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='IndirectDispatchArguments.xml' path='doc/member[@name="IndirectDispatchArguments"]/*' />
public partial struct IndirectDispatchArguments
{
    /// <include file='IndirectDispatchArguments.xml' path='doc/member[@name="IndirectDispatchArguments.ThreadGroupCountX"]/*' />
    [NativeTypeName("gfx::GfxCount")]
    public int ThreadGroupCountX;

    /// <include file='IndirectDispatchArguments.xml' path='doc/member[@name="IndirectDispatchArguments.ThreadGroupCountY"]/*' />
    [NativeTypeName("gfx::GfxCount")]
    public int ThreadGroupCountY;

    /// <include file='IndirectDispatchArguments.xml' path='doc/member[@name="IndirectDispatchArguments.ThreadGroupCountZ"]/*' />
    [NativeTypeName("gfx::GfxCount")]
    public int ThreadGroupCountZ;
}
