using ShaderSlang.Net.Bindings.Generated;

namespace ShaderSlang.Net;

/// <include file='BindingType.xml' path='doc/member[@name="BindingType"]/*' />
[NativeTypeName("SlangBindingTypeIntegral")]
public enum BindingType : uint
{
    /// <include file='BindingType.xml' path='doc/member[@name="BindingType.Unknown"]/*' />
    Unknown = 0,

    /// <include file='BindingType.xml' path='doc/member[@name="BindingType.Sampler"]/*' />
    Sampler,

    /// <include file='BindingType.xml' path='doc/member[@name="BindingType.Texture"]/*' />
    Texture,

    /// <include file='BindingType.xml' path='doc/member[@name="BindingType.ConstantBuffer"]/*' />
    ConstantBuffer,

    /// <include file='BindingType.xml' path='doc/member[@name="BindingType.ParameterBlock"]/*' />
    ParameterBlock,

    /// <include file='BindingType.xml' path='doc/member[@name="BindingType.TypedBuffer"]/*' />
    TypedBuffer,

    /// <include file='BindingType.xml' path='doc/member[@name="BindingType.RawBuffer"]/*' />
    RawBuffer,

    /// <include file='BindingType.xml' path='doc/member[@name="BindingType.CombinedTextureSampler"]/*' />
    CombinedTextureSampler,

    /// <include file='BindingType.xml' path='doc/member[@name="BindingType.InputRenderTarget"]/*' />
    InputRenderTarget,

    /// <include file='BindingType.xml' path='doc/member[@name="BindingType.InlineUniformData"]/*' />
    InlineUniformData,

    /// <include file='BindingType.xml' path='doc/member[@name="BindingType.RayTracingAccelerationStructure"]/*' />
    RayTracingAccelerationStructure,

    /// <include file='BindingType.xml' path='doc/member[@name="BindingType.VaryingInput"]/*' />
    VaryingInput,

    /// <include file='BindingType.xml' path='doc/member[@name="BindingType.VaryingOutput"]/*' />
    VaryingOutput,

    /// <include file='BindingType.xml' path='doc/member[@name="BindingType.ExistentialValue"]/*' />
    ExistentialValue,

    /// <include file='BindingType.xml' path='doc/member[@name="BindingType.PushConstant"]/*' />
    PushConstant,

    /// <include file='BindingType.xml' path='doc/member[@name="BindingType.MutableFlag"]/*' />
    MutableFlag = 0x100,

    /// <include file='BindingType.xml' path='doc/member[@name="BindingType.MutableTeture"]/*' />
    MutableTeture = Texture | MutableFlag,

    /// <include file='BindingType.xml' path='doc/member[@name="BindingType.MutableTypedBuffer"]/*' />
    MutableTypedBuffer = TypedBuffer | MutableFlag,

    /// <include file='BindingType.xml' path='doc/member[@name="BindingType.MutableRawBuffer"]/*' />
    MutableRawBuffer = RawBuffer | MutableFlag,

    /// <include file='BindingType.xml' path='doc/member[@name="BindingType.BaseMask"]/*' />
    BaseMask = 0x00FF,

    /// <include file='BindingType.xml' path='doc/member[@name="BindingType.ExtMask"]/*' />
    ExtMask = 0xFF00,
}
