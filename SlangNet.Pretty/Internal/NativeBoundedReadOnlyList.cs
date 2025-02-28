using System;
using System.Collections;
using System.Collections.Generic;

namespace SlangNet;

// for lists of opaque objects returned as pair of
//   X_getCount
//   Element* getAt
internal readonly unsafe struct NativeBoundedReadOnlyList<TContainer, TElement> : IReadOnlyList<TElement>
    where TContainer : unmanaged
{
    public delegate nint GetCountDelegate(TContainer* container);
    public delegate bool TryGetAtDelegate(TContainer* container, nint index, out TElement result);
    
    public TContainer* Container { get; init; }
    public GetCountDelegate GetCount { get; init; }
    public TryGetAtDelegate TryGetAt { get; init; }

    public long Count => GetCount(Container);
    int IReadOnlyCollection<TElement>.Count => checked((int)Count);

    public TElement this[int index] => this[(nint)index];
    public TElement this[nint index]
    {
        get
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            return TryGetAt(Container, index, out var element)
                ? element
                : throw new SlangException("Slang list returned a null pointer");
        }
    }

    public IEnumerator<TElement> GetEnumerator() => new IndexEnumerator<TElement>(this);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

// and there is one two-dimensional list (TypeLayoutReflection.DescriptorSetDescriptorRange)
internal readonly unsafe struct NativeBoundedReadOnlyList<TContainer, TArgument, TElement> : IReadOnlyList<TElement>
    where TContainer : unmanaged
{
    public delegate nint GetCountDelegate(TContainer* container, TArgument argument);
    public delegate bool TryGetAtDelegate(TContainer* container, TArgument argument, nint index, out TElement result);
    
    public TContainer* Container { get; init; }
    public TArgument Argument { get; init; }
    public GetCountDelegate GetCount { get; init; }
    public TryGetAtDelegate TryGetAt { get; init; }

    public long Count => GetCount(Container, Argument);
    int IReadOnlyCollection<TElement>.Count => checked((int)Count);

    public TElement this[int index] => this[index];
    public TElement this[nint index]
    {
        get
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            return TryGetAt(Container, Argument, index, out var element)
                ? element
                : throw new SlangException("Slang list returned a null pointer");
        }
    }

    public IEnumerator<TElement> GetEnumerator() => new IndexEnumerator<TElement>(this);
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
