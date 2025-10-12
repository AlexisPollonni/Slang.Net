using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace ShaderSlang.Net.Pretty.SourceGenerator.Tooling;

public sealed class DiagnosticsList : IList<Diagnostic>, IEquatable<DiagnosticsList>
{
    private  readonly List<Diagnostic> _diagnostics = [];
    
    public int Count => _diagnostics.Count;
    public bool IsReadOnly => false;
    
    public IEnumerator<Diagnostic> GetEnumerator() =>  _diagnostics.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void Add(DiagnosticDescriptor descriptor, params object?[]? messageArgs) =>
        Add(Diagnostic.Create(descriptor, null, messageArgs));
    public void Add(DiagnosticDescriptor descriptor, Location location, params object?[]? messageArgs) =>
        Add(Diagnostic.Create(descriptor, location, messageArgs));
    
    public void Add(Diagnostic item) => _diagnostics.Add(item);
    public void Insert(int index, Diagnostic item) => _diagnostics.Insert(index, item);
    public void Clear() => _diagnostics.Clear();
    public bool Contains(Diagnostic item) => _diagnostics.Contains(item);
    public void CopyTo(Diagnostic[] array, int arrayIndex) => _diagnostics.CopyTo(array, arrayIndex);
    public bool Remove(Diagnostic item) =>  _diagnostics.Remove(item);
    public int IndexOf(Diagnostic item) =>  _diagnostics.IndexOf(item);

    public void RemoveAt(int index) => _diagnostics.RemoveAt(index);

    public Diagnostic this[int index]
    {
        get => _diagnostics[index];
        set => _diagnostics[index] = value;
    }

    public bool Equals(DiagnosticsList other)
    {
        return _diagnostics.SequenceEqual(other, comparer: new DiagComparer());
    }

    private readonly struct DiagComparer : IEqualityComparer<Diagnostic>
    {
        public bool Equals(Diagnostic? x, Diagnostic? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null) return false;
            if (y is null) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Id == y.Id 
                   && x.Location.Equals(y.Location)
                   && x.AdditionalLocations.SequenceEqual(y.AdditionalLocations);
        }

        public int GetHashCode(Diagnostic obj)
        {
            unchecked
            {
                var hashCode = obj.Id.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.Location.GetHashCode();
                hashCode = (hashCode * 397) ^ obj.AdditionalLocations.GetHashCode();
                return hashCode;
            }
        }
    }
}