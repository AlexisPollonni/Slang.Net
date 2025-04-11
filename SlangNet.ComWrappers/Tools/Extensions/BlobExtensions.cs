﻿using SlangNet.ComWrappers.Interfaces;

namespace SlangNet.ComWrappers.Tools.Extensions;

public static class BlobExtensions
{
    public static unsafe string? AsString(this IBlob? blob)
    {
        if(blob is null) return null;
        var ptr = blob.GetBufferPointer();
        if (ptr is null) return null;
        
        return new((char*)ptr, 0, (int)blob.GetBufferSize());
    }

    public static unsafe ReadOnlySpan<byte> AsReadOnlySpan(this IBlob blob) =>
        new(blob.GetBufferPointer(), (int)blob.GetBufferSize());
}