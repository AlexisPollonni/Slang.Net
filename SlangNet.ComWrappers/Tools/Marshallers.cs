using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace SlangNet.ComWrappers.Tools;


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


internal interface INativeHandleMarshallable<out TManaged>
{
    internal nint Handle { get; }
    internal static abstract TManaged CreateFromHandle(nint handle);
}

[CustomMarshaller(typeof(CustomMarshallerAttribute.GenericPlaceholder), MarshalMode.Default, typeof(HandleStructMarshaller<>))]
internal static class HandleStructMarshaller<T> where T : struct, INativeHandleMarshallable<T>
{
    public static nint ConvertToUnmanaged(T managed)
    {
        return managed.Handle;
    }

    public static T ConvertToManaged(nint unmanaged)
    {
        if (unmanaged == nint.Zero)
            throw new NullReferenceException($"Native handle was null when marshalling to managed type {typeof(T)}.");
        return T.CreateFromHandle(unmanaged);
    }
}

[CustomMarshaller(typeof(Nullable<>), MarshalMode.Default, typeof(NullableHandleStructMarshaller<>))]
internal static class NullableHandleStructMarshaller<T> where T : struct, INativeHandleMarshallable<T>
{
    public static nint ConvertToUnmanaged(T? managed)
    {
        return managed?.Handle ?? nint.Zero;
    }
    public static T? ConvertToManaged(nint unmanaged)
    {
        if (unmanaged == nint.Zero) return null;
        return T.CreateFromHandle(unmanaged);
    }
}