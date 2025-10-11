namespace SlangNet.Bindings.Generated;

/// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape"]/*' />
[NativeTypeName("SlangResourceShapeIntegral")]
public enum ResourceShape : uint
{
    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.BaseShapeMask"]/*' />
    BaseShapeMask = 0x0F,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.None"]/*' />
    None = 0x00,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.Texture1d"]/*' />
    Texture1d = 0x01,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.Texture2d"]/*' />
    Texture2d = 0x02,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.Texture3d"]/*' />
    Texture3d = 0x03,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.TextureCube"]/*' />
    TextureCube = 0x04,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.TextureBuffer"]/*' />
    TextureBuffer = 0x05,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.StructuredBuffer"]/*' />
    StructuredBuffer = 0x06,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.ByteAddressBuffer"]/*' />
    ByteAddressBuffer = 0x07,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.Unknown"]/*' />
    Unknown = 0x08,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.AccelerationStructure"]/*' />
    AccelerationStructure = 0x09,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.TextureSubpass"]/*' />
    TextureSubpass = 0x0A,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.ExtShapeMask"]/*' />
    ExtShapeMask = 0x1F0,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.TextureFeedbackFlag"]/*' />
    TextureFeedbackFlag = 0x10,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.TextureShadowFlag"]/*' />
    TextureShadowFlag = 0x20,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.TextureArrayFlag"]/*' />
    TextureArrayFlag = 0x40,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.TextureMultisampleFlag"]/*' />
    TextureMultisampleFlag = 0x80,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.TextureCombinedFlag"]/*' />
    TextureCombinedFlag = 0x100,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.Texture1dArray"]/*' />
    Texture1dArray = Texture1d | TextureArrayFlag,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.Texture2dArray"]/*' />
    Texture2dArray = Texture2d | TextureArrayFlag,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.TextureCubeArray"]/*' />
    TextureCubeArray = TextureCube | TextureArrayFlag,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.Texture2dMultisample"]/*' />
    Texture2dMultisample = Texture2d | TextureMultisampleFlag,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.Texture2dMultisampleArray"]/*' />
    Texture2dMultisampleArray = Texture2d | TextureMultisampleFlag | TextureArrayFlag,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.TextureSubpassMultisample"]/*' />
    TextureSubpassMultisample = TextureSubpass | TextureMultisampleFlag,
}
