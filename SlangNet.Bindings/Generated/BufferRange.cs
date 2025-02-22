namespace SlangNet.Bindings.Generated;

/// <include file='BufferRange.xml' path='doc/member[@name="BufferRange"]/*' />
public partial struct BufferRange
{
    /// <include file='BufferRange.xml' path='doc/member[@name="BufferRange.offset"]/*' />
    [NativeTypeName("gfx::Offset")]
    public nuint offset;

    /// <include file='BufferRange.xml' path='doc/member[@name="BufferRange.size"]/*' />
    [NativeTypeName("gfx::Size")]
    public nuint size;
}
