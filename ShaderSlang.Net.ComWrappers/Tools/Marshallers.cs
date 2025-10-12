using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace ShaderSlang.Net.ComWrappers.Tools;

//The built in string marshaller frees the unmanaged memory when it returns from a native function. Needs this to avoid errors.
[CustomMarshaller(typeof(string), MarshalMode.Default, typeof(UnownedUTF8StringMarshaller))]
internal ref struct UnownedUTF8StringMarshaller
{
    private string? _str;
    private unsafe sbyte* _unmanagedValue;
    private bool _allocated;

    public static int BufferSize => Utf8StringMarshaller.ManagedToUnmanagedIn.BufferSize;
    
    public unsafe void Free()
    {
        if(_allocated)
            NativeMemory.Free(_unmanagedValue);
    }

    public unsafe void FromManaged(string? managed, Span<byte> buffer)
    {
        _allocated = false;

        if (managed is null)
        {
            _unmanagedValue = null;
            return;
        }

        const int maxUtf8BytesPerChar = 3;

        // >= for null terminator
        // Use the cast to long to avoid the checked operation
        if ((long)maxUtf8BytesPerChar * managed.Length >= buffer.Length)
        {
            // Calculate accurate byte count when the provided stack-allocated buffer is not sufficient
            var exactByteCount = checked(Encoding.UTF8.GetByteCount(managed) + 1); // + 1 for null terminator
            if (exactByteCount > buffer.Length)
            {
                buffer = new((byte*)NativeMemory.Alloc((nuint)exactByteCount), exactByteCount);
                _allocated = true;
            }
        }

        // Unsafe.AsPointer is safe since buffer must be pinned
        _unmanagedValue = (sbyte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference(buffer));

        var byteCount = Encoding.UTF8.GetBytes(managed, buffer);
        buffer[byteCount] = 0; // null-terminate
    }

    public unsafe sbyte* ToUnmanaged()
    {
        return _unmanagedValue;
    }

    public string? ToManaged()
    {
        return _str;
    }

    public unsafe void FromUnmanaged(sbyte* unmanaged)
    {
        _str = Utf8StringMarshaller.ConvertToManaged((byte*)unmanaged);
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