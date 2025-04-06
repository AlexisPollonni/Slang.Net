using System;
using System.Runtime.InteropServices.Marshalling;
using SlangNet.Bindings.Generated;

namespace SlangNet.ComWrappers.Tools;

[CustomMarshaller(typeof(SessionDescription), MarshalMode.ManagedToUnmanagedIn, typeof(ManagedToUnmanagedIn))]
[CustomMarshaller(typeof(SessionDescription), MarshalMode.ManagedToUnmanagedOut, typeof(SessionDescriptionMarshaller))]
public static class SessionDescriptionMarshaller
{
    internal unsafe ref struct ManagedToUnmanagedIn
    {
        public static int BufferSize => 1024;

        private GrowingStackBuffer _buffer;
        private SessionDesc* _unmanaged;

        public void FromManaged(SessionDescription managed, Span<byte> unmanaged)
        {
            _buffer = new(unmanaged);

            _unmanaged = _buffer.GetStructPtr(ManagedToUnmanagedConverters.SessionDescConverter(in managed, ref _buffer));
        }
        
        public readonly SessionDesc* ToUnmanaged() => _unmanaged;

        public void Free()
        {
            //Do not forget to free the filesystem interface
            ComInterfaceMarshaller<IFileSystem>.Free(_unmanaged->fileSystem);
            _buffer.Free();
        }
    }

    public unsafe static SessionDescription ConvertToManaged(SessionDesc* unmanaged)
    {
        throw new NotImplementedException();
    }
}
