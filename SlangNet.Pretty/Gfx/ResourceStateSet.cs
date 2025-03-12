namespace SlangNet.Gfx;

public struct ResourceStateSet
{
    private ulong bitFields;
    
    public ResourceStateSet(ulong value)
    {
        bitFields = value;
    }
    
    public ResourceStateSet(params ResourceState[] states)
    {
        bitFields = 0;
        foreach (var state in states)
        {
            bitFields |= 1UL << (int)state;
        }
    }
    
    public void Add(ResourceState state)
    {
        bitFields |= 1UL << (int)state;
    }
    
    public readonly bool HasState(ResourceState state)
    {
        return (bitFields & (1UL << (int)state)) != 0;
    }

    public static ResourceStateSet operator |(ResourceStateSet a, ResourceStateSet b)
    {
        return new ResourceStateSet { bitFields = a.bitFields | b.bitFields };
    }
    
    public static ResourceStateSet operator &(ResourceStateSet a, ResourceStateSet b)
    {
        return new ResourceStateSet { bitFields = a.bitFields & b.bitFields };
    }

    public static ResourceStateSet operator ~(ResourceStateSet a)
    {
        return new ResourceStateSet { bitFields = ~a.bitFields };
    }

    public static bool operator ==(ResourceStateSet a, ResourceStateSet b)
    {
        return a.bitFields == b.bitFields;
    }

    public static bool operator !=(ResourceStateSet a, ResourceStateSet b)
    {
        return !(a == b);
    }

    public override readonly bool Equals(object? obj)
    {
        if (obj is ResourceStateSet other)
        {
            return this == other;
        }
        return false;
    }

    public override readonly int GetHashCode()
    {
        return bitFields.GetHashCode();
    }

    public static implicit operator ResourceStateSet(ulong value) => new(value);

    public static implicit operator ulong(ResourceStateSet set) => set.bitFields;

    public static implicit operator ResourceStateSet(ResourceState state)
    {
        return new(1UL << (int)state);
    }
} 
