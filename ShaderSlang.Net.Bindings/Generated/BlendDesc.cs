using System.Runtime.CompilerServices;

namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='BlendDesc.xml' path='doc/member[@name="BlendDesc"]/*' />
public partial struct BlendDesc
{
    /// <include file='BlendDesc.xml' path='doc/member[@name="BlendDesc.targets"]/*' />
    [NativeTypeName("TargetBlendDesc[8]")]
    public _targets_e__FixedBuffer targets;

    /// <include file='BlendDesc.xml' path='doc/member[@name="BlendDesc.targetCount"]/*' />
    [NativeTypeName("gfx::GfxCount")]
    public int targetCount;

    /// <include file='BlendDesc.xml' path='doc/member[@name="BlendDesc.alphaToCoverageEnable"]/*' />
    [NativeTypeName("bool")]
    public Boolean alphaToCoverageEnable;

    /// <include file='_targets_e__FixedBuffer.xml' path='doc/member[@name="_targets_e__FixedBuffer"]/*' />
    [InlineArray(8)]
    public partial struct _targets_e__FixedBuffer
    {
        public TargetBlendDesc e0;
    }
}
