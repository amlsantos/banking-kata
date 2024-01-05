using static Domain.TransactionStatus;

namespace Domain;

public abstract class Transaction
{
    private Guid _id;
    private TransactionStatus _status;
    protected readonly Date Date;

    public readonly Money Amount;

    public Transaction(Money amount)
    {
        Date = new Date(2015, 12, 24);
        
        _id = Guid.NewGuid();
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

    public abstract string AsString();
}