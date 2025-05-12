namespace SlangNet.Bindings.Generated;

/// <include file='Stage.xml' path='doc/member[@name="Stage"]/*' />
[NativeTypeName("SlangStageIntegral")]
public enum Stage : uint
{
    /// <include file='Stage.xml' path='doc/member[@name="Stage.None"]/*' />
    None,

    /// <include file='Stage.xml' path='doc/member[@name="Stage.Vertex"]/*' />
    Vertex,

    /// <include file='Stage.xml' path='doc/member[@name="Stage.Hull"]/*' />
    Hull,

    /// <include file='Stage.xml' path='doc/member[@name="Stage.Domain"]/*' />
    Domain,

    /// <include file='Stage.xml' path='doc/member[@name="Stage.Geometry"]/*' />
    Geometry,

    /// <include file='Stage.xml' path='doc/member[@name="Stage.Fragment"]/*' />
    Fragment,

    /// <include file='Stage.xml' path='doc/member[@name="Stage.Compute"]/*' />
    Compute,

    /// <include file='Stage.xml' path='doc/member[@name="Stage.RayGeneration"]/*' />
    RayGeneration,

    /// <include file='Stage.xml' path='doc/member[@name="Stage.Intersection"]/*' />
    Intersection,

    /// <include file='Stage.xml' path='doc/member[@name="Stage.AnyHit"]/*' />
    AnyHit,

    /// <include file='Stage.xml' path='doc/member[@name="Stage.ClosestHit"]/*' />
    ClosestHit,

    /// <include file='Stage.xml' path='doc/member[@name="Stage.Miss"]/*' />
    Miss,

    /// <include file='Stage.xml' path='doc/member[@name="Stage.Callable"]/*' />
    Callable,

    /// <include file='Stage.xml' path='doc/member[@name="Stage.Mesh"]/*' />
    Mesh,

    /// <include file='Stage.xml' path='doc/member[@name="Stage.Amplification"]/*' />
    Amplification,

    /// <include file='Stage.xml' path='doc/member[@name="Stage.Dispatch"]/*' />
    Dispatch,

    /// <include file='Stage.xml' path='doc/member[@name="Stage.Count"]/*' />
    Count,

    /// <include file='Stage.xml' path='doc/member[@name="Stage.Pixel"]/*' />
    Pixel = Fragment,
}
