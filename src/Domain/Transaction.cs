using static Domain.TransactionStatus;

namespace Domain;

public class Transaction
{
    protected readonly Date Date;
    private TransactionStatus _status;
    
    public readonly Money Amount;

    public Transaction(Money amount)
    {
        Date = new Date(2015, 12, 24);
        _status = Pending;

        if (amount <= 0)
            throw new InvalidOperationException();
        
        Amount = amount;
    }

    private void SetAsCompleted() => _status = Success;

    private void SetAsFailed() => _status = Failure;

    public bool CanExecute() => _status is Pending;

    public void Execute()
    {
        if (!CanExecute()) 
            SetAsFailed();

        SetAsCompleted();
    }

    public bool IsCompleted() => _status == Success;

    public virtual string AsString()
    {
        var positiveAmount = $"+{Amount.AsString()}";
        return $"{Date.AsString(),-12} {positiveAmount,-9}";
    }
}