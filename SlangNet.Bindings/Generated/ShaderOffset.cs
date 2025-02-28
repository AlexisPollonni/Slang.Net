namespace SlangNet.Bindings.Generated;

/// <include file='ShaderOffset.xml' path='doc/member[@name="ShaderOffset"]/*' />
public partial struct ShaderOffset
{
    /// <include file='ShaderOffset.xml' path='doc/member[@name="ShaderOffset.uniformOffset"]/*' />
    [NativeTypeName("SlangInt")]
    public long uniformOffset;

    /// <include file='ShaderOffset.xml' path='doc/member[@name="ShaderOffset.bindingRangeIndex"]/*' />
    [NativeTypeName("gfx::GfxIndex")]
    public int bindingRangeIndex;

    /// <include file='ShaderOffset.xml' path='doc/member[@name="ShaderOffset.bindingArrayIndex"]/*' />
    [NativeTypeName("gfx::GfxIndex")]
    public int bindingArrayIndex;
}
