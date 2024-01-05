namespace Domain;

public class Deposit : Transaction
{
    public Deposit(Money amount) : base(amount) { }
    
    public override string AsString()
    {
        var positiveAmount = $"+{Amount.AsString()}";
        return $"{Date.AsString(),-12} {positiveAmount,-9}";
    }
}