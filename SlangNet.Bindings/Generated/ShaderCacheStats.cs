namespace SlangNet.Bindings.Generated;

/// <include file='ShaderCacheStats.xml' path='doc/member[@name="ShaderCacheStats"]/*' />
public partial struct ShaderCacheStats
{
    /// <include file='ShaderCacheStats.xml' path='doc/member[@name="ShaderCacheStats.hitCount"]/*' />
    [NativeTypeName("gfx::GfxCount")]
    public int hitCount;

    /// <include file='ShaderCacheStats.xml' path='doc/member[@name="ShaderCacheStats.missCount"]/*' />
    [NativeTypeName("gfx::GfxCount")]
    public int missCount;

    /// <include file='ShaderCacheStats.xml' path='doc/member[@name="ShaderCacheStats.entryCount"]/*' />
    [NativeTypeName("gfx::GfxCount")]
    public int entryCount;
}
