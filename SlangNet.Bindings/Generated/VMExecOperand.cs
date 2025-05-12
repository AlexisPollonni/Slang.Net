using System.Runtime.CompilerServices;

namespace SlangNet.Bindings.Generated;

/// <include file='VMExecOperand.xml' path='doc/member[@name="VMExecOperand"]/*' />
public unsafe partial struct VMExecOperand
{
    /// <include file='VMExecOperand.xml' path='doc/member[@name="VMExecOperand.section"]/*' />
    [NativeTypeName("uint8_t **")]
    public byte** section;

    public uint _bitfield;

    /// <include file='VMExecOperand.xml' path='doc/member[@name="VMExecOperand.type"]/*' />
    [NativeTypeName("uint32_t : 8")]
    public uint type
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return _bitfield & 0xFFu;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield = (_bitfield & ~0xFFu) | (value & 0xFFu);
        }
    }

    /// <include file='VMExecOperand.xml' path='doc/member[@name="VMExecOperand.size"]/*' />
    [NativeTypeName("uint32_t : 24")]
    public uint size
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        readonly get
        {
            return (_bitfield >> 8) & 0xFFFFFFu;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            _bitfield = (_bitfield & ~(0xFFFFFFu << 8)) | ((value & 0xFFFFFFu) << 8);
        }
    }

    /// <include file='VMExecOperand.xml' path='doc/member[@name="VMExecOperand.offset"]/*' />
    [NativeTypeName("uint32_t")]
    public uint offset;
}
