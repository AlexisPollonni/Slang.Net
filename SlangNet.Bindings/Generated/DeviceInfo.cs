using System.Runtime.CompilerServices;

namespace SlangNet.Bindings.Generated;

/// <include file='DeviceInfo.xml' path='doc/member[@name="DeviceInfo"]/*' />
public unsafe partial struct DeviceInfo
{
    /// <include file='DeviceInfo.xml' path='doc/member[@name="DeviceInfo.deviceType"]/*' />
    [NativeTypeName("gfx::DeviceType")]
    public DeviceType deviceType;

    /// <include file='DeviceInfo.xml' path='doc/member[@name="DeviceInfo.limits"]/*' />
    [NativeTypeName("gfx::DeviceLimits")]
    public DeviceLimits limits;

    /// <include file='DeviceInfo.xml' path='doc/member[@name="DeviceInfo.bindingStyle"]/*' />
    [NativeTypeName("gfx::BindingStyle")]
    public BindingStyle bindingStyle;

    /// <include file='DeviceInfo.xml' path='doc/member[@name="DeviceInfo.projectionStyle"]/*' />
    [NativeTypeName("gfx::ProjectionStyle")]
    public ProjectionStyle projectionStyle;

    /// <include file='DeviceInfo.xml' path='doc/member[@name="DeviceInfo.identityProjectionMatrix"]/*' />
    [NativeTypeName("float[16]")]
    public _identityProjectionMatrix_e__FixedBuffer identityProjectionMatrix;

    /// <include file='DeviceInfo.xml' path='doc/member[@name="DeviceInfo.apiName"]/*' />
    [NativeTypeName("const char *")]
    public sbyte* apiName;

    /// <include file='DeviceInfo.xml' path='doc/member[@name="DeviceInfo.adapterName"]/*' />
    [NativeTypeName("const char *")]
    public sbyte* adapterName;

    /// <include file='DeviceInfo.xml' path='doc/member[@name="DeviceInfo.timestampFrequency"]/*' />
    [NativeTypeName("uint64_t")]
    public ulong timestampFrequency;

    /// <include file='_identityProjectionMatrix_e__FixedBuffer.xml' path='doc/member[@name="_identityProjectionMatrix_e__FixedBuffer"]/*' />
    [InlineArray(16)]
    public partial struct _identityProjectionMatrix_e__FixedBuffer
    {
        public float e0;
    }
}
