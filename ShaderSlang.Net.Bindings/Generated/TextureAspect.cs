namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='TextureAspect.xml' path='doc/member[@name="TextureAspect"]/*' />
[NativeTypeName("uint32_t")]
public enum TextureAspect : uint
{
    /// <include file='TextureAspect.xml' path='doc/member[@name="TextureAspect.Default"]/*' />
    Default = 0,

    /// <include file='TextureAspect.xml' path='doc/member[@name="TextureAspect.Color"]/*' />
    Color = 0x00000001,

    /// <include file='TextureAspect.xml' path='doc/member[@name="TextureAspect.Depth"]/*' />
    Depth = 0x00000002,

    /// <include file='TextureAspect.xml' path='doc/member[@name="TextureAspect.Stencil"]/*' />
    Stencil = 0x00000004,

    /// <include file='TextureAspect.xml' path='doc/member[@name="TextureAspect.MetaData"]/*' />
    MetaData = 0x00000008,

    /// <include file='TextureAspect.xml' path='doc/member[@name="TextureAspect.Plane0"]/*' />
    Plane0 = 0x00000010,

    /// <include file='TextureAspect.xml' path='doc/member[@name="TextureAspect.Plane1"]/*' />
    Plane1 = 0x00000020,

    /// <include file='TextureAspect.xml' path='doc/member[@name="TextureAspect.Plane2"]/*' />
    Plane2 = 0x00000040,

    /// <include file='TextureAspect.xml' path='doc/member[@name="TextureAspect.DepthStencil"]/*' />
    DepthStencil = Depth | Stencil,
}
