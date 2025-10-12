namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='SubresourceRange.xml' path='doc/member[@name="SubresourceRange"]/*' />
public partial struct SubresourceRange
{
    /// <include file='SubresourceRange.xml' path='doc/member[@name="SubresourceRange.aspectMask"]/*' />
    [NativeTypeName("gfx::TextureAspect")]
    public TextureAspect aspectMask;

    /// <include file='SubresourceRange.xml' path='doc/member[@name="SubresourceRange.mipLevel"]/*' />
    [NativeTypeName("gfx::GfxIndex")]
    public int mipLevel;

    /// <include file='SubresourceRange.xml' path='doc/member[@name="SubresourceRange.mipLevelCount"]/*' />
    [NativeTypeName("gfx::GfxCount")]
    public int mipLevelCount;

    /// <include file='SubresourceRange.xml' path='doc/member[@name="SubresourceRange.baseArrayLayer"]/*' />
    [NativeTypeName("gfx::GfxIndex")]
    public int baseArrayLayer;

    /// <include file='SubresourceRange.xml' path='doc/member[@name="SubresourceRange.layerCount"]/*' />
    [NativeTypeName("gfx::GfxCount")]
    public int layerCount;
}
