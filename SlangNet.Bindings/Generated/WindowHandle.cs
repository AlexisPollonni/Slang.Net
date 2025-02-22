using System.Runtime.CompilerServices;

namespace SlangNet.Bindings.Generated;

/// <include file='WindowHandle.xml' path='doc/member[@name="WindowHandle"]/*' />
public partial struct WindowHandle
{
    /// <include file='WindowHandle.xml' path='doc/member[@name="WindowHandle.type"]/*' />
    [NativeTypeName("gfx::WindowHandle::Type")]
    public Type type;

    /// <include file='WindowHandle.xml' path='doc/member[@name="WindowHandle.handleValues"]/*' />
    [NativeTypeName("intptr_t[2]")]
    public _handleValues_e__FixedBuffer handleValues;

    /// <include file='Type.xml' path='doc/member[@name="Type"]/*' />
    public enum Type
    {
        /// <include file='Type.xml' path='doc/member[@name="Type.Unknown"]/*' />
        Unknown,

        /// <include file='Type.xml' path='doc/member[@name="Type.Win32Handle"]/*' />
        Win32Handle,

        /// <include file='Type.xml' path='doc/member[@name="Type.NSWindowHandle"]/*' />
        NSWindowHandle,

        /// <include file='Type.xml' path='doc/member[@name="Type.XLibHandle"]/*' />
        XLibHandle,
    }

    /// <include file='_handleValues_e__FixedBuffer.xml' path='doc/member[@name="_handleValues_e__FixedBuffer"]/*' />
    [InlineArray(2)]
    public partial struct _handleValues_e__FixedBuffer
    {
        public nint e0;
    }
}
