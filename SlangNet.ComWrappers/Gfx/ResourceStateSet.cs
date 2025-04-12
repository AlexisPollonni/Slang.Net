namespace SlangNet.ComWrappers.Gfx;

public struct ResourceStateSet : IEquatable<ResourceStateSet>
{
    private ulong _bitFields;
    
    public ResourceStateSet(ulong value)
    {
        _bitFields = value;
    }
    
    public ResourceStateSet(params Unmanaged.ResourceState[] states)
    {
        _bitFields = 0;
        foreach (var state in states)
        {
            _bitFields |= 1UL << (int)state;
        }
    }
    
    public void Add(Unmanaged.ResourceState state)
    {
        _bitFields |= 1UL << (int)state;
    }
    
    public readonly bool HasState(Unmanaged.ResourceState state)
    {
        return (_bitFields & (1UL << (int)state)) != 0;
    }

    public static ResourceStateSet operator |(ResourceStateSet a, ResourceStateSet b)
    {
        return new() { _bitFields = a._bitFields | b._bitFields };
    }
    
    public static ResourceStateSet operator &(ResourceStateSet a, ResourceStateSet b)
    {
        return new() { _bitFields = a._bitFields & b._bitFields };
    }

    public static ResourceStateSet operator ~(ResourceStateSet a)
    {
        return new() { _bitFields = ~a._bitFields };
    }

    public static bool operator ==(ResourceStateSet a, ResourceStateSet b)
    {
        return a._bitFields == b._bitFields;
    }

    public static bool operator !=(ResourceStateSet a, ResourceStateSet b)
    {
        return !(a == b);
    }

    public readonly override bool Equals(object? obj)
    {
        if (obj is ResourceStateSet other)
        {
            return this == other;
        }
        return false;
    }

    public readonly override int GetHashCode()
    {
        return _bitFields.GetHashCode();
    }

    public static implicit operator ResourceStateSet(ulong value) => new(value);

    public static implicit operator ulong(ResourceStateSet set) => set._bitFields;

    public static implicit operator ResourceStateSet(Unmanaged.ResourceState state)
    {
        return new(1UL << (int)state);
    }

    public bool Equals(ResourceStateSet other) =>
        _bitFields == other._bitFields;
} 
