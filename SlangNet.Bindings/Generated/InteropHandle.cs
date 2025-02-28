namespace SlangNet.Bindings.Generated;

/// <include file='InteropHandle.xml' path='doc/member[@name="InteropHandle"]/*' />
public partial struct InteropHandle
{
    /// <include file='InteropHandle.xml' path='doc/member[@name="InteropHandle.api"]/*' />
    [NativeTypeName("gfx::InteropHandleAPI")]
    public InteropHandleAPI api;

    /// <include file='InteropHandle.xml' path='doc/member[@name="InteropHandle.handleValue"]/*' />
    [NativeTypeName("uint64_t")]
    public ulong handleValue;
}
