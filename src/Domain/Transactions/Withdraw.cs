namespace Domain.Transactions;

public class Withdraw : Transaction
{
    public Withdraw(Money amount) : base(amount) { }

    public override bool CanExecute(Money currentBalance)
    {
        return Status == TransactionStatus.Pending && currentBalance >= Amount;
    }

    public override Money Execute(Money currentBalance)
    {
        if (!CanExecute(currentBalance))
        {
            SetAsFailed();
            return currentBalance;
        }
        
        SetAsCompleted();
        return currentBalance - Amount;
    }

    public override string AsString()
    {
        var negativeAmount = $"-{Amount.AsString()}";
        return $"{Date.AsString(),-12} {negativeAmount,-9}";
    }
}