namespace Domain;

public class Money
{
    private readonly int _value;

    public Money(int value)
    {
        if (value < 0)
            throw new InvalidOperationException();
        
        _value = value;
    }
    
    public static Money operator + (Money one, Money two) => new(one._value + two._value);

    public static bool operator >(Money money, int value) => money._value > value;

    public static bool operator <(Money money, int value) => money._value < value;

    public string SignAsString() => $"+{_value}";

    public string MoneyAsString() => $"{_value}";
}