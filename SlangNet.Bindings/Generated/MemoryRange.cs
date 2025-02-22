namespace SlangNet.Bindings.Generated;

/// <include file='MemoryRange.xml' path='doc/member[@name="MemoryRange"]/*' />
public partial struct MemoryRange
{
    /// <include file='MemoryRange.xml' path='doc/member[@name="MemoryRange.offset"]/*' />
    [NativeTypeName("uint64_t")]
    public nuint offset;

    /// <include file='MemoryRange.xml' path='doc/member[@name="MemoryRange.size"]/*' />
    [NativeTypeName("uint64_t")]
    public nuint size;
}
