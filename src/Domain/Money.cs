namespace Domain;

public class Money
{
    public static Money None = new(0);
    
    private readonly int _value;

    public Money(int value)
    {
        if (value < 0)
            throw new InvalidOperationException();
        
        _value = value;
    }

    public Money(Money other) => _value = other._value;

    public static Money operator + (Money one, Money two) => new(one._value + two._value);
    public static Money operator - (Money one, Money two) => new(one._value - two._value);
    public static bool operator >(Money money, int value) => money._value > value;
    public static bool operator <(Money money, int value) => money._value < value;
    public static bool operator >=(Money money, int value) => money._value >= value;
    public static bool operator <=(Money money, int value) => money._value <= value;
    public static bool operator >=(Money first, Money second) => first._value >= second._value;
    public static bool operator <=(Money first, Money second) => first._value <= second._value;

    public string SignAsString() => $"+{_value}";
    public string AsString() => $"{_value}";
}