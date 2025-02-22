namespace SlangNet.Bindings.Generated;

/// <include file='FormatInfo.xml' path='doc/member[@name="FormatInfo"]/*' />
public partial struct FormatInfo
{
    /// <include file='FormatInfo.xml' path='doc/member[@name="FormatInfo.channelCount"]/*' />
    [NativeTypeName("gfx::GfxCount")]
    public int channelCount;

    /// <include file='FormatInfo.xml' path='doc/member[@name="FormatInfo.channelType"]/*' />
    [NativeTypeName("uint8_t")]
    public byte channelType;

    /// <include file='FormatInfo.xml' path='doc/member[@name="FormatInfo.blockSizeInBytes"]/*' />
    [NativeTypeName("gfx::Size")]
    public nuint blockSizeInBytes;

    /// <include file='FormatInfo.xml' path='doc/member[@name="FormatInfo.pixelsPerBlock"]/*' />
    [NativeTypeName("gfx::GfxCount")]
    public int pixelsPerBlock;

    /// <include file='FormatInfo.xml' path='doc/member[@name="FormatInfo.blockWidth"]/*' />
    [NativeTypeName("gfx::GfxCount")]
    public int blockWidth;

    /// <include file='FormatInfo.xml' path='doc/member[@name="FormatInfo.blockHeight"]/*' />
    [NativeTypeName("gfx::GfxCount")]
    public int blockHeight;
}
