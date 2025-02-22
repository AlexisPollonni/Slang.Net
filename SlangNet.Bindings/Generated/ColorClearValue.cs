using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SlangNet.Bindings.Generated;

/// <include file='ColorClearValue.xml' path='doc/member[@name="ColorClearValue"]/*' />
[StructLayout(LayoutKind.Explicit)]
public partial struct ColorClearValue
{
    /// <include file='ColorClearValue.xml' path='doc/member[@name="ColorClearValue.floatValues"]/*' />
    [FieldOffset(0)]
    [NativeTypeName("float[4]")]
    public _floatValues_e__FixedBuffer floatValues;

    /// <include file='ColorClearValue.xml' path='doc/member[@name="ColorClearValue.uintValues"]/*' />
    [FieldOffset(0)]
    [NativeTypeName("uint32_t[4]")]
    public _uintValues_e__FixedBuffer uintValues;

    /// <include file='_floatValues_e__FixedBuffer.xml' path='doc/member[@name="_floatValues_e__FixedBuffer"]/*' />
    [InlineArray(4)]
    public partial struct _floatValues_e__FixedBuffer
    {
        public float e0;
    }

    /// <include file='_uintValues_e__FixedBuffer.xml' path='doc/member[@name="_uintValues_e__FixedBuffer"]/*' />
    [InlineArray(4)]
    public partial struct _uintValues_e__FixedBuffer
    {
        public uint e0;
    }
}
