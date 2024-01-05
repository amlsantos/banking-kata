namespace Domain;

public class Transactions
{
    private readonly List<UserTransaction> _transactions = new();
    public IReadOnlyList<UserTransaction> AsReadOnly => _transactions.AsReadOnly();

    public void Add(UserTransaction transaction) => _transactions.Add(transaction);
}