using System.Runtime.InteropServices;
using CommunityToolkit.HighPerformance;

namespace SlangNet.ComWrappers.Gfx;

public static class SpanExtensions
{
    extension<T>(ref T inline) where T : unmanaged
    {
        public Span<T> AsSpan()
        {
            return MemoryMarshal.CreateSpan(ref inline, 1);
        }

        public Span<TCast> AsSpan<TCast>() where TCast : unmanaged
        {
            return inline.AsSpan().Cast<T, TCast>();
        }

        public ReadOnlySpan<T> AsReadOnlySpan()
        {
            return MemoryMarshal.CreateReadOnlySpan(in inline, 1);
        }

        public ReadOnlySpan<TCast> AsReadOnlySpan<TCast>() where TCast : unmanaged
        {
            return inline.AsReadOnlySpan().Cast<T, TCast>();
        }

        public Span<uint> AsUintSpan()
        {
            return inline.AsSpan<T, uint>();
        }

        public Span<float> AsFloatSpan()
        {
            return inline.AsSpan<T, float>();
        }
    }
}