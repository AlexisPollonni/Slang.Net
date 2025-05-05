using System;
using System.IO;
using System.Text;

internal class StreamToStringWrapper(Encoding? encoding = null) : Stream
{
    private readonly StringBuilder _stringBuilder = new();
    private readonly Encoding _encoding = encoding ?? Encoding.Default;
    private long _position;

    public override string ToString() =>
        _stringBuilder.ToString();

    public override void Flush()
    {
        //Noop
    }

    public override int Read(byte[] buffer, int offset, int count) =>
        throw new NotSupportedException();

    public override long Seek(long offset, SeekOrigin origin)
    {
        var newPosition = origin switch
        {
            SeekOrigin.Begin => offset,
            SeekOrigin.Current => _position + offset,
            SeekOrigin.End => Length + offset,
            _ => throw new ArgumentOutOfRangeException(nameof(origin), origin, null)
        };

        if (newPosition < 0 || newPosition > Length) throw new ArgumentOutOfRangeException(nameof(offset), offset, null);

        _position = newPosition;
        return _position;
    }

    public override void SetLength(long value) =>
        throw new NotSupportedException();

    public override void Write(byte[] buffer, int offset, int count)
    {
        ArgumentNullException.ThrowIfNull(buffer);
        if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset), offset, null);
        if (count < 0) throw new ArgumentOutOfRangeException(nameof(count), count, null);
        if (buffer.Length - offset < count) throw new ArgumentException("Invalid offset length");

        var str = _encoding.GetString(buffer, offset, count);
        _stringBuilder.Append(str);
        _position += count;
    }

    public override bool CanRead => false;
    public override bool CanSeek => true;
    public override bool CanWrite => true;
    public override long Length => _encoding.GetByteCount(_stringBuilder.ToString());

    public override long Position
    {
        get => _position;
        set
        {
            if (value < 0 || value > Length) throw new ArgumentOutOfRangeException(nameof(value));
            _position = value;
        }
    }
}