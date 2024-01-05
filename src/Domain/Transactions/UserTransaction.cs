namespace Domain.Transactions;

public class UserTransaction
{
    private readonly Account _account;
    private readonly Transaction _transaction;
    private readonly Money _start; 
    private readonly Money _end;

    public UserTransaction(Account account, Transaction transaction, Money start, Money end)
    {
        _account = account;
        _transaction = transaction;
        _start = start;
        _end = end;
    }

    public string AsString()
    {
        var transaction = $"{_transaction.AsString(), -21} {_end.AsString(),-8}";
        return transaction.TrimEnd();
    }
}