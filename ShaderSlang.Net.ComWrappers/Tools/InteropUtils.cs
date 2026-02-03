using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using ShaderSlang.Net.ComWrappers.Interfaces;

namespace ShaderSlang.Net.ComWrappers.Tools;

internal static unsafe class InteropUtils
{
    public static string? PtrToStringUtf8(void* ptr, Encoding? encoding = null)
    {
        if (ptr is null)
            return null;

        encoding ??= Encoding.UTF8;

        var span = MemoryMarshal.CreateReadOnlySpanFromNullTerminated((byte*)ptr);
        return encoding.GetString(span);
    }

    public static string[]? PtrToStringArray(sbyte** ptr, int count)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(count);

        if (ptr is null || count == 0)
            return null;

        var resArray = new string[count];
        for (var i = 0; i < count; i++)
            resArray[i] = PtrToStringUtf8(ptr[i]) ?? "";

        return resArray;
    }

    public static TManaged[]? PtrToManagedMarshal<TManaged, TUnmanaged>(
        TUnmanaged* native,
        int count
    )
        where TUnmanaged : unmanaged
        where TManaged : IMarshalsFromNative<TManaged, TUnmanaged>
    {
        if (native is null || count == 0)
            return null;

        var res = new TManaged[count];
        var span = new Span<TUnmanaged>(native, count);

        for (var i = 0; i < count; i++)
        {
            var managed = TManaged.CreateFromNative(span[i]);
            res[i] = managed;
        }

        return res;
    }

    public static TManaged[]? ComPtrToManagedMarshal<TManaged, TUnmanaged>(
        TUnmanaged** native,
        int count
    )
        where TUnmanaged : unmanaged
        where TManaged : IUnknown
    {
        if (native is null || count == 0)
            return null;

        var res = new TManaged[count];

        for (var i = 0; i < count; i++)
        {
            var managed = ComInterfaceMarshaller<TManaged>.ConvertToManaged(native[i]);
            res[i] =
                managed
                ?? throw new InvalidOperationException(
                    $"Failed to marshal COM interface pointer to {typeof(TManaged).FullName}"
                );
        }

        return res;
    }

    public static TUnmanaged* InterfaceToPtr<TManagedInterface, TUnmanaged>(
        this TManagedInterface? comObject
    )
        where TManagedInterface : IUnknown
        where TUnmanaged : unmanaged
    {
        return (TUnmanaged*)ComInterfaceMarshaller<TManagedInterface>.ConvertToUnmanaged(comObject);
    }


    public static TUnmanaged* AllocAndCopyToNativeMemory<TUnmanaged>(this Memory<TUnmanaged> memory) where TUnmanaged : unmanaged
    {
        var pointer = NativeMemory.Alloc((UIntPtr)memory.Length);
        var nativeData = new Span<TUnmanaged>(pointer, memory.Length);
        
        memory.Span.CopyTo(nativeData);
        
        return (TUnmanaged*)pointer;
    }
}
