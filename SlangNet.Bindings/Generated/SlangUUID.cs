using System.Runtime.CompilerServices;

namespace SlangNet.Bindings.Generated;

/// <include file='SlangUUID.xml' path='doc/member[@name="SlangUUID"]/*' />
public partial struct SlangUUID
{
    /// <include file='SlangUUID.xml' path='doc/member[@name="SlangUUID.data1"]/*' />
    [NativeTypeName("uint32_t")]
    public uint data1;

    /// <include file='SlangUUID.xml' path='doc/member[@name="SlangUUID.data2"]/*' />
    [NativeTypeName("uint16_t")]
    public ushort data2;

    /// <include file='SlangUUID.xml' path='doc/member[@name="SlangUUID.data3"]/*' />
    [NativeTypeName("uint16_t")]
    public ushort data3;

    /// <include file='SlangUUID.xml' path='doc/member[@name="SlangUUID.data4"]/*' />
    [NativeTypeName("uint8_t[8]")]
    public _data4_e__FixedBuffer data4;

    /// <include file='_data4_e__FixedBuffer.xml' path='doc/member[@name="_data4_e__FixedBuffer"]/*' />
    [InlineArray(8)]
    public partial struct _data4_e__FixedBuffer
    {
        public byte e0;
    }
}
