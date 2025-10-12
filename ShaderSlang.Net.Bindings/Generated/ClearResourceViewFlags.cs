namespace ShaderSlang.Net.Bindings.Generated;

/// <include file='ClearResourceViewFlags.xml' path='doc/member[@name="ClearResourceViewFlags"]/*' />
public partial struct ClearResourceViewFlags
{

    /// <include file='Enum.xml' path='doc/member[@name="Enum"]/*' />
    [NativeTypeName("uint32_t")]
    public enum Enum : uint
    {
        /// <include file='Enum.xml' path='doc/member[@name="Enum.None"]/*' />
        None = 0,

        /// <include file='Enum.xml' path='doc/member[@name="Enum.ClearDepth"]/*' />
        ClearDepth = 1,

        /// <include file='Enum.xml' path='doc/member[@name="Enum.ClearStencil"]/*' />
        ClearStencil = 2,

        /// <include file='Enum.xml' path='doc/member[@name="Enum.FloatClearValues"]/*' />
        FloatClearValues = 4,
    }
}
