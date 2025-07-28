// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// Based on https://github.com/CommunityToolkit/dotnet/blob/main/src/CommunityToolkit.Mvvm.SourceGenerators/Helpers/EquatableArray%7BT%7D.cs

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;

namespace SlangNet.Pretty.SourceGenerator.Tooling;

/// <summary>
/// Extensions for <see cref="EquatableArray{T}"/>.
/// </summary>
public static class EquatableArray
{
    /// <summary>
    /// Creates an <see cref="EquatableArray{T}"/> instance from a given <see cref="ImmutableArray{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of items in the input array.</typeparam>
    /// <param name="array">The input <see cref="ImmutableArray{T}"/> instance.</param>
    /// <returns>An <see cref="EquatableArray{T}"/> instance from a given <see cref="ImmutableArray{T}"/>.</returns>
    public static EquatableArray<T> AsEquatableArray<T>(this ImmutableArray<T> array) where T : IEquatable<T>
    {
        return new(array);
    }
}

/// <summary>
/// An immutable, equatable array. This is equivalent to <see cref="ImmutableArray{T}"/> but with value equality support.
/// </summary>
/// <typeparam name="T">The type of values in the array.</typeparam>
public readonly struct EquatableArray<T> : IEquatable<EquatableArray<T>>, IImmutableList<T> where T : IEquatable<T>
{
    /// <summary>
    /// The underlying <typeparamref name="T"/> array.
    /// </summary>
    private readonly T[]? _array;

    /// <summary>
    /// Creates a new <see cref="EquatableArray{T}"/> instance.
    /// </summary>
    /// <param name="array">The input <see cref="ImmutableArray{T}"/> to wrap.</param>
    public EquatableArray(ImmutableArray<T> array)
    {
        _array = Unsafe.As<ImmutableArray<T>, T[]?>(ref array);
    }

    /// <summary>
    /// Gets a reference to an item at a specified position within the array.
    /// </summary>
    /// <param name="index">The index of the item to retrieve a reference to.</param>
    /// <returns>A reference to an item at a specified position within the array.</returns>
    public ref readonly T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => ref AsImmutableArray().ItemRef(index);
    }

    /// <summary>
    /// Gets a value indicating whether the current array is empty.
    /// </summary>
    public bool IsEmpty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => AsImmutableArray().IsEmpty;
    }

    /// <sinheritdoc/>
    public bool Equals(EquatableArray<T> array)
    {
        return AsSpan().SequenceEqual(array.AsSpan());
    }

    /// <sinheritdoc/>
    public override bool Equals(object? obj)
    {
        return obj is EquatableArray<T> array && Equals(this, array);
    }

    /// <sinheritdoc/>
    public override int GetHashCode()
    {
        if (_array is not { } array)
        {
            return 0;
        }

        HashCode hashCode = default;

        foreach (var item in array)
        {
            hashCode.Add(item);
        }

        return hashCode.ToHashCode();
    }

    /// <summary>
    /// Gets an <see cref="ImmutableArray{T}"/> instance from the current <see cref="EquatableArray{T}"/>.
    /// </summary>
    /// <returns>The <see cref="ImmutableArray{T}"/> from the current <see cref="EquatableArray{T}"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ImmutableArray<T> AsImmutableArray()
    {
        return Unsafe.As<T[]?, ImmutableArray<T>>(ref Unsafe.AsRef(in _array));
    }

    /// <summary>
    /// Creates an <see cref="EquatableArray{T}"/> instance from a given <see cref="ImmutableArray{T}"/>.
    /// </summary>
    /// <param name="array">The input <see cref="ImmutableArray{T}"/> instance.</param>
    /// <returns>An <see cref="EquatableArray{T}"/> instance from a given <see cref="ImmutableArray{T}"/>.</returns>
    public static EquatableArray<T> FromImmutableArray(ImmutableArray<T> array)
    {
        return new(array);
    }

    /// <summary>
    /// Returns a <see cref="ReadOnlySpan{T}"/> wrapping the current items.
    /// </summary>
    /// <returns>A <see cref="ReadOnlySpan{T}"/> wrapping the current items.</returns>
    public ReadOnlySpan<T> AsSpan()
    {
        return AsImmutableArray().AsSpan();
    }

    /// <summary>
    /// Copies the contents of this <see cref="EquatableArray{T}"/> instance to a mutable array.
    /// </summary>
    /// <returns>The newly instantiated array.</returns>
    public T[] ToArray()
    {
        return AsImmutableArray().ToArray();
    }

    /// <summary>
    /// Gets an <see cref="ImmutableArray{T}.Enumerator"/> value to traverse items in the current array.
    /// </summary>
    /// <returns>An <see cref="ImmutableArray{T}.Enumerator"/> value to traverse items in the current array.</returns>
    public ImmutableArray<T>.Enumerator GetEnumerator()
    {
        return AsImmutableArray().GetEnumerator();
    }

    /// <sinheritdoc/>
    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return ((IEnumerable<T>)AsImmutableArray()).GetEnumerator();
    }

    /// <sinheritdoc/>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)AsImmutableArray()).GetEnumerator();
    }

    /// <summary>
    /// Implicitly converts an <see cref="ImmutableArray{T}"/> to <see cref="EquatableArray{T}"/>.
    /// </summary>
    /// <returns>An <see cref="EquatableArray{T}"/> instance from a given <see cref="ImmutableArray{T}"/>.</returns>
    public static implicit operator EquatableArray<T>(ImmutableArray<T> array)
    {
        return FromImmutableArray(array);
    }

    /// <summary>
    /// Implicitly converts an <see cref="EquatableArray{T}"/> to <see cref="ImmutableArray{T}"/>.
    /// </summary>
    /// <returns>An <see cref="ImmutableArray{T}"/> instance from a given <see cref="EquatableArray{T}"/>.</returns>
    public static implicit operator ImmutableArray<T>(EquatableArray<T> array)
    {
        return array.AsImmutableArray();
    }

    /// <summary>
    /// Checks whether two <see cref="EquatableArray{T}"/> values are the same.
    /// </summary>
    /// <param name="left">The first <see cref="EquatableArray{T}"/> value.</param>
    /// <param name="right">The second <see cref="EquatableArray{T}"/> value.</param>
    /// <returns>Whether <paramref name="left"/> and <paramref name="right"/> are equal.</returns>
    public static bool operator ==(EquatableArray<T> left, EquatableArray<T> right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// Checks whether two <see cref="EquatableArray{T}"/> values are not the same.
    /// </summary>
    /// <param name="left">The first <see cref="EquatableArray{T}"/> value.</param>
    /// <param name="right">The second <see cref="EquatableArray{T}"/> value.</param>
    /// <returns>Whether <paramref name="left"/> and <paramref name="right"/> are not equal.</returns>
    public static bool operator !=(EquatableArray<T> left, EquatableArray<T> right)
    {
        return !left.Equals(right);
    }

    T IReadOnlyList<T>.this[int index] => AsImmutableArray()[index];

    public int Count => AsImmutableArray().Length;

    public int IndexOf(T item, int index, int count, IEqualityComparer<T>? equalityComparer) =>
        AsImmutableArray().IndexOf(item, index, count, equalityComparer);

    public int LastIndexOf(T item, int index, int count, IEqualityComparer<T>? equalityComparer) =>
        AsImmutableArray().LastIndexOf(item, index, count, equalityComparer);

    public EquatableArray<T> Clear() =>
        AsImmutableArray().Clear().AsEquatableArray();

    public EquatableArray<T> Add(T value) =>
        AsImmutableArray().Add(value).AsEquatableArray();

    public EquatableArray<T> AddRange(IEnumerable<T> items) =>
        AsImmutableArray().AddRange(items).AsEquatableArray();

    public EquatableArray<T> Insert(int index, T element) =>
        AsImmutableArray().Insert(index, element).AsEquatableArray();

    public EquatableArray<T> InsertRange(int index, IEnumerable<T> items) =>
        AsImmutableArray().InsertRange(index, items).AsEquatableArray();

    public EquatableArray<T> Remove(T value, IEqualityComparer<T>? equalityComparer) =>
        AsImmutableArray().Remove(value, equalityComparer).AsEquatableArray();

    public EquatableArray<T> RemoveAll(Predicate<T> match) =>
        AsImmutableArray().RemoveAll(match).AsEquatableArray();

    public EquatableArray<T> RemoveRange(IEnumerable<T> items, IEqualityComparer<T>? equalityComparer) =>
        AsImmutableArray().RemoveRange(items, equalityComparer).AsEquatableArray();

    public EquatableArray<T> RemoveRange(int index, int count) =>
        AsImmutableArray().RemoveRange(index, count).AsEquatableArray();

    public EquatableArray<T> RemoveAt(int index) =>
        AsImmutableArray().RemoveAt(index).AsEquatableArray();

    public EquatableArray<T> SetItem(int index, T value) =>
        AsImmutableArray().SetItem(index, value).AsEquatableArray();

    public EquatableArray<T> Replace(T oldValue, T newValue, IEqualityComparer<T>? equalityComparer) =>
        AsImmutableArray().Replace(oldValue, newValue, equalityComparer).AsEquatableArray();

    IImmutableList<T> IImmutableList<T>.Clear() =>
        Clear();

    IImmutableList<T> IImmutableList<T>.Add(T value) =>
        Add(value);

    IImmutableList<T> IImmutableList<T>.AddRange(IEnumerable<T> items) =>
        AddRange(items);

    IImmutableList<T> IImmutableList<T>.Insert(int index, T element) =>
        Insert(index, element);

    IImmutableList<T> IImmutableList<T>.InsertRange(int index, IEnumerable<T> items) =>
        InsertRange(index, items);

    IImmutableList<T> IImmutableList<T>.Remove(T value, IEqualityComparer<T>? equalityComparer) =>
        Remove(value, equalityComparer);

    IImmutableList<T> IImmutableList<T>.RemoveAll(Predicate<T> match) =>
        RemoveAll(match);

    IImmutableList<T> IImmutableList<T>.RemoveRange(IEnumerable<T> items, IEqualityComparer<T>? equalityComparer) =>
        RemoveRange(items, equalityComparer);

    IImmutableList<T> IImmutableList<T>.RemoveRange(int index, int count) =>
        RemoveRange(index, count);

    IImmutableList<T> IImmutableList<T>.RemoveAt(int index) =>
        RemoveAt(index);

    IImmutableList<T> IImmutableList<T>.SetItem(int index, T value) =>
        SetItem(index, value);

    IImmutableList<T> IImmutableList<T>.Replace(T oldValue, T newValue, IEqualityComparer<T>? equalityComparer) =>
        Replace(oldValue, newValue, equalityComparer);
}