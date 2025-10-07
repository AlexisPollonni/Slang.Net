using SlangNet.ComWrappers.Interfaces;

namespace SlangNet.ComWrappers.Tools.Extensions;

public static class BlobExtensions
{
    extension(IBlob blob)
    {
        public unsafe ReadOnlySpan<byte> AsReadOnlySpan() =>
            new(blob.GetBufferPointer(), checked((int)blob.GetBufferSize()));

        public unsafe ReadOnlySpan<T> AsReadOnlySpan<T>() where T : unmanaged =>
            new(blob.GetBufferPointer(), checked((int)(blob.GetBufferSize() / (ulong)sizeof(T))));

        public unsafe string? AsString()
        {
            var ptr = blob.GetBufferPointer();
            if (ptr is null) return null;
        
            return new((sbyte*)ptr, 0, (int)blob.GetBufferSize());
        }
    }
}