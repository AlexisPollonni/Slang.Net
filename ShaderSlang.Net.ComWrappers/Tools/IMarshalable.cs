using System.Runtime.CompilerServices;

namespace ShaderSlang.Net.ComWrappers.Tools;

internal interface IMarshalsToNative<TUnmanaged>
    where TUnmanaged : unmanaged
{
    /// <summary>
    /// Marshals the object to its native representation.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public TUnmanaged AsNative(ref GrowingStackBuffer buffer);
    
    /// <summary>
    /// Frees any resources allocated during marshaling.
    /// Default implementation does nothing.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static virtual void Free(scoped ref readonly TUnmanaged unmanaged)
    {
        // Noop: Default implementation does nothing.
    }
}

internal interface IMarshalsFromNative<out TManaged, in TUnmanaged>
    where TUnmanaged : unmanaged
    where TManaged : IMarshalsFromNative<TManaged, TUnmanaged>
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static abstract TManaged CreateFromNative(TUnmanaged unmanaged);
}