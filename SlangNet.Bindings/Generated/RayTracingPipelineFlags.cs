namespace SlangNet.Bindings.Generated;

/// <include file='RayTracingPipelineFlags.xml' path='doc/member[@name="RayTracingPipelineFlags"]/*' />
public partial struct RayTracingPipelineFlags
{

    /// <include file='RayTracingPipelineFlagsEnum.xml' path='doc/member[@name="RayTracingPipelineFlagsEnum"]/*' />
    [NativeTypeName("uint32_t")]
    public enum RayTracingPipelineFlagsEnum : uint
    {
        /// <include file='RayTracingPipelineFlagsEnum.xml' path='doc/member[@name="RayTracingPipelineFlagsEnum.None"]/*' />
        None = 0,

        /// <include file='RayTracingPipelineFlagsEnum.xml' path='doc/member[@name="RayTracingPipelineFlagsEnum.SkipTriangles"]/*' />
        SkipTriangles = 1,

        /// <include file='RayTracingPipelineFlagsEnum.xml' path='doc/member[@name="RayTracingPipelineFlagsEnum.SkipProcedurals"]/*' />
        SkipProcedurals = 2,
    }
}
