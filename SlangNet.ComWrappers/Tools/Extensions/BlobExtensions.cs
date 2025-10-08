using SlangNet.ComWrappers.Interfaces;

namespace SlangNet.ComWrappers.Tools.Extensions;

public static class BlobExtensions
{
    extension(IBlob? blob)
    {
        public unsafe ReadOnlySpan<T> AsReadOnlySpan<T>() where T : unmanaged =>
            blob is null ? ReadOnlySpan<T>.Empty : new(blob.GetBufferPointer(), checked((int)(blob.GetBufferSize() / (ulong)sizeof(T))));

        public unsafe string? AsString()
        {
            if (blob is null) return null;
            var ptr = blob.GetBufferPointer();
            if (ptr is null) return null;
        
            return new((sbyte*)ptr, 0, (int)blob.GetBufferSize());
        }
    }
}