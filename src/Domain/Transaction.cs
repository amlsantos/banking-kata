using static Domain.TransactionStatus;

namespace Domain;

public class Transaction
{
    private readonly Date _date;
    private TransactionStatus _status;
    
    public readonly Money Amount;

    public Transaction(Money amount)
    {
        _date = new Date(2015, 12, 24);
        _status = Pending;
        Amount = amount;
    }

    public void SetAsCompleted() => _status = Success;
    
    public void SetAsFailed() => _status = Failure;

    public bool CanExecute() => _status is Pending;

    public void Execute()
    {
        if (!CanExecute()) 
            SetAsFailed();

        SetAsCompleted();
    }

    public bool IsCompleted() => _status == Success;

    public string AsString()
    {
        return $"{_date.AsString(),-12} {Amount.SignAsString(),-9}";
    }
}