namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='RayTracingPipelineStateDesc.xml' path='doc/member[@name="RayTracingPipelineStateDesc"]/*' />
public unsafe partial struct RayTracingPipelineStateDesc
{
    /// <include file='RayTracingPipelineStateDesc.xml' path='doc/member[@name="RayTracingPipelineStateDesc.program"]/*' />
    [NativeTypeName("gfx::IShaderProgram *")]
    public IShaderProgram* program;

    /// <include file='RayTracingPipelineStateDesc.xml' path='doc/member[@name="RayTracingPipelineStateDesc.hitGroupCount"]/*' />
    [NativeTypeName("gfx::GfxCount")]
    public int hitGroupCount;

    /// <include file='RayTracingPipelineStateDesc.xml' path='doc/member[@name="RayTracingPipelineStateDesc.hitGroups"]/*' />
    [NativeTypeName("const HitGroupDesc *")]
    public HitGroupDesc* hitGroups;

    /// <include file='RayTracingPipelineStateDesc.xml' path='doc/member[@name="RayTracingPipelineStateDesc.maxRecursion"]/*' />
    public int maxRecursion;

    /// <include file='RayTracingPipelineStateDesc.xml' path='doc/member[@name="RayTracingPipelineStateDesc.maxRayPayloadSize"]/*' />
    [NativeTypeName("gfx::Size")]
    public nuint maxRayPayloadSize;

    /// <include file='RayTracingPipelineStateDesc.xml' path='doc/member[@name="RayTracingPipelineStateDesc.maxAttributeSizeInBytes"]/*' />
    [NativeTypeName("gfx::Size")]
    public nuint maxAttributeSizeInBytes;

    /// <include file='RayTracingPipelineStateDesc.xml' path='doc/member[@name="RayTracingPipelineStateDesc.flags"]/*' />
    [NativeTypeName("gfx::RayTracingPipelineFlags::Enum")]
    public RayTracingPipelineFlagsEnum flags;
}
