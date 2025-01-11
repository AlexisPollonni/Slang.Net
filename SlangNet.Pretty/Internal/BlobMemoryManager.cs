using System;
using System.Buffers;
using SlangNet.Internal;

namespace SlangNet;

internal sealed unsafe class BlobMemoryManager : MemoryManager<byte>
{
    private readonly COMObject<ISlangBlob> blob;
    private readonly void* pointer;
    private readonly int size;

    public BlobMemoryManager(ISlangBlob* blob)
    {
        if (blob == null)
            throw new ArgumentNullException(nameof(blob));
        this.blob = new(blob);
        pointer = blob->getBufferPointer();
        size = checked((int)blob->getBufferSize());
    }

    public override Span<byte> GetSpan() =>
        new(pointer, size);

    public override MemoryHandle Pin(int elementIndex = 0)
    {
        blob.ThrowIfDisposed();
        if (elementIndex < 0 || elementIndex >= size)
            throw new ArgumentOutOfRangeException(nameof(elementIndex));
        return new(((byte*)pointer) + elementIndex, pinnable: this);
    }

    public override void Unpin() { }

    protected override void Dispose(bool disposing) => blob.Dispose();

    ~BlobMemoryManager()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: false);
    }
}
