using System.Collections;

namespace SlangNet.ComWrappers.Tools;

internal class IndexEnumerator<T>(IReadOnlyList<T> list) : IEnumerator<T>
{
    private readonly int _count = list.Count; // we cache to save native calls
    private T? _current;
    private int _index = -1;

    public T Current => _current ?? default!;
    object IEnumerator.Current => Current!;

    public bool MoveNext()
    {
        ResetCurrent();
        if (++_index >= _count)
            return false;
        _current = list[_index];
        return true;
    }

    public void Reset()
    {
        ResetCurrent();
        _index = -1;
    }

    private void ResetCurrent()
    {
        if (EqualityComparer<T?>.Default.Equals(_current, default(T?)))
            return;
        if (Current is IDisposable disposable)
            disposable.Dispose();
        _current = default;
    }

    public void Dispose() => ResetCurrent();
}
