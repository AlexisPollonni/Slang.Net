namespace SlangNet.Bindings.Generated;

/// <include file='RayTracingPipelineFlags.xml' path='doc/member[@name="RayTracingPipelineFlags"]/*' />
public partial struct RayTracingPipelineFlags
{

    /// <include file='Enum.xml' path='doc/member[@name="Enum"]/*' />
    [NativeTypeName("uint32_t")]
    public enum Enum : uint
    {
        /// <include file='Enum.xml' path='doc/member[@name="Enum.None"]/*' />
        None = 0,

        /// <include file='Enum.xml' path='doc/member[@name="Enum.SkipTriangles"]/*' />
        SkipTriangles = 1,

        /// <include file='Enum.xml' path='doc/member[@name="Enum.SkipProcedurals"]/*' />
        SkipProcedurals = 2,
    }
}
