namespace SlangNet.Bindings.Generated;

/// <include file='RasterizerDesc.xml' path='doc/member[@name="RasterizerDesc"]/*' />
public partial struct RasterizerDesc
{
    /// <include file='RasterizerDesc.xml' path='doc/member[@name="RasterizerDesc.fillMode"]/*' />
    [NativeTypeName("gfx::FillMode")]
    public FillMode fillMode;

    /// <include file='RasterizerDesc.xml' path='doc/member[@name="RasterizerDesc.cullMode"]/*' />
    [NativeTypeName("gfx::CullMode")]
    public CullMode cullMode;

    /// <include file='RasterizerDesc.xml' path='doc/member[@name="RasterizerDesc.frontFace"]/*' />
    [NativeTypeName("gfx::FrontFaceMode")]
    public FrontFaceMode frontFace;

    /// <include file='RasterizerDesc.xml' path='doc/member[@name="RasterizerDesc.depthBias"]/*' />
    [NativeTypeName("int32_t")]
    public int depthBias;

    /// <include file='RasterizerDesc.xml' path='doc/member[@name="RasterizerDesc.depthBiasClamp"]/*' />
    public float depthBiasClamp;

    /// <include file='RasterizerDesc.xml' path='doc/member[@name="RasterizerDesc.slopeScaledDepthBias"]/*' />
    public float slopeScaledDepthBias;

    /// <include file='RasterizerDesc.xml' path='doc/member[@name="RasterizerDesc.depthClipEnable"]/*' />
    [NativeTypeName("bool")]
    public byte depthClipEnable;

    /// <include file='RasterizerDesc.xml' path='doc/member[@name="RasterizerDesc.scissorEnable"]/*' />
    [NativeTypeName("bool")]
    public byte scissorEnable;

    /// <include file='RasterizerDesc.xml' path='doc/member[@name="RasterizerDesc.multisampleEnable"]/*' />
    [NativeTypeName("bool")]
    public byte multisampleEnable;

    /// <include file='RasterizerDesc.xml' path='doc/member[@name="RasterizerDesc.antialiasedLineEnable"]/*' />
    [NativeTypeName("bool")]
    public byte antialiasedLineEnable;

    /// <include file='RasterizerDesc.xml' path='doc/member[@name="RasterizerDesc.enableConservativeRasterization"]/*' />
    [NativeTypeName("bool")]
    public byte enableConservativeRasterization;

    /// <include file='RasterizerDesc.xml' path='doc/member[@name="RasterizerDesc.forcedSampleCount"]/*' />
    [NativeTypeName("uint32_t")]
    public uint forcedSampleCount;
}
