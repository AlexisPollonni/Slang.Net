using System;
using SlangNet.ComWrappers.Interfaces;
using SlangNet.ComWrappers.Tools.Extensions;

namespace SlangNet.Gfx.Tools;

public readonly struct BlobMemory<T>(IBlob blob) 
    where T : unmanaged
{
    public ReadOnlySpan<T> AsReadOnlySpan() =>
        blob.AsReadOnlySpan<T>();
}