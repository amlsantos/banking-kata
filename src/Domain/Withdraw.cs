namespace Domain;

public class Withdraw : Transaction
{
    public Withdraw(Money amount) : base(amount) { }

    public override string AsString()
    {
        var negativeAmount = $"-{Amount.AsString()}";
        return $"{Date.AsString(),-12} {negativeAmount,-9}";
    }
}