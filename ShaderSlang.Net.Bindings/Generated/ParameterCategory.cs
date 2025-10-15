using ShaderSlang.Net.Bindings.Generated;

namespace ShaderSlang.Net;

/// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory"]/*' />
[NativeTypeName("SlangParameterCategoryIntegral")]
public enum ParameterCategory : uint
{
    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.None"]/*' />
    None,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.Mixed"]/*' />
    Mixed,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.ConstantBuffer"]/*' />
    ConstantBuffer,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.ShaderResource"]/*' />
    ShaderResource,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.UnorderedAccess"]/*' />
    UnorderedAccess,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.VaryingInput"]/*' />
    VaryingInput,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.VaryingOutput"]/*' />
    VaryingOutput,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.SamplerState"]/*' />
    SamplerState,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.Uniform"]/*' />
    Uniform,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.DescriptorTableSlot"]/*' />
    DescriptorTableSlot,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.SpecializationConstant"]/*' />
    SpecializationConstant,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.PushConstantBuffer"]/*' />
    PushConstantBuffer,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.RegisterSpace"]/*' />
    RegisterSpace,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.Generic"]/*' />
    Generic,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.RayPayload"]/*' />
    RayPayload,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.HitAttributes"]/*' />
    HitAttributes,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.CallablePayload"]/*' />
    CallablePayload,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.ShaderRecord"]/*' />
    ShaderRecord,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.ExistentialTypeParam"]/*' />
    ExistentialTypeParam,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.ExistentialObjectParam"]/*' />
    ExistentialObjectParam,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.SubElementRegisterSpace"]/*' />
    SubElementRegisterSpace,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.Subpass"]/*' />
    Subpass,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.MetalArgumentBufferElement"]/*' />
    MetalArgumentBufferElement,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.MetalAttribute"]/*' />
    MetalAttribute,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.MetalPayload"]/*' />
    MetalPayload,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.Count"]/*' />
    Count,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.MetalBuffer"]/*' />
    MetalBuffer = ConstantBuffer,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.MetalTexture"]/*' />
    MetalTexture = ShaderResource,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.MetalSampler"]/*' />
    MetalSampler = SamplerState,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.VertexInput"]/*' />
    VertexInput = VaryingInput,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.FragmentOutput"]/*' />
    FragmentOutput = VaryingOutput,

    /// <include file='ParameterCategory.xml' path='doc/member[@name="ParameterCategory.CountV1"]/*' />
    CountV1 = Subpass,
}
