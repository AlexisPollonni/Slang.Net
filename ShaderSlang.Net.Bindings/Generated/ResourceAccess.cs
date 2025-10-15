namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='ResourceAccess.xml' path='doc/member[@name="ResourceAccess"]/*' />
[NativeTypeName("SlangResourceAccessIntegral")]
public enum ResourceAccess : uint
{
    /// <include file='ResourceAccess.xml' path='doc/member[@name="ResourceAccess.None"]/*' />
    None,

    /// <include file='ResourceAccess.xml' path='doc/member[@name="ResourceAccess.Read"]/*' />
    Read,

    /// <include file='ResourceAccess.xml' path='doc/member[@name="ResourceAccess.ReadWrite"]/*' />
    ReadWrite,

    /// <include file='ResourceAccess.xml' path='doc/member[@name="ResourceAccess.RasterOrdered"]/*' />
    RasterOrdered,

    /// <include file='ResourceAccess.xml' path='doc/member[@name="ResourceAccess.Append"]/*' />
    Append,

    /// <include file='ResourceAccess.xml' path='doc/member[@name="ResourceAccess.Consume"]/*' />
    Consume,

    /// <include file='ResourceAccess.xml' path='doc/member[@name="ResourceAccess.Write"]/*' />
    Write,

    /// <include file='ResourceAccess.xml' path='doc/member[@name="ResourceAccess.Feedback"]/*' />
    Feedback,

    /// <include file='ResourceAccess.xml' path='doc/member[@name="ResourceAccess.Unknown"]/*' />
    Unknown = 0x7FFFFFFF,
}
