namespace SlangNet.Bindings.Generated;

/// <include file='ComputePipelineStateDesc.xml' path='doc/member[@name="ComputePipelineStateDesc"]/*' />
public unsafe partial struct ComputePipelineStateDesc
{
    /// <include file='ComputePipelineStateDesc.xml' path='doc/member[@name="ComputePipelineStateDesc.program"]/*' />
    [NativeTypeName("gfx::IShaderProgram *")]
    public IShaderProgram* program;

    /// <include file='ComputePipelineStateDesc.xml' path='doc/member[@name="ComputePipelineStateDesc.d3d12RootSignatureOverride"]/*' />
    public void* d3d12RootSignatureOverride;
}
