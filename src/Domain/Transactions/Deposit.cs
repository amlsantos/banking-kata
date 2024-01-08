namespace Domain.Transactions;

public class Deposit : Transaction
{
    public Deposit(Money amount) : base(amount) { }
    
    public override bool CanExecute(Money currentBalance) => Status == TransactionStatus.Pending;
    
    public override Money Execute(Money currentBalance)
    {
        if (!CanExecute(currentBalance))
        {
            SetAsFailed();
            return currentBalance;
        }

        SetAsCompleted();
        return Amount + currentBalance;
    }

    public override string AsString()
    {
        var positiveAmount = $"+{Amount.AsString()}";
        return $"{Date.AsString(),-12} {positiveAmount,-9}";
    }
}