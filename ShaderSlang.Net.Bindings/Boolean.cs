#nullable enable

// ReSharper disable once CheckNamespace
namespace ShaderSlang.Net.Bindings.Generated;

public readonly struct Boolean(byte value)
    : IComparable,
        IComparable<Boolean>,
        IEquatable<Boolean>,
        IFormattable
{
    private readonly byte _value = value;

    public static Boolean False => new(0);

    public static Boolean True => new(1);

    public static bool operator ==(Boolean left, Boolean right) => left._value == right._value;

    public static bool operator !=(Boolean left, Boolean right) => left._value != right._value;

    public static bool operator <(Boolean left, Boolean right) => left._value < right._value;

    public static bool operator <=(Boolean left, Boolean right) => left._value <= right._value;

    public static bool operator >(Boolean left, Boolean right) => left._value > right._value;

    public static bool operator >=(Boolean left, Boolean right) => left._value >= right._value;

    public static implicit operator bool(Boolean value) => value._value != 0;

    public static implicit operator Boolean(bool value) => new((byte)(value ? 1u : 0u));

    public static bool operator false(Boolean value) => value._value == 0;

    public static bool operator true(Boolean value) => value._value != 0;

    public static implicit operator Boolean(byte value) => new(value);

    public static implicit operator byte(Boolean value) => value._value;

    public static explicit operator Boolean(short value) => new(unchecked((byte)(value)));

    public static implicit operator short(Boolean value) => value._value;

    public static explicit operator Boolean(int value) => new(unchecked((byte)(value)));

    public static implicit operator int(Boolean value) => value._value;

    public static explicit operator Boolean(long value) => new(unchecked((byte)(value)));

    public static implicit operator long(Boolean value) => value._value;

    public static explicit operator Boolean(nint value) => new(unchecked((byte)(value)));

    public static implicit operator nint(Boolean value) => value._value;

    public static explicit operator Boolean(sbyte value) => new(unchecked((byte)(value)));

    public static explicit operator sbyte(Boolean value) => (sbyte)(value._value);

    public static explicit operator Boolean(ushort value) => new(unchecked((byte)(value)));

    public static implicit operator ushort(Boolean value) => value._value;

    public static explicit operator Boolean(uint value) => new(unchecked((byte)(value)));

    public static implicit operator uint(Boolean value) => value._value;

    public static explicit operator Boolean(ulong value) => new(unchecked((byte)(value)));

    public static implicit operator ulong(Boolean value) => value._value;

    public static explicit operator Boolean(nuint value) => new(unchecked((byte)(value)));

    public static implicit operator nuint(Boolean value) => value._value;

    public int CompareTo(object? obj)
    {
        if (obj is Boolean other)
        {
            return CompareTo(other);
        }

        return (obj is null)
            ? 1
            : throw new ArgumentException("obj is not an instance of Boolean.");
    }

    public int CompareTo(Boolean other) => _value.CompareTo(other._value);

    public override bool Equals(object? obj) => (obj is Boolean other) && Equals(other);

    public bool Equals(Boolean other) => _value.Equals(other._value);

    public override int GetHashCode() => _value.GetHashCode();

    public override string ToString() => _value.ToString();

    public string ToString(string? format, IFormatProvider? formatProvider) =>
        _value.ToString(format, formatProvider);
}
