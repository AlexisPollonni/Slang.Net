using System.Collections;
using ShaderSlang.Net.Bindings;

namespace ShaderSlang.Net.ComWrappers.Tools;

// for lists of opaque objects returned as pair of
//   X_getCount
//   Element* getAt
internal readonly struct NativeBoundedReadOnlyList<TContainer, TElement> : IReadOnlyList<TElement>
    where TElement : struct
{
    public TContainer Container { get; init; }
    public Func<TContainer, nint> GetCount { get; init; }
    public Func<TContainer, nint, TElement?> TryGetAt { get; init; }

    public nint Count => GetCount(Container);
    int IReadOnlyCollection<TElement>.Count => checked((int)Count);

    public TElement this[int index] => this[(nint)index];

    public TElement this[nint index]
    {
        get
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            var element = TryGetAt(Container, index);
            return element ?? throw new SlangException("Slang list returned a null pointer");
        }
    }

    public IEnumerator<TElement> GetEnumerator() => new IndexEnumerator<TElement>(this);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

//TODO: clean this up
internal readonly struct NativeClassBoundedReadOnlyList<TContainer, TElement>
    : IReadOnlyList<TElement>
    where TElement : class
{
    public TContainer Container { get; init; }
    public Func<TContainer, nint> GetCount { get; init; }
    public Func<TContainer, nint, TElement?> TryGetAt { get; init; }

    public nint Count => GetCount(Container);
    int IReadOnlyCollection<TElement>.Count => checked((int)Count);

    public TElement this[int index] => this[(nint)index];

    public TElement this[nint index]
    {
        get
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            var element = TryGetAt(Container, index);
            return element ?? throw new SlangException("Slang list returned a null pointer");
        }
    }

    public IEnumerator<TElement> GetEnumerator() => new IndexEnumerator<TElement>(this);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

// and there is one two-dimensional list (TypeLayoutReflection.DescriptorSetDescriptorRange)
internal readonly struct NativeBoundedReadOnlyList<TContainer, TArgument, TElement>
    : IReadOnlyList<TElement>
    where TElement : struct
{
    public TContainer Container { get; init; }
    public TArgument Argument { get; init; }
    public Func<TContainer, TArgument, nint> GetCount { get; init; }
    public Func<TContainer, TArgument, nint, TElement?> TryGetAt { get; init; }

    public long Count => GetCount(Container, Argument);
    int IReadOnlyCollection<TElement>.Count => checked((int)Count);

    public TElement this[int index] => this[(nint)index];

    public TElement this[nint index]
    {
        get
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            return TryGetAt(Container, Argument, index)
                ?? throw new SlangException("Slang list returned a null pointer");
        }
    }

    public IEnumerator<TElement> GetEnumerator() => new IndexEnumerator<TElement>(this);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
