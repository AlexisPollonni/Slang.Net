using System.Runtime.InteropServices;
using CommunityToolkit.HighPerformance;

namespace SlangNet.ComWrappers;

public static class SpanExtensions
{
    public static Span<T> AsSpan<T>(ref this T inline) where T : unmanaged
    {
        return MemoryMarshal.CreateSpan(ref inline, 1);
    }

    public static Span<TCast> AsSpan<T, TCast>(ref this T inline)
        where T : unmanaged
        where TCast : unmanaged
    {
        return inline.AsSpan().Cast<T, TCast>();
    }

    public static ReadOnlySpan<T> AsReadOnlySpan<T>(ref this T inline) where T : unmanaged
    {
        return MemoryMarshal.CreateReadOnlySpan(in inline, 1);
    }

    public static ReadOnlySpan<TCast> AsReadOnlySpan<T, TCast>(ref this T inline) 
        where T : unmanaged 
        where TCast : unmanaged
    {
        return inline.AsReadOnlySpan().Cast<T, TCast>();
    }

    public static Span<uint> AsUintSpan<T>(ref this T inline) 
        where T : unmanaged 
    {
        return inline.AsSpan<T, uint>();
    }
    public static Span<float> AsFloatSpan<T>(ref this T inline) 
        where T : unmanaged 
    {
        return inline.AsSpan<T, float>();
    }
}