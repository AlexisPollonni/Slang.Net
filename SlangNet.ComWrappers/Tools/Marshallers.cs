using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace SlangNet.ComWrappers.Tools;

[CustomMarshaller(typeof(SessionDescription), MarshalMode.ManagedToUnmanagedIn, typeof(ManagedToUnmanagedIn))]
[CustomMarshaller(typeof(SessionDescription), MarshalMode.ManagedToUnmanagedOut, typeof(SessionDescriptionMarshaller))]
internal static class SessionDescriptionMarshaller
{
    internal unsafe ref struct ManagedToUnmanagedIn
    {
        public static int BufferSize => 1024;

        private GrowingStackBuffer _buffer;
        private Unmanaged.SessionDesc* _unmanaged;

        public void FromManaged(SessionDescription managed, Span<byte> unmanaged)
        {
            _buffer = new(unmanaged);

            _unmanaged = _buffer.GetStructPtr(ManagedToUnmanagedConverters.SessionDescConverter(in managed, ref _buffer));
        }
        
        public readonly Unmanaged.SessionDesc* ToUnmanaged() => _unmanaged;

        public void Free()
        {
            //Do not forget to free the filesystem interface
            ComInterfaceMarshaller<IFileSystem>.Free(_unmanaged->fileSystem);
            _buffer.Free();
        }
    }

    public static unsafe SessionDescription ConvertToManaged(Unmanaged.SessionDesc* unmanaged)
    {
        throw new NotImplementedException();
    }
}


[CustomMarshaller(typeof(Action<Unmanaged.PathType, string, nint>), MarshalMode.Default, typeof(FileSystemContentsCallBackMarshaller))]
internal static unsafe class FileSystemContentsCallBackMarshaller
{
    public static nint ConvertToUnmanaged(Action<Unmanaged.PathType, string, nint> managed)
    {
        return Marshal.GetFunctionPointerForDelegate<Unmanaged.FileSystemContentsCallBack>((type, name, dataPtr) =>
        {
            managed(type, new(name), (nint)dataPtr);
        });
    }

    public static Action<Unmanaged.PathType, string, nint> ConvertToManaged(nint unmanaged)
    {
        var managedDelegate = Marshal.GetDelegateForFunctionPointer<Unmanaged.FileSystemContentsCallBack>(unmanaged);

        return (type, str, data) =>
        {
            var b = new GrowingStackBuffer(stackalloc byte[256]);
            managedDelegate(type, b.GetStringPtr(str), (void*)data);
            b.Free();
        };
    }
}

[CustomMarshaller(typeof(TimeSpan), MarshalMode.Default, typeof(TimeSpanMillisecondsMarshaller))]
internal static class TimeSpanMillisecondsMarshaller
{
    public static uint ConvertToUnmanaged(TimeSpan managed)
    {
        return (uint)managed.Milliseconds;
    }

    public static TimeSpan ConvertToManaged(uint unmanaged)
    {
        return TimeSpan.FromMilliseconds(unmanaged);
    }
}