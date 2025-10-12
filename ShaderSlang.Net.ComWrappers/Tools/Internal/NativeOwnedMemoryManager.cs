using System.Buffers;

namespace ShaderSlang.Net.ComWrappers.Tools.Internal;

internal unsafe class NativeOwnedMemoryManager(byte* data, int size) : MemoryManager<byte>
{
    protected override void Dispose(bool disposing)
    {
        //noop
    }
    public override Span<byte> GetSpan() => new(data, size);

    public override MemoryHandle Pin(int elementIndex = 0) => new(data + elementIndex);

    public override void Unpin()
    {
        //noop
    }
}