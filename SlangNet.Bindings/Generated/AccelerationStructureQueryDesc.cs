namespace SlangNet.Bindings.Generated;

/// <include file='AccelerationStructureQueryDesc.xml' path='doc/member[@name="AccelerationStructureQueryDesc"]/*' />
public unsafe partial struct AccelerationStructureQueryDesc
{
    /// <include file='AccelerationStructureQueryDesc.xml' path='doc/member[@name="AccelerationStructureQueryDesc.queryType"]/*' />
    [NativeTypeName("gfx::QueryType")]
    public QueryType queryType;

    /// <include file='AccelerationStructureQueryDesc.xml' path='doc/member[@name="AccelerationStructureQueryDesc.queryPool"]/*' />
    [NativeTypeName("gfx::IQueryPool *")]
    public IQueryPool* queryPool;

    /// <include file='AccelerationStructureQueryDesc.xml' path='doc/member[@name="AccelerationStructureQueryDesc.firstQueryIndex"]/*' />
    [NativeTypeName("gfx::GfxIndex")]
    public int firstQueryIndex;
}
