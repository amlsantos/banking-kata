namespace Domain;

public class UserTransaction
{
    private readonly Account _account;
    private readonly Transaction _transaction;
    private Money _endBalance;

    public UserTransaction(Account account, Transaction transaction, Money endBalance)
    {
        _account = account;
        _transaction = transaction;
        _endBalance = endBalance;
    }

    public string AsString()
    {
        var transaction = $"{_transaction.AsString(), -21} {_endBalance.AsString(),-8}";
        return transaction.TrimEnd();
    }
}