using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;

namespace ShaderSlang.Net.ComWrappers.Tools;

internal interface IMarshalsToNative<out TNative> where TNative : unmanaged
{
    /// <summary>
    /// Marshals the object to its native representation.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public TNative AsNative(ref GrowingStackBuffer buffer);
}

internal interface IMarshalsFromNative<out TManaged, in TUnmanaged> where TUnmanaged : unmanaged
                                                                    where TManaged : IMarshalsFromNative<TManaged,
                                                                        TUnmanaged>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static abstract TManaged CreateFromNative(TUnmanaged unmanaged);
}

internal interface IFreeAfterMarshal<TUnmanaged> where TUnmanaged : unmanaged
{
    internal unsafe void Free(TUnmanaged* unmanaged);
}



internal static class MarshalableMarshaller
{
    [CustomMarshaller(typeof(CustomMarshallerAttribute.GenericPlaceholder), MarshalMode.Default, typeof(Bidirectional<,>))]
    internal unsafe ref struct Bidirectional<TManaged, TUnmanaged>
        where TManaged : IMarshalsToNative<TUnmanaged>, IMarshalsFromNative<TManaged, TUnmanaged>
        where TUnmanaged : unmanaged
    {
        private ManagedToUnmanaged<TManaged, TUnmanaged> _inMarshaller;
        private TManaged? _managed;

        public static int BufferSize => ManagedToUnmanaged<TManaged, TUnmanaged>.BufferSize;

        public void Free() =>
            _inMarshaller.Free();

        public void FromManaged(TManaged managed, Span<byte> unmanaged) =>
            _inMarshaller.FromManaged(managed, unmanaged);

        public void FromUnmanaged(TUnmanaged* unmanaged) =>
            _managed = UnmanagedToManaged<TManaged, TUnmanaged>.ConvertToManaged(unmanaged);

        public TUnmanaged* ToUnmanaged() =>
            _inMarshaller.Native is not null
                ? _inMarshaller.Native
                : throw new InvalidOperationException("Unmanaged object was not set");

        public TManaged ToManaged()
        {
            return _managed ?? throw new InvalidOperationException("Managed object was not set");
        }
    }

    [CustomMarshaller(typeof(CustomMarshallerAttribute.GenericPlaceholder),
                      MarshalMode.ManagedToUnmanagedIn,
                      typeof(ManagedToUnmanaged<,>))]
    [CustomMarshaller(typeof(CustomMarshallerAttribute.GenericPlaceholder),
                      MarshalMode.UnmanagedToManagedOut,
                      typeof(ManagedToUnmanaged<,>))]
    internal ref struct ManagedToUnmanaged<TManaged, TUnmanaged>
        where TManaged : IMarshalsToNative<TUnmanaged> where TUnmanaged : unmanaged
    {
        private GrowingStackBuffer _alloc;
        private TManaged _managed;
        internal unsafe TUnmanaged* Native;

        public static int BufferSize => 1024;

        public unsafe void FromManaged(TManaged managed, Span<byte> unmanaged)
        {
            _managed = managed;
            _alloc = new(unmanaged);

            var native = managed.AsNative(ref _alloc);
            Native = _alloc.GetStructPtr(in native);
        }

        public unsafe TUnmanaged* ToUnmanaged() =>
            Native;

        public unsafe void Free()
        {
            if (_managed is IFreeAfterMarshal<TUnmanaged> freeable) freeable.Free(Native);
            _alloc.Free();
        }
    }

    [CustomMarshaller(typeof(CustomMarshallerAttribute.GenericPlaceholder),
                      MarshalMode.ManagedToUnmanagedOut,
                      typeof(UnmanagedToManaged<,>))]
    [CustomMarshaller(typeof(CustomMarshallerAttribute.GenericPlaceholder),
                      MarshalMode.UnmanagedToManagedIn,
                      typeof(UnmanagedToManaged<,>))]
    internal static class UnmanagedToManaged<TManaged, TUnmanaged> where TManaged : IMarshalsFromNative<TManaged, TUnmanaged>
                                                                   where TUnmanaged : unmanaged
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe TManaged ConvertToManaged(TUnmanaged* unmanaged)
        {
            return TManaged.CreateFromNative(*unmanaged);
        }
    }
}