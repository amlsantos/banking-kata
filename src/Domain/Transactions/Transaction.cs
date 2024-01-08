using static Domain.Transactions.TransactionStatus;

namespace Domain.Transactions;

public abstract class Transaction
{
    private Guid _id;
    protected TransactionStatus Status;
    protected readonly Date Date;
    protected readonly Money Amount;

    protected Transaction(Money amount)
    {
        Date = new Date(2015, 12, 24);
        
        _id = Guid.NewGuid();
        Status = Pending;

        if (amount <= 0)
            throw new InvalidOperationException();

        Amount = amount;
    }

    public abstract bool CanExecute(Money currentBalance);
    public abstract Money Execute(Money currentBalance);

    protected void SetAsCompleted() => Status = Success;
    protected void SetAsFailed() => Status = Failure;
    public bool IsCompleted() => Status == Success;

    public abstract string AsString();
}