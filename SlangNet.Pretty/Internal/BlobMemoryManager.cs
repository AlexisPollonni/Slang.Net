using System;
using System.Buffers;
using System.Runtime.InteropServices;
using SlangNet.Internal;

namespace SlangNet;

internal sealed unsafe class BlobMemoryManager<T> : MemoryManager<T> where T : unmanaged
{
    private readonly COMObject<ISlangBlob> _blob;
    private readonly void* _pointer;
    private readonly int _count;

    public BlobMemoryManager(ISlangBlob* blob)
    {
        if (blob == null)
            throw new ArgumentNullException(nameof(blob));
        _blob = new(blob);
        _pointer = blob->getBufferPointer();
        _count = checked((int)(blob->getBufferSize() / (nuint)sizeof(T)));
    }

    public override Span<T> GetSpan() =>
        new(_pointer, _count);

    public override MemoryHandle Pin(int elementIndex = 0)
    {
        _blob.ThrowIfDisposed();
        ArgumentOutOfRangeException.ThrowIfNegative(elementIndex);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(elementIndex, 0);
        
        return new((byte*)_pointer + elementIndex, pinnable: this);
    }

    public override void Unpin() { }

    protected override void Dispose(bool disposing) => _blob.Dispose();
}
