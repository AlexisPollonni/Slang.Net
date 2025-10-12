using ShaderSlang.Net.ComWrappers.Interfaces;
using ShaderSlang.Net.ComWrappers.Tools.Extensions;

namespace ShaderSlang.Net.Pretty.Gfx.Tools;

public readonly struct BlobMemory<T>(IBlob blob)
    where T : unmanaged
{
    public ReadOnlySpan<T> AsReadOnlySpan() => blob.AsReadOnlySpan<T>();
}
