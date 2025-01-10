namespace SlangNet.Bindings.Generated;

/// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape"]/*' />
[NativeTypeName("SlangResourceShapeIntegral")]
public enum ResourceShape : uint
{
    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.SlangResourceBaseShapeMask"]/*' />
    SlangResourceBaseShapeMask = 0x0F,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.SlangResourceNone"]/*' />
    SlangResourceNone = 0x00,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.SlangTexture1D"]/*' />
    SlangTexture1D = 0x01,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.SlangTexture2D"]/*' />
    SlangTexture2D = 0x02,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.SlangTexture3D"]/*' />
    SlangTexture3D = 0x03,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.SlangTextureCube"]/*' />
    SlangTextureCube = 0x04,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.SlangTextureBuffer"]/*' />
    SlangTextureBuffer = 0x05,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.SlangStructuredBuffer"]/*' />
    SlangStructuredBuffer = 0x06,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.SlangByteAddressBuffer"]/*' />
    SlangByteAddressBuffer = 0x07,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.SlangResourceUnknown"]/*' />
    SlangResourceUnknown = 0x08,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.SlangAccelerationStructure"]/*' />
    SlangAccelerationStructure = 0x09,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.SlangTextureSubpass"]/*' />
    SlangTextureSubpass = 0x0A,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.SlangResourceExtShapeMask"]/*' />
    SlangResourceExtShapeMask = 0xF0,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.SlangTextureFeedbackFlag"]/*' />
    SlangTextureFeedbackFlag = 0x10,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.SlangTextureShadowFlag"]/*' />
    SlangTextureShadowFlag = 0x20,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.SlangTextureArrayFlag"]/*' />
    SlangTextureArrayFlag = 0x40,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.SlangTextureMultisampleFlag"]/*' />
    SlangTextureMultisampleFlag = 0x80,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.SlangTexture1DArray"]/*' />
    SlangTexture1DArray = SlangTexture1D | SlangTextureArrayFlag,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.SlangTexture2DArray"]/*' />
    SlangTexture2DArray = SlangTexture2D | SlangTextureArrayFlag,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.SlangTextureCubeArray"]/*' />
    SlangTextureCubeArray = SlangTextureCube | SlangTextureArrayFlag,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.SlangTexture2DMultisample"]/*' />
    SlangTexture2DMultisample = SlangTexture2D | SlangTextureMultisampleFlag,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.SlangTexture2DMultisampleArray"]/*' />
    SlangTexture2DMultisampleArray = SlangTexture2D | SlangTextureMultisampleFlag | SlangTextureArrayFlag,

    /// <include file='ResourceShape.xml' path='doc/member[@name="ResourceShape.SlangTextureSubpassMultisample"]/*' />
    SlangTextureSubpassMultisample = SlangTextureSubpass | SlangTextureMultisampleFlag,
}
