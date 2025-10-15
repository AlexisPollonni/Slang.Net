namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='D3D12ExperimentalFeaturesDesc.xml' path='doc/member[@name="D3D12ExperimentalFeaturesDesc"]/*' />
public unsafe partial struct D3D12ExperimentalFeaturesDesc
{
    /// <include file='D3D12ExperimentalFeaturesDesc.xml' path='doc/member[@name="D3D12ExperimentalFeaturesDesc.structType"]/*' />
    [NativeTypeName("gfx::StructType")]
    public StructType structType;

    /// <include file='D3D12ExperimentalFeaturesDesc.xml' path='doc/member[@name="D3D12ExperimentalFeaturesDesc.numFeatures"]/*' />
    [NativeTypeName("uint32_t")]
    public uint numFeatures;

    /// <include file='D3D12ExperimentalFeaturesDesc.xml' path='doc/member[@name="D3D12ExperimentalFeaturesDesc.featureIIDs"]/*' />
    [NativeTypeName("const void *")]
    public void* featureIIDs;

    /// <include file='D3D12ExperimentalFeaturesDesc.xml' path='doc/member[@name="D3D12ExperimentalFeaturesDesc.configurationStructs"]/*' />
    public void* configurationStructs;

    /// <include file='D3D12ExperimentalFeaturesDesc.xml' path='doc/member[@name="D3D12ExperimentalFeaturesDesc.configurationStructSizes"]/*' />
    [NativeTypeName("uint32_t *")]
    public uint* configurationStructSizes;
}
