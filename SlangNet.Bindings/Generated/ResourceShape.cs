namespace SlangNet.Bindings.Generated.Slang;

/// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape"]/*' />
[NativeTypeName("SlangResourceShapeIntegral")]
public enum ResourceShape : uint
{
    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.ResourceBaseShapeMask"]/*' />
    ResourceBaseShapeMask = 0x0F,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.ResourceNone"]/*' />
    ResourceNone = 0x00,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.Texture1D"]/*' />
    Texture1D = 0x01,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.Texture2D"]/*' />
    Texture2D = 0x02,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.Texture3D"]/*' />
    Texture3D = 0x03,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.TextureCube"]/*' />
    TextureCube = 0x04,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.TextureBuffer"]/*' />
    TextureBuffer = 0x05,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.StructuredBuffer"]/*' />
    StructuredBuffer = 0x06,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.ByteAddressBuffer"]/*' />
    ByteAddressBuffer = 0x07,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.ResourceUnknown"]/*' />
    ResourceUnknown = 0x08,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.AccelerationStructure"]/*' />
    AccelerationStructure = 0x09,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.TextureSubpass"]/*' />
    TextureSubpass = 0x0A,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.ResourceExtShapeMask"]/*' />
    ResourceExtShapeMask = 0xF0,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.TextureFeedbackFlag"]/*' />
    TextureFeedbackFlag = 0x10,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.TextureShadowFlag"]/*' />
    TextureShadowFlag = 0x20,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.TextureArrayFlag"]/*' />
    TextureArrayFlag = 0x40,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.TextureMultisampleFlag"]/*' />
    TextureMultisampleFlag = 0x80,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.Texture1DArray"]/*' />
    Texture1DArray = Texture1D | TextureArrayFlag,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.Texture2DArray"]/*' />
    Texture2DArray = Texture2D | TextureArrayFlag,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.TextureCubeArray"]/*' />
    TextureCubeArray = TextureCube | TextureArrayFlag,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.Texture2DMultisample"]/*' />
    Texture2DMultisample = Texture2D | TextureMultisampleFlag,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.Texture2DMultisampleArray"]/*' />
    Texture2DMultisampleArray = Texture2D | TextureMultisampleFlag | TextureArrayFlag,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.TextureSubpassMultisample"]/*' />
    TextureSubpassMultisample = TextureSubpass | TextureMultisampleFlag,
}
