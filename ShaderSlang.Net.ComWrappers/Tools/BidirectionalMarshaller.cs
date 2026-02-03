using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using CommunityToolkit.HighPerformance;

namespace ShaderSlang.Net.ComWrappers.Tools;

internal ref struct ManagedToUnmanagedIn<TManaged, TUnmanaged>
    where TManaged : struct, IMarshalsToNative<TUnmanaged>
    where TUnmanaged : unmanaged
{
    private GrowingStackBuffer _alloc;
    private TManaged? _managed;
    private TUnmanaged? _unmanagedFromManaged;

    public static int BufferSize => 1024; //TODO: eventually add size request from TManaged

    public void Free()
    {
        if (_unmanagedFromManaged is null) return;
        if (_managed is null) return;

        //TODO: find a way to call static abstract interface on type
        //freeable.Free(ref _unmanagedFromManaged.DangerousGetValueOrNullReference());
        _unmanagedFromManaged = null;
    }

    public void FromManaged(ref readonly TManaged managed, Span<byte> unmanaged)
    {
        _alloc = new(unmanaged);
        _managed = managed;
        _unmanagedFromManaged = _managed?.AsNative(ref _alloc) ??
                                throw new InvalidOperationException("Managed value is null.");
    }

    public unsafe TUnmanaged* ToUnmanaged()
    {
        return (TUnmanaged*)Unsafe.AsPointer(ref _unmanagedFromManaged.DangerousGetValueOrNullReference());
    }
}

internal static class UnmanagedToManaged<TManaged, TUnmanaged>
    where TManaged : IMarshalsFromNative<TManaged, TUnmanaged>
    where TUnmanaged : unmanaged
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TManaged ConvertToManaged(TUnmanaged unmanaged)
    {
        return TManaged.CreateFromNative(unmanaged);
    }
}

internal static class ElementBi<TManaged, TUnmanaged>
    where TManaged : struct, IMarshalsToNative<TUnmanaged>, IMarshalsFromNative<TManaged, TUnmanaged>
    where TUnmanaged : unmanaged
{
    public static int BufferSize => 1024; //TODO: eventually add size request from TManaged
    
    public static unsafe TUnmanaged* ConvertToUnmanaged(TManaged? managed, Span<byte> unmanaged)
    {
        if (managed is null )
        {
            return null;
        }
        
        var managedValue = managed.Value;
        var growingStackBuffer = new GrowingStackBuffer(unmanaged);
        var unmanagedFromManaged = managedValue.AsNative(ref growingStackBuffer);
        
        return growingStackBuffer.GetStructPtr(unmanagedFromManaged);
    }

    public static unsafe TManaged? ConvertToManaged(TUnmanaged* unmanaged)
    {
        if (unmanaged is null)
        {
            return null;
        }
        return TManaged.CreateFromNative(*unmanaged);
    }
    
    public static unsafe void Free(TUnmanaged* unmanaged)
    {
        TManaged.Free(ref Unsafe.AsRef<TUnmanaged>(unmanaged));
    }
}


[CustomMarshaller(
    typeof(CustomMarshallerAttribute.GenericPlaceholder),
    MarshalMode.ElementIn,
    typeof(ElementBi<,>)
)]

[CustomMarshaller(
    typeof(CustomMarshallerAttribute.GenericPlaceholder),
    MarshalMode.ManagedToUnmanagedIn,
    typeof(ManagedToUnmanagedIn<,>)
)]
[CustomMarshaller(
    typeof(CustomMarshallerAttribute.GenericPlaceholder),
    MarshalMode.ManagedToUnmanagedOut,
    typeof(UnmanagedToManaged<,>)
)]
[CustomMarshaller(
    typeof(CustomMarshallerAttribute.GenericPlaceholder),
    MarshalMode.UnmanagedToManagedIn,
    typeof(UnmanagedToManaged<,>)
)]
internal static class BidirectionalMarshaller<TManaged, TUnmanaged>
    where TManaged : IMarshalsToNative<TUnmanaged>, IMarshalsFromNative<TManaged, TUnmanaged>
    where TUnmanaged : unmanaged
{
}

[CustomMarshaller(
    typeof(CustomMarshallerAttribute.GenericPlaceholder),
    MarshalMode.ManagedToUnmanagedIn,
    typeof(ManagedToUnmanagedIn<,>)
)]
internal static class ManagedToUnmanagedMarshaller<TManaged, TUnmanaged>
    where TManaged : IMarshalsToNative<TUnmanaged>
    where TUnmanaged : unmanaged
{
}

[CustomMarshaller(
    typeof(CustomMarshallerAttribute.GenericPlaceholder),
    MarshalMode.ManagedToUnmanagedOut,
    typeof(UnmanagedToManaged<,>)
)]
[CustomMarshaller(
    typeof(CustomMarshallerAttribute.GenericPlaceholder),
    MarshalMode.UnmanagedToManagedIn,
    typeof(UnmanagedToManaged<,>)
)]
internal static class UnmanagedToManagedMarshaller<TManaged, TUnmanaged>
    where TManaged : IMarshalsFromNative<TManaged, TUnmanaged>
    where TUnmanaged : unmanaged
{
}